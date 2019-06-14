using System.Text;
using System.Runtime.InteropServices;
using System;

namespace SampleBindCppCode
{
    class Program
    {
        //[DllImport(@"F:/THULAC_pro_c++_v1/libthulac.dll")]      //引入C语言写的动态链接库文件，win下是dll，类Unix下是so文件
        [DllImport(@"/usr/local/src/THULAC/libthulac.so")]
        public static extern int init(string model_path = null, string user_dict_path = null, int ret_size = 1024 * 1024 * 16, int t2s = 0, int just_seg = 0);

        //[DllImport(@"F:/THULAC_pro_c++_v1/libthulac.dll")]
        [DllImport(@"/usr/local/src/THULAC/libthulac.so")]  
        public static extern int seg(byte[] inStr);

        //[DllImport(@"F:/THULAC_pro_c++_v1/libthulac.dll")]
        [DllImport(@"/usr/local/src/THULAC/libthulac.so")]
        public static extern IntPtr getResult();
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Bind Cpp Code!");

            //init(model_path: @"F:/THULAC_pro_c++_v1/models");
            init(model_path:@"/usr/local/src/THULAC/models");
            Console.WriteLine("初始化成功");

            string inputStr = "我去你妈的终于成功了";
            byte[] utf8 = Encoding.UTF8.GetBytes(inputStr);
            


            var count = seg(utf8);
            Console.WriteLine("seg结果:" + count);
            var result = getResult();
            Console.WriteLine("获得结果ptr:" + result);
            String resultStr = PtrToStringUtf8(result);
            Console.WriteLine("获得结果resultStr:" + resultStr);
            Console.WriteLine("process end!");
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
