using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private int index = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = String.Empty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Timers.Timer timer = new System.Timers.Timer(100);
            timer.AutoReset = true;//设置是执行一次（false）还是一直执行(true)；
            timer.Enabled = true;//是否执行System.Timers.Timer.Elapsed事件；
            timer.Elapsed += new System.Timers.ElapsedEventHandler(theout);

        }

        public void theout(object source, System.Timers.ElapsedEventArgs e)
        {
            string str = "121";
            if (index == 0) {
                index = index + 1;
            }
            else if (index == 1)
            {
                str = "\r";
                index = index + 1;
            }
            else if (index == 2) {
                str = "\n";
                index = 0;
                //str = "";
            }


            this.BeginInvoke((EventHandler)(
                delegate
                {
                    
                    //textBox1.Text += str;
                    textBox1.AppendText(str);

                }

                ));
            

        }
    }
}
