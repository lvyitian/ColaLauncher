namespace ColaLauncher
{
    partial class Form4
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form4));
            this.panel3 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.javapath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.mem = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.minecraftpath = new System.Windows.Forms.TextBox();
            this.isdebug = new Bunifu.Framework.UI.BunifuiOSSwitch();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.israndom = new Bunifu.Framework.UI.BunifuiOSSwitch();
            this.label9 = new System.Windows.Forms.Label();
            this.mcargs = new System.Windows.Forms.TextBox();
            this.jvmargs = new System.Windows.Forms.Label();
            this.jvmarg = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.enableForge = new Bunifu.Framework.UI.BunifuiOSSwitch();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.SeaGreen;
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Controls.Add(this.pictureBox2);
            this.panel3.Location = new System.Drawing.Point(-29, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1006, 32);
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
            this.pictureBox1.Location = new System.Drawing.Point(482, 1);
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
            this.pictureBox2.Location = new System.Drawing.Point(431, 1);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(45, 29);
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("黑体", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 34);
            this.label1.TabIndex = 6;
            this.label1.Text = "设置";
            // 
            // javapath
            // 
            this.javapath.Location = new System.Drawing.Point(124, 109);
            this.javapath.Name = "javapath";
            this.javapath.Size = new System.Drawing.Size(235, 25);
            this.javapath.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("黑体", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(14, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 22);
            this.label2.TabIndex = 6;
            this.label2.Text = "Java位置";
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox6.BackgroundImage")));
            this.pictureBox6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox6.Location = new System.Drawing.Point(369, 107);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(38, 30);
            this.pictureBox6.TabIndex = 8;
            this.pictureBox6.TabStop = false;
            this.pictureBox6.Click += new System.EventHandler(this.pictureBox6_Click);
            // 
            // mem
            // 
            this.mem.Location = new System.Drawing.Point(124, 164);
            this.mem.Name = "mem";
            this.mem.Size = new System.Drawing.Size(235, 25);
            this.mem.TabIndex = 9;
            this.mem.TextChanged += new System.EventHandler(this.mem_TextChanged);
            this.mem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mem_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("黑体", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(14, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 22);
            this.label3.TabIndex = 10;
            this.label3.Text = "内存大小";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("黑体", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(14, 222);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 22);
            this.label4.TabIndex = 11;
            this.label4.Text = "启动器皮肤";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox3.BackgroundImage")));
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox3.Location = new System.Drawing.Point(145, 218);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(38, 30);
            this.pictureBox3.TabIndex = 12;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox4.BackgroundImage")));
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox4.Location = new System.Drawing.Point(206, 219);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(38, 30);
            this.pictureBox4.TabIndex = 13;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox5.BackgroundImage")));
            this.pictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox5.Location = new System.Drawing.Point(269, 218);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(38, 30);
            this.pictureBox5.TabIndex = 14;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Click += new System.EventHandler(this.pictureBox5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("黑体", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(17, 280);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 22);
            this.label6.TabIndex = 15;
            this.label6.Text = "MC路径";
            // 
            // minecraftpath
            // 
            this.minecraftpath.Location = new System.Drawing.Point(124, 278);
            this.minecraftpath.Name = "minecraftpath";
            this.minecraftpath.Size = new System.Drawing.Size(235, 25);
            this.minecraftpath.TabIndex = 16;
            // 
            // isdebug
            // 
            this.isdebug.BackColor = System.Drawing.Color.Transparent;
            this.isdebug.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("isdebug.BackgroundImage")));
            this.isdebug.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.isdebug.Cursor = System.Windows.Forms.Cursors.Hand;
            this.isdebug.Location = new System.Drawing.Point(145, 440);
            this.isdebug.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.isdebug.Name = "isdebug";
            this.isdebug.OffColor = System.Drawing.Color.Gray;
            this.isdebug.OnColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(202)))), ((int)(((byte)(94)))));
            this.isdebug.Size = new System.Drawing.Size(35, 20);
            this.isdebug.TabIndex = 18;
            this.isdebug.Value = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("黑体", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(14, 438);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(116, 22);
            this.label7.TabIndex = 19;
            this.label7.Text = "Debug模式";
            // 
            // pictureBox8
            // 
            this.pictureBox8.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox8.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox8.BackgroundImage")));
            this.pictureBox8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox8.Location = new System.Drawing.Point(334, 218);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(38, 30);
            this.pictureBox8.TabIndex = 20;
            this.pictureBox8.TabStop = false;
            this.pictureBox8.Click += new System.EventHandler(this.pictureBox8_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("黑体", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(14, 491);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(102, 22);
            this.label8.TabIndex = 21;
            this.label8.Text = "随机背景";
            // 
            // israndom
            // 
            this.israndom.BackColor = System.Drawing.Color.Transparent;
            this.israndom.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("israndom.BackgroundImage")));
            this.israndom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.israndom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.israndom.Location = new System.Drawing.Point(136, 491);
            this.israndom.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.israndom.Name = "israndom";
            this.israndom.OffColor = System.Drawing.Color.Gray;
            this.israndom.OnColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(202)))), ((int)(((byte)(94)))));
            this.israndom.Size = new System.Drawing.Size(35, 20);
            this.israndom.TabIndex = 22;
            this.israndom.Value = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("黑体", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(17, 332);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 22);
            this.label9.TabIndex = 23;
            this.label9.Text = "MC Args";
            // 
            // mcargs
            // 
            this.mcargs.Location = new System.Drawing.Point(124, 332);
            this.mcargs.Name = "mcargs";
            this.mcargs.Size = new System.Drawing.Size(235, 25);
            this.mcargs.TabIndex = 24;
            // 
            // jvmargs
            // 
            this.jvmargs.AutoSize = true;
            this.jvmargs.BackColor = System.Drawing.Color.Transparent;
            this.jvmargs.Font = new System.Drawing.Font("黑体", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.jvmargs.ForeColor = System.Drawing.Color.Black;
            this.jvmargs.Location = new System.Drawing.Point(10, 386);
            this.jvmargs.Name = "jvmargs";
            this.jvmargs.Size = new System.Drawing.Size(106, 22);
            this.jvmargs.TabIndex = 25;
            this.jvmargs.Text = "JVM Args";
            // 
            // jvmarg
            // 
            this.jvmarg.Location = new System.Drawing.Point(124, 383);
            this.jvmarg.Name = "jvmarg";
            this.jvmarg.Size = new System.Drawing.Size(235, 25);
            this.jvmarg.TabIndex = 26;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("黑体", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(202, 440);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(116, 22);
            this.label10.TabIndex = 27;
            this.label10.Text = "启用Forge";
            // 
            // enableForge
            // 
            this.enableForge.BackColor = System.Drawing.Color.Transparent;
            this.enableForge.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("enableForge.BackgroundImage")));
            this.enableForge.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.enableForge.Cursor = System.Windows.Forms.Cursors.Hand;
            this.enableForge.Location = new System.Drawing.Point(325, 442);
            this.enableForge.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.enableForge.Name = "enableForge";
            this.enableForge.OffColor = System.Drawing.Color.Gray;
            this.enableForge.OnColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(202)))), ((int)(((byte)(94)))));
            this.enableForge.Size = new System.Drawing.Size(35, 20);
            this.enableForge.TabIndex = 28;
            this.enableForge.Value = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox7.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox7.BackgroundImage")));
            this.pictureBox7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox7.Location = new System.Drawing.Point(369, 273);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(38, 30);
            this.pictureBox7.TabIndex = 29;
            this.pictureBox7.TabStop = false;
            this.pictureBox7.Click += new System.EventHandler(this.pictureBox7_Click_1);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 550);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.enableForge);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.jvmarg);
            this.Controls.Add(this.jvmargs);
            this.Controls.Add(this.mcargs);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.israndom);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.pictureBox8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.isdebug);
            this.Controls.Add(this.minecraftpath);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.mem);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.javapath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form4";
            this.Text = "Form4";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form4_FormClosing);
            this.Load += new System.EventHandler(this.Form4_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form4_MouseDown);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox javapath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.TextBox mem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox minecraftpath;
        private Bunifu.Framework.UI.BunifuiOSSwitch isdebug;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.Label label8;
        private Bunifu.Framework.UI.BunifuiOSSwitch israndom;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox mcargs;
        private System.Windows.Forms.Label jvmargs;
        private System.Windows.Forms.TextBox jvmarg;
        private System.Windows.Forms.Label label10;
        private Bunifu.Framework.UI.BunifuiOSSwitch enableForge;
        private System.Windows.Forms.PictureBox pictureBox7;
    }
}