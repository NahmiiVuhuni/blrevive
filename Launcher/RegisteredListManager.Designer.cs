namespace BLRevive.Launcher
{
    partial class RegisteredListManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisteredListManager));
            this.RegisteredListMgrListview = new System.Windows.Forms.ListView();
            this.serverIPColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.serverPortColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.serverNameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.serverMaxPlayersColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.serverNumBotsColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RegisteredListMgrUnregisterButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // RegisteredListMgrListview
            // 
            this.RegisteredListMgrListview.AllowColumnReorder = true;
            this.RegisteredListMgrListview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.serverIPColumnHeader,
            this.serverPortColumnHeader,
            this.serverNameColumnHeader,
            this.serverMaxPlayersColumnHeader,
            this.serverNumBotsColumnHeader});
            this.RegisteredListMgrListview.FullRowSelect = true;
            this.RegisteredListMgrListview.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.RegisteredListMgrListview.HideSelection = false;
            this.RegisteredListMgrListview.LabelWrap = false;
            this.RegisteredListMgrListview.Location = new System.Drawing.Point(12, 12);
            this.RegisteredListMgrListview.MultiSelect = false;
            this.RegisteredListMgrListview.Name = "RegisteredListMgrListview";
            this.RegisteredListMgrListview.Size = new System.Drawing.Size(512, 160);
            this.RegisteredListMgrListview.TabIndex = 31;
            this.RegisteredListMgrListview.TileSize = new System.Drawing.Size(168, 30);
            this.RegisteredListMgrListview.UseCompatibleStateImageBehavior = false;
            this.RegisteredListMgrListview.View = System.Windows.Forms.View.Details;
            this.RegisteredListMgrListview.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.RegisteredListMgrListview_ColumnWidthChanging);
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
            // RegisteredListMgrUnregisterButton
            // 
            this.RegisteredListMgrUnregisterButton.Enabled = false;
            this.RegisteredListMgrUnregisterButton.Location = new System.Drawing.Point(202, 178);
            this.RegisteredListMgrUnregisterButton.Name = "RegisteredListMgrUnregisterButton";
            this.RegisteredListMgrUnregisterButton.Size = new System.Drawing.Size(133, 23);
            this.RegisteredListMgrUnregisterButton.TabIndex = 32;
            this.RegisteredListMgrUnregisterButton.Text = "Unregister Server";
            this.RegisteredListMgrUnregisterButton.UseVisualStyleBackColor = true;
            // 
            // RegisteredListManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 209);
            this.Controls.Add(this.RegisteredListMgrUnregisterButton);
            this.Controls.Add(this.RegisteredListMgrListview);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RegisteredListManager";
            this.Text = "Registered Server List Manager";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView RegisteredListMgrListview;
        private System.Windows.Forms.ColumnHeader serverIPColumnHeader;
        private System.Windows.Forms.ColumnHeader serverPortColumnHeader;
        private System.Windows.Forms.ColumnHeader serverNameColumnHeader;
        private System.Windows.Forms.ColumnHeader serverMaxPlayersColumnHeader;
        private System.Windows.Forms.ColumnHeader serverNumBotsColumnHeader;
        private System.Windows.Forms.Button RegisteredListMgrUnregisterButton;
    }
}