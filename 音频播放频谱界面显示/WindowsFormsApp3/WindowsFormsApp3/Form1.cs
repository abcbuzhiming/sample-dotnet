using System;
using System.Windows.Forms;
using Un4seen.Bass;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //启动频谱(参数是响应延迟，数字越小，音柱回起速度越快)
            peakMeterCtrl1.Start(1000 / Int32.Parse(cbo_fps.Text));

            //-1 表示 默认设备输出
            //44100 表示 输出采样率
            //BASS_DEVICE_CPSPEAKERS 表示输出模式
            if (!Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_CPSPEAKERS, this.Handle))
            {
                MessageBox.Show("出错了，" + Bass.BASS_ErrorGetCode().ToString());
            }

            Timer t = new Timer();
            t.Interval = 1;
            t.Tick += T_Tick;
            t.Start();
        }

        string fileName;
        int stream;

        private void btn_open_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            if (o.ShowDialog() == DialogResult.OK)
            {
                fileName = o.FileName;

                //第一个参数是文件名，
                //第二个参数是文件流开始位置，
                //第三个是文件流长度 0为使用文件整个长度，
                //最后一个是流的创建模式
                stream = Bass.BASS_StreamCreateFile(fileName, 0L, 0L, BASSFlag.BASS_SAMPLE_FLOAT);
            }
        }

       
        private void btn_play_Click(object sender, EventArgs e)
        {
            Bass.BASS_ChannelPlay(stream, true); //开始播放
        }

        private void btn_pause_Click(object sender, EventArgs e)
        {
            Bass.BASS_ChannelPause(stream);//音乐暂停
        }

        private void btn_resume_Click(object sender, EventArgs e)
        {
            Bass.BASS_ChannelPlay(stream, false);
        }

        private void btn_stop_Click(object sender, EventArgs e)
        {
            Bass.BASS_ChannelStop(stream);  //停止播放
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Bass.BASS_Stop();   //停止所有输出
            Bass.BASS_Free();   //释放所有资源

            if (!Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_CPSPEAKERS, this.Handle))
            {
                MessageBox.Show("出错了，" + Bass.BASS_ErrorGetCode().ToString());
            }
        }

        private void btn_test_Click(object sender, EventArgs e)
        {
            this.peakMeterCtrl1.SetRange(33, 66, 100);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Bass.BASS_ChannelStop(stream);  //停止播放
            Bass.BASS_StreamFree(stream);   //释放音频流
            Bass.BASS_Stop();   //停止所有输出
            Bass.BASS_Free();   //释放所有资源
        }

        const int BandsCount = 128;
        int[] FFTPeacks = new int[BandsCount];
        int[] FFTFall = new int[BandsCount];
        int rate = 1500;

        /// <summary>
        /// 用计时器绘制频谱（如果有更好的思路欢迎留言）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void T_Tick(object sender, EventArgs e)
        {
            if (Bass.BASS_ChannelIsActive(stream) != BASSActive.BASS_ACTIVE_PLAYING) return;
            int[] FFTFall = Array.ConvertAll<float, int>(GetFFTData(), delegate (float f) { return (int)Math.Abs(f * rate); });
            this.peakMeterCtrl1.SetData(FFTFall, 0, FFTFall.Length);
        }

        // 获取FFT采样数据，返回128个浮点采样数据
        public float[] GetFFTData()
        {
            float[] fft = new float[BandsCount];
            Bass.BASS_ChannelGetData(stream, fft, (int)BASSData.BASS_DATA_FFT256);
            return fft;
        }

        private void cbo_fps_SelectedIndexChanged(object sender, EventArgs e)
        {
            peakMeterCtrl1.Stop();
            peakMeterCtrl1.Start(1000 / Int32.Parse(cbo_fps.Text)); //fps
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            rate = Int32.Parse(numericUpDown1.Value.ToString()); //增益效果
        }

        private void txt_LEDCount_TextChanged(object sender, EventArgs e)
        {
            peakMeterCtrl1.LEDCount = Convert.ToInt32(txt_LEDCount.Text);//纵向格子数量
        }

        private void txt_BANDSCount_TextChanged(object sender, EventArgs e)
        {
            peakMeterCtrl1.BandsCount = Convert.ToInt32(txt_BANDSCount.Text); //横向格子数量
        }

        private void cheb_ShowGrid_CheckedChanged(object sender, EventArgs e)
        {
            peakMeterCtrl1.ShowGrid = cheb_ColoredGrid.Enabled = cheb_ShowGrid.Checked; //显示背景格子
        }

        private void cheb_ColoredGrid_CheckedChanged(object sender, EventArgs e)
        {
            peakMeterCtrl1.ColoredGrid = cheb_ColoredGrid.Checked; //显示彩色背景格子
        }

        private void cheb_FalloffEffect_CheckedChanged(object sender, EventArgs e)
        {
            peakMeterCtrl1.FalloffEffect = cheb_FalloffEffect.Checked;  //显示回落效果
        }
    }

       
    
}
