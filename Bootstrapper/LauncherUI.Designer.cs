
namespace Bootstrapper
{
    partial class LauncherUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LauncherTabControl = new System.Windows.Forms.TabControl();
            this.BotMatchTab = new System.Windows.Forms.TabPage();
            this.BGTabBotCountNum = new System.Windows.Forms.NumericUpDown();
            this.BGTabBotCountLable = new System.Windows.Forms.Label();
            this.BGTabLaunchButton = new System.Windows.Forms.Button();
            this.BGTabMapLable = new System.Windows.Forms.Label();
            this.BGTabGamemodeLabel = new System.Windows.Forms.Label();
            this.BGTabMapsCombo = new System.Windows.Forms.ComboBox();
            this.BGTabGamemodesCombo = new System.Windows.Forms.ComboBox();
            this.ClientTab = new System.Windows.Forms.TabPage();
            this.ClientTabServerPortNum = new System.Windows.Forms.NumericUpDown();
            this.ClientTabHostServersRestoreButton = new System.Windows.Forms.Button();
            this.ClientTabHostServersBackupButton = new System.Windows.Forms.Button();
            this.ClientTabServerAddressSaveButton = new System.Windows.Forms.Button();
            this.ClientTabHostServersResetButton = new System.Windows.Forms.Button();
            this.ClientTabHostServersComboBox = new System.Windows.Forms.ComboBox();
            this.ClientTabHostServersLable = new System.Windows.Forms.Label();
            this.ClientTabLocalConnectCheckBox = new System.Windows.Forms.CheckBox();
            this.ClientTabCustomURLTextBox = new System.Windows.Forms.TextBox();
            this.ClientTabCustomURLCheckBox = new System.Windows.Forms.CheckBox();
            this.ClientTabLaunchOptionsLable = new System.Windows.Forms.Label();
            this.ClientTabPlayerNameLabel = new System.Windows.Forms.Label();
            this.ClientTabServerAddressLable = new System.Windows.Forms.Label();
            this.ClientTabLaunchButton = new System.Windows.Forms.Button();
            this.ClientTabLaunchOptionsTextBox = new System.Windows.Forms.TextBox();
            this.ClientTabPlayerNameTextBox = new System.Windows.Forms.TextBox();
            this.ClientTabServerAddressTextBox = new System.Windows.Forms.TextBox();
            this.ServerTab = new System.Windows.Forms.TabPage();
            this.ServerTabPortLable = new System.Windows.Forms.Label();
            this.ServerTabPortNum = new System.Windows.Forms.NumericUpDown();
            this.ServerTabPlayerCountNum = new System.Windows.Forms.NumericUpDown();
            this.ServerTabMaxPlayersLabel = new System.Windows.Forms.Label();
            this.ServerTabCustomURLCheckbox = new System.Windows.Forms.CheckBox();
            this.ServerTabCustomURLTextBox = new System.Windows.Forms.TextBox();
            this.ServerTabLaunchOptionsLabel = new System.Windows.Forms.Label();
            this.ServerTabBotCountLabel = new System.Windows.Forms.Label();
            this.ServerTabMapLabel = new System.Windows.Forms.Label();
            this.ServerTabGamemodeLabel = new System.Windows.Forms.Label();
            this.ServerTabLaunchOptionsTextBox = new System.Windows.Forms.TextBox();
            this.ServerTabLaunchButton = new System.Windows.Forms.Button();
            this.ServerTabBotCountNum = new System.Windows.Forms.NumericUpDown();
            this.ServerTabMapsCombo = new System.Windows.Forms.ComboBox();
            this.ServerTabGamemodesCombo = new System.Windows.Forms.ComboBox();
            this.MasterServerTab = new System.Windows.Forms.TabPage();
            this.MSTabNotImplementedLable = new System.Windows.Forms.Label();
            this.LauncherTabControl.SuspendLayout();
            this.BotMatchTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BGTabBotCountNum)).BeginInit();
            this.ClientTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ClientTabServerPortNum)).BeginInit();
            this.ServerTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ServerTabPortNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerTabPlayerCountNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerTabBotCountNum)).BeginInit();
            this.MasterServerTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // LauncherTabControl
            // 
            this.LauncherTabControl.Controls.Add(this.BotMatchTab);
            this.LauncherTabControl.Controls.Add(this.ClientTab);
            this.LauncherTabControl.Controls.Add(this.ServerTab);
            this.LauncherTabControl.Controls.Add(this.MasterServerTab);
            this.LauncherTabControl.Location = new System.Drawing.Point(0, 0);
            this.LauncherTabControl.Name = "LauncherTabControl";
            this.LauncherTabControl.SelectedIndex = 0;
            this.LauncherTabControl.Size = new System.Drawing.Size(622, 322);
            this.LauncherTabControl.TabIndex = 0;
            // 
            // BotMatchTab
            // 
            this.BotMatchTab.Controls.Add(this.BGTabBotCountNum);
            this.BotMatchTab.Controls.Add(this.BGTabBotCountLable);
            this.BotMatchTab.Controls.Add(this.BGTabLaunchButton);
            this.BotMatchTab.Controls.Add(this.BGTabMapLable);
            this.BotMatchTab.Controls.Add(this.BGTabGamemodeLabel);
            this.BotMatchTab.Controls.Add(this.BGTabMapsCombo);
            this.BotMatchTab.Controls.Add(this.BGTabGamemodesCombo);
            this.BotMatchTab.Location = new System.Drawing.Point(4, 22);
            this.BotMatchTab.Name = "BotMatchTab";
            this.BotMatchTab.Padding = new System.Windows.Forms.Padding(3);
            this.BotMatchTab.Size = new System.Drawing.Size(614, 296);
            this.BotMatchTab.TabIndex = 0;
            this.BotMatchTab.Text = "Bot Match";
            this.BotMatchTab.UseVisualStyleBackColor = true;
            // 
            // BGTabBotCountNum
            // 
            this.BGTabBotCountNum.Location = new System.Drawing.Point(425, 144);
            this.BGTabBotCountNum.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.BGTabBotCountNum.Name = "BGTabBotCountNum";
            this.BGTabBotCountNum.Size = new System.Drawing.Size(121, 20);
            this.BGTabBotCountNum.TabIndex = 17;
            // 
            // BGTabBotCountLable
            // 
            this.BGTabBotCountLable.AutoSize = true;
            this.BGTabBotCountLable.Location = new System.Drawing.Point(72, 146);
            this.BGTabBotCountLable.Name = "BGTabBotCountLable";
            this.BGTabBotCountLable.Size = new System.Drawing.Size(54, 13);
            this.BGTabBotCountLable.TabIndex = 16;
            this.BGTabBotCountLable.Text = "Bot Count";
            // 
            // BGTabLaunchButton
            // 
            this.BGTabLaunchButton.Location = new System.Drawing.Point(270, 244);
            this.BGTabLaunchButton.Name = "BGTabLaunchButton";
            this.BGTabLaunchButton.Size = new System.Drawing.Size(75, 23);
            this.BGTabLaunchButton.TabIndex = 15;
            this.BGTabLaunchButton.Text = "Launch";
            this.BGTabLaunchButton.UseVisualStyleBackColor = true;
            this.BGTabLaunchButton.Click += new System.EventHandler(this.BGLaunchButton_Click);
            // 
            // BGTabMapLable
            // 
            this.BGTabMapLable.AutoSize = true;
            this.BGTabMapLable.Location = new System.Drawing.Point(72, 120);
            this.BGTabMapLable.Name = "BGTabMapLable";
            this.BGTabMapLable.Size = new System.Drawing.Size(28, 13);
            this.BGTabMapLable.TabIndex = 14;
            this.BGTabMapLable.Text = "Map";
            // 
            // BGTabGamemodeLabel
            // 
            this.BGTabGamemodeLabel.AutoSize = true;
            this.BGTabGamemodeLabel.Location = new System.Drawing.Point(72, 93);
            this.BGTabGamemodeLabel.Name = "BGTabGamemodeLabel";
            this.BGTabGamemodeLabel.Size = new System.Drawing.Size(61, 13);
            this.BGTabGamemodeLabel.TabIndex = 13;
            this.BGTabGamemodeLabel.Text = "Gamemode";
            // 
            // BGTabMapsCombo
            // 
            this.BGTabMapsCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BGTabMapsCombo.FormattingEnabled = true;
            this.BGTabMapsCombo.Items.AddRange(new object[] {
            "HeloDeck"});
            this.BGTabMapsCombo.Location = new System.Drawing.Point(425, 117);
            this.BGTabMapsCombo.Name = "BGTabMapsCombo";
            this.BGTabMapsCombo.Size = new System.Drawing.Size(121, 21);
            this.BGTabMapsCombo.TabIndex = 12;
            // 
            // BGTabGamemodesCombo
            // 
            this.BGTabGamemodesCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BGTabGamemodesCombo.FormattingEnabled = true;
            this.BGTabGamemodesCombo.Items.AddRange(new object[] {
            "Deathmatch",
            "Team Deathmatch",
            "Domination",
            "KOTH",
            "Kill Confirmed",
            "Last Man Standing",
            "Last Team Standing",
            "Search and Destroy",
            "Onslaught"});
            this.BGTabGamemodesCombo.Location = new System.Drawing.Point(425, 90);
            this.BGTabGamemodesCombo.Name = "BGTabGamemodesCombo";
            this.BGTabGamemodesCombo.Size = new System.Drawing.Size(121, 21);
            this.BGTabGamemodesCombo.TabIndex = 11;
            // 
            // ClientTab
            // 
            this.ClientTab.Controls.Add(this.ClientTabServerPortNum);
            this.ClientTab.Controls.Add(this.ClientTabHostServersRestoreButton);
            this.ClientTab.Controls.Add(this.ClientTabHostServersBackupButton);
            this.ClientTab.Controls.Add(this.ClientTabServerAddressSaveButton);
            this.ClientTab.Controls.Add(this.ClientTabHostServersResetButton);
            this.ClientTab.Controls.Add(this.ClientTabHostServersComboBox);
            this.ClientTab.Controls.Add(this.ClientTabHostServersLable);
            this.ClientTab.Controls.Add(this.ClientTabLocalConnectCheckBox);
            this.ClientTab.Controls.Add(this.ClientTabCustomURLTextBox);
            this.ClientTab.Controls.Add(this.ClientTabCustomURLCheckBox);
            this.ClientTab.Controls.Add(this.ClientTabLaunchOptionsLable);
            this.ClientTab.Controls.Add(this.ClientTabPlayerNameLabel);
            this.ClientTab.Controls.Add(this.ClientTabServerAddressLable);
            this.ClientTab.Controls.Add(this.ClientTabLaunchButton);
            this.ClientTab.Controls.Add(this.ClientTabLaunchOptionsTextBox);
            this.ClientTab.Controls.Add(this.ClientTabPlayerNameTextBox);
            this.ClientTab.Controls.Add(this.ClientTabServerAddressTextBox);
            this.ClientTab.Location = new System.Drawing.Point(4, 22);
            this.ClientTab.Name = "ClientTab";
            this.ClientTab.Padding = new System.Windows.Forms.Padding(3);
            this.ClientTab.Size = new System.Drawing.Size(614, 296);
            this.ClientTab.TabIndex = 1;
            this.ClientTab.Text = "Client";
            this.ClientTab.UseVisualStyleBackColor = true;
            // 
            // ClientTabServerPortNum
            // 
            this.ClientTabServerPortNum.Location = new System.Drawing.Point(418, 121);
            this.ClientTabServerPortNum.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.ClientTabServerPortNum.Name = "ClientTabServerPortNum";
            this.ClientTabServerPortNum.Size = new System.Drawing.Size(60, 20);
            this.ClientTabServerPortNum.TabIndex = 28;
            this.ClientTabServerPortNum.Value = new decimal(new int[] {
            7777,
            0,
            0,
            0});
            // 
            // ClientTabHostServersRestoreButton
            // 
            this.ClientTabHostServersRestoreButton.Location = new System.Drawing.Point(483, 69);
            this.ClientTabHostServersRestoreButton.Name = "ClientTabHostServersRestoreButton";
            this.ClientTabHostServersRestoreButton.Size = new System.Drawing.Size(70, 23);
            this.ClientTabHostServersRestoreButton.TabIndex = 27;
            this.ClientTabHostServersRestoreButton.Text = "Restore";
            this.ClientTabHostServersRestoreButton.UseVisualStyleBackColor = true;
            this.ClientTabHostServersRestoreButton.Click += new System.EventHandler(this.ClientHostServersRestoreButton_Click);
            // 
            // ClientTabHostServersBackupButton
            // 
            this.ClientTabHostServersBackupButton.Location = new System.Drawing.Point(403, 69);
            this.ClientTabHostServersBackupButton.Name = "ClientTabHostServersBackupButton";
            this.ClientTabHostServersBackupButton.Size = new System.Drawing.Size(75, 23);
            this.ClientTabHostServersBackupButton.TabIndex = 26;
            this.ClientTabHostServersBackupButton.Text = "Backup";
            this.ClientTabHostServersBackupButton.UseVisualStyleBackColor = true;
            this.ClientTabHostServersBackupButton.Click += new System.EventHandler(this.ClientHostServersBackupButton_Click);
            // 
            // ClientTabServerAddressSaveButton
            // 
            this.ClientTabServerAddressSaveButton.Location = new System.Drawing.Point(484, 119);
            this.ClientTabServerAddressSaveButton.Name = "ClientTabServerAddressSaveButton";
            this.ClientTabServerAddressSaveButton.Size = new System.Drawing.Size(70, 23);
            this.ClientTabServerAddressSaveButton.TabIndex = 25;
            this.ClientTabServerAddressSaveButton.Text = "Save";
            this.ClientTabServerAddressSaveButton.UseVisualStyleBackColor = true;
            this.ClientTabServerAddressSaveButton.Click += new System.EventHandler(this.ClientServerAddressSaveButton_Click);
            // 
            // ClientTabHostServersResetButton
            // 
            this.ClientTabHostServersResetButton.Location = new System.Drawing.Point(322, 69);
            this.ClientTabHostServersResetButton.Name = "ClientTabHostServersResetButton";
            this.ClientTabHostServersResetButton.Size = new System.Drawing.Size(70, 23);
            this.ClientTabHostServersResetButton.TabIndex = 24;
            this.ClientTabHostServersResetButton.Text = "Reset";
            this.ClientTabHostServersResetButton.UseVisualStyleBackColor = true;
            this.ClientTabHostServersResetButton.Click += new System.EventHandler(this.ClientHostServersResetButton_Click);
            // 
            // ClientTabHostServersComboBox
            // 
            this.ClientTabHostServersComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ClientTabHostServersComboBox.FormattingEnabled = true;
            this.ClientTabHostServersComboBox.Location = new System.Drawing.Point(322, 42);
            this.ClientTabHostServersComboBox.Name = "ClientTabHostServersComboBox";
            this.ClientTabHostServersComboBox.Size = new System.Drawing.Size(231, 21);
            this.ClientTabHostServersComboBox.TabIndex = 23;
            this.ClientTabHostServersComboBox.SelectedIndexChanged += new System.EventHandler(this.ClientHostServersComboBox_SelectedIndexChanged);
            // 
            // ClientTabHostServersLable
            // 
            this.ClientTabHostServersLable.AutoSize = true;
            this.ClientTabHostServersLable.Location = new System.Drawing.Point(73, 45);
            this.ClientTabHostServersLable.Name = "ClientTabHostServersLable";
            this.ClientTabHostServersLable.Size = new System.Drawing.Size(102, 13);
            this.ClientTabHostServersLable.TabIndex = 22;
            this.ClientTabHostServersLable.Text = "Saved Host Servers";
            // 
            // ClientTabLocalConnectCheckBox
            // 
            this.ClientTabLocalConnectCheckBox.AutoSize = true;
            this.ClientTabLocalConnectCheckBox.Location = new System.Drawing.Point(418, 98);
            this.ClientTabLocalConnectCheckBox.Name = "ClientTabLocalConnectCheckBox";
            this.ClientTabLocalConnectCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ClientTabLocalConnectCheckBox.Size = new System.Drawing.Size(135, 17);
            this.ClientTabLocalConnectCheckBox.TabIndex = 22;
            this.ClientTabLocalConnectCheckBox.Text = "Connect to local server";
            this.ClientTabLocalConnectCheckBox.UseVisualStyleBackColor = true;
            this.ClientTabLocalConnectCheckBox.CheckedChanged += new System.EventHandler(this.ClientLocalConnectCheckBox_CheckedChanged);
            // 
            // ClientTabCustomURLTextBox
            // 
            this.ClientTabCustomURLTextBox.Enabled = false;
            this.ClientTabCustomURLTextBox.Location = new System.Drawing.Point(322, 199);
            this.ClientTabCustomURLTextBox.Name = "ClientTabCustomURLTextBox";
            this.ClientTabCustomURLTextBox.Size = new System.Drawing.Size(231, 20);
            this.ClientTabCustomURLTextBox.TabIndex = 21;
            // 
            // ClientTabCustomURLCheckBox
            // 
            this.ClientTabCustomURLCheckBox.AutoSize = true;
            this.ClientTabCustomURLCheckBox.Location = new System.Drawing.Point(75, 201);
            this.ClientTabCustomURLCheckBox.Name = "ClientTabCustomURLCheckBox";
            this.ClientTabCustomURLCheckBox.Size = new System.Drawing.Size(86, 17);
            this.ClientTabCustomURLCheckBox.TabIndex = 20;
            this.ClientTabCustomURLCheckBox.Text = "Custom URL";
            this.ClientTabCustomURLCheckBox.UseVisualStyleBackColor = true;
            this.ClientTabCustomURLCheckBox.CheckedChanged += new System.EventHandler(this.ClientCustomURLCheckBox_CheckedChanged);
            // 
            // ClientTabLaunchOptionsLable
            // 
            this.ClientTabLaunchOptionsLable.AutoSize = true;
            this.ClientTabLaunchOptionsLable.Location = new System.Drawing.Point(72, 176);
            this.ClientTabLaunchOptionsLable.Name = "ClientTabLaunchOptionsLable";
            this.ClientTabLaunchOptionsLable.Size = new System.Drawing.Size(109, 13);
            this.ClientTabLaunchOptionsLable.TabIndex = 19;
            this.ClientTabLaunchOptionsLable.Text = "Additional Parameters";
            // 
            // ClientTabPlayerNameLabel
            // 
            this.ClientTabPlayerNameLabel.AutoSize = true;
            this.ClientTabPlayerNameLabel.Location = new System.Drawing.Point(72, 150);
            this.ClientTabPlayerNameLabel.Name = "ClientTabPlayerNameLabel";
            this.ClientTabPlayerNameLabel.Size = new System.Drawing.Size(67, 13);
            this.ClientTabPlayerNameLabel.TabIndex = 18;
            this.ClientTabPlayerNameLabel.Text = "Player Name";
            // 
            // ClientTabServerAddressLable
            // 
            this.ClientTabServerAddressLable.AutoSize = true;
            this.ClientTabServerAddressLable.Location = new System.Drawing.Point(72, 124);
            this.ClientTabServerAddressLable.Name = "ClientTabServerAddressLable";
            this.ClientTabServerAddressLable.Size = new System.Drawing.Size(103, 13);
            this.ClientTabServerAddressLable.TabIndex = 17;
            this.ClientTabServerAddressLable.Text = "Server Address/Port";
            // 
            // ClientTabLaunchButton
            // 
            this.ClientTabLaunchButton.Location = new System.Drawing.Point(270, 244);
            this.ClientTabLaunchButton.Name = "ClientTabLaunchButton";
            this.ClientTabLaunchButton.Size = new System.Drawing.Size(75, 23);
            this.ClientTabLaunchButton.TabIndex = 16;
            this.ClientTabLaunchButton.Text = "Launch";
            this.ClientTabLaunchButton.UseVisualStyleBackColor = true;
            this.ClientTabLaunchButton.Click += new System.EventHandler(this.ClientLaunchButton_Click);
            // 
            // ClientTabLaunchOptionsTextBox
            // 
            this.ClientTabLaunchOptionsTextBox.Location = new System.Drawing.Point(322, 173);
            this.ClientTabLaunchOptionsTextBox.Name = "ClientTabLaunchOptionsTextBox";
            this.ClientTabLaunchOptionsTextBox.Size = new System.Drawing.Size(231, 20);
            this.ClientTabLaunchOptionsTextBox.TabIndex = 15;
            // 
            // ClientTabPlayerNameTextBox
            // 
            this.ClientTabPlayerNameTextBox.Location = new System.Drawing.Point(322, 147);
            this.ClientTabPlayerNameTextBox.MaxLength = 24;
            this.ClientTabPlayerNameTextBox.Name = "ClientTabPlayerNameTextBox";
            this.ClientTabPlayerNameTextBox.Size = new System.Drawing.Size(231, 20);
            this.ClientTabPlayerNameTextBox.TabIndex = 14;
            this.ClientTabPlayerNameTextBox.Text = "Player";
            // 
            // ClientTabServerAddressTextBox
            // 
            this.ClientTabServerAddressTextBox.Location = new System.Drawing.Point(322, 121);
            this.ClientTabServerAddressTextBox.Name = "ClientTabServerAddressTextBox";
            this.ClientTabServerAddressTextBox.Size = new System.Drawing.Size(90, 20);
            this.ClientTabServerAddressTextBox.TabIndex = 13;
            this.ClientTabServerAddressTextBox.Text = "127.0.0.1";
            // 
            // ServerTab
            // 
            this.ServerTab.Controls.Add(this.ServerTabPortLable);
            this.ServerTab.Controls.Add(this.ServerTabPortNum);
            this.ServerTab.Controls.Add(this.ServerTabPlayerCountNum);
            this.ServerTab.Controls.Add(this.ServerTabMaxPlayersLabel);
            this.ServerTab.Controls.Add(this.ServerTabCustomURLCheckbox);
            this.ServerTab.Controls.Add(this.ServerTabCustomURLTextBox);
            this.ServerTab.Controls.Add(this.ServerTabLaunchOptionsLabel);
            this.ServerTab.Controls.Add(this.ServerTabBotCountLabel);
            this.ServerTab.Controls.Add(this.ServerTabMapLabel);
            this.ServerTab.Controls.Add(this.ServerTabGamemodeLabel);
            this.ServerTab.Controls.Add(this.ServerTabLaunchOptionsTextBox);
            this.ServerTab.Controls.Add(this.ServerTabLaunchButton);
            this.ServerTab.Controls.Add(this.ServerTabBotCountNum);
            this.ServerTab.Controls.Add(this.ServerTabMapsCombo);
            this.ServerTab.Controls.Add(this.ServerTabGamemodesCombo);
            this.ServerTab.Location = new System.Drawing.Point(4, 22);
            this.ServerTab.Name = "ServerTab";
            this.ServerTab.Size = new System.Drawing.Size(614, 296);
            this.ServerTab.TabIndex = 2;
            this.ServerTab.Text = "Server";
            this.ServerTab.UseVisualStyleBackColor = true;
            // 
            // ServerTabPortLable
            // 
            this.ServerTabPortLable.AutoSize = true;
            this.ServerTabPortLable.Location = new System.Drawing.Point(72, 149);
            this.ServerTabPortLable.Name = "ServerTabPortLable";
            this.ServerTabPortLable.Size = new System.Drawing.Size(64, 13);
            this.ServerTabPortLable.TabIndex = 30;
            this.ServerTabPortLable.Text = "Custom Port";
            // 
            // ServerTabPortNum
            // 
            this.ServerTabPortNum.Location = new System.Drawing.Point(425, 147);
            this.ServerTabPortNum.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.ServerTabPortNum.Name = "ServerTabPortNum";
            this.ServerTabPortNum.Size = new System.Drawing.Size(121, 20);
            this.ServerTabPortNum.TabIndex = 29;
            this.ServerTabPortNum.Value = new decimal(new int[] {
            7777,
            0,
            0,
            0});
            // 
            // ServerTabPlayerCountNum
            // 
            this.ServerTabPlayerCountNum.Location = new System.Drawing.Point(425, 95);
            this.ServerTabPlayerCountNum.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.ServerTabPlayerCountNum.Name = "ServerTabPlayerCountNum";
            this.ServerTabPlayerCountNum.Size = new System.Drawing.Size(121, 20);
            this.ServerTabPlayerCountNum.TabIndex = 26;
            // 
            // ServerTabMaxPlayersLabel
            // 
            this.ServerTabMaxPlayersLabel.AutoSize = true;
            this.ServerTabMaxPlayersLabel.Location = new System.Drawing.Point(72, 97);
            this.ServerTabMaxPlayersLabel.Name = "ServerTabMaxPlayersLabel";
            this.ServerTabMaxPlayersLabel.Size = new System.Drawing.Size(64, 13);
            this.ServerTabMaxPlayersLabel.TabIndex = 25;
            this.ServerTabMaxPlayersLabel.Text = "Max Players";
            // 
            // ServerTabCustomURLCheckbox
            // 
            this.ServerTabCustomURLCheckbox.AutoSize = true;
            this.ServerTabCustomURLCheckbox.Location = new System.Drawing.Point(75, 201);
            this.ServerTabCustomURLCheckbox.Name = "ServerTabCustomURLCheckbox";
            this.ServerTabCustomURLCheckbox.Size = new System.Drawing.Size(86, 17);
            this.ServerTabCustomURLCheckbox.TabIndex = 24;
            this.ServerTabCustomURLCheckbox.Text = "Custom URL";
            this.ServerTabCustomURLCheckbox.UseVisualStyleBackColor = true;
            this.ServerTabCustomURLCheckbox.CheckedChanged += new System.EventHandler(this.ServerCustomURLCheckbox_CheckedChanged);
            // 
            // ServerTabCustomURLTextBox
            // 
            this.ServerTabCustomURLTextBox.Enabled = false;
            this.ServerTabCustomURLTextBox.Location = new System.Drawing.Point(315, 199);
            this.ServerTabCustomURLTextBox.Name = "ServerTabCustomURLTextBox";
            this.ServerTabCustomURLTextBox.Size = new System.Drawing.Size(231, 20);
            this.ServerTabCustomURLTextBox.TabIndex = 23;
            // 
            // ServerTabLaunchOptionsLabel
            // 
            this.ServerTabLaunchOptionsLabel.AutoSize = true;
            this.ServerTabLaunchOptionsLabel.Location = new System.Drawing.Point(72, 176);
            this.ServerTabLaunchOptionsLabel.Name = "ServerTabLaunchOptionsLabel";
            this.ServerTabLaunchOptionsLabel.Size = new System.Drawing.Size(109, 13);
            this.ServerTabLaunchOptionsLabel.TabIndex = 22;
            this.ServerTabLaunchOptionsLabel.Text = "Additional Parameters";
            // 
            // ServerTabBotCountLabel
            // 
            this.ServerTabBotCountLabel.AutoSize = true;
            this.ServerTabBotCountLabel.Location = new System.Drawing.Point(72, 123);
            this.ServerTabBotCountLabel.Name = "ServerTabBotCountLabel";
            this.ServerTabBotCountLabel.Size = new System.Drawing.Size(54, 13);
            this.ServerTabBotCountLabel.TabIndex = 21;
            this.ServerTabBotCountLabel.Text = "Bot Count";
            // 
            // ServerTabMapLabel
            // 
            this.ServerTabMapLabel.AutoSize = true;
            this.ServerTabMapLabel.Location = new System.Drawing.Point(72, 71);
            this.ServerTabMapLabel.Name = "ServerTabMapLabel";
            this.ServerTabMapLabel.Size = new System.Drawing.Size(28, 13);
            this.ServerTabMapLabel.TabIndex = 20;
            this.ServerTabMapLabel.Text = "Map";
            // 
            // ServerTabGamemodeLabel
            // 
            this.ServerTabGamemodeLabel.AutoSize = true;
            this.ServerTabGamemodeLabel.Location = new System.Drawing.Point(72, 44);
            this.ServerTabGamemodeLabel.Name = "ServerTabGamemodeLabel";
            this.ServerTabGamemodeLabel.Size = new System.Drawing.Size(61, 13);
            this.ServerTabGamemodeLabel.TabIndex = 19;
            this.ServerTabGamemodeLabel.Text = "Gamemode";
            // 
            // ServerTabLaunchOptionsTextBox
            // 
            this.ServerTabLaunchOptionsTextBox.Location = new System.Drawing.Point(315, 173);
            this.ServerTabLaunchOptionsTextBox.Name = "ServerTabLaunchOptionsTextBox";
            this.ServerTabLaunchOptionsTextBox.Size = new System.Drawing.Size(231, 20);
            this.ServerTabLaunchOptionsTextBox.TabIndex = 18;
            // 
            // ServerTabLaunchButton
            // 
            this.ServerTabLaunchButton.Location = new System.Drawing.Point(270, 244);
            this.ServerTabLaunchButton.Name = "ServerTabLaunchButton";
            this.ServerTabLaunchButton.Size = new System.Drawing.Size(75, 23);
            this.ServerTabLaunchButton.TabIndex = 17;
            this.ServerTabLaunchButton.Text = "Launch";
            this.ServerTabLaunchButton.UseVisualStyleBackColor = true;
            this.ServerTabLaunchButton.Click += new System.EventHandler(this.ServerLaunchButton_Click);
            // 
            // ServerTabBotCountNum
            // 
            this.ServerTabBotCountNum.Location = new System.Drawing.Point(425, 121);
            this.ServerTabBotCountNum.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.ServerTabBotCountNum.Name = "ServerTabBotCountNum";
            this.ServerTabBotCountNum.Size = new System.Drawing.Size(121, 20);
            this.ServerTabBotCountNum.TabIndex = 16;
            // 
            // ServerTabMapsCombo
            // 
            this.ServerTabMapsCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ServerTabMapsCombo.FormattingEnabled = true;
            this.ServerTabMapsCombo.Location = new System.Drawing.Point(425, 68);
            this.ServerTabMapsCombo.Name = "ServerTabMapsCombo";
            this.ServerTabMapsCombo.Size = new System.Drawing.Size(121, 21);
            this.ServerTabMapsCombo.TabIndex = 15;
            // 
            // ServerTabGamemodesCombo
            // 
            this.ServerTabGamemodesCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ServerTabGamemodesCombo.FormattingEnabled = true;
            this.ServerTabGamemodesCombo.Location = new System.Drawing.Point(425, 41);
            this.ServerTabGamemodesCombo.Name = "ServerTabGamemodesCombo";
            this.ServerTabGamemodesCombo.Size = new System.Drawing.Size(121, 21);
            this.ServerTabGamemodesCombo.TabIndex = 14;
            // 
            // MasterServerTab
            // 
            this.MasterServerTab.Controls.Add(this.MSTabNotImplementedLable);
            this.MasterServerTab.Location = new System.Drawing.Point(4, 22);
            this.MasterServerTab.Name = "MasterServerTab";
            this.MasterServerTab.Size = new System.Drawing.Size(614, 296);
            this.MasterServerTab.TabIndex = 3;
            this.MasterServerTab.Text = "Master Server";
            this.MasterServerTab.UseVisualStyleBackColor = true;
            // 
            // MSTabNotImplementedLable
            // 
            this.MSTabNotImplementedLable.AutoSize = true;
            this.MSTabNotImplementedLable.Location = new System.Drawing.Point(270, 132);
            this.MSTabNotImplementedLable.Name = "MSTabNotImplementedLable";
            this.MSTabNotImplementedLable.Size = new System.Drawing.Size(89, 13);
            this.MSTabNotImplementedLable.TabIndex = 0;
            this.MSTabNotImplementedLable.Text = "Not implemented!";
            // 
            // LauncherUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 321);
            this.Controls.Add(this.LauncherTabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "LauncherUI";
            this.Text = "BLRevive Launcher";
            this.Load += new System.EventHandler(this.LauncherUI_Load);
            this.LauncherTabControl.ResumeLayout(false);
            this.BotMatchTab.ResumeLayout(false);
            this.BotMatchTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BGTabBotCountNum)).EndInit();
            this.ClientTab.ResumeLayout(false);
            this.ClientTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ClientTabServerPortNum)).EndInit();
            this.ServerTab.ResumeLayout(false);
            this.ServerTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ServerTabPortNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerTabPlayerCountNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerTabBotCountNum)).EndInit();
            this.MasterServerTab.ResumeLayout(false);
            this.MasterServerTab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl LauncherTabControl;
        private System.Windows.Forms.TabPage BotMatchTab;
        private System.Windows.Forms.TabPage ClientTab;
        private System.Windows.Forms.TabPage ServerTab;
        private System.Windows.Forms.TabPage MasterServerTab;
        private System.Windows.Forms.NumericUpDown BGTabBotCountNum;
        private System.Windows.Forms.Label BGTabBotCountLable;
        private System.Windows.Forms.Button BGTabLaunchButton;
        private System.Windows.Forms.Label BGTabMapLable;
        private System.Windows.Forms.Label BGTabGamemodeLabel;
        private System.Windows.Forms.ComboBox BGTabMapsCombo;
        private System.Windows.Forms.ComboBox BGTabGamemodesCombo;
        private System.Windows.Forms.Label MSTabNotImplementedLable;
        private System.Windows.Forms.TextBox ClientTabCustomURLTextBox;
        private System.Windows.Forms.CheckBox ClientTabCustomURLCheckBox;
        private System.Windows.Forms.Label ClientTabLaunchOptionsLable;
        private System.Windows.Forms.Label ClientTabPlayerNameLabel;
        private System.Windows.Forms.Label ClientTabServerAddressLable;
        private System.Windows.Forms.Button ClientTabLaunchButton;
        private System.Windows.Forms.TextBox ClientTabLaunchOptionsTextBox;
        private System.Windows.Forms.TextBox ClientTabPlayerNameTextBox;
        private System.Windows.Forms.TextBox ClientTabServerAddressTextBox;
        private System.Windows.Forms.NumericUpDown ServerTabPlayerCountNum;
        private System.Windows.Forms.Label ServerTabMaxPlayersLabel;
        private System.Windows.Forms.CheckBox ServerTabCustomURLCheckbox;
        private System.Windows.Forms.TextBox ServerTabCustomURLTextBox;
        private System.Windows.Forms.Label ServerTabLaunchOptionsLabel;
        private System.Windows.Forms.Label ServerTabBotCountLabel;
        private System.Windows.Forms.Label ServerTabMapLabel;
        private System.Windows.Forms.Label ServerTabGamemodeLabel;
        private System.Windows.Forms.TextBox ServerTabLaunchOptionsTextBox;
        private System.Windows.Forms.Button ServerTabLaunchButton;
        private System.Windows.Forms.NumericUpDown ServerTabBotCountNum;
        private System.Windows.Forms.ComboBox ServerTabMapsCombo;
        private System.Windows.Forms.ComboBox ServerTabGamemodesCombo;
        private System.Windows.Forms.Label ClientTabHostServersLable;
        private System.Windows.Forms.ComboBox ClientTabHostServersComboBox;
        private System.Windows.Forms.Button ClientTabHostServersResetButton;
        private System.Windows.Forms.Button ClientTabServerAddressSaveButton;
        private System.Windows.Forms.Button ClientTabHostServersRestoreButton;
        private System.Windows.Forms.Button ClientTabHostServersBackupButton;
        private System.Windows.Forms.CheckBox ClientTabLocalConnectCheckBox;
        private System.Windows.Forms.NumericUpDown ClientTabServerPortNum;
        private System.Windows.Forms.NumericUpDown ServerTabPortNum;
        private System.Windows.Forms.Label ServerTabPortLable;
    }
}