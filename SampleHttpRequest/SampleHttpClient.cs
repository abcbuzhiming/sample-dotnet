using System;
using System.Text;
using System.Net.Http;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Security;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Web;

namespace SampleHttpRequest
{
    /// <summary>
    /// 使用HttpClient的例子
    /// </summary>
    public class SampleHttpClient
    {
        public static async void samplePost(){
             var url = new Uri(@"http://127.0.0.1:8080/ccnu-study-schedule-butler-system/app/infoVersion", UriKind.Absolute);
            var httpClient = new HttpClient();
            //httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));        //Accept头
            HttpContent httpContent = new StringContent("type=1");
            //HttpContent httpContent = new StringContent("{'type':1}");
            //httpContent.Headers.ContentType= new MediaTypeHeaderValue("application/json");
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
            //Console.WriteLine(httpContent.ToString());
            var reponse = await httpClient.PostAsync(url, httpContent);
            String result = await reponse.Content.ReadAsStringAsync();
            Console.WriteLine("result:" + result);
            
        }
    }
}