using System.Configuration;
using System.Reflection;
using System.Runtime.InteropServices;
using DerivSmartRobot;
using DerivSmartRobot.Domain.Enums;
using DerivSmartRobot.Interfaces.Services;
using DerivSmartRobot.Models.Classes;
using DerivSmartRobot.Pages;
using DerivSmartRobot.Redis;
using DerivSmartRobot.Robots;
using DerivSmartRobot.Services;
using MediatR;
using NuGet.Packaging;



internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [MTAThread]
    static async Task Main()
    {

        var services = new ServiceCollection();
        ConfigureServices(services);

        var serviceProvider = ServiceCollectionContainerBuilderExtensions.BuildServiceProvider(services
            .AddLogging());

        Application.SetHighDpiMode(HighDpiMode.SystemAware);
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);


        //Application.Run(new Login(serviceProvider));
        Application.Run(new Login(serviceProvider));
        AllocConsole();
    }

    [DllImport("kernel32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool AllocConsole();
    static void ConfigureServices(ServiceCollection services)
    {
        services.AddSingleton<IClientDeriv, DerivClient>();
        services.AddSingleton<ITradeService, TradeService>();
        services.AddSingleton<HostedService>();

        services.AddSingleton<ITendencyWithAiRobot, TendencyWithAi>();
        services.AddSingleton<IDigitAiPrediction, DigitAiPrediction>();
        services.AddSingleton<IFractalRobot, FractalRobot>();


        services.AddSingleton<AIService>();


        services.AddTransient<ReaderService>();
        services.AddTransient<IAuthService, AuthService>();



    }
}








