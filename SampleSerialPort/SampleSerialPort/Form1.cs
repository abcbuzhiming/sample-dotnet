using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            /* 第一种检测串口的方式，无法检测到被使用的串口
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
            */
            //第二种检测串口方式
            foreach (string s in SerialPort.GetPortNames())
            {
                comExist = true;
                comboBoxPort.Items.Add(s);
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
                SetPortProperty();
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
                    return;
                }

                //设置读取的另外一种方式
                /*
                byte[] buffer = new byte[100];
                Action kickoffRead = null;
                kickoffRead = delegate
                {
                    serialPort.BaseStream.BeginRead(buffer, 0, buffer.Length, delegate (IAsyncResult ar)
                    {
                        try
                        {
                            int actualLength = serialPort.BaseStream.EndRead(ar);
                            byte[] received = new byte[actualLength];
                            Buffer.BlockCopy(buffer, 0, received, 0, actualLength);
                            //raiseAppSerialDataEvent(received);
                            System.Text.UTF8Encoding utf8 = new System.Text.UTF8Encoding();// 显示汉字与字符
                            string decodedString = utf8.GetString(received);
                            this.Invoke((EventHandler)(
                                delegate
                                {
                                    if (boolHexShow == false)       //非16位显示
                                {
                                        textBoxRecvData.Text += decodedString;
                                    }
                                    else        //16位显示数据
                                {

                                    }

                                }
                                ));
                        }
                        catch (IOException exc)
                        {
                            Console.WriteLine("IO错误:" + exc.Message);
                        }
                        kickoffRead();
                    }, null);
                };
                kickoffRead();
                */
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

        /// <summary>
        /// 设置串口
        /// </summary>
        private void SetPortProperty()
        {
            serialPort = new SerialPort();
            serialPort.PortName = comboBoxPort.Text.Trim();  //设置串口名
            serialPort.BaudRate = Convert.ToInt32(comboBoxRate.Text.Trim()); //设置串口波特率
            int stopBit = (int)Convert.ToSingle(comboBoxStopBit.Text.Trim()) * 10; //设置停止位            
            switch (stopBit)
            {
                case 0:
                    serialPort.StopBits = StopBits.None;
                    break;
                case 10:
                    serialPort.StopBits = StopBits.One;
                    break;
                case 15:
                    serialPort.StopBits = StopBits.OnePointFive;
                    break;
                case 20:
                    serialPort.StopBits = StopBits.Two;
                    break;
                default:
                    serialPort.StopBits = StopBits.None;
                    break;
            }
            serialPort.DataBits = Convert.ToInt16(comboBoxDataBit.Text.Trim()); //设置数据位
            string parityType = comboBoxCheckBit.Text.Trim(); //设置奇偶校验
            switch (parityType)
            {
                case "None (无)":
                    serialPort.Parity = Parity.None;
                    break;
                case "Odd   (偶)":
                    serialPort.Parity = Parity.Odd;
                    break;
                case "Even  (奇)":
                    serialPort.Parity = Parity.Even;
                    break;
                case "Mark (=1)":
                    serialPort.Parity = Parity.Mark;
                    break;
                case "Space(=0)":
                    serialPort.Parity = Parity.Space;
                    break;
                default:
                    serialPort.Parity = Parity.None;
                    break;
            }
            serialPort.ReadTimeout = 500; //超时读取时间
            serialPort.RtsEnable = true; // 指示本设备准备好可接收数据
            //定义Data Received事件，当串口收到数据后出发事件
            serialPort.DataReceived += new SerialDataReceivedEventHandler(serial_DataReceived);
            serialPort.ErrorReceived += new SerialErrorReceivedEventHandler(serial_ErrorReceived);

            

        }

        /// <summary>
        /// 串口接收数据事件处理程序
        /// </summary>
        /// <remarks>这个事件是在非ui线程中被调用</remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void serial_DataReceived(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(100);  //延迟100ms等待接收完成数据
            Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 触发接收事件，可读取字符串数量:" + serialPort.BytesToRead);

            System.Text.UTF8Encoding utf8 = new System.Text.UTF8Encoding();// 显示汉字与字符
            Byte[] readBytes = new Byte[serialPort.BytesToRead];
            serialPort.Read(readBytes, 0, readBytes.Length);
            string decodedString = utf8.GetString(readBytes);
            //string decodedString = utf8.GetString(readBytes).Replace("\r", "").Replace("\n", "");
            if (decodedString.IndexOf("\r") >= 0) {
                return;
            }
            if (decodedString.IndexOf("\n") >= 0) {
                decodedString = decodedString.Replace("\r", "").Replace("\n", "");
                decodedString += "\r\n";
            }

            

            Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 接收到字符串:" + decodedString);

            
            this.BeginInvoke((EventHandler)(
                delegate
                {
                    if (boolHexShow == false)       //非16位显示
                    {
                        textBoxRecvData.AppendText(decodedString);
                    }
                    else        //16位显示数据
                    {

                    }

                }

                ));
            
        }

        /// <summary>
        /// 接收错误事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void serial_ErrorReceived(object sender, EventArgs e)
        {
            //SerialErrorReceivedEventArgs se = (SerialErrorReceivedEventArgs)e;
            Console.WriteLine("读取错误:" + e.ToString());
        }

        /// <summary>
        /// 发送数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSend_Click(object sender, EventArgs e)
        {
            if (!boolOpen)
            {
                return;
            }
            if (textBoxSend.Text == null || textBoxSend.Text.Trim().Equals(""))
            {
                return;
            }

            try
            {
                System.Text.UTF8Encoding utf8 = new System.Text.UTF8Encoding();
                byte[] writeBytes = utf8.GetBytes(textBoxSend.Text);
                //byte[] writeBytes11 = new Byte[data1.length]; //
                serialPort.Write(writeBytes, 0, writeBytes.Length); //发送数据内容


            }
            catch (Exception ex)
            {
                MessageBox.Show("发送数据时发生错误:" + ex.Message, "错误提示");
                return;

            }
        }

        private void buttonClearResv_Click(object sender, EventArgs e)
        {
            textBoxRecvData.Text = String.Empty;

        }
    }


}
