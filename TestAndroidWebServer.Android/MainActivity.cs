using Android.App;
using Android.Content.PM;

using Avalonia;
using Avalonia.Android;
using TestAndroidWebServer.Android.Services;

namespace TestAndroidWebServer.Android;

[Activity(
    Label = "TestAndroidWebServer.Android",
    Theme = "@style/MyTheme.NoActionBar",
    Icon = "@drawable/icon",
    MainLauncher = true,
    ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize | ConfigChanges.UiMode)]
public class MainActivity : AvaloniaMainActivity<App>
{
    private WebServerService? _webServerService;
    protected override AppBuilder CustomizeAppBuilder(AppBuilder builder)
    {

        StartWebServer();

        return base.CustomizeAppBuilder(builder)
            .WithInterFont();
    }

    private async void StartWebServer()
    {
        _webServerService = new WebServerService();
        await _webServerService.StartAsync();
    }

    //프로그램 꺼질때 웹서버도 종료시켜줘야함.
    protected override void OnDestroy()
    {

        _webServerService?.StopAsync().GetAwaiter().GetResult();
        base.OnDestroy();
    }
}
