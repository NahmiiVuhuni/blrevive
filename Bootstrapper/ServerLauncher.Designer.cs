
namespace Bootstrapper
{
    partial class ServerLauncher
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
            this.GameModesCombo = new System.Windows.Forms.ComboBox();
            this.MapsCombo = new System.Windows.Forms.ComboBox();
            this.BotCountCombo = new System.Windows.Forms.ComboBox();
            this.LaunchButton = new System.Windows.Forms.Button();
            this.AdditionalOptionsTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CustomUrlTextBox = new System.Windows.Forms.TextBox();
            this.UseCustomUrlCheckbox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // GameModesCombo
            // 
            this.GameModesCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GameModesCombo.FormattingEnabled = true;
            this.GameModesCombo.Location = new System.Drawing.Point(238, 12);
            this.GameModesCombo.Name = "GameModesCombo";
            this.GameModesCombo.Size = new System.Drawing.Size(121, 21);
            this.GameModesCombo.TabIndex = 0;
            // 
            // MapsCombo
            // 
            this.MapsCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MapsCombo.FormattingEnabled = true;
            this.MapsCombo.Location = new System.Drawing.Point(238, 39);
            this.MapsCombo.Name = "MapsCombo";
            this.MapsCombo.Size = new System.Drawing.Size(121, 21);
            this.MapsCombo.TabIndex = 1;
            // 
            // BotCountCombo
            // 
            this.BotCountCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BotCountCombo.FormattingEnabled = true;
            this.BotCountCombo.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16"});
            this.BotCountCombo.Location = new System.Drawing.Point(238, 66);
            this.BotCountCombo.Name = "BotCountCombo";
            this.BotCountCombo.Size = new System.Drawing.Size(121, 21);
            this.BotCountCombo.TabIndex = 2;
            // 
            // LaunchButton
            // 
            this.LaunchButton.Location = new System.Drawing.Point(146, 156);
            this.LaunchButton.Name = "LaunchButton";
            this.LaunchButton.Size = new System.Drawing.Size(75, 23);
            this.LaunchButton.TabIndex = 4;
            this.LaunchButton.Text = "Launch";
            this.LaunchButton.UseVisualStyleBackColor = true;
            this.LaunchButton.Click += new System.EventHandler(this.LaunchButton_Click);
            // 
            // AdditionalOptionsTextBox
            // 
            this.AdditionalOptionsTextBox.Location = new System.Drawing.Point(146, 94);
            this.AdditionalOptionsTextBox.Name = "AdditionalOptionsTextBox";
            this.AdditionalOptionsTextBox.Size = new System.Drawing.Size(213, 20);
            this.AdditionalOptionsTextBox.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Game Mode";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Map";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Bot Count";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Additional Options";
            // 
            // CustomUrlTextBox
            // 
            this.CustomUrlTextBox.Location = new System.Drawing.Point(146, 121);
            this.CustomUrlTextBox.Name = "CustomUrlTextBox";
            this.CustomUrlTextBox.Size = new System.Drawing.Size(213, 20);
            this.CustomUrlTextBox.TabIndex = 10;
            this.CustomUrlTextBox.Visible = false;
            // 
            // UseCustomUrlCheckbox
            // 
            this.UseCustomUrlCheckbox.AutoSize = true;
            this.UseCustomUrlCheckbox.Location = new System.Drawing.Point(16, 124);
            this.UseCustomUrlCheckbox.Name = "UseCustomUrlCheckbox";
            this.UseCustomUrlCheckbox.Size = new System.Drawing.Size(86, 17);
            this.UseCustomUrlCheckbox.TabIndex = 11;
            this.UseCustomUrlCheckbox.Text = "Custom URL";
            this.UseCustomUrlCheckbox.UseVisualStyleBackColor = true;
            this.UseCustomUrlCheckbox.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // ServerLauncher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 191);
            this.Controls.Add(this.UseCustomUrlCheckbox);
            this.Controls.Add(this.CustomUrlTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AdditionalOptionsTextBox);
            this.Controls.Add(this.LaunchButton);
            this.Controls.Add(this.BotCountCombo);
            this.Controls.Add(this.MapsCombo);
            this.Controls.Add(this.GameModesCombo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ServerLauncher";
            this.Text = "BLRevive Launcher - Server";
            this.Load += new System.EventHandler(this.ServerLauncher_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox GameModesCombo;
        private System.Windows.Forms.ComboBox MapsCombo;
        private System.Windows.Forms.ComboBox BotCountCombo;
        private System.Windows.Forms.Button LaunchButton;
        private System.Windows.Forms.TextBox AdditionalOptionsTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox CustomUrlTextBox;
        private System.Windows.Forms.CheckBox UseCustomUrlCheckbox;
    }
}