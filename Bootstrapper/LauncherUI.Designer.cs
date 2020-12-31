
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
            this.BGBotCountNum = new System.Windows.Forms.NumericUpDown();
            this.BGBotCountLable = new System.Windows.Forms.Label();
            this.BGLaunchButton = new System.Windows.Forms.Button();
            this.BGMapLable = new System.Windows.Forms.Label();
            this.BGGamemodeLabel = new System.Windows.Forms.Label();
            this.BGMapsCombo = new System.Windows.Forms.ComboBox();
            this.BGGamemodesCombo = new System.Windows.Forms.ComboBox();
            this.ClientTab = new System.Windows.Forms.TabPage();
            this.ClientHostServersRestoreButton = new System.Windows.Forms.Button();
            this.ClientHostServersBackupButton = new System.Windows.Forms.Button();
            this.ClientServerAddressSaveButton = new System.Windows.Forms.Button();
            this.ClientHostServersResetButton = new System.Windows.Forms.Button();
            this.ClientHostServersComboBox = new System.Windows.Forms.ComboBox();
            this.ClientHostServersLable = new System.Windows.Forms.Label();
            this.ClientLocalConnectCheckBox = new System.Windows.Forms.CheckBox();
            this.ClientCustomURLTextBox = new System.Windows.Forms.TextBox();
            this.ClientCustomURLCheckBox = new System.Windows.Forms.CheckBox();
            this.ClientLaunchOptionsLable = new System.Windows.Forms.Label();
            this.ClientPlayerNameLabel = new System.Windows.Forms.Label();
            this.ClientServerAddressLable = new System.Windows.Forms.Label();
            this.ClientLaunchButton = new System.Windows.Forms.Button();
            this.ClientLaunchOptionsTextBox = new System.Windows.Forms.TextBox();
            this.ClientPlayerNameTextBox = new System.Windows.Forms.TextBox();
            this.ClientServerAddressTextBox = new System.Windows.Forms.TextBox();
            this.ServerTab = new System.Windows.Forms.TabPage();
            this.ServerPlayerCountNum = new System.Windows.Forms.NumericUpDown();
            this.ServerMaxPlayersLabel = new System.Windows.Forms.Label();
            this.ServerCustomURLCheckbox = new System.Windows.Forms.CheckBox();
            this.ServerCustomURLTextBox = new System.Windows.Forms.TextBox();
            this.ServerLaunchOptionsLabel = new System.Windows.Forms.Label();
            this.ServerBotCountLabel = new System.Windows.Forms.Label();
            this.ServerMapLabel = new System.Windows.Forms.Label();
            this.ServerGamemodeLabel = new System.Windows.Forms.Label();
            this.ServerLaunchOptionsTextBox = new System.Windows.Forms.TextBox();
            this.ServerLaunchButton = new System.Windows.Forms.Button();
            this.ServerBotCountNum = new System.Windows.Forms.NumericUpDown();
            this.ServerMapsCombo = new System.Windows.Forms.ComboBox();
            this.ServerGamemodesCombo = new System.Windows.Forms.ComboBox();
            this.MasterServerTab = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.LauncherTabControl.SuspendLayout();
            this.BotMatchTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BGBotCountNum)).BeginInit();
            this.ClientTab.SuspendLayout();
            this.ServerTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ServerPlayerCountNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerBotCountNum)).BeginInit();
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
            this.BotMatchTab.Controls.Add(this.BGBotCountNum);
            this.BotMatchTab.Controls.Add(this.BGBotCountLable);
            this.BotMatchTab.Controls.Add(this.BGLaunchButton);
            this.BotMatchTab.Controls.Add(this.BGMapLable);
            this.BotMatchTab.Controls.Add(this.BGGamemodeLabel);
            this.BotMatchTab.Controls.Add(this.BGMapsCombo);
            this.BotMatchTab.Controls.Add(this.BGGamemodesCombo);
            this.BotMatchTab.Location = new System.Drawing.Point(4, 22);
            this.BotMatchTab.Name = "BotMatchTab";
            this.BotMatchTab.Padding = new System.Windows.Forms.Padding(3);
            this.BotMatchTab.Size = new System.Drawing.Size(614, 296);
            this.BotMatchTab.TabIndex = 0;
            this.BotMatchTab.Text = "Bot Match";
            this.BotMatchTab.UseVisualStyleBackColor = true;
            // 
            // BGBotCountNum
            // 
            this.BGBotCountNum.Location = new System.Drawing.Point(425, 144);
            this.BGBotCountNum.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.BGBotCountNum.Name = "BGBotCountNum";
            this.BGBotCountNum.Size = new System.Drawing.Size(121, 20);
            this.BGBotCountNum.TabIndex = 17;
            // 
            // BGBotCountLable
            // 
            this.BGBotCountLable.AutoSize = true;
            this.BGBotCountLable.Location = new System.Drawing.Point(72, 146);
            this.BGBotCountLable.Name = "BGBotCountLable";
            this.BGBotCountLable.Size = new System.Drawing.Size(54, 13);
            this.BGBotCountLable.TabIndex = 16;
            this.BGBotCountLable.Text = "Bot Count";
            // 
            // BGLaunchButton
            // 
            this.BGLaunchButton.Location = new System.Drawing.Point(270, 244);
            this.BGLaunchButton.Name = "BGLaunchButton";
            this.BGLaunchButton.Size = new System.Drawing.Size(75, 23);
            this.BGLaunchButton.TabIndex = 15;
            this.BGLaunchButton.Text = "Launch";
            this.BGLaunchButton.UseVisualStyleBackColor = true;
            this.BGLaunchButton.Click += new System.EventHandler(this.BGLaunchButton_Click);
            // 
            // BGMapLable
            // 
            this.BGMapLable.AutoSize = true;
            this.BGMapLable.Location = new System.Drawing.Point(72, 120);
            this.BGMapLable.Name = "BGMapLable";
            this.BGMapLable.Size = new System.Drawing.Size(28, 13);
            this.BGMapLable.TabIndex = 14;
            this.BGMapLable.Text = "Map";
            // 
            // BGGamemodeLabel
            // 
            this.BGGamemodeLabel.AutoSize = true;
            this.BGGamemodeLabel.Location = new System.Drawing.Point(72, 93);
            this.BGGamemodeLabel.Name = "BGGamemodeLabel";
            this.BGGamemodeLabel.Size = new System.Drawing.Size(61, 13);
            this.BGGamemodeLabel.TabIndex = 13;
            this.BGGamemodeLabel.Text = "Gamemode";
            // 
            // BGMapsCombo
            // 
            this.BGMapsCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BGMapsCombo.FormattingEnabled = true;
            this.BGMapsCombo.Items.AddRange(new object[] {
            "HeloDeck"});
            this.BGMapsCombo.Location = new System.Drawing.Point(425, 117);
            this.BGMapsCombo.Name = "BGMapsCombo";
            this.BGMapsCombo.Size = new System.Drawing.Size(121, 21);
            this.BGMapsCombo.TabIndex = 12;
            // 
            // BGGamemodesCombo
            // 
            this.BGGamemodesCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BGGamemodesCombo.FormattingEnabled = true;
            this.BGGamemodesCombo.Items.AddRange(new object[] {
            "Deathmatch",
            "Team Deathmatch",
            "Domination",
            "KOTH",
            "Kill Confirmed",
            "Last Man Standing",
            "Last Team Standing",
            "Search and Destroy",
            "Onslaught"});
            this.BGGamemodesCombo.Location = new System.Drawing.Point(425, 90);
            this.BGGamemodesCombo.Name = "BGGamemodesCombo";
            this.BGGamemodesCombo.Size = new System.Drawing.Size(121, 21);
            this.BGGamemodesCombo.TabIndex = 11;
            // 
            // ClientTab
            // 
            this.ClientTab.Controls.Add(this.ClientHostServersRestoreButton);
            this.ClientTab.Controls.Add(this.ClientHostServersBackupButton);
            this.ClientTab.Controls.Add(this.ClientServerAddressSaveButton);
            this.ClientTab.Controls.Add(this.ClientHostServersResetButton);
            this.ClientTab.Controls.Add(this.ClientHostServersComboBox);
            this.ClientTab.Controls.Add(this.ClientHostServersLable);
            this.ClientTab.Controls.Add(this.ClientLocalConnectCheckBox);
            this.ClientTab.Controls.Add(this.ClientCustomURLTextBox);
            this.ClientTab.Controls.Add(this.ClientCustomURLCheckBox);
            this.ClientTab.Controls.Add(this.ClientLaunchOptionsLable);
            this.ClientTab.Controls.Add(this.ClientPlayerNameLabel);
            this.ClientTab.Controls.Add(this.ClientServerAddressLable);
            this.ClientTab.Controls.Add(this.ClientLaunchButton);
            this.ClientTab.Controls.Add(this.ClientLaunchOptionsTextBox);
            this.ClientTab.Controls.Add(this.ClientPlayerNameTextBox);
            this.ClientTab.Controls.Add(this.ClientServerAddressTextBox);
            this.ClientTab.Location = new System.Drawing.Point(4, 22);
            this.ClientTab.Name = "ClientTab";
            this.ClientTab.Padding = new System.Windows.Forms.Padding(3);
            this.ClientTab.Size = new System.Drawing.Size(614, 296);
            this.ClientTab.TabIndex = 1;
            this.ClientTab.Text = "Client";
            this.ClientTab.UseVisualStyleBackColor = true;
            // 
            // ClientHostServersRestoreButton
            // 
            this.ClientHostServersRestoreButton.Location = new System.Drawing.Point(483, 56);
            this.ClientHostServersRestoreButton.Name = "ClientHostServersRestoreButton";
            this.ClientHostServersRestoreButton.Size = new System.Drawing.Size(70, 23);
            this.ClientHostServersRestoreButton.TabIndex = 27;
            this.ClientHostServersRestoreButton.Text = "Restore";
            this.ClientHostServersRestoreButton.UseVisualStyleBackColor = true;
            this.ClientHostServersRestoreButton.Click += new System.EventHandler(this.ClientHostServersRestoreButton_Click);
            // 
            // ClientHostServersBackupButton
            // 
            this.ClientHostServersBackupButton.Location = new System.Drawing.Point(403, 56);
            this.ClientHostServersBackupButton.Name = "ClientHostServersBackupButton";
            this.ClientHostServersBackupButton.Size = new System.Drawing.Size(75, 23);
            this.ClientHostServersBackupButton.TabIndex = 26;
            this.ClientHostServersBackupButton.Text = "Backup";
            this.ClientHostServersBackupButton.UseVisualStyleBackColor = true;
            this.ClientHostServersBackupButton.Click += new System.EventHandler(this.ClientHostServersBackupButton_Click);
            // 
            // ClientServerAddressSaveButton
            // 
            this.ClientServerAddressSaveButton.Location = new System.Drawing.Point(484, 119);
            this.ClientServerAddressSaveButton.Name = "ClientServerAddressSaveButton";
            this.ClientServerAddressSaveButton.Size = new System.Drawing.Size(70, 23);
            this.ClientServerAddressSaveButton.TabIndex = 25;
            this.ClientServerAddressSaveButton.Text = "Save";
            this.ClientServerAddressSaveButton.UseVisualStyleBackColor = true;
            this.ClientServerAddressSaveButton.Click += new System.EventHandler(this.ClientServerAddressSaveButton_Click);
            // 
            // ClientHostServersResetButton
            // 
            this.ClientHostServersResetButton.Location = new System.Drawing.Point(322, 56);
            this.ClientHostServersResetButton.Name = "ClientHostServersResetButton";
            this.ClientHostServersResetButton.Size = new System.Drawing.Size(70, 23);
            this.ClientHostServersResetButton.TabIndex = 24;
            this.ClientHostServersResetButton.Text = "Reset";
            this.ClientHostServersResetButton.UseVisualStyleBackColor = true;
            this.ClientHostServersResetButton.Click += new System.EventHandler(this.ClientHostServersResetButton_Click);
            // 
            // ClientHostServersComboBox
            // 
            this.ClientHostServersComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ClientHostServersComboBox.FormattingEnabled = true;
            this.ClientHostServersComboBox.Location = new System.Drawing.Point(322, 28);
            this.ClientHostServersComboBox.Name = "ClientHostServersComboBox";
            this.ClientHostServersComboBox.Size = new System.Drawing.Size(231, 21);
            this.ClientHostServersComboBox.TabIndex = 23;
            this.ClientHostServersComboBox.SelectedIndexChanged += new System.EventHandler(this.ClientHostServersComboBox_SelectedIndexChanged);
            // 
            // ClientHostServersLable
            // 
            this.ClientHostServersLable.AutoSize = true;
            this.ClientHostServersLable.Location = new System.Drawing.Point(79, 31);
            this.ClientHostServersLable.Name = "ClientHostServersLable";
            this.ClientHostServersLable.Size = new System.Drawing.Size(102, 13);
            this.ClientHostServersLable.TabIndex = 22;
            this.ClientHostServersLable.Text = "Saved Host Servers";
            // 
            // ClientLocalConnectCheckBox
            // 
            this.ClientLocalConnectCheckBox.AutoSize = true;
            this.ClientLocalConnectCheckBox.Location = new System.Drawing.Point(418, 98);
            this.ClientLocalConnectCheckBox.Name = "ClientLocalConnectCheckBox";
            this.ClientLocalConnectCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ClientLocalConnectCheckBox.Size = new System.Drawing.Size(135, 17);
            this.ClientLocalConnectCheckBox.TabIndex = 22;
            this.ClientLocalConnectCheckBox.Text = "Connect to local server";
            this.ClientLocalConnectCheckBox.UseVisualStyleBackColor = true;
            this.ClientLocalConnectCheckBox.CheckedChanged += new System.EventHandler(this.ClientLocalConnectCheckBox_CheckedChanged);
            // 
            // ClientCustomURLTextBox
            // 
            this.ClientCustomURLTextBox.Enabled = false;
            this.ClientCustomURLTextBox.Location = new System.Drawing.Point(322, 199);
            this.ClientCustomURLTextBox.Name = "ClientCustomURLTextBox";
            this.ClientCustomURLTextBox.Size = new System.Drawing.Size(231, 20);
            this.ClientCustomURLTextBox.TabIndex = 21;
            // 
            // ClientCustomURLCheckBox
            // 
            this.ClientCustomURLCheckBox.AutoSize = true;
            this.ClientCustomURLCheckBox.Location = new System.Drawing.Point(82, 201);
            this.ClientCustomURLCheckBox.Name = "ClientCustomURLCheckBox";
            this.ClientCustomURLCheckBox.Size = new System.Drawing.Size(86, 17);
            this.ClientCustomURLCheckBox.TabIndex = 20;
            this.ClientCustomURLCheckBox.Text = "Custom URL";
            this.ClientCustomURLCheckBox.UseVisualStyleBackColor = true;
            this.ClientCustomURLCheckBox.CheckedChanged += new System.EventHandler(this.ClientCustomURLCheckBox_CheckedChanged);
            // 
            // ClientLaunchOptionsLable
            // 
            this.ClientLaunchOptionsLable.AutoSize = true;
            this.ClientLaunchOptionsLable.Location = new System.Drawing.Point(79, 176);
            this.ClientLaunchOptionsLable.Name = "ClientLaunchOptionsLable";
            this.ClientLaunchOptionsLable.Size = new System.Drawing.Size(109, 13);
            this.ClientLaunchOptionsLable.TabIndex = 19;
            this.ClientLaunchOptionsLable.Text = "Additional Parameters";
            // 
            // ClientPlayerNameLabel
            // 
            this.ClientPlayerNameLabel.AutoSize = true;
            this.ClientPlayerNameLabel.Location = new System.Drawing.Point(79, 150);
            this.ClientPlayerNameLabel.Name = "ClientPlayerNameLabel";
            this.ClientPlayerNameLabel.Size = new System.Drawing.Size(67, 13);
            this.ClientPlayerNameLabel.TabIndex = 18;
            this.ClientPlayerNameLabel.Text = "Player Name";
            // 
            // ClientServerAddressLable
            // 
            this.ClientServerAddressLable.AutoSize = true;
            this.ClientServerAddressLable.Location = new System.Drawing.Point(79, 124);
            this.ClientServerAddressLable.Name = "ClientServerAddressLable";
            this.ClientServerAddressLable.Size = new System.Drawing.Size(79, 13);
            this.ClientServerAddressLable.TabIndex = 17;
            this.ClientServerAddressLable.Text = "Server Address";
            // 
            // ClientLaunchButton
            // 
            this.ClientLaunchButton.Location = new System.Drawing.Point(270, 244);
            this.ClientLaunchButton.Name = "ClientLaunchButton";
            this.ClientLaunchButton.Size = new System.Drawing.Size(75, 23);
            this.ClientLaunchButton.TabIndex = 16;
            this.ClientLaunchButton.Text = "Launch";
            this.ClientLaunchButton.UseVisualStyleBackColor = true;
            this.ClientLaunchButton.Click += new System.EventHandler(this.ClientLaunchButton_Click);
            // 
            // ClientLaunchOptionsTextBox
            // 
            this.ClientLaunchOptionsTextBox.Location = new System.Drawing.Point(322, 173);
            this.ClientLaunchOptionsTextBox.Name = "ClientLaunchOptionsTextBox";
            this.ClientLaunchOptionsTextBox.Size = new System.Drawing.Size(231, 20);
            this.ClientLaunchOptionsTextBox.TabIndex = 15;
            // 
            // ClientPlayerNameTextBox
            // 
            this.ClientPlayerNameTextBox.Location = new System.Drawing.Point(322, 147);
            this.ClientPlayerNameTextBox.MaxLength = 24;
            this.ClientPlayerNameTextBox.Name = "ClientPlayerNameTextBox";
            this.ClientPlayerNameTextBox.Size = new System.Drawing.Size(231, 20);
            this.ClientPlayerNameTextBox.TabIndex = 14;
            this.ClientPlayerNameTextBox.Text = "Player";
            // 
            // ClientServerAddressTextBox
            // 
            this.ClientServerAddressTextBox.Location = new System.Drawing.Point(322, 121);
            this.ClientServerAddressTextBox.Name = "ClientServerAddressTextBox";
            this.ClientServerAddressTextBox.Size = new System.Drawing.Size(156, 20);
            this.ClientServerAddressTextBox.TabIndex = 13;
            this.ClientServerAddressTextBox.Text = "127.0.0.1";
            // 
            // ServerTab
            // 
            this.ServerTab.Controls.Add(this.ServerPlayerCountNum);
            this.ServerTab.Controls.Add(this.ServerMaxPlayersLabel);
            this.ServerTab.Controls.Add(this.ServerCustomURLCheckbox);
            this.ServerTab.Controls.Add(this.ServerCustomURLTextBox);
            this.ServerTab.Controls.Add(this.ServerLaunchOptionsLabel);
            this.ServerTab.Controls.Add(this.ServerBotCountLabel);
            this.ServerTab.Controls.Add(this.ServerMapLabel);
            this.ServerTab.Controls.Add(this.ServerGamemodeLabel);
            this.ServerTab.Controls.Add(this.ServerLaunchOptionsTextBox);
            this.ServerTab.Controls.Add(this.ServerLaunchButton);
            this.ServerTab.Controls.Add(this.ServerBotCountNum);
            this.ServerTab.Controls.Add(this.ServerMapsCombo);
            this.ServerTab.Controls.Add(this.ServerGamemodesCombo);
            this.ServerTab.Location = new System.Drawing.Point(4, 22);
            this.ServerTab.Name = "ServerTab";
            this.ServerTab.Size = new System.Drawing.Size(614, 296);
            this.ServerTab.TabIndex = 2;
            this.ServerTab.Text = "Server";
            this.ServerTab.UseVisualStyleBackColor = true;
            // 
            // ServerPlayerCountNum
            // 
            this.ServerPlayerCountNum.Location = new System.Drawing.Point(425, 104);
            this.ServerPlayerCountNum.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.ServerPlayerCountNum.Name = "ServerPlayerCountNum";
            this.ServerPlayerCountNum.Size = new System.Drawing.Size(121, 20);
            this.ServerPlayerCountNum.TabIndex = 26;
            // 
            // ServerMaxPlayersLabel
            // 
            this.ServerMaxPlayersLabel.AutoSize = true;
            this.ServerMaxPlayersLabel.Location = new System.Drawing.Point(72, 106);
            this.ServerMaxPlayersLabel.Name = "ServerMaxPlayersLabel";
            this.ServerMaxPlayersLabel.Size = new System.Drawing.Size(64, 13);
            this.ServerMaxPlayersLabel.TabIndex = 25;
            this.ServerMaxPlayersLabel.Text = "Max Players";
            // 
            // ServerCustomURLCheckbox
            // 
            this.ServerCustomURLCheckbox.AutoSize = true;
            this.ServerCustomURLCheckbox.Location = new System.Drawing.Point(75, 184);
            this.ServerCustomURLCheckbox.Name = "ServerCustomURLCheckbox";
            this.ServerCustomURLCheckbox.Size = new System.Drawing.Size(86, 17);
            this.ServerCustomURLCheckbox.TabIndex = 24;
            this.ServerCustomURLCheckbox.Text = "Custom URL";
            this.ServerCustomURLCheckbox.UseVisualStyleBackColor = true;
            this.ServerCustomURLCheckbox.CheckedChanged += new System.EventHandler(this.ServerCustomURLCheckbox_CheckedChanged);
            // 
            // ServerCustomURLTextBox
            // 
            this.ServerCustomURLTextBox.Enabled = false;
            this.ServerCustomURLTextBox.Location = new System.Drawing.Point(315, 182);
            this.ServerCustomURLTextBox.Name = "ServerCustomURLTextBox";
            this.ServerCustomURLTextBox.Size = new System.Drawing.Size(231, 20);
            this.ServerCustomURLTextBox.TabIndex = 23;
            // 
            // ServerLaunchOptionsLabel
            // 
            this.ServerLaunchOptionsLabel.AutoSize = true;
            this.ServerLaunchOptionsLabel.Location = new System.Drawing.Point(72, 159);
            this.ServerLaunchOptionsLabel.Name = "ServerLaunchOptionsLabel";
            this.ServerLaunchOptionsLabel.Size = new System.Drawing.Size(109, 13);
            this.ServerLaunchOptionsLabel.TabIndex = 22;
            this.ServerLaunchOptionsLabel.Text = "Additional Parameters";
            // 
            // ServerBotCountLabel
            // 
            this.ServerBotCountLabel.AutoSize = true;
            this.ServerBotCountLabel.Location = new System.Drawing.Point(72, 132);
            this.ServerBotCountLabel.Name = "ServerBotCountLabel";
            this.ServerBotCountLabel.Size = new System.Drawing.Size(54, 13);
            this.ServerBotCountLabel.TabIndex = 21;
            this.ServerBotCountLabel.Text = "Bot Count";
            // 
            // ServerMapLabel
            // 
            this.ServerMapLabel.AutoSize = true;
            this.ServerMapLabel.Location = new System.Drawing.Point(72, 80);
            this.ServerMapLabel.Name = "ServerMapLabel";
            this.ServerMapLabel.Size = new System.Drawing.Size(28, 13);
            this.ServerMapLabel.TabIndex = 20;
            this.ServerMapLabel.Text = "Map";
            // 
            // ServerGamemodeLabel
            // 
            this.ServerGamemodeLabel.AutoSize = true;
            this.ServerGamemodeLabel.Location = new System.Drawing.Point(72, 53);
            this.ServerGamemodeLabel.Name = "ServerGamemodeLabel";
            this.ServerGamemodeLabel.Size = new System.Drawing.Size(61, 13);
            this.ServerGamemodeLabel.TabIndex = 19;
            this.ServerGamemodeLabel.Text = "Gamemode";
            // 
            // ServerLaunchOptionsTextBox
            // 
            this.ServerLaunchOptionsTextBox.Location = new System.Drawing.Point(315, 156);
            this.ServerLaunchOptionsTextBox.Name = "ServerLaunchOptionsTextBox";
            this.ServerLaunchOptionsTextBox.Size = new System.Drawing.Size(231, 20);
            this.ServerLaunchOptionsTextBox.TabIndex = 18;
            // 
            // ServerLaunchButton
            // 
            this.ServerLaunchButton.Location = new System.Drawing.Point(270, 244);
            this.ServerLaunchButton.Name = "ServerLaunchButton";
            this.ServerLaunchButton.Size = new System.Drawing.Size(75, 23);
            this.ServerLaunchButton.TabIndex = 17;
            this.ServerLaunchButton.Text = "Launch";
            this.ServerLaunchButton.UseVisualStyleBackColor = true;
            this.ServerLaunchButton.Click += new System.EventHandler(this.ServerLaunchButton_Click);
            // 
            // ServerBotCountNum
            // 
            this.ServerBotCountNum.Location = new System.Drawing.Point(425, 130);
            this.ServerBotCountNum.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.ServerBotCountNum.Name = "ServerBotCountNum";
            this.ServerBotCountNum.Size = new System.Drawing.Size(121, 20);
            this.ServerBotCountNum.TabIndex = 16;
            // 
            // ServerMapsCombo
            // 
            this.ServerMapsCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ServerMapsCombo.FormattingEnabled = true;
            this.ServerMapsCombo.Location = new System.Drawing.Point(425, 77);
            this.ServerMapsCombo.Name = "ServerMapsCombo";
            this.ServerMapsCombo.Size = new System.Drawing.Size(121, 21);
            this.ServerMapsCombo.TabIndex = 15;
            // 
            // ServerGamemodesCombo
            // 
            this.ServerGamemodesCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ServerGamemodesCombo.FormattingEnabled = true;
            this.ServerGamemodesCombo.Location = new System.Drawing.Point(425, 50);
            this.ServerGamemodesCombo.Name = "ServerGamemodesCombo";
            this.ServerGamemodesCombo.Size = new System.Drawing.Size(121, 21);
            this.ServerGamemodesCombo.TabIndex = 14;
            // 
            // MasterServerTab
            // 
            this.MasterServerTab.Controls.Add(this.label4);
            this.MasterServerTab.Location = new System.Drawing.Point(4, 22);
            this.MasterServerTab.Name = "MasterServerTab";
            this.MasterServerTab.Size = new System.Drawing.Size(614, 296);
            this.MasterServerTab.TabIndex = 3;
            this.MasterServerTab.Text = "Master Server";
            this.MasterServerTab.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(270, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Not implemented!";
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
            ((System.ComponentModel.ISupportInitialize)(this.BGBotCountNum)).EndInit();
            this.ClientTab.ResumeLayout(false);
            this.ClientTab.PerformLayout();
            this.ServerTab.ResumeLayout(false);
            this.ServerTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ServerPlayerCountNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerBotCountNum)).EndInit();
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
        private System.Windows.Forms.NumericUpDown BGBotCountNum;
        private System.Windows.Forms.Label BGBotCountLable;
        private System.Windows.Forms.Button BGLaunchButton;
        private System.Windows.Forms.Label BGMapLable;
        private System.Windows.Forms.Label BGGamemodeLabel;
        private System.Windows.Forms.ComboBox BGMapsCombo;
        private System.Windows.Forms.ComboBox BGGamemodesCombo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ClientCustomURLTextBox;
        private System.Windows.Forms.CheckBox ClientCustomURLCheckBox;
        private System.Windows.Forms.Label ClientLaunchOptionsLable;
        private System.Windows.Forms.Label ClientPlayerNameLabel;
        private System.Windows.Forms.Label ClientServerAddressLable;
        private System.Windows.Forms.Button ClientLaunchButton;
        private System.Windows.Forms.TextBox ClientLaunchOptionsTextBox;
        private System.Windows.Forms.TextBox ClientPlayerNameTextBox;
        private System.Windows.Forms.TextBox ClientServerAddressTextBox;
        private System.Windows.Forms.NumericUpDown ServerPlayerCountNum;
        private System.Windows.Forms.Label ServerMaxPlayersLabel;
        private System.Windows.Forms.CheckBox ServerCustomURLCheckbox;
        private System.Windows.Forms.TextBox ServerCustomURLTextBox;
        private System.Windows.Forms.Label ServerLaunchOptionsLabel;
        private System.Windows.Forms.Label ServerBotCountLabel;
        private System.Windows.Forms.Label ServerMapLabel;
        private System.Windows.Forms.Label ServerGamemodeLabel;
        private System.Windows.Forms.TextBox ServerLaunchOptionsTextBox;
        private System.Windows.Forms.Button ServerLaunchButton;
        private System.Windows.Forms.NumericUpDown ServerBotCountNum;
        private System.Windows.Forms.ComboBox ServerMapsCombo;
        private System.Windows.Forms.ComboBox ServerGamemodesCombo;
        private System.Windows.Forms.Label ClientHostServersLable;
        private System.Windows.Forms.ComboBox ClientHostServersComboBox;
        private System.Windows.Forms.Button ClientHostServersResetButton;
        private System.Windows.Forms.Button ClientServerAddressSaveButton;
        private System.Windows.Forms.Button ClientHostServersRestoreButton;
        private System.Windows.Forms.Button ClientHostServersBackupButton;
        private System.Windows.Forms.CheckBox ClientLocalConnectCheckBox;
    }
}