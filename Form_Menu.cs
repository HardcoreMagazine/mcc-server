using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;
using System.Data.Common;
using System.Net;
using System.Globalization;
using SimpleHttp;

namespace mcc_server
{
    public partial class Form_Menu : Form
    {
        public Form_Menu()
        {
            InitializeComponent();
        }

        private struct MCCD
        {
            public double tmp; //temperature
            public double vbr; //vibrations
            public double rpm; //rounds per minute
        }

        private const int msgSize = 128; //max message size: 128 B
        private byte[] asyncBuffer = new byte[msgSize];
        private HttpListener httpListener = new HttpListener();

        /// <summary>
        /// Save all current settings on local hard drive. 
        /// Settings grabbed directly from FORM properties.
        /// </summary>
        private void SaveSettings()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "user_settings";
            UserSettings settings = new UserSettings
            {
                MccIp = textBox_mccAddr.Text,
                MccPort = (ushort)numericUD_mccPort.Value,
                DbIP = textBox_dbAddr.Text,
                DbPort = (ushort)numericUD_dbPort.Value,
                DbName = textBox_dbName.Text,
                DbTableName = textBox_dbTableName.Text,
                HostIp = textBox_hostAddr.Text,
                HostPort = (ushort)numericUD_hostPort.Value,
                ClientsPort = (ushort)numericUD_clientsPort.Value,
                RunInBG = checkBox_bgRun.Checked,
                SaveSettings = checkBox_saveUserSettings.Checked
            };
            string jsonString = JsonSerializer.Serialize(settings);
            try
            {
                File.WriteAllText(path, jsonString);
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to save settings on local drive", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Load application settings from local hard drive if available.
        /// </summary>
        private void LoadSettings()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "user_settings";
            if (File.Exists(path)) // Check if file exists
            {
                // Read json from file into string
                string jsonString = File.ReadAllText(path); 
                if (!string.IsNullOrWhiteSpace(jsonString))
                {
                    try
                    {
                        // Deserialize json and write values into application settings
                        UserSettings settings = JsonSerializer.Deserialize<UserSettings>(jsonString)!;
                        textBox_mccAddr.Text = settings.MccIp;
                        numericUD_mccPort.Value = settings.MccPort;
                        textBox_dbAddr.Text = settings.DbIP;
                        numericUD_dbPort.Value = settings.DbPort;
                        textBox_dbName.Text = settings.DbName;
                        textBox_dbTableName.Text = settings.DbTableName;
                        textBox_hostAddr.Text = settings.HostIp;
                        numericUD_hostPort.Value = settings.HostPort;
                        numericUD_clientsPort.Value = settings.ClientsPort;
                        checkBox_bgRun.Checked = settings.RunInBG;
                        checkBox_saveUserSettings.Checked = settings.SaveSettings;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Unable to load local user settings", "Warning",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        /// <summary>
        /// Toggles label_engineStatus
        /// </summary>
        /// <param name="forceOff">Optional param. Set to true to override into 'OFF' mode</param>
        private void ToggleEngineLabel(bool forceOff = false)
        {
            if (forceOff)
            {
                label_engineStatus.Text = "ENGINE IS OFF";
                label_engineStatus.ForeColor = Color.Red;
            }
            else
            {
                if (label_engineStatus.Text == "ENGINE IS OFF")
                {
                    label_engineStatus.Text = "ENGINE IS ON";
                    label_engineStatus.ForeColor = Color.Green;
                }
                else
                {
                    label_engineStatus.Text = "ENGINE IS OFF";
                    label_engineStatus.ForeColor = Color.Red;
                }
            }
        }

        /// <summary>
        /// Parses raw bytes into array of values,
        /// write recieved values in TextBox-es ('dataflow' tab)
        /// and sends SQL query.
        /// </summary>
        /// <returns>MCCD data stuct. If no data found in buffer - returns MCCD filled with zeroes.</returns>
        private MCCD ProcessData()
        {
            // Get string from bytes, remove empty values, split returned strings by ';'
            string[] stringBuffer = Encoding.ASCII.GetString(asyncBuffer).Trim('\0').Split(';');
            asyncBuffer = new byte[msgSize]; // Override used data with empty values
            MCCD data = new MCCD()
            {
                tmp = 0,
                vbr = 0,
                rpm = 0
            };
            // Extracts all numbers from string; works will any-point numbers
            string numRegex = "[-0-9\\.|,0-9]+";
            for (int j = 0; j < stringBuffer.Length; j++)
            {
                try
                {
                    string valueRaw = Regex.Match(stringBuffer[j], numRegex).Value;
                    double valueDouble = Math.Round(double.Parse(valueRaw, CultureInfo.InvariantCulture), 3);
                    string valueString = valueDouble.ToString(); // Rounded value (point-3)
                    // Could've used SWITCH statement here, 
                    // but since 'string.Contains()' is present
                    // it'll be A LOT easier to understand
                    // IF-ELSE statements in (possible) future.
                    if (stringBuffer[j].Contains("tmp="))
                    {
                        // No direct textBox access from parallel thread
                        textBox_varTmp.Invoke(
                            new Action(() => textBox_varTmp.Text = valueString));
                        data.tmp = valueDouble;
                    }
                    else if (stringBuffer[j].Contains("vbr="))
                    {
                        textBox_varVbr.Invoke(
                            new Action(() => textBox_varVbr.Text = valueString));
                        data.vbr = valueDouble;
                    }
                    else if (stringBuffer[j].Contains("rpm="))
                    {
                        textBox_varRpm.Invoke(
                            new Action(() => textBox_varRpm.Text = valueString));
                        data.rpm = valueDouble;
                    }
                    else
                    {
                        continue;
                    }
                }
                catch (Exception) { } // No handling
            }
            return data;
        }

        /// <summary>
        /// Attempts connecting to database; on success - 
        /// sends query and closes the connection.
        /// </summary>
        /// <param name="dt">Query data</param>
        async private Task SendToDatabase(MCCD dt)
        {
            string ip = textBox_dbAddr.Text;
            ushort port = (ushort)numericUD_dbPort.Value;
            string databaseName = textBox_dbName.Text;
            string dbTableName = textBox_dbTableName.Text;
            if (String.IsNullOrWhiteSpace(ip))
            {
                // Low-medium priority:
                // will never show up unless called on main thread
                this.Invoke(new Action(() =>
                {
                    MessageBox.Show("Operation aborted: provide database connection address", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }));
                try
                {
                    // !! Deprecated function (level: warning) !!
                    Thread.CurrentThread.Abort();
                }
                catch (Exception) { } // No handling, just abort
            }
            else
            {
                try
                {
                    // Open connection
                    string connectionString =
                        $"Server={ip};" +
                        $"Port={port};" +
                        $"User ID=user;" +
                        $"Password=user;" +
                        $"Database={databaseName}";
                    MySqlConnection dbConnection = new MySqlConnection(connectionString);
                    await dbConnection.OpenAsync(); // Default timeout: 15s
                                                    // Throws exception on timeout

                    // Send query
                    string[] parsedValues = new string[]
                    {
                        dt.tmp.ToString().Replace(',', '.'),
                        dt.vbr.ToString().Replace(',', '.'),
                        dt.rpm.ToString().Replace(',', '.')
                    };
                    string queryString =
                        $"INSERT INTO {databaseName}.{dbTableName} " +
                        $"(temperature, vibrations,  rpm) " +
                        $"values('{parsedValues[0]}', '{parsedValues[1]}', '{parsedValues[2]}')";
                    MySqlCommand command = new MySqlCommand(queryString, dbConnection);
                    await command.ExecuteNonQueryAsync();

                    // Close connection
                    await dbConnection.CloseAsync();
                }
                catch (MySqlException)
                {
                    this.Invoke(new Action(() =>
                    {
                        MessageBox.Show($"Unable to connect with '{ip}:{port}'", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }));
                    try
                    {
                        Thread.CurrentThread.Abort();
                    }
                    catch (Exception) { }
                }
                catch (DbException)
                {
                    this.Invoke(new Action(() =>
                    {
                        MessageBox.Show($"Unable to send query to '{databaseName}.{dbTableName}'", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }));
                    try
                    {
                        Thread.CurrentThread.Abort();
                    }
                    catch (Exception) { }
                }
                catch (Exception)
                {
                    this.Invoke(new Action(() =>
                    {
                        MessageBox.Show("Unknown database error", "Error", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }));
                    try
                    {
                        Thread.CurrentThread.Abort();
                    }
                    catch (Exception) { }
                }
            }
        }

        /// <summary>
        /// Attempts connecting to mcc; on success -
        /// sends command, listens to assigned port (if listen eq. true)
        /// and closes the connection.
        /// </summary>
        /// <param name="cmd">Command to execute</param>
        /// <param name="listen">Optional param. Set to true if listening is required (answer is expected)</param>
        async private void SendToMcc(string cmd, bool listen = false)
        {
            string mccIp = textBox_mccAddr.Text;
            ushort mccPort = (ushort)numericUD_mccPort.Value;
            string hostIp = textBox_hostAddr.Text;
            ushort hostPort = (ushort)numericUD_hostPort.Value;
            TcpClient mccTcpClient = new TcpClient();
            try
            {
                await mccTcpClient.ConnectAsync(mccIp, mccPort);
                using (NetworkStream ns = mccTcpClient.GetStream())
                {
                    await ns.WriteAsync(Encoding.ASCII.GetBytes(cmd));
                }
                mccTcpClient.Close();
                this.Invoke(new Action(() => button_engineToggle.Enabled = true));
                if (listen)
                {
                    TcpListener tcpListener = new TcpListener(IPAddress.Parse(hostIp), hostPort);
                    tcpListener.Start();
                    TcpClient client = tcpListener.AcceptTcpClient();
                    while (label_engineStatus.Text == "ENGINE IS ON")
                    {
                        NetworkStream ns = client.GetStream();
                        await ns.ReadAsync(asyncBuffer);
                        MCCD data = ProcessData();
                        // Double-check if processed data isnt empty
                        if (data.vbr != 0 || data.tmp != 0 || data.rpm != 0)
                            await SendToDatabase(data);
                    }
                    client.Close();
                    tcpListener.Stop();
                }
                button_engineToggle.Enabled = true;
            }
            catch (SocketException)
            {
                // Invoke functions on main thread
                this.Invoke(new Action(() =>
                {
                    ToggleEngineLabel(true);
                    MessageBox.Show($"Unable to connect with '{mccIp}:{mccPort}'", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    button_engineToggle.Enabled = true;
                }));
                try
                {
                    // !! Deprecated function (level: warning) !!
                    Thread.CurrentThread.Abort(); 
                }
                catch (Exception) { } // No handling, just abort
            }
            catch (IOException)
            {
                this.Invoke(new Action(() =>
                {
                    ToggleEngineLabel(true);
                    MessageBox.Show($"Unable to send command to '{mccIp}:{mccPort}'", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    button_engineToggle.Enabled = true;
                }));
                try
                {
                    Thread.CurrentThread.Abort();
                }
                catch (Exception) { }
            }
            catch (Exception) // Unknown error 
            {
                this.Invoke(new Action(() =>
                {
                    ToggleEngineLabel(true);
                    MessageBox.Show("Unknown mcc error", "Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    button_engineToggle.Enabled = true;
                }));
                try
                {
                    Thread.CurrentThread.Abort();
                }
                catch (Exception) { }
            }
        }

        //--------------------------------------------------------------------------------------------//
        async private void button_engineToggle_Click(object sender, EventArgs e)
        {
            button_engineToggle.Enabled = false;
            if (label_engineStatus.Text == "ENGINE IS OFF") // Default option
            {
                // Enable engine, begin listening
                this.Invoke(new Action(() => ToggleEngineLabel()));
                // Run cascade function on parallel thread
                // without locking UI
                await Task.Run(() =>
                {
                    SendToMcc("@ee", true);
                }); 
            }
            else
            {
                // Disable engine, no listening
                this.Invoke(new Action(() => ToggleEngineLabel()));
                await Task.Run(() =>
                {
                    SendToMcc("@de");
                });
            }
        }

        private void Form_Menu_Load(object sender, EventArgs e)
        {
            // If 'checkBox_saveUserSettings' was checked once 
            // keep saving unless user checks-out option (until next launch)
            LoadSettings();
        }

        private void NotifyIcon_bgRun_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            notifyIcon_bgRun.Visible = false;
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //remove "ghost icon" from tray
            notifyIcon_bgRun.Visible = false;
            //save current settings if required
            if (checkBox_saveUserSettings.Checked) //true by default
                SaveSettings();
            //exit applcation
            this.Dispose(); //questionable
            //Environment.Exit(0); //equal to SIGKILL
        }

        private void Form_Menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (checkBox_bgRun.Checked)
            {
                e.Cancel = true; //cancel application closing event
                Hide(); //hide application window
                notifyIcon_bgRun.Visible = true; //make tray icon visible
                notifyIcon_bgRun.BalloonTipTitle = "MCC-server";
                notifyIcon_bgRun.BalloonTipText = "Running in background";
                notifyIcon_bgRun.ShowBalloonTip(2000); //notify user about app running in background
            }
            else
            {
                if (checkBox_saveUserSettings.Checked) //true by default
                    SaveSettings();
            }
        }

        async private void button_applyClientPort_Click(object sender, EventArgs e)
        {
            // Disable controls [failsafe]
            button_applyClientPort.Enabled = false;
            numericUD_clientsPort.Enabled = false;

            // Get server port
            ushort port = (ushort)numericUD_clientsPort.Value;

            // Add routes to http server
            // HTTP responses: 0 - off, 1 - on, 2 - error
            Route.Add("/cmd_ee", async (req, res, args) =>
            {
                if (label_engineStatus.Text == "ENGINE IS ON")
                {
                    res.AsText("@ENG_ST=1");
                    res.Close();
                }
                else
                {
                    button_engineToggle.Invoke(
                        new Action(() => button_engineToggle.PerformClick()));
                    // Sleep for 3 seconds && check if connection was made
                    await Task.Run(() => Thread.Sleep(3000));
                    if (label_engineStatus.Text == "ENGINE IS ON")
                    {
                        res.AsText("@ENG_ST=1");
                        res.Close();
                    }
                    else
                    {
                        res.AsText("@ENG_ST=2");
                        res.Close();
                    }
                }
            });
            Route.Add("/cmd_de", (req, res, args) =>
            {
                if (label_engineStatus.Text == "ENGINE IS OFF")
                {
                    res.AsText("@ENG_ST=0");
                    res.Close();
                }
                else
                {
                    button_engineToggle.Invoke(
                        new Action(() => button_engineToggle.PerformClick()));
                    // Will send 0 status regardless of 
                    // event_buttonClick results
                    // (original button function limitation)
                    res.AsText("@ENG_ST=0");
                    res.Close();
                }
            });
            try
            {
                // Create simple HTTP server for remote control
                // Note that code below task call does not execute
                // because server runs indefinitely (until app is closed)
                await HttpServer.ListenAsync(port, CancellationToken.None,
                    Route.OnHttpRequestAsync);
            }
            catch (Exception ex)
            {
                button_applyClientPort.Enabled = true;
                numericUD_clientsPort.Enabled = true;
                MessageBox.Show(ex.Message, "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
