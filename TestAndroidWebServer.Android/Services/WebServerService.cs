using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace TestAndroidWebServer.Android.Services
{
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

                })
                .Configure(app =>
                {

                    app.Map("", statusApp =>
                    statusApp.Run(async context =>
                    {
                        context.Response.ContentType = "application/json";
                        await context.Response.WriteAsync("Root 다");
                    }
                    ));

                    app.Map("/path", statusApp =>
                    statusApp.Run(async context =>
                    {
                        context.Response.ContentType = "application/json";
                        await context.Response.WriteAsync("패쓰 1이다");
                    }
                    ));

                    app.Map("/path1", statusApp =>
                    statusApp.Run(async context =>
                    {
                        context.Response.ContentType = "application/json";
                        await context.Response.WriteAsync("패쓰 2다 ");
                    }
                    ));
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

    // API 핸들러 인터페이스
    public interface IApiHandler
    {
        string Path { get; }
        Task HandleAsync(HttpContext context);
    }


}
