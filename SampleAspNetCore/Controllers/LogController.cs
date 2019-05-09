using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SampleAspNetCore.Models;


namespace SampleAspNetCore.Controllers {
    /**
    打印日志
    */
    public class LogController : Controller {
        private readonly ILogger _logger;

        public LogController (
            ILogger<LogController> logger) {
            _logger = logger;
        }
        public string hello () {
            _logger.LogInformation(111,"_logger:hello log");
            
            return "hello log";
        }
    }
}