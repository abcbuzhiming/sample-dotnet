using System.Text;
using System.Runtime.InteropServices;
using System;

namespace SampleAspNetLTP.LTP
{
    public class Segmentation
    {
        [DllImport(@"E:/NLP/LTP/lib/segmentor.dll")]      //引入C语言写的动态链接库文件，win下是dll，类Unix下是so文件
        public static extern IntPtr segmentor_create_segmentor(string modelPath,string lexiconFile = null);      //初始化分词器，得到分词器对象指针

        [DllImport(@"E:/NLP/LTP/lib/segmentor.dll")]
        public static extern int segmentor_release_segmentor(IntPtr parser);        //释放分词器

        [DllImport(@"E:/NLP/LTP/lib/segmentor.dll")]
        public static extern int segmentor_segment(IntPtr parser,string source,IntPtr words);

        public static IntPtr parser;        //分词器的指针

        static Segmentation(){
            Console.WriteLine("init LTP!");
            Segmentation.parser = segmentor_create_segmentor(@"E:/NLP/LTP/ltp_data/cws.model");       //只使用模型的分词器
            //segmentor_create_segmentor(@"E:/NLP/LTP/ltp_data/cws.model",@"E:/NLP/LTP/cidian.txt");        //自定义词典的分词器(词典并不一定生效)
            Console.WriteLine("init success");
        }

        public static string splite(string source){
            string resultStr = source;
            return resultStr;
        }
    }
}