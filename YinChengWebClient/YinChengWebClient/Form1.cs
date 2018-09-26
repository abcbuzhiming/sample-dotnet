using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;

namespace YinChengWebClient
{
    public partial class Form1 : Form
    {
        public ChromiumWebBrowser chromiumWebBrowser;
        public Form1()
        {
            InitializeComponent();
            //初始化浏览器
            InitializeChromium();
        }

        private void InitializeChromium()
        {
            CefSettings settings = new CefSettings();
            settings.Locale = "zh-CN";      //语言，中文
            //settings.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/50.0.2661.102 Safari/537.36";        //cef设置userAgent
            settings.PersistSessionCookies = true;
            //settings.CefCommandLineArgs.Add("ppapi-flash-version", "21.0.0.213");//PepperFlash\manifest.json中的version
            settings.CefCommandLineArgs.Add("ppapi-flash-path", @"plugins\pepflashplayer.dll");     //注意插件必须和cef的版本x86和x64对应的，版本不对，无法加载,并且这个插件挑系统，系统版本低就必须找低版本的插件
            settings.CefCommandLineArgs.Add("plugin-polic", "allow");       //直接允许插件
            //初始化
            Cef.Initialize(settings);
            //新建浏览器组件
            this.chromiumWebBrowser = new ChromiumWebBrowser("Http://www.baidu.com");
            this.chromiumWebBrowser.MenuHandler = new CustomMenuHandler();      //自定义菜单处理器
            //this.Controls.Add(chromiumWebBrowser);
            groupBox1.Controls.Add(this.chromiumWebBrowser);        //把浏览器控件放入groupBox容器内
            this.chromiumWebBrowser.Dock = DockStyle.Fill;
        }

        //窗口关闭(退出)
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cef.Shutdown();     //窗口关闭时释放 cef
        }

        //刷新页面按钮处理事件
        private void button3_Click(object sender, EventArgs e)
        {
            chromiumWebBrowser.GetBrowser().Reload();
        }

        //前进
        private void button2_Click(object sender, EventArgs e)
        {
            chromiumWebBrowser.GetBrowser().GoForward();
        }

        //后退
        private void button1_Click(object sender, EventArgs e)
        {
            chromiumWebBrowser.GetBrowser().GoBack();
        }

        //首页
        private void button4_Click(object sender, EventArgs e)
        {

            chromiumWebBrowser.Load("http://yc.yixueks.com:8080/medicalWeb/login"); 
        }
    }
}
