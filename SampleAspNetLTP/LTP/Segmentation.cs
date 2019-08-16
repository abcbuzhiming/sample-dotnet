using System.Text;
using System.Runtime.InteropServices;
using System;

namespace SampleAspNetLTP.LTP
{
    public class Segmentation
    {
        //[DllImport(@"E:/NLP/LTP/lib/segmentor.dll")]      //引入C语言写的动态链接库文件，win下是dll，类Unix下是so文件
        [DllImport(@"E:/NLP/LTP/ltp-3.4.0-SourceCode/lib/Release/segmentor.dll")]
        public static extern IntPtr segmentor_create_segmentor(string modelPath,string lexiconFile = null);      //初始化分词器，得到分词器对象指针

        //[DllImport(@"E:/NLP/LTP/lib/segmentor.dll")]
        [DllImport(@"E:/NLP/LTP/ltp-3.4.0-SourceCode/lib/Release/segmentor.dll")]
        public static extern int segmentor_release_segmentor(IntPtr parser);        //释放分词器

        //[DllImport(@"E:/NLP/LTP/lib/segmentor.dll")]
        [DllImport(@"E:/NLP/LTP/ltp-3.4.0-SourceCode/lib/Release/segmentor.dll")]
        public static extern int segmentor_segment_csharp(IntPtr parser,byte[] inStr,IntPtr words);
        //public static extern int segmentor_segment_csharp(IntPtr parser,byte[] inStr,StringBuilder words);

        public static IntPtr parser;        //分词器的指针

        static Segmentation(){
            Console.WriteLine("init LTP!");
            Segmentation.parser = segmentor_create_segmentor(@"E:/NLP/LTP/ltp_data/cws.model");       //只使用模型的分词器
            //segmentor_create_segmentor(@"E:/NLP/LTP/ltp_data/cws.model",@"E:/NLP/LTP/cidian.txt");        //自定义词典的分词器(词典并不一定生效)
            Console.WriteLine("init success");
        }

        public static string splite(string source){
            Console.WriteLine("source:" + source);

            byte[] byteUtf8 = Encoding.UTF8.GetBytes(source);
            for (int i = 0; i < byteUtf8.Length; i++)
            {
                Console.Write(byteUtf8[i].ToString("x2"));
            }
            Console.WriteLine();
            
            int length = byteUtf8.Length + source.Length * 4;
            //int length = 1024;
            IntPtr words= Marshal.AllocHGlobal(length);    //申请内存，注意内存上可能不干净，有别的数据,需要用下面的代码清0
            for(int i=0; i < length; i++)
            {
                Marshal.WriteByte(words, i, 0);     //内存清0
            }
            
            segmentor_segment_csharp(parser,byteUtf8,words);

            string resultStr = Marshal.PtrToStringUTF8(words);
            Marshal.FreeHGlobal(words);     //释放内存，否则会泄露
            byte[] bytes = Encoding.UTF8.GetBytes(resultStr);
            for (int i = 0; i < bytes.Length; i++)
            {
                Console.Write(bytes[i].ToString("x2"));
            }
            
            return resultStr;
        }


        
    }
}