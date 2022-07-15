using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;
using System.Data.Common;
using System.Net;
using System.Globalization;
using System.Linq.Expressions;
using System.Reflection;

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
            string numRegex = "[0-9\\.|,0-9]+";
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
                        textBox_varTmp.Invoke(new Action(() => textBox_varTmp.Text = valueString));
                        data.tmp = valueDouble;
                    }
                    else if (stringBuffer[j].Contains("vbr="))
                    {
                        textBox_varVbr.Invoke(new Action(() => textBox_varVbr.Text = valueString));
                        data.vbr = valueDouble;
                    }
                    else if (stringBuffer[j].Contains("rpm="))
                    {
                        textBox_varRpm.Invoke(new Action(() => textBox_varRpm.Text = valueString));
                        data.rpm = valueDouble;
                    }
                    else
                    {
                        continue;
                    }
                }
                catch (Exception)
                {
                    // No handling
                }
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
                MessageBox.Show("Provide database connection address", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show($"Unable to connect with '{ip}:{port}'", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (DbException)
                {
                    MessageBox.Show($"Unable to send query to '{databaseName}.{dbTableName}'", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception)
                {
                    // Unknown error / no handling
                }
            }
        }

        /// <summary>
        /// Get host's active IPv4 address.
        /// <para>
        /// Note that if VirtualBox or VMware present in system
        /// their 'host-only' adapters must be disabled, otherwise function will return
        /// virtual adapter IPv4 address.
        /// </para>
        /// </summary>
        /// <returns>Host own IPv4 address as a string.</returns>
        private static string GetLocalIPv4Address()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            for (int i = 0; i < host.AddressList.Length; i++)
            {
                if (host.AddressList[i].AddressFamily == AddressFamily.InterNetwork)
                    return host.AddressList[i].ToString();
            }
            // No network adapters with an IPv4 address in the system
            return "127.0.0.1";
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
            string ip = textBox_mccAddr.Text;
            ushort port = (ushort)numericUD_mccPort.Value;
            TcpClient mccTcpClient = new TcpClient();
            try
            {
                await mccTcpClient.ConnectAsync(ip, port);
                using (NetworkStream ns = mccTcpClient.GetStream())
                {
                    await ns.WriteAsync(Encoding.ASCII.GetBytes(cmd));
                }
                mccTcpClient.Close();
                if (listen)
                {
                    TcpListener tcpListener = new TcpListener(IPAddress.Parse(GetLocalIPv4Address()), 29000 + 1);
                    tcpListener.Start();
                    TcpClient client = tcpListener.AcceptTcpClient();
                    do
                    {
                        NetworkStream ns = client.GetStream();
                        await ns.ReadAsync(asyncBuffer);
                        MCCD data = ProcessData();
                        // Double-check if processed data isnt empty
                        if (data.vbr != 0 || data.tmp != 0 || data.rpm != 0)
                            await SendToDatabase(data);
                    } while (label_engineStatus.Text == "ENGINE IS ON");
                    client.Close();
                    tcpListener.Stop();
                }
            }
            catch (SocketException)
            {
                ToggleEngineLabel(true);
                MessageBox.Show($"Unable to connect with '{ip}:{port}'", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IOException)
            {
                ToggleEngineLabel(true);
                MessageBox.Show($"Unable to send command to '{ip}:{port}'", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception) // Unknown error 
            {
                ToggleEngineLabel(true);
            }
        }

        //--------------------------------------------------------------------------------------------//
        async private void button_engineToggle_Click(object sender, EventArgs e)
        {
            button_engineToggle.Enabled = false;
            if (label_engineStatus.Text == "ENGINE IS OFF") // Default option
            {
                // Enable engine, begin listening
                ToggleEngineLabel();
                await Task.Run(() =>
                {
                    SendToMcc("@ee", true);
                });
            }
            else
            {
                // Disable engine, no listening
                ToggleEngineLabel(true);
                await Task.Run(() =>
                {
                    SendToMcc("@de");
                });
            }
            button_engineToggle.Enabled = true;
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
    }
}
