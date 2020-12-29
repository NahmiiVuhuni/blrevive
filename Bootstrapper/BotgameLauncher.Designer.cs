
namespace Bootstrapper
{
    partial class BotgameLauncher
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.BotCountNum = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.BotCountNum)).BeginInit();
            this.SuspendLayout();
            // 
            // GameModesCombo
            // 
            this.GameModesCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GameModesCombo.FormattingEnabled = true;
            this.GameModesCombo.Items.AddRange(new object[] {
            "Deathmatch",
            "Team Deathmatch",
            "Domination",
            "KOTH",
            "Kill Confirmed",
            "Last Man Standing",
            "Last Team Standing",
            "Search and Destroy",
            "Onslaught"});
            this.GameModesCombo.Location = new System.Drawing.Point(143, 12);
            this.GameModesCombo.Name = "GameModesCombo";
            this.GameModesCombo.Size = new System.Drawing.Size(121, 21);
            this.GameModesCombo.TabIndex = 0;
            this.GameModesCombo.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // MapsCombo
            // 
            this.MapsCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MapsCombo.FormattingEnabled = true;
            this.MapsCombo.Items.AddRange(new object[] {
            "HeloDeck"});
            this.MapsCombo.Location = new System.Drawing.Point(143, 40);
            this.MapsCombo.Name = "MapsCombo";
            this.MapsCombo.Size = new System.Drawing.Size(121, 21);
            this.MapsCombo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "GameMode";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Map";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(104, 105);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Launch";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Bot Count";
            // 
            // BotCountNum
            // 
            this.BotCountNum.Location = new System.Drawing.Point(143, 67);
            this.BotCountNum.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.BotCountNum.Name = "BotCountNum";
            this.BotCountNum.Size = new System.Drawing.Size(121, 20);
            this.BotCountNum.TabIndex = 10;
            // 
            // BotgameLauncher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(276, 144);
            this.Controls.Add(this.BotCountNum);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MapsCombo);
            this.Controls.Add(this.GameModesCombo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "BotgameLauncher";
            this.Text = "BLRevive Launcher - Botgame";
            this.Load += new System.EventHandler(this.BotgameLauncher_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BotCountNum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox GameModesCombo;
        private System.Windows.Forms.ComboBox MapsCombo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown BotCountNum;
    }
}