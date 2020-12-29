
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.BotMatchTab = new System.Windows.Forms.TabPage();
            this.BGBotCountNum = new System.Windows.Forms.NumericUpDown();
            this.BGBotCountLable = new System.Windows.Forms.Label();
            this.BGLaunchButton = new System.Windows.Forms.Button();
            this.BGMapLable = new System.Windows.Forms.Label();
            this.BGGamemodeLabel = new System.Windows.Forms.Label();
            this.BGMapsCombo = new System.Windows.Forms.ComboBox();
            this.BGGamemodesCombo = new System.Windows.Forms.ComboBox();
            this.ClientTab = new System.Windows.Forms.TabPage();
            this.ClientCustomURLTextBox = new System.Windows.Forms.TextBox();
            this.ClientCustomURLCheckBox = new System.Windows.Forms.CheckBox();
            this.ClientLaunchOptionsLable = new System.Windows.Forms.Label();
            this.ClientPlayerNameLabel = new System.Windows.Forms.Label();
            this.ClientSeverIPLable = new System.Windows.Forms.Label();
            this.ClientLaunchButton = new System.Windows.Forms.Button();
            this.ClientLaunchOptionsTextBox = new System.Windows.Forms.TextBox();
            this.ClientPlayerNameTextBox = new System.Windows.Forms.TextBox();
            this.ClientIPTextBox = new System.Windows.Forms.TextBox();
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
            this.tabControl1.SuspendLayout();
            this.BotMatchTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BGBotCountNum)).BeginInit();
            this.ClientTab.SuspendLayout();
            this.ServerTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ServerPlayerCountNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerBotCountNum)).BeginInit();
            this.MasterServerTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.BotMatchTab);
            this.tabControl1.Controls.Add(this.ClientTab);
            this.tabControl1.Controls.Add(this.ServerTab);
            this.tabControl1.Controls.Add(this.MasterServerTab);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(496, 282);
            this.tabControl1.TabIndex = 0;
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
            this.BotMatchTab.Size = new System.Drawing.Size(488, 256);
            this.BotMatchTab.TabIndex = 0;
            this.BotMatchTab.Text = "Bot Match";
            this.BotMatchTab.UseVisualStyleBackColor = true;
            // 
            // BGBotCountNum
            // 
            this.BGBotCountNum.Location = new System.Drawing.Point(302, 130);
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
            this.BGBotCountLable.Location = new System.Drawing.Point(71, 132);
            this.BGBotCountLable.Name = "BGBotCountLable";
            this.BGBotCountLable.Size = new System.Drawing.Size(54, 13);
            this.BGBotCountLable.TabIndex = 16;
            this.BGBotCountLable.Text = "Bot Count";
            // 
            // BGLaunchButton
            // 
            this.BGLaunchButton.Location = new System.Drawing.Point(210, 205);
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
            this.BGMapLable.Location = new System.Drawing.Point(71, 106);
            this.BGMapLable.Name = "BGMapLable";
            this.BGMapLable.Size = new System.Drawing.Size(28, 13);
            this.BGMapLable.TabIndex = 14;
            this.BGMapLable.Text = "Map";
            // 
            // BGGamemodeLabel
            // 
            this.BGGamemodeLabel.AutoSize = true;
            this.BGGamemodeLabel.Location = new System.Drawing.Point(71, 82);
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
            this.BGMapsCombo.Location = new System.Drawing.Point(302, 103);
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
            this.BGGamemodesCombo.Location = new System.Drawing.Point(302, 75);
            this.BGGamemodesCombo.Name = "BGGamemodesCombo";
            this.BGGamemodesCombo.Size = new System.Drawing.Size(121, 21);
            this.BGGamemodesCombo.TabIndex = 11;
            // 
            // ClientTab
            // 
            this.ClientTab.Controls.Add(this.ClientCustomURLTextBox);
            this.ClientTab.Controls.Add(this.ClientCustomURLCheckBox);
            this.ClientTab.Controls.Add(this.ClientLaunchOptionsLable);
            this.ClientTab.Controls.Add(this.ClientPlayerNameLabel);
            this.ClientTab.Controls.Add(this.ClientSeverIPLable);
            this.ClientTab.Controls.Add(this.ClientLaunchButton);
            this.ClientTab.Controls.Add(this.ClientLaunchOptionsTextBox);
            this.ClientTab.Controls.Add(this.ClientPlayerNameTextBox);
            this.ClientTab.Controls.Add(this.ClientIPTextBox);
            this.ClientTab.Location = new System.Drawing.Point(4, 22);
            this.ClientTab.Name = "ClientTab";
            this.ClientTab.Padding = new System.Windows.Forms.Padding(3);
            this.ClientTab.Size = new System.Drawing.Size(488, 256);
            this.ClientTab.TabIndex = 1;
            this.ClientTab.Text = "Client";
            this.ClientTab.UseVisualStyleBackColor = true;
            // 
            // ClientCustomURLTextBox
            // 
            this.ClientCustomURLTextBox.Enabled = false;
            this.ClientCustomURLTextBox.Location = new System.Drawing.Point(192, 147);
            this.ClientCustomURLTextBox.Name = "ClientCustomURLTextBox";
            this.ClientCustomURLTextBox.Size = new System.Drawing.Size(231, 20);
            this.ClientCustomURLTextBox.TabIndex = 21;
            // 
            // ClientCustomURLCheckBox
            // 
            this.ClientCustomURLCheckBox.AutoSize = true;
            this.ClientCustomURLCheckBox.Location = new System.Drawing.Point(74, 149);
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
            this.ClientLaunchOptionsLable.Location = new System.Drawing.Point(71, 119);
            this.ClientLaunchOptionsLable.Name = "ClientLaunchOptionsLable";
            this.ClientLaunchOptionsLable.Size = new System.Drawing.Size(109, 13);
            this.ClientLaunchOptionsLable.TabIndex = 19;
            this.ClientLaunchOptionsLable.Text = "Additional Parameters";
            // 
            // ClientPlayerNameLabel
            // 
            this.ClientPlayerNameLabel.AutoSize = true;
            this.ClientPlayerNameLabel.Location = new System.Drawing.Point(71, 89);
            this.ClientPlayerNameLabel.Name = "ClientPlayerNameLabel";
            this.ClientPlayerNameLabel.Size = new System.Drawing.Size(67, 13);
            this.ClientPlayerNameLabel.TabIndex = 18;
            this.ClientPlayerNameLabel.Text = "Player Name";
            // 
            // ClientSeverIPLable
            // 
            this.ClientSeverIPLable.AutoSize = true;
            this.ClientSeverIPLable.Location = new System.Drawing.Point(71, 62);
            this.ClientSeverIPLable.Name = "ClientSeverIPLable";
            this.ClientSeverIPLable.Size = new System.Drawing.Size(79, 13);
            this.ClientSeverIPLable.TabIndex = 17;
            this.ClientSeverIPLable.Text = "Server Address";
            // 
            // ClientLaunchButton
            // 
            this.ClientLaunchButton.Location = new System.Drawing.Point(210, 205);
            this.ClientLaunchButton.Name = "ClientLaunchButton";
            this.ClientLaunchButton.Size = new System.Drawing.Size(75, 23);
            this.ClientLaunchButton.TabIndex = 16;
            this.ClientLaunchButton.Text = "Launch";
            this.ClientLaunchButton.UseVisualStyleBackColor = true;
            this.ClientLaunchButton.Click += new System.EventHandler(this.ClientLaunchButton_Click);
            // 
            // ClientLaunchOptionsTextBox
            // 
            this.ClientLaunchOptionsTextBox.Location = new System.Drawing.Point(192, 116);
            this.ClientLaunchOptionsTextBox.Name = "ClientLaunchOptionsTextBox";
            this.ClientLaunchOptionsTextBox.Size = new System.Drawing.Size(231, 20);
            this.ClientLaunchOptionsTextBox.TabIndex = 15;
            // 
            // ClientPlayerNameTextBox
            // 
            this.ClientPlayerNameTextBox.Location = new System.Drawing.Point(302, 86);
            this.ClientPlayerNameTextBox.Name = "ClientPlayerNameTextBox";
            this.ClientPlayerNameTextBox.Size = new System.Drawing.Size(121, 20);
            this.ClientPlayerNameTextBox.TabIndex = 14;
            this.ClientPlayerNameTextBox.Text = "Player";
            // 
            // ClientIPTextBox
            // 
            this.ClientIPTextBox.Location = new System.Drawing.Point(302, 59);
            this.ClientIPTextBox.Name = "ClientIPTextBox";
            this.ClientIPTextBox.Size = new System.Drawing.Size(121, 20);
            this.ClientIPTextBox.TabIndex = 13;
            this.ClientIPTextBox.Text = "127.0.0.1";
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
            this.ServerTab.Size = new System.Drawing.Size(488, 256);
            this.ServerTab.TabIndex = 2;
            this.ServerTab.Text = "Server";
            this.ServerTab.UseVisualStyleBackColor = true;
            // 
            // ServerPlayerCountNum
            // 
            this.ServerPlayerCountNum.Location = new System.Drawing.Point(302, 88);
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
            this.ServerMaxPlayersLabel.Location = new System.Drawing.Point(71, 90);
            this.ServerMaxPlayersLabel.Name = "ServerMaxPlayersLabel";
            this.ServerMaxPlayersLabel.Size = new System.Drawing.Size(64, 13);
            this.ServerMaxPlayersLabel.TabIndex = 25;
            this.ServerMaxPlayersLabel.Text = "Max Players";
            // 
            // ServerCustomURLCheckbox
            // 
            this.ServerCustomURLCheckbox.AutoSize = true;
            this.ServerCustomURLCheckbox.Location = new System.Drawing.Point(74, 168);
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
            this.ServerCustomURLTextBox.Location = new System.Drawing.Point(210, 166);
            this.ServerCustomURLTextBox.Name = "ServerCustomURLTextBox";
            this.ServerCustomURLTextBox.Size = new System.Drawing.Size(213, 20);
            this.ServerCustomURLTextBox.TabIndex = 23;
            // 
            // ServerLaunchOptionsLabel
            // 
            this.ServerLaunchOptionsLabel.AutoSize = true;
            this.ServerLaunchOptionsLabel.Location = new System.Drawing.Point(71, 143);
            this.ServerLaunchOptionsLabel.Name = "ServerLaunchOptionsLabel";
            this.ServerLaunchOptionsLabel.Size = new System.Drawing.Size(109, 13);
            this.ServerLaunchOptionsLabel.TabIndex = 22;
            this.ServerLaunchOptionsLabel.Text = "Additional Parameters";
            // 
            // ServerBotCountLabel
            // 
            this.ServerBotCountLabel.AutoSize = true;
            this.ServerBotCountLabel.Location = new System.Drawing.Point(71, 116);
            this.ServerBotCountLabel.Name = "ServerBotCountLabel";
            this.ServerBotCountLabel.Size = new System.Drawing.Size(54, 13);
            this.ServerBotCountLabel.TabIndex = 21;
            this.ServerBotCountLabel.Text = "Bot Count";
            // 
            // ServerMapLabel
            // 
            this.ServerMapLabel.AutoSize = true;
            this.ServerMapLabel.Location = new System.Drawing.Point(71, 64);
            this.ServerMapLabel.Name = "ServerMapLabel";
            this.ServerMapLabel.Size = new System.Drawing.Size(28, 13);
            this.ServerMapLabel.TabIndex = 20;
            this.ServerMapLabel.Text = "Map";
            // 
            // ServerGamemodeLabel
            // 
            this.ServerGamemodeLabel.AutoSize = true;
            this.ServerGamemodeLabel.Location = new System.Drawing.Point(71, 37);
            this.ServerGamemodeLabel.Name = "ServerGamemodeLabel";
            this.ServerGamemodeLabel.Size = new System.Drawing.Size(65, 13);
            this.ServerGamemodeLabel.TabIndex = 19;
            this.ServerGamemodeLabel.Text = "Game Mode";
            // 
            // ServerLaunchOptionsTextBox
            // 
            this.ServerLaunchOptionsTextBox.Location = new System.Drawing.Point(210, 140);
            this.ServerLaunchOptionsTextBox.Name = "ServerLaunchOptionsTextBox";
            this.ServerLaunchOptionsTextBox.Size = new System.Drawing.Size(213, 20);
            this.ServerLaunchOptionsTextBox.TabIndex = 18;
            // 
            // ServerLaunchButton
            // 
            this.ServerLaunchButton.Location = new System.Drawing.Point(210, 205);
            this.ServerLaunchButton.Name = "ServerLaunchButton";
            this.ServerLaunchButton.Size = new System.Drawing.Size(75, 23);
            this.ServerLaunchButton.TabIndex = 17;
            this.ServerLaunchButton.Text = "Launch";
            this.ServerLaunchButton.UseVisualStyleBackColor = true;
            this.ServerLaunchButton.Click += new System.EventHandler(this.ServerLaunchButton_Click);
            // 
            // ServerBotCountNum
            // 
            this.ServerBotCountNum.Location = new System.Drawing.Point(302, 114);
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
            this.ServerMapsCombo.Location = new System.Drawing.Point(302, 61);
            this.ServerMapsCombo.Name = "ServerMapsCombo";
            this.ServerMapsCombo.Size = new System.Drawing.Size(121, 21);
            this.ServerMapsCombo.TabIndex = 15;
            // 
            // ServerGamemodesCombo
            // 
            this.ServerGamemodesCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ServerGamemodesCombo.FormattingEnabled = true;
            this.ServerGamemodesCombo.Location = new System.Drawing.Point(302, 34);
            this.ServerGamemodesCombo.Name = "ServerGamemodesCombo";
            this.ServerGamemodesCombo.Size = new System.Drawing.Size(121, 21);
            this.ServerGamemodesCombo.TabIndex = 14;
            // 
            // MasterServerTab
            // 
            this.MasterServerTab.Controls.Add(this.label4);
            this.MasterServerTab.Location = new System.Drawing.Point(4, 22);
            this.MasterServerTab.Name = "MasterServerTab";
            this.MasterServerTab.Size = new System.Drawing.Size(488, 256);
            this.MasterServerTab.TabIndex = 3;
            this.MasterServerTab.Text = "Master Server";
            this.MasterServerTab.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(199, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Not implemented!";
            // 
            // LauncherUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 278);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "LauncherUI";
            this.Text = "BLRevive Launcher";
            this.Load += new System.EventHandler(this.LauncherUI_Load);
            this.tabControl1.ResumeLayout(false);
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

        private System.Windows.Forms.TabControl tabControl1;
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
        private System.Windows.Forms.Label ClientSeverIPLable;
        private System.Windows.Forms.Button ClientLaunchButton;
        private System.Windows.Forms.TextBox ClientLaunchOptionsTextBox;
        private System.Windows.Forms.TextBox ClientPlayerNameTextBox;
        private System.Windows.Forms.TextBox ClientIPTextBox;
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
    }
}