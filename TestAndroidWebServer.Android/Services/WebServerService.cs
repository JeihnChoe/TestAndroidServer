using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace TestAndroidWebServer.Android.Services
{
    public class WebServerService
    {

        string url = "http://0.0.0.0:8080";
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
