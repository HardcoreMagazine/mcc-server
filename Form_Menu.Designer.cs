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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Menu));
            this.tabControl_menu = new System.Windows.Forms.TabControl();
            this.tabPage_settings = new System.Windows.Forms.TabPage();
            this.label_dbTableNameTip = new System.Windows.Forms.Label();
            this.label_dbNameTip = new System.Windows.Forms.Label();
            this.textBox_dbName = new System.Windows.Forms.TextBox();
            this.textBox_dbTableName = new System.Windows.Forms.TextBox();
            this.checkBox_saveUserSettings = new System.Windows.Forms.CheckBox();
            this.checkBox_bgRun = new System.Windows.Forms.CheckBox();
            this.numericUD_dbPort = new System.Windows.Forms.NumericUpDown();
            this.numericUD_mccPort = new System.Windows.Forms.NumericUpDown();
            this.label_dbAddr = new System.Windows.Forms.Label();
            this.textBox_dbAddr = new System.Windows.Forms.TextBox();
            this.label_mccAddr = new System.Windows.Forms.Label();
            this.textBox_mccAddr = new System.Windows.Forms.TextBox();
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
            this.tabControl_menu.SuspendLayout();
            this.tabPage_settings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUD_dbPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUD_mccPort)).BeginInit();
            this.tabPage_dataflow.SuspendLayout();
            this.contextMenuStrip_bgRunMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_addrTip
            // 
            label_addrTip.AutoSize = true;
            label_addrTip.Location = new System.Drawing.Point(89, 11);
            label_addrTip.Name = "label_addrTip";
            label_addrTip.Size = new System.Drawing.Size(95, 15);
            label_addrTip.TabIndex = 10;
            label_addrTip.Text = "Network address";
            // 
            // label_portTip
            // 
            label_portTip.AutoSize = true;
            label_portTip.Location = new System.Drawing.Point(217, 11);
            label_portTip.Name = "label_portTip";
            label_portTip.Size = new System.Drawing.Size(29, 15);
            label_portTip.TabIndex = 11;
            label_portTip.Text = "Port";
            // 
            // tabControl_menu
            // 
            this.tabControl_menu.Controls.Add(this.tabPage_settings);
            this.tabControl_menu.Controls.Add(this.tabPage_dataflow);
            this.tabControl_menu.Location = new System.Drawing.Point(0, 0);
            this.tabControl_menu.Name = "tabControl_menu";
            this.tabControl_menu.SelectedIndex = 0;
            this.tabControl_menu.Size = new System.Drawing.Size(289, 273);
            this.tabControl_menu.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl_menu.TabIndex = 0;
            // 
            // tabPage_settings
            // 
            this.tabPage_settings.Controls.Add(this.label_dbTableNameTip);
            this.tabPage_settings.Controls.Add(this.label_dbNameTip);
            this.tabPage_settings.Controls.Add(this.textBox_dbName);
            this.tabPage_settings.Controls.Add(this.textBox_dbTableName);
            this.tabPage_settings.Controls.Add(this.checkBox_saveUserSettings);
            this.tabPage_settings.Controls.Add(this.checkBox_bgRun);
            this.tabPage_settings.Controls.Add(this.numericUD_dbPort);
            this.tabPage_settings.Controls.Add(this.numericUD_mccPort);
            this.tabPage_settings.Controls.Add(label_portTip);
            this.tabPage_settings.Controls.Add(label_addrTip);
            this.tabPage_settings.Controls.Add(this.label_dbAddr);
            this.tabPage_settings.Controls.Add(this.textBox_dbAddr);
            this.tabPage_settings.Controls.Add(this.label_mccAddr);
            this.tabPage_settings.Controls.Add(this.textBox_mccAddr);
            this.tabPage_settings.Location = new System.Drawing.Point(4, 24);
            this.tabPage_settings.Name = "tabPage_settings";
            this.tabPage_settings.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_settings.Size = new System.Drawing.Size(281, 245);
            this.tabPage_settings.TabIndex = 0;
            this.tabPage_settings.Text = "Settings";
            this.tabPage_settings.UseVisualStyleBackColor = true;
            // 
            // label_dbTableNameTip
            // 
            this.label_dbTableNameTip.AutoSize = true;
            this.label_dbTableNameTip.Location = new System.Drawing.Point(166, 118);
            this.label_dbTableNameTip.Name = "label_dbTableNameTip";
            this.label_dbTableNameTip.Size = new System.Drawing.Size(67, 15);
            this.label_dbTableNameTip.TabIndex = 19;
            this.label_dbTableNameTip.Text = "Table name";
            // 
            // label_dbNameTip
            // 
            this.label_dbNameTip.AutoSize = true;
            this.label_dbNameTip.Location = new System.Drawing.Point(62, 118);
            this.label_dbNameTip.Name = "label_dbNameTip";
            this.label_dbNameTip.Size = new System.Drawing.Size(88, 15);
            this.label_dbNameTip.TabIndex = 18;
            this.label_dbNameTip.Text = "Database name";
            // 
            // textBox_dbName
            // 
            this.textBox_dbName.Location = new System.Drawing.Point(62, 92);
            this.textBox_dbName.Name = "textBox_dbName";
            this.textBox_dbName.Size = new System.Drawing.Size(103, 23);
            this.textBox_dbName.TabIndex = 17;
            this.textBox_dbName.Text = "mydb";
            // 
            // textBox_dbTableName
            // 
            this.textBox_dbTableName.Location = new System.Drawing.Point(166, 92);
            this.textBox_dbTableName.Name = "textBox_dbTableName";
            this.textBox_dbTableName.Size = new System.Drawing.Size(103, 23);
            this.textBox_dbTableName.TabIndex = 16;
            this.textBox_dbTableName.Text = "mymcc";
            // 
            // checkBox_saveUserSettings
            // 
            this.checkBox_saveUserSettings.AutoSize = true;
            this.checkBox_saveUserSettings.Checked = true;
            this.checkBox_saveUserSettings.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_saveUserSettings.Location = new System.Drawing.Point(8, 191);
            this.checkBox_saveUserSettings.Name = "checkBox_saveUserSettings";
            this.checkBox_saveUserSettings.Size = new System.Drawing.Size(168, 19);
            this.checkBox_saveUserSettings.TabIndex = 15;
            this.checkBox_saveUserSettings.Text = "Save settings on local drive";
            this.checkBox_saveUserSettings.UseVisualStyleBackColor = true;
            // 
            // checkBox_bgRun
            // 
            this.checkBox_bgRun.AutoSize = true;
            this.checkBox_bgRun.Location = new System.Drawing.Point(8, 216);
            this.checkBox_bgRun.Name = "checkBox_bgRun";
            this.checkBox_bgRun.Size = new System.Drawing.Size(246, 19);
            this.checkBox_bgRun.TabIndex = 14;
            this.checkBox_bgRun.Text = "Keep running in background when closed";
            this.checkBox_bgRun.UseVisualStyleBackColor = true;
            // 
            // numericUD_dbPort
            // 
            this.numericUD_dbPort.Location = new System.Drawing.Point(209, 63);
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
            // numericUD_mccPort
            // 
            this.numericUD_mccPort.Location = new System.Drawing.Point(209, 29);
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
            // label_dbAddr
            // 
            this.label_dbAddr.AutoSize = true;
            this.label_dbAddr.Location = new System.Drawing.Point(1, 67);
            this.label_dbAddr.Name = "label_dbAddr";
            this.label_dbAddr.Size = new System.Drawing.Size(55, 15);
            this.label_dbAddr.TabIndex = 5;
            this.label_dbAddr.Text = "Database";
            // 
            // textBox_dbAddr
            // 
            this.textBox_dbAddr.Location = new System.Drawing.Point(62, 63);
            this.textBox_dbAddr.Name = "textBox_dbAddr";
            this.textBox_dbAddr.Size = new System.Drawing.Size(141, 23);
            this.textBox_dbAddr.TabIndex = 3;
            this.textBox_dbAddr.Text = "127.0.0.1";
            // 
            // label_mccAddr
            // 
            this.label_mccAddr.AutoSize = true;
            this.label_mccAddr.Location = new System.Drawing.Point(1, 32);
            this.label_mccAddr.Name = "label_mccAddr";
            this.label_mccAddr.Size = new System.Drawing.Size(60, 15);
            this.label_mccAddr.TabIndex = 2;
            this.label_mccAddr.Text = "Controller";
            // 
            // textBox_mccAddr
            // 
            this.textBox_mccAddr.Location = new System.Drawing.Point(62, 29);
            this.textBox_mccAddr.Name = "textBox_mccAddr";
            this.textBox_mccAddr.Size = new System.Drawing.Size(141, 23);
            this.textBox_mccAddr.TabIndex = 0;
            this.textBox_mccAddr.Text = "127.0.0.1";
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
            this.tabPage_dataflow.Size = new System.Drawing.Size(281, 245);
            this.tabPage_dataflow.TabIndex = 1;
            this.tabPage_dataflow.Text = "Dataflow";
            this.tabPage_dataflow.UseVisualStyleBackColor = true;
            // 
            // label_engineStatus
            // 
            this.label_engineStatus.AutoSize = true;
            this.label_engineStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_engineStatus.ForeColor = System.Drawing.Color.Red;
            this.label_engineStatus.Location = new System.Drawing.Point(55, 98);
            this.label_engineStatus.Name = "label_engineStatus";
            this.label_engineStatus.Size = new System.Drawing.Size(88, 15);
            this.label_engineStatus.TabIndex = 10;
            this.label_engineStatus.Text = "ENGINE IS OFF";
            // 
            // button_engineToggle
            // 
            this.button_engineToggle.Location = new System.Drawing.Point(14, 116);
            this.button_engineToggle.Name = "button_engineToggle";
            this.button_engineToggle.Size = new System.Drawing.Size(159, 23);
            this.button_engineToggle.TabIndex = 9;
            this.button_engineToggle.Text = "TOGGLE ENGINE";
            this.button_engineToggle.UseVisualStyleBackColor = true;
            this.button_engineToggle.Click += new System.EventHandler(this.button_engineToggle_Click);
            // 
            // label_varRpm
            // 
            this.label_varRpm.AutoSize = true;
            this.label_varRpm.Location = new System.Drawing.Point(55, 65);
            this.label_varRpm.Name = "label_varRpm";
            this.label_varRpm.Size = new System.Drawing.Size(32, 15);
            this.label_varRpm.TabIndex = 7;
            this.label_varRpm.Text = "RPM";
            // 
            // label_varVbr
            // 
            this.label_varVbr.AutoSize = true;
            this.label_varVbr.Location = new System.Drawing.Point(27, 39);
            this.label_varVbr.Name = "label_varVbr";
            this.label_varVbr.Size = new System.Drawing.Size(60, 15);
            this.label_varVbr.TabIndex = 6;
            this.label_varVbr.Text = "Vibrations";
            // 
            // label_varTmp
            // 
            this.label_varTmp.AutoSize = true;
            this.label_varTmp.Location = new System.Drawing.Point(14, 10);
            this.label_varTmp.Name = "label_varTmp";
            this.label_varTmp.Size = new System.Drawing.Size(73, 15);
            this.label_varTmp.TabIndex = 5;
            this.label_varTmp.Text = "Temperature";
            // 
            // textBox_varRpm
            // 
            this.textBox_varRpm.Location = new System.Drawing.Point(93, 65);
            this.textBox_varRpm.Name = "textBox_varRpm";
            this.textBox_varRpm.ReadOnly = true;
            this.textBox_varRpm.Size = new System.Drawing.Size(80, 23);
            this.textBox_varRpm.TabIndex = 3;
            // 
            // textBox_varTmp
            // 
            this.textBox_varTmp.Location = new System.Drawing.Point(93, 7);
            this.textBox_varTmp.Name = "textBox_varTmp";
            this.textBox_varTmp.ReadOnly = true;
            this.textBox_varTmp.Size = new System.Drawing.Size(80, 23);
            this.textBox_varTmp.TabIndex = 2;
            // 
            // textBox_varVbr
            // 
            this.textBox_varVbr.Location = new System.Drawing.Point(93, 36);
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
            this.ClientSize = new System.Drawing.Size(287, 271);
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
            ((System.ComponentModel.ISupportInitialize)(this.numericUD_dbPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUD_mccPort)).EndInit();
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
    }
}