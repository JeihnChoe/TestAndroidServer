using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace TestAndroidWebServer.Android.Services
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
        [HttpGet("test")]
        public IActionResult GetTestCommunication()
        {
            return Content("TestCommunication", "application/json");
        }


    }


    public class WebServerService
    {

        string url = "http://0.0.0.0:8081";
        private IWebHost _webHost;

        public async Task StartAsync()
        {
            _webHost = new WebHostBuilder()
                .UseKestrel()
                .UseUrls(url)
                .ConfigureServices(services =>
                {

                    services.AddMvc()
                                 .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

                })
                .Configure(app =>
                {
                    //MVC 미들웨어 추가
                    app.UseMvc();

                })
                .Build();

            await _webHost.StartAsync();

        }

        public async Task StopAsync()
        {
            if (_webHost != null)
            {
                await _webHost.StopAsync();
                _webHost.Dispose();
                _webHost = null;
            }
        }
    }


}
