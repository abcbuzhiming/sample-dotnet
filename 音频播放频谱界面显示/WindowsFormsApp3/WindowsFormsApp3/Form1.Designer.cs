namespace WindowsFormsApp3
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_open = new System.Windows.Forms.Button();
            this.btn_play = new System.Windows.Forms.Button();
            this.btn_pause = new System.Windows.Forms.Button();
            this.btn_resume = new System.Windows.Forms.Button();
            this.peakMeterCtrl1 = new Ernzo.WinForms.Controls.PeakMeterCtrl();
            this.label6 = new System.Windows.Forms.Label();
            this.cbo_fps = new System.Windows.Forms.ComboBox();
            this.btn_stop = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_close = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_LEDCount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_BANDSCount = new System.Windows.Forms.TextBox();
            this.cheb_ShowGrid = new System.Windows.Forms.CheckBox();
            this.cheb_ColoredGrid = new System.Windows.Forms.CheckBox();
            this.cheb_FalloffEffect = new System.Windows.Forms.CheckBox();
            this.btn_test = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_open
            // 
            this.btn_open.Location = new System.Drawing.Point(12, 12);
            this.btn_open.Name = "btn_open";
            this.btn_open.Size = new System.Drawing.Size(75, 23);
            this.btn_open.TabIndex = 0;
            this.btn_open.Text = "加载文件";
            this.btn_open.UseVisualStyleBackColor = true;
            this.btn_open.Click += new System.EventHandler(this.btn_open_Click);
            // 
            // btn_play
            // 
            this.btn_play.Location = new System.Drawing.Point(12, 73);
            this.btn_play.Name = "btn_play";
            this.btn_play.Size = new System.Drawing.Size(75, 23);
            this.btn_play.TabIndex = 1;
            this.btn_play.Text = "播放";
            this.btn_play.UseVisualStyleBackColor = true;
            this.btn_play.Click += new System.EventHandler(this.btn_play_Click);
            // 
            // btn_pause
            // 
            this.btn_pause.Location = new System.Drawing.Point(102, 73);
            this.btn_pause.Name = "btn_pause";
            this.btn_pause.Size = new System.Drawing.Size(75, 23);
            this.btn_pause.TabIndex = 2;
            this.btn_pause.Text = "暂停";
            this.btn_pause.UseVisualStyleBackColor = true;
            this.btn_pause.Click += new System.EventHandler(this.btn_pause_Click);
            // 
            // btn_resume
            // 
            this.btn_resume.Location = new System.Drawing.Point(196, 73);
            this.btn_resume.Name = "btn_resume";
            this.btn_resume.Size = new System.Drawing.Size(75, 23);
            this.btn_resume.TabIndex = 3;
            this.btn_resume.Text = "继续";
            this.btn_resume.UseVisualStyleBackColor = true;
            this.btn_resume.Click += new System.EventHandler(this.btn_resume_Click);
            // 
            // peakMeterCtrl1
            // 
            this.peakMeterCtrl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.peakMeterCtrl1.BackColor = System.Drawing.Color.Black;
            this.peakMeterCtrl1.BandsCount = 128;
            this.peakMeterCtrl1.ColorHigh = System.Drawing.Color.Red;
            this.peakMeterCtrl1.ColorHighBack = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.peakMeterCtrl1.ColorMedium = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.peakMeterCtrl1.ColorMediumBack = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.peakMeterCtrl1.ColorNormal = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.peakMeterCtrl1.ColorNormalBack = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.peakMeterCtrl1.FalloffColor = System.Drawing.Color.White;
            this.peakMeterCtrl1.ForeColor = System.Drawing.Color.Black;
            this.peakMeterCtrl1.GridColor = System.Drawing.Color.White;
            this.peakMeterCtrl1.LEDCount = 16;
            this.peakMeterCtrl1.Location = new System.Drawing.Point(9, 246);
            this.peakMeterCtrl1.Margin = new System.Windows.Forms.Padding(0);
            this.peakMeterCtrl1.Name = "peakMeterCtrl1";
            this.peakMeterCtrl1.ShowGrid = false;
            this.peakMeterCtrl1.Size = new System.Drawing.Size(385, 50);
            this.peakMeterCtrl1.TabIndex = 6;
            this.peakMeterCtrl1.Text = "peakMeterCtrl1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 123);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 12);
            this.label6.TabIndex = 18;
            this.label6.Text = "FPS";
            // 
            // cbo_fps
            // 
            this.cbo_fps.FormattingEnabled = true;
            this.cbo_fps.Items.AddRange(new object[] {
            "30",
            "60",
            "90",
            "120",
            "180"});
            this.cbo_fps.Location = new System.Drawing.Point(43, 120);
            this.cbo_fps.Name = "cbo_fps";
            this.cbo_fps.Size = new System.Drawing.Size(121, 20);
            this.cbo_fps.TabIndex = 19;
            this.cbo_fps.Text = "120";
            this.cbo_fps.SelectedIndexChanged += new System.EventHandler(this.cbo_fps_SelectedIndexChanged);
            // 
            // btn_stop
            // 
            this.btn_stop.Location = new System.Drawing.Point(286, 73);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Size = new System.Drawing.Size(75, 23);
            this.btn_stop.TabIndex = 20;
            this.btn_stop.Text = "停止";
            this.btn_stop.UseVisualStyleBackColor = true;
            this.btn_stop.Click += new System.EventHandler(this.btn_stop_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDown1.Location = new System.Drawing.Point(277, 121);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 21);
            this.numericUpDown1.TabIndex = 21;
            this.numericUpDown1.Value = new decimal(new int[] {
            1500,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(218, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 22;
            this.label1.Text = "显示增益";
            // 
            // btn_close
            // 
            this.btn_close.Location = new System.Drawing.Point(102, 12);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(75, 23);
            this.btn_close.TabIndex = 23;
            this.btn_close.Text = "释放资源";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 163);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 24;
            this.label2.Text = "纵向格子数";
            // 
            // txt_LEDCount
            // 
            this.txt_LEDCount.Location = new System.Drawing.Point(90, 160);
            this.txt_LEDCount.Name = "txt_LEDCount";
            this.txt_LEDCount.Size = new System.Drawing.Size(100, 21);
            this.txt_LEDCount.TabIndex = 25;
            this.txt_LEDCount.Text = "16";
            this.txt_LEDCount.TextChanged += new System.EventHandler(this.txt_LEDCount_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 190);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 26;
            this.label3.Text = "横向格子数";
            // 
            // txt_BANDSCount
            // 
            this.txt_BANDSCount.Location = new System.Drawing.Point(90, 187);
            this.txt_BANDSCount.Name = "txt_BANDSCount";
            this.txt_BANDSCount.Size = new System.Drawing.Size(100, 21);
            this.txt_BANDSCount.TabIndex = 27;
            this.txt_BANDSCount.Text = "128";
            this.txt_BANDSCount.TextChanged += new System.EventHandler(this.txt_BANDSCount_TextChanged);
            // 
            // cheb_ShowGrid
            // 
            this.cheb_ShowGrid.AutoSize = true;
            this.cheb_ShowGrid.Location = new System.Drawing.Point(229, 160);
            this.cheb_ShowGrid.Name = "cheb_ShowGrid";
            this.cheb_ShowGrid.Size = new System.Drawing.Size(96, 16);
            this.cheb_ShowGrid.TabIndex = 28;
            this.cheb_ShowGrid.Text = "显示背景网格";
            this.cheb_ShowGrid.UseVisualStyleBackColor = true;
            this.cheb_ShowGrid.CheckedChanged += new System.EventHandler(this.cheb_ShowGrid_CheckedChanged);
            // 
            // cheb_ColoredGrid
            // 
            this.cheb_ColoredGrid.AutoSize = true;
            this.cheb_ColoredGrid.Enabled = false;
            this.cheb_ColoredGrid.Location = new System.Drawing.Point(229, 186);
            this.cheb_ColoredGrid.Name = "cheb_ColoredGrid";
            this.cheb_ColoredGrid.Size = new System.Drawing.Size(72, 16);
            this.cheb_ColoredGrid.TabIndex = 29;
            this.cheb_ColoredGrid.Text = "彩色网格";
            this.cheb_ColoredGrid.UseVisualStyleBackColor = true;
            this.cheb_ColoredGrid.CheckedChanged += new System.EventHandler(this.cheb_ColoredGrid_CheckedChanged);
            // 
            // cheb_FalloffEffect
            // 
            this.cheb_FalloffEffect.AutoSize = true;
            this.cheb_FalloffEffect.Checked = true;
            this.cheb_FalloffEffect.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cheb_FalloffEffect.Location = new System.Drawing.Point(229, 211);
            this.cheb_FalloffEffect.Name = "cheb_FalloffEffect";
            this.cheb_FalloffEffect.Size = new System.Drawing.Size(120, 16);
            this.cheb_FalloffEffect.TabIndex = 30;
            this.cheb_FalloffEffect.Text = "显示顶部回落效果";
            this.cheb_FalloffEffect.UseVisualStyleBackColor = true;
            this.cheb_FalloffEffect.CheckedChanged += new System.EventHandler(this.cheb_FalloffEffect_CheckedChanged);
            // 
            // btn_test
            // 
            this.btn_test.Location = new System.Drawing.Point(196, 12);
            this.btn_test.Name = "btn_test";
            this.btn_test.Size = new System.Drawing.Size(165, 23);
            this.btn_test.TabIndex = 31;
            this.btn_test.Text = "频谱区域低中高音比例";
            this.btn_test.UseVisualStyleBackColor = true;
            this.btn_test.Click += new System.EventHandler(this.btn_test_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 303);
            this.Controls.Add(this.btn_test);
            this.Controls.Add(this.cheb_FalloffEffect);
            this.Controls.Add(this.cheb_ColoredGrid);
            this.Controls.Add(this.cheb_ShowGrid);
            this.Controls.Add(this.txt_BANDSCount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_LEDCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.btn_stop);
            this.Controls.Add(this.cbo_fps);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.peakMeterCtrl1);
            this.Controls.Add(this.btn_resume);
            this.Controls.Add(this.btn_pause);
            this.Controls.Add(this.btn_play);
            this.Controls.Add(this.btn_open);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BASS Demo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_open;
        private System.Windows.Forms.Button btn_play;
        private System.Windows.Forms.Button btn_pause;
        private System.Windows.Forms.Button btn_resume;
        private Ernzo.WinForms.Controls.PeakMeterCtrl peakMeterCtrl1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbo_fps;
        private System.Windows.Forms.Button btn_stop;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_LEDCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_BANDSCount;
        private System.Windows.Forms.CheckBox cheb_ShowGrid;
        private System.Windows.Forms.CheckBox cheb_ColoredGrid;
        private System.Windows.Forms.CheckBox cheb_FalloffEffect;
        private System.Windows.Forms.Button btn_test;
    }
}

