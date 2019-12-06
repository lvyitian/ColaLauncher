namespace ColaLauncher
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.GetVersion = new System.Windows.Forms.Button();
            this.install = new System.Windows.Forms.Button();
            this.bunifuiOSSwitch1 = new Bunifu.Framework.UI.BunifuiOSSwitch();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(26, 59);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(407, 379);
            this.listBox1.TabIndex = 0;
            // 
            // GetVersion
            // 
            this.GetVersion.BackColor = System.Drawing.Color.SeaGreen;
            this.GetVersion.Font = new System.Drawing.Font("黑体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.GetVersion.ForeColor = System.Drawing.Color.White;
            this.GetVersion.Location = new System.Drawing.Point(739, 360);
            this.GetVersion.Name = "GetVersion";
            this.GetVersion.Size = new System.Drawing.Size(186, 115);
            this.GetVersion.TabIndex = 1;
            this.GetVersion.Text = "获取版本列表";
            this.GetVersion.UseVisualStyleBackColor = false;
            this.GetVersion.Click += new System.EventHandler(this.GetVersion_Click);
            // 
            // install
            // 
            this.install.BackColor = System.Drawing.Color.SeaGreen;
            this.install.Font = new System.Drawing.Font("黑体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.install.ForeColor = System.Drawing.Color.White;
            this.install.Location = new System.Drawing.Point(522, 360);
            this.install.Name = "install";
            this.install.Size = new System.Drawing.Size(176, 115);
            this.install.TabIndex = 2;
            this.install.Text = "下载选中项";
            this.install.UseVisualStyleBackColor = false;
            this.install.Click += new System.EventHandler(this.install_Click);
            // 
            // bunifuiOSSwitch1
            // 
            this.bunifuiOSSwitch1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuiOSSwitch1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuiOSSwitch1.BackgroundImage")));
            this.bunifuiOSSwitch1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuiOSSwitch1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuiOSSwitch1.Location = new System.Drawing.Point(248, 458);
            this.bunifuiOSSwitch1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.bunifuiOSSwitch1.Name = "bunifuiOSSwitch1";
            this.bunifuiOSSwitch1.OffColor = System.Drawing.Color.Gray;
            this.bunifuiOSSwitch1.OnColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(202)))), ((int)(((byte)(94)))));
            this.bunifuiOSSwitch1.Size = new System.Drawing.Size(35, 20);
            this.bunifuiOSSwitch1.TabIndex = 3;
            this.bunifuiOSSwitch1.Value = true;
            this.bunifuiOSSwitch1.OnValueChange += new System.EventHandler(this.bunifuiOSSwitch1_OnValueChange);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("黑体", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(22, 458);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(206, 22);
            this.label4.TabIndex = 4;
            this.label4.Text = "官方下载源/非官方";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.SeaGreen;
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Controls.Add(this.pictureBox2);
            this.panel3.Location = new System.Drawing.Point(-29, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1108, 35);
            this.panel3.TabIndex = 5;
            this.panel3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel3_MouseDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("黑体", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(32, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 22);
            this.label5.TabIndex = 5;
            this.label5.Text = "ILauncher";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(925, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(45, 29);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Location = new System.Drawing.Point(874, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(45, 29);
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(951, 525);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.bunifuiOSSwitch1);
            this.Controls.Add(this.install);
            this.Controls.Add(this.GetVersion);
            this.Controls.Add(this.listBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form2";
            this.Text = "Form2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form2_MouseDown);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button GetVersion;
        private System.Windows.Forms.Button install;
        private Bunifu.Framework.UI.BunifuiOSSwitch bunifuiOSSwitch1;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}