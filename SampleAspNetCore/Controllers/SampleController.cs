using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SampleAspNetCore.Models;

/**
基本范例控制器
 */
namespace SampleAspNetCore.Controllers
{
    public class SampleController: Controller
    {
        public string hello(){
            return "sample hello";
        }

        public IActionResult helloJson(){
            Dictionary<string,string> dictionary = new Dictionary<string,string>();
            dictionary.Add("key1","value1");
            return Json(dictionary);
        }
        /*
        跳转范例
         */
        public IActionResult redirect(){
            return this.Redirect("/sample/hello");
        }
    }

    
}