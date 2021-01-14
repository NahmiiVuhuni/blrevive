
namespace BLRevive.Launcher
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LauncherUI));
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
            this.ClientTabServerListView = new System.Windows.Forms.ListView();
            this.serverIPColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.serverPortColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.serverNameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.serverMaxPlayersColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.serverNumBotsColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ClientTabServerPortNum = new System.Windows.Forms.NumericUpDown();
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
            this.ServerTabPlaylistLabel = new System.Windows.Forms.Label();
            this.ServerTabPlaylistsCombo = new System.Windows.Forms.ComboBox();
            this.ServerTabNameLabel = new System.Windows.Forms.Label();
            this.ServerTabNameTextBox = new System.Windows.Forms.TextBox();
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
            this.PatchTab = new System.Windows.Forms.TabPage();
            this.PatchTabGameFileOutputLabel = new System.Windows.Forms.Label();
            this.PatchTabGameFileInputLabel = new System.Windows.Forms.Label();
            this.PatchTabOpenGameOutputDialogButton = new System.Windows.Forms.Button();
            this.PatchTabGameFileOutputTextBox = new System.Windows.Forms.TextBox();
            this.PatchTabNoProxyInjectionCheckBox = new System.Windows.Forms.CheckBox();
            this.PatchTabNoEmblemPatchCheckBox = new System.Windows.Forms.CheckBox();
            this.PatchTabASLROnlyCheckBox = new System.Windows.Forms.CheckBox();
            this.PatchTabOpenGameInputDialogButton = new System.Windows.Forms.Button();
            this.PatchTabPatchFileButton = new System.Windows.Forms.Button();
            this.PatchTabGameFileInputTextBox = new System.Windows.Forms.TextBox();
            this.SettingsTab = new System.Windows.Forms.TabPage();
            this.SettingsTabBlacklightDirectoryBrowseButton = new System.Windows.Forms.Button();
            this.SettingsTabBlacklightDirectoryTextBox = new System.Windows.Forms.TextBox();
            this.SettingsTabGameFileLabel = new System.Windows.Forms.Label();
            this.ClientTabManageServersButton = new System.Windows.Forms.Button();
            this.ClientTabDirectIPCheckBox = new System.Windows.Forms.CheckBox();
            this.ServerTabRegisterCheckBox = new System.Windows.Forms.CheckBox();
            this.ServerTabManageServersButton = new System.Windows.Forms.Button();
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
            this.PatchTab.SuspendLayout();
            this.SettingsTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // LauncherTabControl
            // 
            this.LauncherTabControl.Controls.Add(this.BotMatchTab);
            this.LauncherTabControl.Controls.Add(this.ClientTab);
            this.LauncherTabControl.Controls.Add(this.ServerTab);
            this.LauncherTabControl.Controls.Add(this.MasterServerTab);
            this.LauncherTabControl.Controls.Add(this.PatchTab);
            this.LauncherTabControl.Controls.Add(this.SettingsTab);
            this.LauncherTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LauncherTabControl.Location = new System.Drawing.Point(0, 0);
            this.LauncherTabControl.Name = "LauncherTabControl";
            this.LauncherTabControl.SelectedIndex = 0;
            this.LauncherTabControl.Size = new System.Drawing.Size(704, 441);
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
            this.BotMatchTab.Size = new System.Drawing.Size(696, 415);
            this.BotMatchTab.TabIndex = 0;
            this.BotMatchTab.Text = "Bot Match";
            this.BotMatchTab.UseVisualStyleBackColor = true;
            // 
            // BGTabBotCountNum
            // 
            this.BGTabBotCountNum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BGTabBotCountNum.Location = new System.Drawing.Point(427, 193);
            this.BGTabBotCountNum.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.BGTabBotCountNum.Name = "BGTabBotCountNum";
            this.BGTabBotCountNum.Size = new System.Drawing.Size(150, 20);
            this.BGTabBotCountNum.TabIndex = 17;
            // 
            // BGTabBotCountLable
            // 
            this.BGTabBotCountLable.AutoSize = true;
            this.BGTabBotCountLable.Location = new System.Drawing.Point(143, 195);
            this.BGTabBotCountLable.Name = "BGTabBotCountLable";
            this.BGTabBotCountLable.Size = new System.Drawing.Size(54, 13);
            this.BGTabBotCountLable.TabIndex = 16;
            this.BGTabBotCountLable.Text = "Bot Count";
            // 
            // BGTabLaunchButton
            // 
            this.BGTabLaunchButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BGTabLaunchButton.Location = new System.Drawing.Point(270, 320);
            this.BGTabLaunchButton.Name = "BGTabLaunchButton";
            this.BGTabLaunchButton.Size = new System.Drawing.Size(155, 25);
            this.BGTabLaunchButton.TabIndex = 15;
            this.BGTabLaunchButton.Text = "Launch";
            this.BGTabLaunchButton.UseVisualStyleBackColor = true;
            this.BGTabLaunchButton.Click += new System.EventHandler(this.BGTabLaunchButton_Click);
            // 
            // BGTabMapLable
            // 
            this.BGTabMapLable.AutoSize = true;
            this.BGTabMapLable.Location = new System.Drawing.Point(143, 169);
            this.BGTabMapLable.Name = "BGTabMapLable";
            this.BGTabMapLable.Size = new System.Drawing.Size(28, 13);
            this.BGTabMapLable.TabIndex = 14;
            this.BGTabMapLable.Text = "Map";
            // 
            // BGTabGamemodeLabel
            // 
            this.BGTabGamemodeLabel.AutoSize = true;
            this.BGTabGamemodeLabel.Location = new System.Drawing.Point(143, 142);
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
            this.BGTabMapsCombo.Location = new System.Drawing.Point(427, 166);
            this.BGTabMapsCombo.Name = "BGTabMapsCombo";
            this.BGTabMapsCombo.Size = new System.Drawing.Size(150, 21);
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
            this.BGTabGamemodesCombo.Location = new System.Drawing.Point(427, 139);
            this.BGTabGamemodesCombo.Name = "BGTabGamemodesCombo";
            this.BGTabGamemodesCombo.Size = new System.Drawing.Size(150, 21);
            this.BGTabGamemodesCombo.TabIndex = 11;
            // 
            // ClientTab
            // 
            this.ClientTab.Controls.Add(this.ClientTabDirectIPCheckBox);
            this.ClientTab.Controls.Add(this.ClientTabManageServersButton);
            this.ClientTab.Controls.Add(this.ClientTabServerListView);
            this.ClientTab.Controls.Add(this.ClientTabServerPortNum);
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
            this.ClientTab.Size = new System.Drawing.Size(696, 415);
            this.ClientTab.TabIndex = 1;
            this.ClientTab.Text = "Client";
            this.ClientTab.UseVisualStyleBackColor = true;
            // 
            // ClientTabServerListView
            // 
            this.ClientTabServerListView.AllowColumnReorder = true;
            this.ClientTabServerListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.serverIPColumnHeader,
            this.serverPortColumnHeader,
            this.serverNameColumnHeader,
            this.serverMaxPlayersColumnHeader,
            this.serverNumBotsColumnHeader});
            this.ClientTabServerListView.FullRowSelect = true;
            this.ClientTabServerListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.ClientTabServerListView.HideSelection = false;
            this.ClientTabServerListView.LabelWrap = false;
            this.ClientTabServerListView.Location = new System.Drawing.Point(97, 44);
            this.ClientTabServerListView.MultiSelect = false;
            this.ClientTabServerListView.Name = "ClientTabServerListView";
            this.ClientTabServerListView.Size = new System.Drawing.Size(510, 126);
            this.ClientTabServerListView.TabIndex = 29;
            this.ClientTabServerListView.TileSize = new System.Drawing.Size(168, 30);
            this.ClientTabServerListView.UseCompatibleStateImageBehavior = false;
            this.ClientTabServerListView.View = System.Windows.Forms.View.Details;
            this.ClientTabServerListView.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.ClientTabServerListView_ColumnWidthChanging);
            this.ClientTabServerListView.SelectedIndexChanged += new System.EventHandler(this.ClientTabServerListView_SelectedIndexChanged);
            // 
            // serverIPColumnHeader
            // 
            this.serverIPColumnHeader.DisplayIndex = 1;
            this.serverIPColumnHeader.Text = "IP";
            this.serverIPColumnHeader.Width = 138;
            // 
            // serverPortColumnHeader
            // 
            this.serverPortColumnHeader.DisplayIndex = 2;
            this.serverPortColumnHeader.Text = "Port";
            this.serverPortColumnHeader.Width = 44;
            // 
            // serverNameColumnHeader
            // 
            this.serverNameColumnHeader.DisplayIndex = 0;
            this.serverNameColumnHeader.Text = "Server Name";
            this.serverNameColumnHeader.Width = 192;
            // 
            // serverMaxPlayersColumnHeader
            // 
            this.serverMaxPlayersColumnHeader.Tag = "";
            this.serverMaxPlayersColumnHeader.Text = "Max Players";
            this.serverMaxPlayersColumnHeader.Width = 73;
            // 
            // serverNumBotsColumnHeader
            // 
            this.serverNumBotsColumnHeader.Text = "Bots";
            this.serverNumBotsColumnHeader.Width = 42;
            // 
            // ClientTabServerPortNum
            // 
            this.ClientTabServerPortNum.Location = new System.Drawing.Point(451, 177);
            this.ClientTabServerPortNum.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.ClientTabServerPortNum.Name = "ClientTabServerPortNum";
            this.ClientTabServerPortNum.Size = new System.Drawing.Size(99, 20);
            this.ClientTabServerPortNum.TabIndex = 28;
            this.ClientTabServerPortNum.Value = new decimal(new int[] {
            7777,
            0,
            0,
            0});
            // 
            // ClientTabCustomURLTextBox
            // 
            this.ClientTabCustomURLTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ClientTabCustomURLTextBox.Enabled = false;
            this.ClientTabCustomURLTextBox.Location = new System.Drawing.Point(300, 260);
            this.ClientTabCustomURLTextBox.Name = "ClientTabCustomURLTextBox";
            this.ClientTabCustomURLTextBox.Size = new System.Drawing.Size(250, 20);
            this.ClientTabCustomURLTextBox.TabIndex = 21;
            // 
            // ClientTabCustomURLCheckBox
            // 
            this.ClientTabCustomURLCheckBox.AutoSize = true;
            this.ClientTabCustomURLCheckBox.Location = new System.Drawing.Point(146, 262);
            this.ClientTabCustomURLCheckBox.Name = "ClientTabCustomURLCheckBox";
            this.ClientTabCustomURLCheckBox.Size = new System.Drawing.Size(86, 17);
            this.ClientTabCustomURLCheckBox.TabIndex = 20;
            this.ClientTabCustomURLCheckBox.Text = "Custom URL";
            this.ClientTabCustomURLCheckBox.UseVisualStyleBackColor = true;
            this.ClientTabCustomURLCheckBox.CheckedChanged += new System.EventHandler(this.ClientTabCustomURLCheckBox_CheckedChanged);
            // 
            // ClientTabLaunchOptionsLable
            // 
            this.ClientTabLaunchOptionsLable.AutoSize = true;
            this.ClientTabLaunchOptionsLable.Location = new System.Drawing.Point(143, 237);
            this.ClientTabLaunchOptionsLable.Name = "ClientTabLaunchOptionsLable";
            this.ClientTabLaunchOptionsLable.Size = new System.Drawing.Size(109, 13);
            this.ClientTabLaunchOptionsLable.TabIndex = 19;
            this.ClientTabLaunchOptionsLable.Text = "Additional Parameters";
            // 
            // ClientTabPlayerNameLabel
            // 
            this.ClientTabPlayerNameLabel.AutoSize = true;
            this.ClientTabPlayerNameLabel.Location = new System.Drawing.Point(143, 206);
            this.ClientTabPlayerNameLabel.Name = "ClientTabPlayerNameLabel";
            this.ClientTabPlayerNameLabel.Size = new System.Drawing.Size(67, 13);
            this.ClientTabPlayerNameLabel.TabIndex = 18;
            this.ClientTabPlayerNameLabel.Text = "Player Name";
            // 
            // ClientTabServerAddressLable
            // 
            this.ClientTabServerAddressLable.AutoSize = true;
            this.ClientTabServerAddressLable.Location = new System.Drawing.Point(143, 179);
            this.ClientTabServerAddressLable.Name = "ClientTabServerAddressLable";
            this.ClientTabServerAddressLable.Size = new System.Drawing.Size(103, 13);
            this.ClientTabServerAddressLable.TabIndex = 17;
            this.ClientTabServerAddressLable.Text = "Server Address/Port";
            // 
            // ClientTabLaunchButton
            // 
            this.ClientTabLaunchButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ClientTabLaunchButton.Location = new System.Drawing.Point(270, 320);
            this.ClientTabLaunchButton.Name = "ClientTabLaunchButton";
            this.ClientTabLaunchButton.Size = new System.Drawing.Size(155, 25);
            this.ClientTabLaunchButton.TabIndex = 16;
            this.ClientTabLaunchButton.Text = "Launch";
            this.ClientTabLaunchButton.UseVisualStyleBackColor = true;
            this.ClientTabLaunchButton.Click += new System.EventHandler(this.ClientTabLaunchButton_Click);
            // 
            // ClientTabLaunchOptionsTextBox
            // 
            this.ClientTabLaunchOptionsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ClientTabLaunchOptionsTextBox.Location = new System.Drawing.Point(300, 234);
            this.ClientTabLaunchOptionsTextBox.Name = "ClientTabLaunchOptionsTextBox";
            this.ClientTabLaunchOptionsTextBox.Size = new System.Drawing.Size(250, 20);
            this.ClientTabLaunchOptionsTextBox.TabIndex = 15;
            // 
            // ClientTabPlayerNameTextBox
            // 
            this.ClientTabPlayerNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ClientTabPlayerNameTextBox.Location = new System.Drawing.Point(300, 203);
            this.ClientTabPlayerNameTextBox.MaxLength = 20;
            this.ClientTabPlayerNameTextBox.Name = "ClientTabPlayerNameTextBox";
            this.ClientTabPlayerNameTextBox.Size = new System.Drawing.Size(145, 20);
            this.ClientTabPlayerNameTextBox.TabIndex = 14;
            this.ClientTabPlayerNameTextBox.Text = "Player";
            // 
            // ClientTabServerAddressTextBox
            // 
            this.ClientTabServerAddressTextBox.Location = new System.Drawing.Point(300, 176);
            this.ClientTabServerAddressTextBox.Name = "ClientTabServerAddressTextBox";
            this.ClientTabServerAddressTextBox.Size = new System.Drawing.Size(145, 20);
            this.ClientTabServerAddressTextBox.TabIndex = 13;
            this.ClientTabServerAddressTextBox.Text = "127.0.0.1";
            // 
            // ServerTab
            // 
            this.ServerTab.Controls.Add(this.ServerTabManageServersButton);
            this.ServerTab.Controls.Add(this.ServerTabRegisterCheckBox);
            this.ServerTab.Controls.Add(this.ServerTabPlaylistLabel);
            this.ServerTab.Controls.Add(this.ServerTabPlaylistsCombo);
            this.ServerTab.Controls.Add(this.ServerTabNameLabel);
            this.ServerTab.Controls.Add(this.ServerTabNameTextBox);
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
            this.ServerTab.Size = new System.Drawing.Size(696, 415);
            this.ServerTab.TabIndex = 2;
            this.ServerTab.Text = "Server";
            this.ServerTab.UseVisualStyleBackColor = true;
            // 
            // ServerTabPlaylistLabel
            // 
            this.ServerTabPlaylistLabel.AutoSize = true;
            this.ServerTabPlaylistLabel.Location = new System.Drawing.Point(143, 48);
            this.ServerTabPlaylistLabel.Name = "ServerTabPlaylistLabel";
            this.ServerTabPlaylistLabel.Size = new System.Drawing.Size(39, 13);
            this.ServerTabPlaylistLabel.TabIndex = 34;
            this.ServerTabPlaylistLabel.Text = "Playlist";
            // 
            // ServerTabPlaylistsCombo
            // 
            this.ServerTabPlaylistsCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ServerTabPlaylistsCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ServerTabPlaylistsCombo.FormattingEnabled = true;
            this.ServerTabPlaylistsCombo.Location = new System.Drawing.Point(402, 45);
            this.ServerTabPlaylistsCombo.Name = "ServerTabPlaylistsCombo";
            this.ServerTabPlaylistsCombo.Size = new System.Drawing.Size(148, 21);
            this.ServerTabPlaylistsCombo.TabIndex = 33;
            this.ServerTabPlaylistsCombo.SelectedIndexChanged += new System.EventHandler(this.ServerTabPlaylistsCombo_SelectedIndexChanged);
            // 
            // ServerTabNameLabel
            // 
            this.ServerTabNameLabel.AutoSize = true;
            this.ServerTabNameLabel.Location = new System.Drawing.Point(143, 130);
            this.ServerTabNameLabel.Name = "ServerTabNameLabel";
            this.ServerTabNameLabel.Size = new System.Drawing.Size(69, 13);
            this.ServerTabNameLabel.TabIndex = 32;
            this.ServerTabNameLabel.Text = "Server Name";
            // 
            // ServerTabNameTextBox
            // 
            this.ServerTabNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ServerTabNameTextBox.Location = new System.Drawing.Point(298, 127);
            this.ServerTabNameTextBox.MaxLength = 30;
            this.ServerTabNameTextBox.Name = "ServerTabNameTextBox";
            this.ServerTabNameTextBox.Size = new System.Drawing.Size(251, 20);
            this.ServerTabNameTextBox.TabIndex = 31;
            this.ServerTabNameTextBox.Text = "BLRevive Server";
            // 
            // ServerTabPortLable
            // 
            this.ServerTabPortLable.AutoSize = true;
            this.ServerTabPortLable.Location = new System.Drawing.Point(143, 206);
            this.ServerTabPortLable.Name = "ServerTabPortLable";
            this.ServerTabPortLable.Size = new System.Drawing.Size(26, 13);
            this.ServerTabPortLable.TabIndex = 30;
            this.ServerTabPortLable.Text = "Port";
            // 
            // ServerTabPortNum
            // 
            this.ServerTabPortNum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ServerTabPortNum.Location = new System.Drawing.Point(402, 204);
            this.ServerTabPortNum.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.ServerTabPortNum.Name = "ServerTabPortNum";
            this.ServerTabPortNum.Size = new System.Drawing.Size(148, 20);
            this.ServerTabPortNum.TabIndex = 29;
            this.ServerTabPortNum.Value = new decimal(new int[] {
            7777,
            0,
            0,
            0});
            // 
            // ServerTabPlayerCountNum
            // 
            this.ServerTabPlayerCountNum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ServerTabPlayerCountNum.Location = new System.Drawing.Point(402, 152);
            this.ServerTabPlayerCountNum.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.ServerTabPlayerCountNum.Name = "ServerTabPlayerCountNum";
            this.ServerTabPlayerCountNum.Size = new System.Drawing.Size(148, 20);
            this.ServerTabPlayerCountNum.TabIndex = 26;
            // 
            // ServerTabMaxPlayersLabel
            // 
            this.ServerTabMaxPlayersLabel.AutoSize = true;
            this.ServerTabMaxPlayersLabel.Location = new System.Drawing.Point(143, 154);
            this.ServerTabMaxPlayersLabel.Name = "ServerTabMaxPlayersLabel";
            this.ServerTabMaxPlayersLabel.Size = new System.Drawing.Size(64, 13);
            this.ServerTabMaxPlayersLabel.TabIndex = 25;
            this.ServerTabMaxPlayersLabel.Text = "Max Players";
            // 
            // ServerTabCustomURLCheckbox
            // 
            this.ServerTabCustomURLCheckbox.AutoSize = true;
            this.ServerTabCustomURLCheckbox.Location = new System.Drawing.Point(146, 288);
            this.ServerTabCustomURLCheckbox.Name = "ServerTabCustomURLCheckbox";
            this.ServerTabCustomURLCheckbox.Size = new System.Drawing.Size(86, 17);
            this.ServerTabCustomURLCheckbox.TabIndex = 24;
            this.ServerTabCustomURLCheckbox.Text = "Custom URL";
            this.ServerTabCustomURLCheckbox.UseVisualStyleBackColor = true;
            this.ServerTabCustomURLCheckbox.CheckedChanged += new System.EventHandler(this.ServerTabCustomURLCheckbox_CheckedChanged);
            // 
            // ServerTabCustomURLTextBox
            // 
            this.ServerTabCustomURLTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ServerTabCustomURLTextBox.Enabled = false;
            this.ServerTabCustomURLTextBox.Location = new System.Drawing.Point(300, 286);
            this.ServerTabCustomURLTextBox.Name = "ServerTabCustomURLTextBox";
            this.ServerTabCustomURLTextBox.Size = new System.Drawing.Size(250, 20);
            this.ServerTabCustomURLTextBox.TabIndex = 23;
            // 
            // ServerTabLaunchOptionsLabel
            // 
            this.ServerTabLaunchOptionsLabel.AutoSize = true;
            this.ServerTabLaunchOptionsLabel.Location = new System.Drawing.Point(143, 263);
            this.ServerTabLaunchOptionsLabel.Name = "ServerTabLaunchOptionsLabel";
            this.ServerTabLaunchOptionsLabel.Size = new System.Drawing.Size(109, 13);
            this.ServerTabLaunchOptionsLabel.TabIndex = 22;
            this.ServerTabLaunchOptionsLabel.Text = "Additional Parameters";
            // 
            // ServerTabBotCountLabel
            // 
            this.ServerTabBotCountLabel.AutoSize = true;
            this.ServerTabBotCountLabel.Location = new System.Drawing.Point(143, 180);
            this.ServerTabBotCountLabel.Name = "ServerTabBotCountLabel";
            this.ServerTabBotCountLabel.Size = new System.Drawing.Size(54, 13);
            this.ServerTabBotCountLabel.TabIndex = 21;
            this.ServerTabBotCountLabel.Text = "Bot Count";
            // 
            // ServerTabMapLabel
            // 
            this.ServerTabMapLabel.AutoSize = true;
            this.ServerTabMapLabel.Location = new System.Drawing.Point(143, 103);
            this.ServerTabMapLabel.Name = "ServerTabMapLabel";
            this.ServerTabMapLabel.Size = new System.Drawing.Size(28, 13);
            this.ServerTabMapLabel.TabIndex = 20;
            this.ServerTabMapLabel.Text = "Map";
            // 
            // ServerTabGamemodeLabel
            // 
            this.ServerTabGamemodeLabel.AutoSize = true;
            this.ServerTabGamemodeLabel.Location = new System.Drawing.Point(143, 76);
            this.ServerTabGamemodeLabel.Name = "ServerTabGamemodeLabel";
            this.ServerTabGamemodeLabel.Size = new System.Drawing.Size(61, 13);
            this.ServerTabGamemodeLabel.TabIndex = 19;
            this.ServerTabGamemodeLabel.Text = "Gamemode";
            // 
            // ServerTabLaunchOptionsTextBox
            // 
            this.ServerTabLaunchOptionsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ServerTabLaunchOptionsTextBox.Location = new System.Drawing.Point(300, 260);
            this.ServerTabLaunchOptionsTextBox.Name = "ServerTabLaunchOptionsTextBox";
            this.ServerTabLaunchOptionsTextBox.Size = new System.Drawing.Size(250, 20);
            this.ServerTabLaunchOptionsTextBox.TabIndex = 18;
            // 
            // ServerTabLaunchButton
            // 
            this.ServerTabLaunchButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ServerTabLaunchButton.Location = new System.Drawing.Point(268, 348);
            this.ServerTabLaunchButton.Name = "ServerTabLaunchButton";
            this.ServerTabLaunchButton.Size = new System.Drawing.Size(155, 25);
            this.ServerTabLaunchButton.TabIndex = 17;
            this.ServerTabLaunchButton.Text = "Launch";
            this.ServerTabLaunchButton.UseVisualStyleBackColor = true;
            this.ServerTabLaunchButton.Click += new System.EventHandler(this.ServerTabLaunchButton_Click);
            // 
            // ServerTabBotCountNum
            // 
            this.ServerTabBotCountNum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ServerTabBotCountNum.Location = new System.Drawing.Point(402, 178);
            this.ServerTabBotCountNum.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.ServerTabBotCountNum.Name = "ServerTabBotCountNum";
            this.ServerTabBotCountNum.Size = new System.Drawing.Size(148, 20);
            this.ServerTabBotCountNum.TabIndex = 16;
            // 
            // ServerTabMapsCombo
            // 
            this.ServerTabMapsCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ServerTabMapsCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ServerTabMapsCombo.FormattingEnabled = true;
            this.ServerTabMapsCombo.Location = new System.Drawing.Point(402, 100);
            this.ServerTabMapsCombo.Name = "ServerTabMapsCombo";
            this.ServerTabMapsCombo.Size = new System.Drawing.Size(148, 21);
            this.ServerTabMapsCombo.TabIndex = 15;
            // 
            // ServerTabGamemodesCombo
            // 
            this.ServerTabGamemodesCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ServerTabGamemodesCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ServerTabGamemodesCombo.FormattingEnabled = true;
            this.ServerTabGamemodesCombo.Location = new System.Drawing.Point(402, 72);
            this.ServerTabGamemodesCombo.Name = "ServerTabGamemodesCombo";
            this.ServerTabGamemodesCombo.Size = new System.Drawing.Size(148, 21);
            this.ServerTabGamemodesCombo.TabIndex = 14;
            // 
            // MasterServerTab
            // 
            this.MasterServerTab.Controls.Add(this.MSTabNotImplementedLable);
            this.MasterServerTab.Location = new System.Drawing.Point(4, 22);
            this.MasterServerTab.Name = "MasterServerTab";
            this.MasterServerTab.Size = new System.Drawing.Size(696, 415);
            this.MasterServerTab.TabIndex = 3;
            this.MasterServerTab.Text = "Master Server";
            this.MasterServerTab.UseVisualStyleBackColor = true;
            // 
            // MSTabNotImplementedLable
            // 
            this.MSTabNotImplementedLable.AutoSize = true;
            this.MSTabNotImplementedLable.Location = new System.Drawing.Point(300, 200);
            this.MSTabNotImplementedLable.Name = "MSTabNotImplementedLable";
            this.MSTabNotImplementedLable.Size = new System.Drawing.Size(89, 13);
            this.MSTabNotImplementedLable.TabIndex = 0;
            this.MSTabNotImplementedLable.Text = "Not implemented!";
            // 
            // PatchTab
            // 
            this.PatchTab.Controls.Add(this.PatchTabGameFileOutputLabel);
            this.PatchTab.Controls.Add(this.PatchTabGameFileInputLabel);
            this.PatchTab.Controls.Add(this.PatchTabOpenGameOutputDialogButton);
            this.PatchTab.Controls.Add(this.PatchTabGameFileOutputTextBox);
            this.PatchTab.Controls.Add(this.PatchTabNoProxyInjectionCheckBox);
            this.PatchTab.Controls.Add(this.PatchTabNoEmblemPatchCheckBox);
            this.PatchTab.Controls.Add(this.PatchTabASLROnlyCheckBox);
            this.PatchTab.Controls.Add(this.PatchTabOpenGameInputDialogButton);
            this.PatchTab.Controls.Add(this.PatchTabPatchFileButton);
            this.PatchTab.Controls.Add(this.PatchTabGameFileInputTextBox);
            this.PatchTab.Location = new System.Drawing.Point(4, 22);
            this.PatchTab.Name = "PatchTab";
            this.PatchTab.Size = new System.Drawing.Size(696, 415);
            this.PatchTab.TabIndex = 4;
            this.PatchTab.Text = "Patcher";
            this.PatchTab.UseVisualStyleBackColor = true;
            // 
            // PatchTabGameFileOutputLabel
            // 
            this.PatchTabGameFileOutputLabel.AutoSize = true;
            this.PatchTabGameFileOutputLabel.Location = new System.Drawing.Point(65, 121);
            this.PatchTabGameFileOutputLabel.Name = "PatchTabGameFileOutputLabel";
            this.PatchTabGameFileOutputLabel.Size = new System.Drawing.Size(42, 13);
            this.PatchTabGameFileOutputLabel.TabIndex = 10;
            this.PatchTabGameFileOutputLabel.Text = "Output:";
            // 
            // PatchTabGameFileInputLabel
            // 
            this.PatchTabGameFileInputLabel.AutoSize = true;
            this.PatchTabGameFileInputLabel.Location = new System.Drawing.Point(65, 95);
            this.PatchTabGameFileInputLabel.Name = "PatchTabGameFileInputLabel";
            this.PatchTabGameFileInputLabel.Size = new System.Drawing.Size(34, 13);
            this.PatchTabGameFileInputLabel.TabIndex = 9;
            this.PatchTabGameFileInputLabel.Text = "Input:";
            // 
            // PatchTabOpenGameOutputDialogButton
            // 
            this.PatchTabOpenGameOutputDialogButton.Location = new System.Drawing.Point(553, 118);
            this.PatchTabOpenGameOutputDialogButton.Name = "PatchTabOpenGameOutputDialogButton";
            this.PatchTabOpenGameOutputDialogButton.Size = new System.Drawing.Size(75, 22);
            this.PatchTabOpenGameOutputDialogButton.TabIndex = 8;
            this.PatchTabOpenGameOutputDialogButton.Text = "Browse";
            this.PatchTabOpenGameOutputDialogButton.UseVisualStyleBackColor = true;
            this.PatchTabOpenGameOutputDialogButton.Click += new System.EventHandler(this.PatchTabOpenGameOutputDialogButton_Click);
            // 
            // PatchTabGameFileOutputTextBox
            // 
            this.PatchTabGameFileOutputTextBox.Location = new System.Drawing.Point(110, 118);
            this.PatchTabGameFileOutputTextBox.Name = "PatchTabGameFileOutputTextBox";
            this.PatchTabGameFileOutputTextBox.Size = new System.Drawing.Size(437, 20);
            this.PatchTabGameFileOutputTextBox.TabIndex = 7;
            // 
            // PatchTabNoProxyInjectionCheckBox
            // 
            this.PatchTabNoProxyInjectionCheckBox.AutoSize = true;
            this.PatchTabNoProxyInjectionCheckBox.Location = new System.Drawing.Point(282, 235);
            this.PatchTabNoProxyInjectionCheckBox.Name = "PatchTabNoProxyInjectionCheckBox";
            this.PatchTabNoProxyInjectionCheckBox.Size = new System.Drawing.Size(112, 17);
            this.PatchTabNoProxyInjectionCheckBox.TabIndex = 6;
            this.PatchTabNoProxyInjectionCheckBox.Text = "No Proxy Injection";
            this.PatchTabNoProxyInjectionCheckBox.UseVisualStyleBackColor = true;
            // 
            // PatchTabNoEmblemPatchCheckBox
            // 
            this.PatchTabNoEmblemPatchCheckBox.AutoSize = true;
            this.PatchTabNoEmblemPatchCheckBox.Location = new System.Drawing.Point(282, 189);
            this.PatchTabNoEmblemPatchCheckBox.Name = "PatchTabNoEmblemPatchCheckBox";
            this.PatchTabNoEmblemPatchCheckBox.Size = new System.Drawing.Size(111, 17);
            this.PatchTabNoEmblemPatchCheckBox.TabIndex = 5;
            this.PatchTabNoEmblemPatchCheckBox.Text = "No Emblem Patch";
            this.PatchTabNoEmblemPatchCheckBox.UseVisualStyleBackColor = true;
            // 
            // PatchTabASLROnlyCheckBox
            // 
            this.PatchTabASLROnlyCheckBox.AutoSize = true;
            this.PatchTabASLROnlyCheckBox.Location = new System.Drawing.Point(282, 212);
            this.PatchTabASLROnlyCheckBox.Name = "PatchTabASLROnlyCheckBox";
            this.PatchTabASLROnlyCheckBox.Size = new System.Drawing.Size(76, 17);
            this.PatchTabASLROnlyCheckBox.TabIndex = 4;
            this.PatchTabASLROnlyCheckBox.Text = "ASLR only";
            this.PatchTabASLROnlyCheckBox.UseVisualStyleBackColor = true;
            this.PatchTabASLROnlyCheckBox.CheckedChanged += new System.EventHandler(this.PatchTabASLROnlyCheckBox_CheckedChanged);
            // 
            // PatchTabOpenGameInputDialogButton
            // 
            this.PatchTabOpenGameInputDialogButton.Location = new System.Drawing.Point(553, 90);
            this.PatchTabOpenGameInputDialogButton.Name = "PatchTabOpenGameInputDialogButton";
            this.PatchTabOpenGameInputDialogButton.Size = new System.Drawing.Size(75, 22);
            this.PatchTabOpenGameInputDialogButton.TabIndex = 3;
            this.PatchTabOpenGameInputDialogButton.Text = "Browse";
            this.PatchTabOpenGameInputDialogButton.UseVisualStyleBackColor = true;
            this.PatchTabOpenGameInputDialogButton.Click += new System.EventHandler(this.PatchTabOpenGameFileDialogButton_Click);
            // 
            // PatchTabPatchFileButton
            // 
            this.PatchTabPatchFileButton.Location = new System.Drawing.Point(270, 320);
            this.PatchTabPatchFileButton.Name = "PatchTabPatchFileButton";
            this.PatchTabPatchFileButton.Size = new System.Drawing.Size(155, 25);
            this.PatchTabPatchFileButton.TabIndex = 1;
            this.PatchTabPatchFileButton.Text = "Patch File";
            this.PatchTabPatchFileButton.UseVisualStyleBackColor = true;
            this.PatchTabPatchFileButton.Click += new System.EventHandler(this.PatchTabPatchFileButton_Click);
            // 
            // PatchTabGameFileInputTextBox
            // 
            this.PatchTabGameFileInputTextBox.Location = new System.Drawing.Point(110, 92);
            this.PatchTabGameFileInputTextBox.Name = "PatchTabGameFileInputTextBox";
            this.PatchTabGameFileInputTextBox.Size = new System.Drawing.Size(437, 20);
            this.PatchTabGameFileInputTextBox.TabIndex = 0;
            // 
            // SettingsTab
            // 
            this.SettingsTab.Controls.Add(this.SettingsTabBlacklightDirectoryBrowseButton);
            this.SettingsTab.Controls.Add(this.SettingsTabBlacklightDirectoryTextBox);
            this.SettingsTab.Controls.Add(this.SettingsTabGameFileLabel);
            this.SettingsTab.Location = new System.Drawing.Point(4, 22);
            this.SettingsTab.Name = "SettingsTab";
            this.SettingsTab.Size = new System.Drawing.Size(696, 415);
            this.SettingsTab.TabIndex = 5;
            this.SettingsTab.Text = "Settings";
            this.SettingsTab.UseVisualStyleBackColor = true;
            // 
            // SettingsTabBlacklightDirectoryBrowseButton
            // 
            this.SettingsTabBlacklightDirectoryBrowseButton.Location = new System.Drawing.Point(543, 183);
            this.SettingsTabBlacklightDirectoryBrowseButton.Name = "SettingsTabBlacklightDirectoryBrowseButton";
            this.SettingsTabBlacklightDirectoryBrowseButton.Size = new System.Drawing.Size(75, 22);
            this.SettingsTabBlacklightDirectoryBrowseButton.TabIndex = 2;
            this.SettingsTabBlacklightDirectoryBrowseButton.Text = "Browse";
            this.SettingsTabBlacklightDirectoryBrowseButton.UseVisualStyleBackColor = true;
            this.SettingsTabBlacklightDirectoryBrowseButton.Click += new System.EventHandler(this.SettingsTabBlacklightDirectoryBrowseButton_Click);
            // 
            // SettingsTabBlacklightDirectoryTextBox
            // 
            this.SettingsTabBlacklightDirectoryTextBox.Location = new System.Drawing.Point(72, 184);
            this.SettingsTabBlacklightDirectoryTextBox.Name = "SettingsTabBlacklightDirectoryTextBox";
            this.SettingsTabBlacklightDirectoryTextBox.Size = new System.Drawing.Size(465, 20);
            this.SettingsTabBlacklightDirectoryTextBox.TabIndex = 1;
            // 
            // SettingsTabGameFileLabel
            // 
            this.SettingsTabGameFileLabel.AutoSize = true;
            this.SettingsTabGameFileLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SettingsTabGameFileLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SettingsTabGameFileLabel.Location = new System.Drawing.Point(72, 166);
            this.SettingsTabGameFileLabel.Name = "SettingsTabGameFileLabel";
            this.SettingsTabGameFileLabel.Size = new System.Drawing.Size(103, 15);
            this.SettingsTabGameFileLabel.TabIndex = 0;
            this.SettingsTabGameFileLabel.Text = "Blacklight Directory:";
            // 
            // ClientTabManageServersButton
            // 
            this.ClientTabManageServersButton.Location = new System.Drawing.Point(451, 201);
            this.ClientTabManageServersButton.Name = "ClientTabManageServersButton";
            this.ClientTabManageServersButton.Size = new System.Drawing.Size(99, 23);
            this.ClientTabManageServersButton.TabIndex = 30;
            this.ClientTabManageServersButton.Text = "Manage Servers";
            this.ClientTabManageServersButton.UseVisualStyleBackColor = true;
            this.ClientTabManageServersButton.Click += new System.EventHandler(this.ClientTabManageServersButton_Click);
            // 
            // ClientTabDirectIPCheckBox
            // 
            this.ClientTabDirectIPCheckBox.AutoSize = true;
            this.ClientTabDirectIPCheckBox.Enabled = false;
            this.ClientTabDirectIPCheckBox.Location = new System.Drawing.Point(284, 297);
            this.ClientTabDirectIPCheckBox.Name = "ClientTabDirectIPCheckBox";
            this.ClientTabDirectIPCheckBox.Size = new System.Drawing.Size(134, 17);
            this.ClientTabDirectIPCheckBox.TabIndex = 31;
            this.ClientTabDirectIPCheckBox.Text = "Connet Using Direct IP";
            this.ClientTabDirectIPCheckBox.UseVisualStyleBackColor = true;
            // 
            // ServerTabRegisterCheckBox
            // 
            this.ServerTabRegisterCheckBox.AutoSize = true;
            this.ServerTabRegisterCheckBox.Location = new System.Drawing.Point(300, 232);
            this.ServerTabRegisterCheckBox.Name = "ServerTabRegisterCheckBox";
            this.ServerTabRegisterCheckBox.Size = new System.Drawing.Size(99, 17);
            this.ServerTabRegisterCheckBox.TabIndex = 35;
            this.ServerTabRegisterCheckBox.Text = "Register Server";
            this.ServerTabRegisterCheckBox.UseVisualStyleBackColor = true;
            // 
            // ServerTabManageServersButton
            // 
            this.ServerTabManageServersButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ServerTabManageServersButton.Location = new System.Drawing.Point(402, 227);
            this.ServerTabManageServersButton.Name = "ServerTabManageServersButton";
            this.ServerTabManageServersButton.Size = new System.Drawing.Size(150, 25);
            this.ServerTabManageServersButton.TabIndex = 36;
            this.ServerTabManageServersButton.Text = "Manage Registered Servers";
            this.ServerTabManageServersButton.UseVisualStyleBackColor = true;
            this.ServerTabManageServersButton.Click += new System.EventHandler(this.ServerTabManageServersButton_Click);
            // 
            // LauncherUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 441);
            this.Controls.Add(this.LauncherTabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
            this.PatchTab.ResumeLayout(false);
            this.PatchTab.PerformLayout();
            this.SettingsTab.ResumeLayout(false);
            this.SettingsTab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl LauncherTabControl;
        private System.Windows.Forms.TabPage BotMatchTab;
        private System.Windows.Forms.TabPage ClientTab;
        private System.Windows.Forms.TabPage ServerTab;
        private System.Windows.Forms.TabPage MasterServerTab;
        private System.Windows.Forms.Label BGTabBotCountLable;
        private System.Windows.Forms.Button BGTabLaunchButton;
        private System.Windows.Forms.Label BGTabMapLable;
        private System.Windows.Forms.Label BGTabGamemodeLabel;
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
        private System.Windows.Forms.NumericUpDown ClientTabServerPortNum;
        private System.Windows.Forms.NumericUpDown ServerTabPortNum;
        private System.Windows.Forms.Label ServerTabPortLable; 
        private System.Windows.Forms.Label ServerTabNameLabel;
        private System.Windows.Forms.TextBox ServerTabNameTextBox;
        private System.Windows.Forms.TabPage PatchTab;
        private System.Windows.Forms.Button PatchTabPatchFileButton;
        private System.Windows.Forms.TextBox PatchTabGameFileInputTextBox;
        private System.Windows.Forms.Button PatchTabOpenGameInputDialogButton;
        private System.Windows.Forms.CheckBox PatchTabNoProxyInjectionCheckBox;
        private System.Windows.Forms.CheckBox PatchTabNoEmblemPatchCheckBox;
        private System.Windows.Forms.CheckBox PatchTabASLROnlyCheckBox;
        private System.Windows.Forms.TabPage SettingsTab;
        private System.Windows.Forms.Label SettingsTabGameFileLabel;
        private System.Windows.Forms.Button SettingsTabBlacklightDirectoryBrowseButton;
        private System.Windows.Forms.TextBox SettingsTabBlacklightDirectoryTextBox;
        private System.Windows.Forms.Button PatchTabOpenGameOutputDialogButton;
        private System.Windows.Forms.TextBox PatchTabGameFileOutputTextBox;
        private System.Windows.Forms.Label PatchTabGameFileOutputLabel;
        private System.Windows.Forms.Label PatchTabGameFileInputLabel;
        private System.Windows.Forms.NumericUpDown BGTabBotCountNum;
        private System.Windows.Forms.ComboBox BGTabMapsCombo;
        private System.Windows.Forms.ComboBox BGTabGamemodesCombo;
        private System.Windows.Forms.Label ServerTabPlaylistLabel;
        private System.Windows.Forms.ComboBox ServerTabPlaylistsCombo;
        private System.Windows.Forms.ListView ClientTabServerListView;
        private System.Windows.Forms.ColumnHeader serverIPColumnHeader;
        private System.Windows.Forms.ColumnHeader serverNameColumnHeader;
        private System.Windows.Forms.ColumnHeader serverPortColumnHeader;
        private System.Windows.Forms.ColumnHeader serverMaxPlayersColumnHeader;
        private System.Windows.Forms.ColumnHeader serverNumBotsColumnHeader;
        private System.Windows.Forms.Button ClientTabManageServersButton;
        private System.Windows.Forms.CheckBox ClientTabDirectIPCheckBox;
        private System.Windows.Forms.CheckBox ServerTabRegisterCheckBox;
        private System.Windows.Forms.Button ServerTabManageServersButton;
    }
}