namespace PeakMeterCS
{
    partial class PeakMeter
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
            this.btnClose = new System.Windows.Forms.Button();
            this.frmSep = new System.Windows.Forms.Label();
            this.btnShowFalloff = new System.Windows.Forms.CheckBox();
            this.btnShowGrid = new System.Windows.Forms.CheckBox();
            this.timerGen = new System.Windows.Forms.Timer(this.components);
            this.btnColoredGrid = new System.Windows.Forms.CheckBox();
            this.btnSmooth = new System.Windows.Forms.CheckBox();
            this.peakMeterCtrl2 = new Ernzo.WinForms.Controls.PeakMeterCtrl();
            this.peakMeterCtrl1 = new Ernzo.WinForms.Controls.PeakMeterCtrl();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnClose.Location = new System.Drawing.Point(413, 46);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 42);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmSep
            // 
            this.frmSep.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.frmSep.Location = new System.Drawing.Point(13, 139);
            this.frmSep.Margin = new System.Windows.Forms.Padding(0);
            this.frmSep.Name = "frmSep";
            this.frmSep.Size = new System.Drawing.Size(475, 2);
            this.frmSep.TabIndex = 1;
            this.frmSep.Text = "label1";
            // 
            // btnShowFalloff
            // 
            this.btnShowFalloff.AutoSize = true;
            this.btnShowFalloff.Location = new System.Drawing.Point(13, 145);
            this.btnShowFalloff.Name = "btnShowFalloff";
            this.btnShowFalloff.Size = new System.Drawing.Size(115, 17);
            this.btnShowFalloff.TabIndex = 2;
            this.btnShowFalloff.Text = "Show Falloff Effect";
            this.btnShowFalloff.UseVisualStyleBackColor = true;
            this.btnShowFalloff.CheckedChanged += new System.EventHandler(this.btnShowFalloff_CheckedChanged);
            // 
            // btnShowGrid
            // 
            this.btnShowGrid.AutoSize = true;
            this.btnShowGrid.Location = new System.Drawing.Point(13, 170);
            this.btnShowGrid.Name = "btnShowGrid";
            this.btnShowGrid.Size = new System.Drawing.Size(75, 17);
            this.btnShowGrid.TabIndex = 3;
            this.btnShowGrid.Text = "Show Grid";
            this.btnShowGrid.UseVisualStyleBackColor = true;
            this.btnShowGrid.CheckedChanged += new System.EventHandler(this.btnShowGrid_CheckedChanged);
            // 
            // timerGen
            // 
            this.timerGen.Enabled = true;
            this.timerGen.Interval = 500;
            this.timerGen.Tick += new System.EventHandler(this.timerGen_Tick);
            // 
            // btnColoredGrid
            // 
            this.btnColoredGrid.AutoSize = true;
            this.btnColoredGrid.Location = new System.Drawing.Point(13, 194);
            this.btnColoredGrid.Name = "btnColoredGrid";
            this.btnColoredGrid.Size = new System.Drawing.Size(84, 17);
            this.btnColoredGrid.TabIndex = 6;
            this.btnColoredGrid.Text = "Colored Grid";
            this.btnColoredGrid.UseVisualStyleBackColor = true;
            this.btnColoredGrid.CheckedChanged += new System.EventHandler(this.btnColoredGrid_CheckedChanged);
            // 
            // btnSmooth
            // 
            this.btnSmooth.AutoSize = true;
            this.btnSmooth.Location = new System.Drawing.Point(13, 218);
            this.btnSmooth.Name = "btnSmooth";
            this.btnSmooth.Size = new System.Drawing.Size(90, 17);
            this.btnSmooth.TabIndex = 7;
            this.btnSmooth.Text = "Smooth Band";
            this.btnSmooth.UseVisualStyleBackColor = true;
            this.btnSmooth.CheckedChanged += new System.EventHandler(this.btnSmooth_CheckedChanged);
            // 
            // peakMeterCtrl2
            // 
            this.peakMeterCtrl2.BackColor = System.Drawing.SystemColors.Control;
            this.peakMeterCtrl2.BandsCount = 15;
            this.peakMeterCtrl2.ColorHigh = System.Drawing.Color.Red;
            this.peakMeterCtrl2.ColorHighBack = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.peakMeterCtrl2.ColorMedium = System.Drawing.Color.Yellow;
            this.peakMeterCtrl2.ColorMediumBack = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.peakMeterCtrl2.ColorNormal = System.Drawing.Color.Green;
            this.peakMeterCtrl2.ColorNormalBack = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.peakMeterCtrl2.FalloffColor = System.Drawing.Color.Gray;
            this.peakMeterCtrl2.FalloffEffect = false;
            this.peakMeterCtrl2.GridColor = System.Drawing.Color.Gainsboro;
            this.peakMeterCtrl2.LEDCount = 15;
            this.peakMeterCtrl2.Location = new System.Drawing.Point(187, 13);
            this.peakMeterCtrl2.MeterStyle = Ernzo.WinForms.Controls.PeakMeterStyle.PMS_Vertical;
            this.peakMeterCtrl2.Name = "peakMeterCtrl2";
            this.peakMeterCtrl2.Size = new System.Drawing.Size(139, 110);
            this.peakMeterCtrl2.TabIndex = 5;
            this.peakMeterCtrl2.Text = "peakMeterCtrl2";
            // 
            // peakMeterCtrl1
            // 
            this.peakMeterCtrl1.BackColor = System.Drawing.SystemColors.Control;
            this.peakMeterCtrl1.BandsCount = 15;
            this.peakMeterCtrl1.ColorHigh = System.Drawing.Color.Red;
            this.peakMeterCtrl1.ColorHighBack = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.peakMeterCtrl1.ColorMedium = System.Drawing.Color.Yellow;
            this.peakMeterCtrl1.ColorMediumBack = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.peakMeterCtrl1.ColorNormal = System.Drawing.Color.Green;
            this.peakMeterCtrl1.ColorNormalBack = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.peakMeterCtrl1.FalloffColor = System.Drawing.Color.Gray;
            this.peakMeterCtrl1.FalloffEffect = false;
            this.peakMeterCtrl1.GridColor = System.Drawing.Color.Gainsboro;
            this.peakMeterCtrl1.LEDCount = 15;
            this.peakMeterCtrl1.Location = new System.Drawing.Point(13, 13);
            this.peakMeterCtrl1.Name = "peakMeterCtrl1";
            this.peakMeterCtrl1.Size = new System.Drawing.Size(139, 110);
            this.peakMeterCtrl1.TabIndex = 4;
            this.peakMeterCtrl1.Text = "peakMeterCtrl1";
            // 
            // PeakMeter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 243);
            this.Controls.Add(this.btnSmooth);
            this.Controls.Add(this.btnColoredGrid);
            this.Controls.Add(this.peakMeterCtrl2);
            this.Controls.Add(this.peakMeterCtrl1);
            this.Controls.Add(this.btnShowGrid);
            this.Controls.Add(this.btnShowFalloff);
            this.Controls.Add(this.frmSep);
            this.Controls.Add(this.btnClose);
            this.Name = "PeakMeter";
            this.Text = "PeakMeter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label frmSep;
        private System.Windows.Forms.CheckBox btnShowFalloff;
        private System.Windows.Forms.CheckBox btnShowGrid;
        private Ernzo.WinForms.Controls.PeakMeterCtrl peakMeterCtrl1;
        private Ernzo.WinForms.Controls.PeakMeterCtrl peakMeterCtrl2;
        private System.Windows.Forms.Timer timerGen;
        private System.Windows.Forms.CheckBox btnColoredGrid;
        private System.Windows.Forms.CheckBox btnSmooth;
    }
}

