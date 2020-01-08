using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SampleSerialPort
{
    public partial class Form1 : Form
    {
        private SerialPort serialPort;
        bool boolOpen = false; //打开串口标志
        bool boolHexShow = false; //是否十六进制显示接收数据
        bool boolHexSend = false;   //是否十六进制发送数据

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 串口检测
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            bool comExist = false;
            comboBoxPort.Items.Clear();
            for (int i = 0; i < 10; i++)
            {
                try
                {
                    SerialPort sp = new SerialPort("COM" + (i + 1).ToString());
                    sp.Open();
                    sp.Close();
                    comboBoxPort.Items.Add("COM" + (i + 1).ToString());
                    comExist = true;
                }
                catch (Exception)
                {
                    continue;
                }
            }
            if (comExist)
            {
                comboBoxPort.SelectedIndex = 0; //默认第一个
            }
            else
            {
                MessageBox.Show("没有找到任何可用串口", "错误提示");
            }
        }

        /// <summary>
        /// 打开串口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonOpen_Click(object sender, EventArgs e)
        {
            if (boolOpen == false)
            {
                if (!CheckPortSetting())  //检测串口设置
                {
                    MessageBox.Show("串口未设置", "错误提示");
                    return;
                }
                
                try //打开串口
                {
                    serialPort.Open();
                    boolOpen = true;
                    buttonOpen.Text = "关闭串口";
                    //串口打开后相关的串口设置按钮不再可选择
                    comboBoxPort.Enabled = false;
                    comboBoxRate.Enabled = false;
                    comboBoxCheckBit.Enabled = false;
                    comboBoxDataBit.Enabled = false;
                    comboBoxStopBit.Enabled = false;
                }
                catch (Exception)
                {   //失败后设置
                    
                    boolOpen = false;
                    MessageBox.Show("串口无效或已经被占用！", "错误提示");
                }
            }
            else
            {
                serialPort.Close();
                boolOpen = false;
                buttonOpen.Text = "打开串口";
                //重置选择按钮有效
                comboBoxPort.Enabled = true;
                comboBoxRate.Enabled = true;
                comboBoxCheckBit.Enabled = true;
                comboBoxDataBit.Enabled = true;
                comboBoxStopBit.Enabled = true;
            }
        }

        /// <summary>
        /// 检测相关配置
        /// </summary>
        /// <returns></returns>
        private bool CheckPortSetting() //检测串口是否初始化
        {
            if (comboBoxPort.Text.Trim() == "") return false;
            if (comboBoxRate.Text.Trim() == "") return false;
            if (comboBoxCheckBit.Text.Trim() == "") return false;
            if (comboBoxDataBit.Text.Trim() == "") return false;
            if (comboBoxStopBit.Text.Trim() == "") return false;
            return true;
        }
    }
}
