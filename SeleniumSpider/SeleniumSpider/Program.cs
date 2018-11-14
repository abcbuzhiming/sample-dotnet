using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;


namespace SeleniumSpider
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Selenium");


            //IWebDriver driver = new InternetExlorerDriver();        //IE浏览器，需配合IEDriverServer使用(支持7,8,9,10,11，不支持ie6)
            //IWebDriver driver = new FirefoxDriver();     //初始化firefox浏览器，需要配合geckodriver使用
            //IWebDriver driver = new ChromeDriver();     //初始化chrome浏览器
            string driverDirectory = @"E:\selenium";

            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.BinaryLocation = @"C:\Program Files(x86)\Google\Chrome\Application\chrome.exe";       //设置chrome浏览器二进制程序路径位置
            //chromeOptions.AddArguments("--headless");       //设置为 headless 模式 （必须）
            chromeOptions.AddArguments("--window-size=1920,1080");      //设置浏览器窗口打开大小  （非必须）


            /* 此代理方案有bug:https://github.com/SeleniumHQ/selenium/issues/5299
            Proxy proxy = new Proxy();
            //proxy.HttpProxy = "127.0.0.1:7070";     //http协议代理
            //proxy.SslProxy = "127.0.0.1:7070";       //ssl协议代理
            proxy.SocksProxy = "127.0.0.1:7070";    //socket协议代理
            chromeOptions.Proxy = proxy;
            
            */
            //代理
            //chromeOptions.AddArgument("--proxy-server=http://127.0.0.1:7070");      //http代理
            chromeOptions.AddArguments("--proxy-server=socks5://127.0.0.1:7070");   //socket协议代理
            chromeOptions.AddArgument("ignore-certificate-errors");       //不检测证书错误

            using (IWebDriver driver = new ChromeDriver(driverDirectory, chromeOptions))       //用using保证资源能够被释放
            {
                //driver.Navigate().GoToUrl("http://www.imooc.com/");
                /*
                driver.Navigate().GoToUrl("http://www.ggzy.gov.cn/information/html/a/640000/0202/201807/27/0064cfa31828b76e44b5adbcb73acbd20f09.shtml");
                String title = driver.Title;
                Console.WriteLine("web title:" + title);
                IWebElement contentElement = driver.FindElement(By.ClassName("h4_o"));
                Console.WriteLine(contentElement.Text);
                contentElement = driver.FindElement(By.ClassName("p_o"));
                Console.WriteLine(contentElement.Text);
                Console.Write("输入任意按键退出");
                Console.ReadLine();
                */

                /*
                driver.Navigate().GoToUrl("http://www.ggzy.gov.cn/information/html/b/620000/0104/201807/12/00623b739b21300342bda797f22fcc0b6ce2.shtml");
                try {
                    String title = driver.Title;        //调用这行代码触发alert异常
                    
                }
                catch (UnhandledAlertException e) {
                    driver.SwitchTo().Alert().Dismiss();        //清除alert      
                }
                String titleA = driver.Title;
                Console.WriteLine("web title:" + titleA);
                Console.Write("输入任意按键退出");
                Console.ReadLine();
                */
                
                driver.Navigate().GoToUrl(@"https://www.bbc.co.uk/");       //加代理访问有土鳖
                Console.Write("输入任意按键退出");
                Console.ReadLine();
            }


        }
    }
}
