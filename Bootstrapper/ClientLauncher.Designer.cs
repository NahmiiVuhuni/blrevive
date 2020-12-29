
namespace Bootstrapper
{
    partial class ClientLauncher
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
            this.IPTextBox = new System.Windows.Forms.TextBox();
            this.PlayerNameTextBox = new System.Windows.Forms.TextBox();
            this.AdditionalGameOptionsTextBox = new System.Windows.Forms.TextBox();
            this.LaunchButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SetCustomURLCheckBox = new System.Windows.Forms.CheckBox();
            this.CustomURLTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // IPTextBox
            // 
            this.IPTextBox.Location = new System.Drawing.Point(238, 9);
            this.IPTextBox.Name = "IPTextBox";
            this.IPTextBox.Size = new System.Drawing.Size(121, 20);
            this.IPTextBox.TabIndex = 2;
            this.IPTextBox.Text = "127.0.0.1";
            // 
            // PlayerNameTextBox
            // 
            this.PlayerNameTextBox.Location = new System.Drawing.Point(238, 36);
            this.PlayerNameTextBox.Name = "PlayerNameTextBox";
            this.PlayerNameTextBox.Size = new System.Drawing.Size(121, 20);
            this.PlayerNameTextBox.TabIndex = 3;
            this.PlayerNameTextBox.Text = "Player";
            // 
            // AdditionalGameOptionsTextBox
            // 
            this.AdditionalGameOptionsTextBox.Location = new System.Drawing.Point(128, 63);
            this.AdditionalGameOptionsTextBox.Name = "AdditionalGameOptionsTextBox";
            this.AdditionalGameOptionsTextBox.Size = new System.Drawing.Size(231, 20);
            this.AdditionalGameOptionsTextBox.TabIndex = 4;
            // 
            // LaunchButton
            // 
            this.LaunchButton.Location = new System.Drawing.Point(148, 133);
            this.LaunchButton.Name = "LaunchButton";
            this.LaunchButton.Size = new System.Drawing.Size(75, 23);
            this.LaunchButton.TabIndex = 5;
            this.LaunchButton.Text = "Launch";
            this.LaunchButton.UseVisualStyleBackColor = true;
            this.LaunchButton.Click += new System.EventHandler(this.LaunchButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Server Address";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Player Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Additional Parameters";
            // 
            // SetCustomURLCheckBox
            // 
            this.SetCustomURLCheckBox.AutoSize = true;
            this.SetCustomURLCheckBox.Location = new System.Drawing.Point(15, 100);
            this.SetCustomURLCheckBox.Name = "SetCustomURLCheckBox";
            this.SetCustomURLCheckBox.Size = new System.Drawing.Size(96, 17);
            this.SetCustomURLCheckBox.TabIndex = 11;
            this.SetCustomURLCheckBox.Text = "Set Custom Url";
            this.SetCustomURLCheckBox.UseVisualStyleBackColor = true;
            this.SetCustomURLCheckBox.CheckedChanged += new System.EventHandler(this.SetCustomURLCheckBox_CheckedChanged);
            // 
            // CustomURLTextBox
            // 
            this.CustomURLTextBox.Location = new System.Drawing.Point(128, 97);
            this.CustomURLTextBox.Name = "CustomURLTextBox";
            this.CustomURLTextBox.Size = new System.Drawing.Size(231, 20);
            this.CustomURLTextBox.TabIndex = 12;
            this.CustomURLTextBox.Visible = false;
            // 
            // ClientLauncher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 166);
            this.Controls.Add(this.CustomURLTextBox);
            this.Controls.Add(this.SetCustomURLCheckBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LaunchButton);
            this.Controls.Add(this.AdditionalGameOptionsTextBox);
            this.Controls.Add(this.PlayerNameTextBox);
            this.Controls.Add(this.IPTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ClientLauncher";
            this.Text = "BLRevive Launcher - Client";
            this.Load += new System.EventHandler(this.ClientLauncher_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox IPTextBox;
        private System.Windows.Forms.TextBox PlayerNameTextBox;
        private System.Windows.Forms.TextBox AdditionalGameOptionsTextBox;
        private System.Windows.Forms.Button LaunchButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox SetCustomURLCheckBox;
        private System.Windows.Forms.TextBox CustomURLTextBox;
    }
}