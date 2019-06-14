using System.Text;
using System.Runtime.InteropServices;
using System;

namespace SampleAspNetTHULAC.THULAC
{
    /// <summary>
    /// THULAC分词工具类，使用THUAC
    /// </summary>
    public class Segmentation
    {
        [DllImport(@"F:/THULAC_pro_c++_v1/libthulac.dll")]      //引入C语言写的动态链接库文件，win下是dll，类Unix下是so文件
        //[DllImport(@"/usr/local/src/THULAC/libthulac.so")]
        public static extern int init(string model_path = null, string user_dict_path = null, int ret_size = 1024 * 1024 * 16, int t2s = 0, int just_seg = 0);

        [DllImport(@"F:/THULAC_pro_c++_v1/libthulac.dll")]
        //[DllImport(@"/usr/local/src/THULAC/libthulac.so")]  
        public static extern int seg(byte[] inStr);

        [DllImport(@"F:/THULAC_pro_c++_v1/libthulac.dll")]
        //[DllImport(@"/usr/local/src/THULAC/libthulac.so")]
        public static extern IntPtr getResult();

        static Segmentation(){
            Console.WriteLine("init THULAC!");
            init(model_path: @"F:/THULAC_pro_c++_v1/models");       //传入模型路径
            //init(model_path:@"/usr/local/src/THULAC/models");
            Console.WriteLine("初始化成功");
        }

        public static string splite(string source){
            byte[] utf8 = Encoding.UTF8.GetBytes(source);
            var count = seg(utf8);
            Console.WriteLine("seg结果:" + count);
            var result = getResult();
            Console.WriteLine("获得结果ptr:" + result);
            String resultStr = PtrToStringUtf8(result);
            Console.WriteLine("获得结果resultStr:" + resultStr);

            return resultStr;
        }
        private static string PtrToStringUtf8(IntPtr ptr) // aPtr is nul-terminated
        {
            if (ptr == IntPtr.Zero)
                return "";
            int len = 0;
            while (System.Runtime.InteropServices.Marshal.ReadByte(ptr, len) != 0)
                len++;
            if (len == 0)
                return "";
            byte[] array = new byte[len];
            System.Runtime.InteropServices.Marshal.Copy(ptr, array, 0, len);
            return System.Text.Encoding.UTF8.GetString(array);
        }
    }
}