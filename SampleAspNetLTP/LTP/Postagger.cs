using System.Text;
using System.Runtime.InteropServices;
using System;

namespace SampleAspNetLTP.LTP
{



    public class Postagger
    {
        //[DllImport(@"E:/NLP/LTP/lib/postagger.dll")]      //引入C语言写的动态链接库文件，win下是dll，类Unix下是so文件
        [DllImport(@"E:/NLP/LTP/ltp-3.4.0-SourceCode/lib/Release/postagger.dll")]
        public static extern IntPtr postagger_create_postagger(string modelPath, string lexiconFile = null);      //初始化分词器，得到分词器对象指针

        //[DllImport(@"E:/NLP/LTP/lib/postagger.dll")]
        [DllImport(@"E:/NLP/LTP/ltp-3.4.0-SourceCode/lib/Release/postagger.dll")]
        public static extern int postagger_release_postagger(IntPtr parser);        //释放词性标注器

        //[DllImport(@"E:/NLP/LTP/lib/postagger.dll")]
        [DllImport(@"E:/NLP/LTP/ltp-3.4.0-SourceCode/lib/Release/postagger.dll")]
        public static extern int postagger_postag_csharp(IntPtr parser, byte[] inStr, IntPtr tags);       //词性标注

        public static IntPtr parser;        //词性标注器的指针

        static Postagger()
        {
            Console.WriteLine("init LTP Postagger!");
            parser = postagger_create_postagger(@"E:/NLP/LTP/ltp_data/pos.model");      //只使用模型的分词器
            //parser = postagger_create_postagger(@"E:/NLP/LTP/ltp_data/pos.model",@"E:/NLP/LTP/cidian_pos.txt");     //自定义词典的分词器(词典并不一定生效)
            Console.WriteLine("init success");
        }

        public static string pos(string source)
        {
            Console.WriteLine("source:" + source);
            byte[] byteUtf8 = Encoding.UTF8.GetBytes(source);
            /*
            for (int i = 0; i < byteUtf8.Length; i++)
            {
                Console.Write(byteUtf8[i].ToString("x2"));
            }
            Console.WriteLine();
             */
            string[] tokenArray = source.Split(" ");
            int num = tokenArray.Length;
            int length = num * 4;
            //int length = 1024;
            IntPtr tags = Marshal.AllocHGlobal(length);    //申请内存，注意内存上可能不干净，有别的数据,需要用下面的代码清0
            for (int i = 0; i < length; i++)
            {
                Marshal.WriteByte(tags, i, 0);     //内存清0
            }

            postagger_postag_csharp(parser, byteUtf8, tags);

            string resultStr = Marshal.PtrToStringUTF8(tags).Trim();
            Marshal.FreeHGlobal(tags);     //释放内存，否则会泄露
            string[] posArray = resultStr.Split(" ");
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < num; i++)
            {
                sb.Append(tokenArray[i]).Append("_").Append(posArray[i]).Append(" ");
            }
            return sb.ToString().Trim();
        }
    }
}