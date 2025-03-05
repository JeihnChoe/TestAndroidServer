using Android.Util;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using System;

namespace TestAndroidWebServer.Android
{

    [Route("")]
    [ApiController]
    public class ApiController : ControllerBase
    {

        [HttpGet("")]
        public IActionResult GetRoot()
        {
            return Content("ROOT", "application/json");
        }
        [HttpGet("order")]
        public IActionResult GetOrder()
        {
            return Content("ORDER", "application/json");
        }
        [HttpGet("path")]
        public IActionResult GetPath()
        {
            return Content("PATH", "application/json");
        }
        [HttpGet("gettest")]
        public IActionResult GetTestCommunication()
        {
            LogRequest("Testlog");
            return Content("GETTestCommunication", "application/json");
        }
        [HttpPost("posttest")]
        public IActionResult PostTestCommunication()
        {

            return Content("POSTTestCommunication", "application/json");
        }


        private void LogRequest(string logtag)
        {
            string method = Request.Method;
            string path = Request.Path.Value;
            string queryString = Request.QueryString.ToString();
            string remoteIp = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "Unknown";
            DateTime timestamp = DateTime.Now;

            string logMessage = $"{timestamp:yyyy-MM-dd HH:mm:ss} | {remoteIp} | {method} | {path}{queryString}";
            Log.Info(logtag, logMessage);

        }
    }
}
