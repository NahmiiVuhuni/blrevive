namespace BLRevive.Launcher
{
    partial class ServerListManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServerListManager));
            this.ServerListMgrListview = new System.Windows.Forms.ListView();
            this.serverIPColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.serverPortColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.serverNameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.serverMaxPlayersColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.serverNumBotsColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ServerListMgrAddButton = new System.Windows.Forms.Button();
            this.ServerListMgrRemoveButton = new System.Windows.Forms.Button();
            this.ClientTabServerPortNum = new System.Windows.Forms.NumericUpDown();
            this.ServerListMgrAddressLabel = new System.Windows.Forms.Label();
            this.ServerListMgrAddressTextBox = new System.Windows.Forms.TextBox();
            this.ServerListMgrNameLabel = new System.Windows.Forms.Label();
            this.ServerListMgrNameTextBox = new System.Windows.Forms.TextBox();
            this.ServerListMgrPlayerCountNum = new System.Windows.Forms.NumericUpDown();
            this.ServerListMgrMaxPlayersLabel = new System.Windows.Forms.Label();
            this.ServerListMgrBotCountLabel = new System.Windows.Forms.Label();
            this.ServerListMgrBotCountNum = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.ClientTabServerPortNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerListMgrPlayerCountNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerListMgrBotCountNum)).BeginInit();
            this.SuspendLayout();
            // 
            // ServerListMgrListview
            // 
            this.ServerListMgrListview.AllowColumnReorder = true;
            this.ServerListMgrListview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.serverIPColumnHeader,
            this.serverPortColumnHeader,
            this.serverNameColumnHeader,
            this.serverMaxPlayersColumnHeader,
            this.serverNumBotsColumnHeader});
            this.ServerListMgrListview.FullRowSelect = true;
            this.ServerListMgrListview.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.ServerListMgrListview.HideSelection = false;
            this.ServerListMgrListview.LabelWrap = false;
            this.ServerListMgrListview.Location = new System.Drawing.Point(12, 12);
            this.ServerListMgrListview.MultiSelect = false;
            this.ServerListMgrListview.Name = "ServerListMgrListview";
            this.ServerListMgrListview.Size = new System.Drawing.Size(512, 160);
            this.ServerListMgrListview.TabIndex = 30;
            this.ServerListMgrListview.TileSize = new System.Drawing.Size(168, 30);
            this.ServerListMgrListview.UseCompatibleStateImageBehavior = false;
            this.ServerListMgrListview.View = System.Windows.Forms.View.Details;
            this.ServerListMgrListview.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.ClientTabServerListView_ColumnWidthChanging);
            // 
            // serverIPColumnHeader
            // 
            this.serverIPColumnHeader.DisplayIndex = 1;
            this.serverIPColumnHeader.Text = "IP";
            this.serverIPColumnHeader.Width = 145;
            // 
            // serverPortColumnHeader
            // 
            this.serverPortColumnHeader.DisplayIndex = 2;
            this.serverPortColumnHeader.Text = "Port";
            this.serverPortColumnHeader.Width = 45;
            // 
            // serverNameColumnHeader
            // 
            this.serverNameColumnHeader.DisplayIndex = 0;
            this.serverNameColumnHeader.Text = "Server Name";
            this.serverNameColumnHeader.Width = 187;
            // 
            // serverMaxPlayersColumnHeader
            // 
            this.serverMaxPlayersColumnHeader.Tag = "";
            this.serverMaxPlayersColumnHeader.Text = "Max Players";
            this.serverMaxPlayersColumnHeader.Width = 72;
            // 
            // serverNumBotsColumnHeader
            // 
            this.serverNumBotsColumnHeader.Text = "Bots";
            this.serverNumBotsColumnHeader.Width = 42;
            // 
            // ServerListMgrAddButton
            // 
            this.ServerListMgrAddButton.Location = new System.Drawing.Point(202, 316);
            this.ServerListMgrAddButton.Name = "ServerListMgrAddButton";
            this.ServerListMgrAddButton.Size = new System.Drawing.Size(133, 23);
            this.ServerListMgrAddButton.TabIndex = 31;
            this.ServerListMgrAddButton.Text = "Add Server";
            this.ServerListMgrAddButton.UseVisualStyleBackColor = true;
            // 
            // ServerListMgrRemoveButton
            // 
            this.ServerListMgrRemoveButton.Enabled = false;
            this.ServerListMgrRemoveButton.Location = new System.Drawing.Point(202, 345);
            this.ServerListMgrRemoveButton.Name = "ServerListMgrRemoveButton";
            this.ServerListMgrRemoveButton.Size = new System.Drawing.Size(133, 23);
            this.ServerListMgrRemoveButton.TabIndex = 32;
            this.ServerListMgrRemoveButton.Text = "Remove Server";
            this.ServerListMgrRemoveButton.UseVisualStyleBackColor = true;
            // 
            // ClientTabServerPortNum
            // 
            this.ClientTabServerPortNum.Location = new System.Drawing.Point(371, 178);
            this.ClientTabServerPortNum.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.ClientTabServerPortNum.Name = "ClientTabServerPortNum";
            this.ClientTabServerPortNum.Size = new System.Drawing.Size(99, 20);
            this.ClientTabServerPortNum.TabIndex = 35;
            this.ClientTabServerPortNum.Value = new decimal(new int[] {
            7777,
            0,
            0,
            0});
            // 
            // ServerListMgrAddressLabel
            // 
            this.ServerListMgrAddressLabel.AutoSize = true;
            this.ServerListMgrAddressLabel.Location = new System.Drawing.Point(63, 181);
            this.ServerListMgrAddressLabel.Name = "ServerListMgrAddressLabel";
            this.ServerListMgrAddressLabel.Size = new System.Drawing.Size(103, 13);
            this.ServerListMgrAddressLabel.TabIndex = 34;
            this.ServerListMgrAddressLabel.Text = "Server Address/Port";
            // 
            // ServerListMgrAddressTextBox
            // 
            this.ServerListMgrAddressTextBox.Location = new System.Drawing.Point(220, 178);
            this.ServerListMgrAddressTextBox.Name = "ServerListMgrAddressTextBox";
            this.ServerListMgrAddressTextBox.Size = new System.Drawing.Size(145, 20);
            this.ServerListMgrAddressTextBox.TabIndex = 33;
            this.ServerListMgrAddressTextBox.Text = "127.0.0.1";
            // 
            // ServerListMgrNameLabel
            // 
            this.ServerListMgrNameLabel.AutoSize = true;
            this.ServerListMgrNameLabel.Location = new System.Drawing.Point(63, 207);
            this.ServerListMgrNameLabel.Name = "ServerListMgrNameLabel";
            this.ServerListMgrNameLabel.Size = new System.Drawing.Size(69, 13);
            this.ServerListMgrNameLabel.TabIndex = 37;
            this.ServerListMgrNameLabel.Text = "Server Name";
            // 
            // ServerListMgrNameTextBox
            // 
            this.ServerListMgrNameTextBox.Location = new System.Drawing.Point(220, 204);
            this.ServerListMgrNameTextBox.Name = "ServerListMgrNameTextBox";
            this.ServerListMgrNameTextBox.Size = new System.Drawing.Size(250, 20);
            this.ServerListMgrNameTextBox.TabIndex = 36;
            // 
            // ServerListMgrPlayerCountNum
            // 
            this.ServerListMgrPlayerCountNum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ServerListMgrPlayerCountNum.Location = new System.Drawing.Point(322, 230);
            this.ServerListMgrPlayerCountNum.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.ServerListMgrPlayerCountNum.Name = "ServerListMgrPlayerCountNum";
            this.ServerListMgrPlayerCountNum.Size = new System.Drawing.Size(148, 20);
            this.ServerListMgrPlayerCountNum.TabIndex = 41;
            this.ServerListMgrPlayerCountNum.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            // 
            // ServerListMgrMaxPlayersLabel
            // 
            this.ServerListMgrMaxPlayersLabel.AutoSize = true;
            this.ServerListMgrMaxPlayersLabel.Location = new System.Drawing.Point(63, 232);
            this.ServerListMgrMaxPlayersLabel.Name = "ServerListMgrMaxPlayersLabel";
            this.ServerListMgrMaxPlayersLabel.Size = new System.Drawing.Size(64, 13);
            this.ServerListMgrMaxPlayersLabel.TabIndex = 40;
            this.ServerListMgrMaxPlayersLabel.Text = "Max Players";
            // 
            // ServerListMgrBotCountLabel
            // 
            this.ServerListMgrBotCountLabel.AutoSize = true;
            this.ServerListMgrBotCountLabel.Location = new System.Drawing.Point(63, 258);
            this.ServerListMgrBotCountLabel.Name = "ServerListMgrBotCountLabel";
            this.ServerListMgrBotCountLabel.Size = new System.Drawing.Size(54, 13);
            this.ServerListMgrBotCountLabel.TabIndex = 39;
            this.ServerListMgrBotCountLabel.Text = "Bot Count";
            // 
            // ServerListMgrBotCountNum
            // 
            this.ServerListMgrBotCountNum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ServerListMgrBotCountNum.Location = new System.Drawing.Point(322, 256);
            this.ServerListMgrBotCountNum.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.ServerListMgrBotCountNum.Name = "ServerListMgrBotCountNum";
            this.ServerListMgrBotCountNum.Size = new System.Drawing.Size(148, 20);
            this.ServerListMgrBotCountNum.TabIndex = 38;
            // 
            // ServerListManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 385);
            this.Controls.Add(this.ServerListMgrPlayerCountNum);
            this.Controls.Add(this.ServerListMgrMaxPlayersLabel);
            this.Controls.Add(this.ServerListMgrBotCountLabel);
            this.Controls.Add(this.ServerListMgrBotCountNum);
            this.Controls.Add(this.ServerListMgrNameLabel);
            this.Controls.Add(this.ServerListMgrNameTextBox);
            this.Controls.Add(this.ClientTabServerPortNum);
            this.Controls.Add(this.ServerListMgrAddressLabel);
            this.Controls.Add(this.ServerListMgrAddressTextBox);
            this.Controls.Add(this.ServerListMgrRemoveButton);
            this.Controls.Add(this.ServerListMgrAddButton);
            this.Controls.Add(this.ServerListMgrListview);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ServerListManager";
            this.Text = "Manage Local Server List";
            ((System.ComponentModel.ISupportInitialize)(this.ClientTabServerPortNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerListMgrPlayerCountNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerListMgrBotCountNum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView ServerListMgrListview;
        private System.Windows.Forms.ColumnHeader serverIPColumnHeader;
        private System.Windows.Forms.ColumnHeader serverPortColumnHeader;
        private System.Windows.Forms.ColumnHeader serverNameColumnHeader;
        private System.Windows.Forms.ColumnHeader serverMaxPlayersColumnHeader;
        private System.Windows.Forms.ColumnHeader serverNumBotsColumnHeader;
        private System.Windows.Forms.Button ServerListMgrAddButton;
        private System.Windows.Forms.Button ServerListMgrRemoveButton;
        private System.Windows.Forms.NumericUpDown ClientTabServerPortNum;
        private System.Windows.Forms.Label ServerListMgrAddressLabel;
        private System.Windows.Forms.TextBox ServerListMgrAddressTextBox;
        private System.Windows.Forms.Label ServerListMgrNameLabel;
        private System.Windows.Forms.TextBox ServerListMgrNameTextBox;
        private System.Windows.Forms.NumericUpDown ServerListMgrPlayerCountNum;
        private System.Windows.Forms.Label ServerListMgrMaxPlayersLabel;
        private System.Windows.Forms.Label ServerListMgrBotCountLabel;
        private System.Windows.Forms.NumericUpDown ServerListMgrBotCountNum;
    }
}