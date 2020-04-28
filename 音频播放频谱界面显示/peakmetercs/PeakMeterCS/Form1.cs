using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PeakMeterCS
{
    public partial class PeakMeter : Form
    {
        private const int NumLEDS = 15;
        public PeakMeter()
        {
            InitializeComponent();
            this.btnShowFalloff.Checked = this.peakMeterCtrl1.FalloffEffect;
            this.btnShowGrid.Checked = this.peakMeterCtrl1.ShowGrid;
            this.btnColoredGrid.Checked = this.peakMeterCtrl1.ColoredGrid;
            this.btnColoredGrid.Enabled = this.btnShowGrid.Checked;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnShowFalloff_CheckedChanged(object sender, EventArgs e)
        {
            this.peakMeterCtrl1.FalloffEffect = this.btnShowFalloff.Checked;
            this.peakMeterCtrl2.FalloffEffect = this.btnShowFalloff.Checked;
            if (this.btnShowFalloff.Checked)
            {
                this.peakMeterCtrl1.Start(1000/20); // 20fps
            }
            else
            {
                this.peakMeterCtrl1.Stop();
            }
        }

        private void btnShowGrid_CheckedChanged(object sender, EventArgs e)
        {
            this.peakMeterCtrl1.ShowGrid = this.btnShowGrid.Checked;
            this.peakMeterCtrl2.ShowGrid = this.btnShowGrid.Checked;
            this.btnColoredGrid.Enabled = this.btnShowGrid.Checked;
        }

        private void btnColoredGrid_CheckedChanged(object sender, EventArgs e)
        {
            this.peakMeterCtrl1.ColoredGrid = this.btnColoredGrid.Checked;
            this.peakMeterCtrl2.ColoredGrid = this.btnColoredGrid.Checked;
        }

        private void btnSmooth_CheckedChanged(object sender, EventArgs e)
        {
            this.peakMeterCtrl1.LEDCount = this.btnSmooth.Checked ? 1 : NumLEDS;
            this.peakMeterCtrl2.LEDCount = this.btnSmooth.Checked ? 1 : NumLEDS;
        }

        private void timerGen_Tick(object sender, EventArgs e)
        {
            int[] meters1 = new int[NumLEDS];
            int[] meters2 = new int[NumLEDS];
            Random rand = new Random();
            for (int i = 0; i < meters1.Length; i++)
            {
                meters1[i] = rand.Next(0, 100);
                meters2[i] = rand.Next(0, 100);
            }
            this.peakMeterCtrl1.SetData(meters1, 0, meters1.Length);
            this.peakMeterCtrl2.SetData(meters2, 0, meters2.Length);
        }

    }
}