namespace mcc_server
{
    partial class Form_Menu
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label label_addrTip;
            System.Windows.Forms.Label label_portTip;
            System.Windows.Forms.Label label_clientsPort;
            System.Windows.Forms.Label label_hostAddr;
            System.Windows.Forms.Label label_hostPort;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Menu));
            this.tabControl_menu = new System.Windows.Forms.TabControl();
            this.tabPage_settings = new System.Windows.Forms.TabPage();
            this.groupBox_host = new System.Windows.Forms.GroupBox();
            this.textBox_hostAddr = new System.Windows.Forms.TextBox();
            this.numericUD_hostPort = new System.Windows.Forms.NumericUpDown();
            this.groupBox_client = new System.Windows.Forms.GroupBox();
            this.button_applyClientPort = new System.Windows.Forms.Button();
            this.numericUD_clientsPort = new System.Windows.Forms.NumericUpDown();
            this.groupBox_database = new System.Windows.Forms.GroupBox();
            this.label_dbNameTip = new System.Windows.Forms.Label();
            this.textBox_dbName = new System.Windows.Forms.TextBox();
            this.label_dbTableNameTip = new System.Windows.Forms.Label();
            this.textBox_dbTableName = new System.Windows.Forms.TextBox();
            this.groupBox_connection = new System.Windows.Forms.GroupBox();
            this.label_mccAddr = new System.Windows.Forms.Label();
            this.textBox_mccAddr = new System.Windows.Forms.TextBox();
            this.numericUD_mccPort = new System.Windows.Forms.NumericUpDown();
            this.textBox_dbAddr = new System.Windows.Forms.TextBox();
            this.numericUD_dbPort = new System.Windows.Forms.NumericUpDown();
            this.label_dbAddr = new System.Windows.Forms.Label();
            this.checkBox_saveUserSettings = new System.Windows.Forms.CheckBox();
            this.checkBox_bgRun = new System.Windows.Forms.CheckBox();
            this.tabPage_dataflow = new System.Windows.Forms.TabPage();
            this.label_engineStatus = new System.Windows.Forms.Label();
            this.button_engineToggle = new System.Windows.Forms.Button();
            this.label_varRpm = new System.Windows.Forms.Label();
            this.label_varVbr = new System.Windows.Forms.Label();
            this.label_varTmp = new System.Windows.Forms.Label();
            this.textBox_varRpm = new System.Windows.Forms.TextBox();
            this.textBox_varTmp = new System.Windows.Forms.TextBox();
            this.textBox_varVbr = new System.Windows.Forms.TextBox();
            this.notifyIcon_bgRun = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip_bgRunMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CloseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            label_addrTip = new System.Windows.Forms.Label();
            label_portTip = new System.Windows.Forms.Label();
            label_clientsPort = new System.Windows.Forms.Label();
            label_hostAddr = new System.Windows.Forms.Label();
            label_hostPort = new System.Windows.Forms.Label();
            this.tabControl_menu.SuspendLayout();
            this.tabPage_settings.SuspendLayout();
            this.groupBox_host.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUD_hostPort)).BeginInit();
            this.groupBox_client.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUD_clientsPort)).BeginInit();
            this.groupBox_database.SuspendLayout();
            this.groupBox_connection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUD_mccPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUD_dbPort)).BeginInit();
            this.tabPage_dataflow.SuspendLayout();
            this.contextMenuStrip_bgRunMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_addrTip
            // 
            label_addrTip.AutoSize = true;
            label_addrTip.Location = new System.Drawing.Point(72, 19);
            label_addrTip.Name = "label_addrTip";
            label_addrTip.Size = new System.Drawing.Size(95, 15);
            label_addrTip.TabIndex = 10;
            label_addrTip.Text = "Network address";
            // 
            // label_portTip
            // 
            label_portTip.AutoSize = true;
            label_portTip.Location = new System.Drawing.Point(185, 19);
            label_portTip.Name = "label_portTip";
            label_portTip.Size = new System.Drawing.Size(29, 15);
            label_portTip.TabIndex = 11;
            label_portTip.Text = "Port";
            // 
            // label_clientsPort
            // 
            label_clientsPort.AutoSize = true;
            label_clientsPort.Location = new System.Drawing.Point(6, 25);
            label_clientsPort.Name = "label_clientsPort";
            label_clientsPort.Size = new System.Drawing.Size(80, 15);
            label_clientsPort.TabIndex = 23;
            label_clientsPort.Text = "Listening port";
            // 
            // label_hostAddr
            // 
            label_hostAddr.AutoSize = true;
            label_hostAddr.Location = new System.Drawing.Point(11, 48);
            label_hostAddr.Name = "label_hostAddr";
            label_hostAddr.Size = new System.Drawing.Size(95, 15);
            label_hostAddr.TabIndex = 23;
            label_hostAddr.Text = "Network address";
            // 
            // label_hostPort
            // 
            label_hostPort.AutoSize = true;
            label_hostPort.Location = new System.Drawing.Point(185, 48);
            label_hostPort.Name = "label_hostPort";
            label_hostPort.Size = new System.Drawing.Size(29, 15);
            label_hostPort.TabIndex = 26;
            label_hostPort.Text = "Port";
            // 
            // tabControl_menu
            // 
            this.tabControl_menu.Controls.Add(this.tabPage_settings);
            this.tabControl_menu.Controls.Add(this.tabPage_dataflow);
            this.tabControl_menu.Location = new System.Drawing.Point(0, 0);
            this.tabControl_menu.Name = "tabControl_menu";
            this.tabControl_menu.SelectedIndex = 0;
            this.tabControl_menu.Size = new System.Drawing.Size(539, 245);
            this.tabControl_menu.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl_menu.TabIndex = 0;
            // 
            // tabPage_settings
            // 
            this.tabPage_settings.Controls.Add(this.groupBox_host);
            this.tabPage_settings.Controls.Add(this.groupBox_client);
            this.tabPage_settings.Controls.Add(this.groupBox_database);
            this.tabPage_settings.Controls.Add(this.groupBox_connection);
            this.tabPage_settings.Controls.Add(this.checkBox_saveUserSettings);
            this.tabPage_settings.Controls.Add(this.checkBox_bgRun);
            this.tabPage_settings.Location = new System.Drawing.Point(4, 24);
            this.tabPage_settings.Name = "tabPage_settings";
            this.tabPage_settings.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_settings.Size = new System.Drawing.Size(531, 217);
            this.tabPage_settings.TabIndex = 0;
            this.tabPage_settings.Text = "Settings";
            this.tabPage_settings.UseVisualStyleBackColor = true;
            // 
            // groupBox_host
            // 
            this.groupBox_host.Controls.Add(label_hostPort);
            this.groupBox_host.Controls.Add(this.textBox_hostAddr);
            this.groupBox_host.Controls.Add(this.numericUD_hostPort);
            this.groupBox_host.Controls.Add(label_hostAddr);
            this.groupBox_host.Location = new System.Drawing.Point(8, 114);
            this.groupBox_host.Name = "groupBox_host";
            this.groupBox_host.Size = new System.Drawing.Size(253, 70);
            this.groupBox_host.TabIndex = 24;
            this.groupBox_host.TabStop = false;
            this.groupBox_host.Text = "Host";
            // 
            // textBox_hostAddr
            // 
            this.textBox_hostAddr.Location = new System.Drawing.Point(11, 22);
            this.textBox_hostAddr.Name = "textBox_hostAddr";
            this.textBox_hostAddr.Size = new System.Drawing.Size(168, 23);
            this.textBox_hostAddr.TabIndex = 25;
            this.textBox_hostAddr.Text = "192.168.0.68";
            // 
            // numericUD_hostPort
            // 
            this.numericUD_hostPort.Location = new System.Drawing.Point(185, 22);
            this.numericUD_hostPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericUD_hostPort.Name = "numericUD_hostPort";
            this.numericUD_hostPort.Size = new System.Drawing.Size(61, 23);
            this.numericUD_hostPort.TabIndex = 14;
            this.numericUD_hostPort.Value = new decimal(new int[] {
            29001,
            0,
            0,
            0});
            // 
            // groupBox_client
            // 
            this.groupBox_client.Controls.Add(this.button_applyClientPort);
            this.groupBox_client.Controls.Add(this.numericUD_clientsPort);
            this.groupBox_client.Controls.Add(label_clientsPort);
            this.groupBox_client.Location = new System.Drawing.Point(267, 114);
            this.groupBox_client.Name = "groupBox_client";
            this.groupBox_client.Size = new System.Drawing.Size(253, 70);
            this.groupBox_client.TabIndex = 22;
            this.groupBox_client.TabStop = false;
            this.groupBox_client.Text = "Web client";
            // 
            // button_applyClientPort
            // 
            this.button_applyClientPort.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button_applyClientPort.Location = new System.Drawing.Point(175, 22);
            this.button_applyClientPort.Name = "button_applyClientPort";
            this.button_applyClientPort.Size = new System.Drawing.Size(70, 24);
            this.button_applyClientPort.TabIndex = 24;
            this.button_applyClientPort.Text = "APPLY";
            this.button_applyClientPort.UseVisualStyleBackColor = true;
            this.button_applyClientPort.Click += new System.EventHandler(this.button_applyClientPort_Click);
            // 
            // numericUD_clientsPort
            // 
            this.numericUD_clientsPort.Location = new System.Drawing.Point(100, 23);
            this.numericUD_clientsPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericUD_clientsPort.Name = "numericUD_clientsPort";
            this.numericUD_clientsPort.Size = new System.Drawing.Size(69, 23);
            this.numericUD_clientsPort.TabIndex = 14;
            this.numericUD_clientsPort.Value = new decimal(new int[] {
            29500,
            0,
            0,
            0});
            // 
            // groupBox_database
            // 
            this.groupBox_database.Controls.Add(this.label_dbNameTip);
            this.groupBox_database.Controls.Add(this.textBox_dbName);
            this.groupBox_database.Controls.Add(this.label_dbTableNameTip);
            this.groupBox_database.Controls.Add(this.textBox_dbTableName);
            this.groupBox_database.Location = new System.Drawing.Point(267, 6);
            this.groupBox_database.Name = "groupBox_database";
            this.groupBox_database.Size = new System.Drawing.Size(253, 102);
            this.groupBox_database.TabIndex = 21;
            this.groupBox_database.TabStop = false;
            this.groupBox_database.Text = "Database";
            // 
            // label_dbNameTip
            // 
            this.label_dbNameTip.AutoSize = true;
            this.label_dbNameTip.Location = new System.Drawing.Point(6, 34);
            this.label_dbNameTip.Name = "label_dbNameTip";
            this.label_dbNameTip.Size = new System.Drawing.Size(88, 15);
            this.label_dbNameTip.TabIndex = 18;
            this.label_dbNameTip.Text = "Database name";
            // 
            // textBox_dbName
            // 
            this.textBox_dbName.Location = new System.Drawing.Point(100, 31);
            this.textBox_dbName.Name = "textBox_dbName";
            this.textBox_dbName.Size = new System.Drawing.Size(145, 23);
            this.textBox_dbName.TabIndex = 17;
            this.textBox_dbName.Text = "mydb";
            // 
            // label_dbTableNameTip
            // 
            this.label_dbTableNameTip.AutoSize = true;
            this.label_dbTableNameTip.Location = new System.Drawing.Point(27, 64);
            this.label_dbTableNameTip.Name = "label_dbTableNameTip";
            this.label_dbTableNameTip.Size = new System.Drawing.Size(67, 15);
            this.label_dbTableNameTip.TabIndex = 19;
            this.label_dbTableNameTip.Text = "Table name";
            // 
            // textBox_dbTableName
            // 
            this.textBox_dbTableName.Location = new System.Drawing.Point(100, 60);
            this.textBox_dbTableName.Name = "textBox_dbTableName";
            this.textBox_dbTableName.Size = new System.Drawing.Size(145, 23);
            this.textBox_dbTableName.TabIndex = 16;
            this.textBox_dbTableName.Text = "mymcc";
            // 
            // groupBox_connection
            // 
            this.groupBox_connection.Controls.Add(this.label_mccAddr);
            this.groupBox_connection.Controls.Add(this.textBox_mccAddr);
            this.groupBox_connection.Controls.Add(this.numericUD_mccPort);
            this.groupBox_connection.Controls.Add(label_addrTip);
            this.groupBox_connection.Controls.Add(label_portTip);
            this.groupBox_connection.Controls.Add(this.textBox_dbAddr);
            this.groupBox_connection.Controls.Add(this.numericUD_dbPort);
            this.groupBox_connection.Controls.Add(this.label_dbAddr);
            this.groupBox_connection.Location = new System.Drawing.Point(8, 6);
            this.groupBox_connection.Name = "groupBox_connection";
            this.groupBox_connection.Size = new System.Drawing.Size(253, 102);
            this.groupBox_connection.TabIndex = 20;
            this.groupBox_connection.TabStop = false;
            this.groupBox_connection.Text = "Connection";
            // 
            // label_mccAddr
            // 
            this.label_mccAddr.AutoSize = true;
            this.label_mccAddr.Location = new System.Drawing.Point(6, 42);
            this.label_mccAddr.Name = "label_mccAddr";
            this.label_mccAddr.Size = new System.Drawing.Size(60, 15);
            this.label_mccAddr.TabIndex = 2;
            this.label_mccAddr.Text = "Controller";
            // 
            // textBox_mccAddr
            // 
            this.textBox_mccAddr.Location = new System.Drawing.Point(72, 39);
            this.textBox_mccAddr.Name = "textBox_mccAddr";
            this.textBox_mccAddr.Size = new System.Drawing.Size(107, 23);
            this.textBox_mccAddr.TabIndex = 0;
            this.textBox_mccAddr.Text = "127.0.0.1";
            // 
            // numericUD_mccPort
            // 
            this.numericUD_mccPort.Location = new System.Drawing.Point(185, 39);
            this.numericUD_mccPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericUD_mccPort.Name = "numericUD_mccPort";
            this.numericUD_mccPort.Size = new System.Drawing.Size(60, 23);
            this.numericUD_mccPort.TabIndex = 12;
            this.numericUD_mccPort.Value = new decimal(new int[] {
            29000,
            0,
            0,
            0});
            // 
            // textBox_dbAddr
            // 
            this.textBox_dbAddr.Location = new System.Drawing.Point(72, 68);
            this.textBox_dbAddr.Name = "textBox_dbAddr";
            this.textBox_dbAddr.Size = new System.Drawing.Size(107, 23);
            this.textBox_dbAddr.TabIndex = 3;
            this.textBox_dbAddr.Text = "127.0.0.1";
            // 
            // numericUD_dbPort
            // 
            this.numericUD_dbPort.Location = new System.Drawing.Point(185, 68);
            this.numericUD_dbPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericUD_dbPort.Name = "numericUD_dbPort";
            this.numericUD_dbPort.Size = new System.Drawing.Size(60, 23);
            this.numericUD_dbPort.TabIndex = 13;
            this.numericUD_dbPort.Value = new decimal(new int[] {
            3306,
            0,
            0,
            0});
            // 
            // label_dbAddr
            // 
            this.label_dbAddr.AutoSize = true;
            this.label_dbAddr.Location = new System.Drawing.Point(11, 71);
            this.label_dbAddr.Name = "label_dbAddr";
            this.label_dbAddr.Size = new System.Drawing.Size(55, 15);
            this.label_dbAddr.TabIndex = 5;
            this.label_dbAddr.Text = "Database";
            // 
            // checkBox_saveUserSettings
            // 
            this.checkBox_saveUserSettings.AutoSize = true;
            this.checkBox_saveUserSettings.Location = new System.Drawing.Point(8, 190);
            this.checkBox_saveUserSettings.Name = "checkBox_saveUserSettings";
            this.checkBox_saveUserSettings.Size = new System.Drawing.Size(168, 19);
            this.checkBox_saveUserSettings.TabIndex = 15;
            this.checkBox_saveUserSettings.Text = "Save settings on local drive";
            this.checkBox_saveUserSettings.UseVisualStyleBackColor = true;
            // 
            // checkBox_bgRun
            // 
            this.checkBox_bgRun.AutoSize = true;
            this.checkBox_bgRun.Location = new System.Drawing.Point(193, 190);
            this.checkBox_bgRun.Name = "checkBox_bgRun";
            this.checkBox_bgRun.Size = new System.Drawing.Size(246, 19);
            this.checkBox_bgRun.TabIndex = 14;
            this.checkBox_bgRun.Text = "Keep running in background when closed";
            this.checkBox_bgRun.UseVisualStyleBackColor = true;
            // 
            // tabPage_dataflow
            // 
            this.tabPage_dataflow.Controls.Add(this.label_engineStatus);
            this.tabPage_dataflow.Controls.Add(this.button_engineToggle);
            this.tabPage_dataflow.Controls.Add(this.label_varRpm);
            this.tabPage_dataflow.Controls.Add(this.label_varVbr);
            this.tabPage_dataflow.Controls.Add(this.label_varTmp);
            this.tabPage_dataflow.Controls.Add(this.textBox_varRpm);
            this.tabPage_dataflow.Controls.Add(this.textBox_varTmp);
            this.tabPage_dataflow.Controls.Add(this.textBox_varVbr);
            this.tabPage_dataflow.Location = new System.Drawing.Point(4, 24);
            this.tabPage_dataflow.Name = "tabPage_dataflow";
            this.tabPage_dataflow.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_dataflow.Size = new System.Drawing.Size(531, 217);
            this.tabPage_dataflow.TabIndex = 1;
            this.tabPage_dataflow.Text = "Dataflow";
            this.tabPage_dataflow.UseVisualStyleBackColor = true;
            // 
            // label_engineStatus
            // 
            this.label_engineStatus.AutoSize = true;
            this.label_engineStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_engineStatus.ForeColor = System.Drawing.Color.Red;
            this.label_engineStatus.Location = new System.Drawing.Point(221, 165);
            this.label_engineStatus.Name = "label_engineStatus";
            this.label_engineStatus.Size = new System.Drawing.Size(88, 15);
            this.label_engineStatus.TabIndex = 10;
            this.label_engineStatus.Text = "ENGINE IS OFF";
            // 
            // button_engineToggle
            // 
            this.button_engineToggle.Location = new System.Drawing.Point(178, 183);
            this.button_engineToggle.Name = "button_engineToggle";
            this.button_engineToggle.Size = new System.Drawing.Size(183, 24);
            this.button_engineToggle.TabIndex = 9;
            this.button_engineToggle.Text = "TOGGLE ENGINE";
            this.button_engineToggle.UseVisualStyleBackColor = true;
            this.button_engineToggle.Click += new System.EventHandler(this.button_engineToggle_Click);
            // 
            // label_varRpm
            // 
            this.label_varRpm.AutoSize = true;
            this.label_varRpm.Location = new System.Drawing.Point(353, 21);
            this.label_varRpm.Name = "label_varRpm";
            this.label_varRpm.Size = new System.Drawing.Size(32, 15);
            this.label_varRpm.TabIndex = 7;
            this.label_varRpm.Text = "RPM";
            // 
            // label_varVbr
            // 
            this.label_varVbr.AutoSize = true;
            this.label_varVbr.Location = new System.Drawing.Point(201, 21);
            this.label_varVbr.Name = "label_varVbr";
            this.label_varVbr.Size = new System.Drawing.Size(60, 15);
            this.label_varVbr.TabIndex = 6;
            this.label_varVbr.Text = "Vibrations";
            // 
            // label_varTmp
            // 
            this.label_varTmp.AutoSize = true;
            this.label_varTmp.Location = new System.Drawing.Point(36, 21);
            this.label_varTmp.Name = "label_varTmp";
            this.label_varTmp.Size = new System.Drawing.Size(73, 15);
            this.label_varTmp.TabIndex = 5;
            this.label_varTmp.Text = "Temperature";
            // 
            // textBox_varRpm
            // 
            this.textBox_varRpm.Location = new System.Drawing.Point(391, 18);
            this.textBox_varRpm.Name = "textBox_varRpm";
            this.textBox_varRpm.ReadOnly = true;
            this.textBox_varRpm.Size = new System.Drawing.Size(80, 23);
            this.textBox_varRpm.TabIndex = 3;
            // 
            // textBox_varTmp
            // 
            this.textBox_varTmp.Location = new System.Drawing.Point(115, 18);
            this.textBox_varTmp.Name = "textBox_varTmp";
            this.textBox_varTmp.ReadOnly = true;
            this.textBox_varTmp.Size = new System.Drawing.Size(80, 23);
            this.textBox_varTmp.TabIndex = 2;
            // 
            // textBox_varVbr
            // 
            this.textBox_varVbr.Location = new System.Drawing.Point(267, 18);
            this.textBox_varVbr.Name = "textBox_varVbr";
            this.textBox_varVbr.ReadOnly = true;
            this.textBox_varVbr.Size = new System.Drawing.Size(80, 23);
            this.textBox_varVbr.TabIndex = 1;
            // 
            // notifyIcon_bgRun
            // 
            this.notifyIcon_bgRun.BalloonTipText = "Running in background";
            this.notifyIcon_bgRun.BalloonTipTitle = "MCC-server";
            this.notifyIcon_bgRun.ContextMenuStrip = this.contextMenuStrip_bgRunMenu;
            this.notifyIcon_bgRun.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon_bgRun.Icon")));
            this.notifyIcon_bgRun.Text = "MCC-server";
            this.notifyIcon_bgRun.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon_bgRun_MouseDoubleClick);
            // 
            // contextMenuStrip_bgRunMenu
            // 
            this.contextMenuStrip_bgRunMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CloseToolStripMenuItem});
            this.contextMenuStrip_bgRunMenu.Name = "contextMenuStrip1";
            this.contextMenuStrip_bgRunMenu.Size = new System.Drawing.Size(104, 26);
            // 
            // CloseToolStripMenuItem
            // 
            this.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem";
            this.CloseToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.CloseToolStripMenuItem.Text = "Close";
            this.CloseToolStripMenuItem.Click += new System.EventHandler(this.CloseToolStripMenuItem_Click);
            // 
            // Form_Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 243);
            this.Controls.Add(this.tabControl_menu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form_Menu";
            this.Text = "MCC-server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Menu_FormClosing);
            this.Load += new System.EventHandler(this.Form_Menu_Load);
            this.tabControl_menu.ResumeLayout(false);
            this.tabPage_settings.ResumeLayout(false);
            this.tabPage_settings.PerformLayout();
            this.groupBox_host.ResumeLayout(false);
            this.groupBox_host.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUD_hostPort)).EndInit();
            this.groupBox_client.ResumeLayout(false);
            this.groupBox_client.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUD_clientsPort)).EndInit();
            this.groupBox_database.ResumeLayout(false);
            this.groupBox_database.PerformLayout();
            this.groupBox_connection.ResumeLayout(false);
            this.groupBox_connection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUD_mccPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUD_dbPort)).EndInit();
            this.tabPage_dataflow.ResumeLayout(false);
            this.tabPage_dataflow.PerformLayout();
            this.contextMenuStrip_bgRunMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl tabControl_menu;
        private TabPage tabPage_settings;
        private TabPage tabPage_dataflow;
        private Label label_dbAddr;
        private TextBox textBox_dbAddr;
        private Label label_mccAddr;
        private TextBox textBox_mccAddr;
        private Label label_portTip;
        private Label label_addrTip;
        private NumericUpDown numericUD_dbPort;
        private NumericUpDown numericUD_mccPort;
        private CheckBox checkBox_bgRun;
        private Label label_varVbr;
        private Label label_varTmp;
        private TextBox textBox_varRpm;
        private TextBox textBox_varTmp;
        private TextBox textBox_varVbr;
        private Label label_varRpm;
        private Label label_engineStatus;
        private Button button_engineToggle;
        private NotifyIcon notifyIcon_bgRun;
        private CheckBox checkBox_saveUserSettings;
        private ContextMenuStrip contextMenuStrip_bgRunMenu;
        private ToolStripMenuItem CloseToolStripMenuItem;
        private Label label_dbNameTip;
        private TextBox textBox_dbName;
        private TextBox textBox_dbTableName;
        private Label label_dbTableNameTip;
        private GroupBox groupBox_client;
        private NumericUpDown numericUD_clientsPort;
        private GroupBox groupBox_database;
        private GroupBox groupBox_connection;
        private GroupBox groupBox_host;
        private NumericUpDown numericUD_hostPort;
        private TextBox textBox_hostAddr;
        private Button button_applyClientPort;
    }
}