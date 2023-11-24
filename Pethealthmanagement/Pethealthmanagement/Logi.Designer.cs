namespace Pethealthmanagement
{
    partial class Logi
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Logi));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LogRole = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.LogBtn = new Bunifu.Framework.UI.BunifuThinButton2();
            this.LogRes = new System.Windows.Forms.Label();
            this.LogName = new System.Windows.Forms.TextBox();
            this.LogPass = new System.Windows.Forms.TextBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.bunifuElipse2 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 30;
            this.bunifuElipse1.TargetControl = this;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(349, 76);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(79, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 22);
            this.label1.TabIndex = 3;
            this.label1.Text = "Pet Health Management";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Pethealthmanagement.Properties.Resources.Cancel_icon_icons_com_73703;
            this.pictureBox2.Location = new System.Drawing.Point(302, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(35, 37);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Pethealthmanagement.Properties.Resources.dog1_removebg_preview;
            this.pictureBox1.Location = new System.Drawing.Point(3, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(61, 61);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // LogRole
            // 
            this.LogRole.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogRole.FormattingEnabled = true;
            this.LogRole.Items.AddRange(new object[] {
            "Admin",
            "Doctor",
            "Receptionist"});
            this.LogRole.Location = new System.Drawing.Point(88, 155);
            this.LogRole.Name = "LogRole";
            this.LogRole.Size = new System.Drawing.Size(160, 29);
            this.LogRole.TabIndex = 2;
            this.LogRole.Text = "Role";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(85, 197);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "UserName";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(85, 253);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 21);
            this.label3.TabIndex = 4;
            this.label3.Text = "Password";
            // 
            // LogBtn
            // 
            this.LogBtn.ActiveBorderThickness = 1;
            this.LogBtn.ActiveCornerRadius = 20;
            this.LogBtn.ActiveFillColor = System.Drawing.Color.Teal;
            this.LogBtn.ActiveForecolor = System.Drawing.Color.Black;
            this.LogBtn.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.LogBtn.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.LogBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("LogBtn.BackgroundImage")));
            this.LogBtn.ButtonText = "Login";
            this.LogBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LogBtn.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogBtn.ForeColor = System.Drawing.Color.Honeydew;
            this.LogBtn.IdleBorderThickness = 1;
            this.LogBtn.IdleCornerRadius = 20;
            this.LogBtn.IdleFillColor = System.Drawing.Color.Teal;
            this.LogBtn.IdleForecolor = System.Drawing.Color.LightSkyBlue;
            this.LogBtn.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.LogBtn.Location = new System.Drawing.Point(122, 315);
            this.LogBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.LogBtn.Name = "LogBtn";
            this.LogBtn.Size = new System.Drawing.Size(102, 35);
            this.LogBtn.TabIndex = 5;
            this.LogBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LogBtn.Click += new System.EventHandler(this.LogBtn_Click);
            // 
            // LogRes
            // 
            this.LogRes.AutoSize = true;
            this.LogRes.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogRes.Location = new System.Drawing.Point(144, 355);
            this.LogRes.Name = "LogRes";
            this.LogRes.Size = new System.Drawing.Size(51, 21);
            this.LogRes.TabIndex = 6;
            this.LogRes.Text = "Reset";
            this.LogRes.Click += new System.EventHandler(this.LogRes_Click);
            // 
            // LogName
            // 
            this.LogName.Location = new System.Drawing.Point(88, 221);
            this.LogName.Name = "LogName";
            this.LogName.Size = new System.Drawing.Size(160, 20);
            this.LogName.TabIndex = 7;
            // 
            // LogPass
            // 
            this.LogPass.Location = new System.Drawing.Point(89, 277);
            this.LogPass.Name = "LogPass";
            this.LogPass.Size = new System.Drawing.Size(160, 20);
            this.LogPass.TabIndex = 8;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Pethealthmanagement.Properties.Resources.dog1_removebg_preview;
            this.pictureBox3.Location = new System.Drawing.Point(122, 80);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(73, 68);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 9;
            this.pictureBox3.TabStop = false;
            // 
            // bunifuElipse2
            // 
            this.bunifuElipse2.ElipseRadius = 30;
            this.bunifuElipse2.TargetControl = this.LogBtn;
            // 
            // Logi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(349, 398);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.LogPass);
            this.Controls.Add(this.LogName);
            this.Controls.Add(this.LogRes);
            this.Controls.Add(this.LogBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LogRole);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Logi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Logi";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LogRes;
        private Bunifu.Framework.UI.BunifuThinButton2 LogBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox LogRole;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TextBox LogPass;
        private System.Windows.Forms.TextBox LogName;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse2;
    }
}