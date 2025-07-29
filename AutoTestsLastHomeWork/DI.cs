using Allure;
using AutoTestsLastHomeWork.Helpers;
using AutoTestsLastHomeWork.Helpers.APIHelpers;
using AutoTestsLastHomeWork.Pages;
using Microsoft.Extensions.DependencyInjection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using RestAPI;

namespace AutoTestsLastHomeWork;

public static class DI
{
    private static readonly Lazy<IServiceProvider> _serviceProvider = new Lazy<IServiceProvider>(Configure);

    public static IServiceProvider ServiceProvider => _serviceProvider.Value;
    public static IWebDriver Driver => ServiceProvider.GetRequiredService<IWebDriver>();

    public static BaseHelper BaseHelper => ServiceProvider.GetRequiredService<BaseHelper>();
    public static AuthHelper AuthHelper => ServiceProvider.GetRequiredService<AuthHelper>();
    public static InventoryListHelper InventoryListHelper => ServiceProvider.GetRequiredService<InventoryListHelper>();
    public static AllureReportHelper AllureReportHelper => ServiceProvider.GetRequiredService<AllureReportHelper>();
    public static APIHelper APIHelper => ServiceProvider.GetRequiredService<APIHelper>();

    public static RestAPIHelper RestApiHelper => ServiceProvider.GetRequiredService<RestAPIHelper>();


    public static ServiceProvider Configure()
    {
        var services = new ServiceCollection();

        //IWebDriver
        services.AddSingleton<IWebDriver>(provider =>
        {
            var options = new ChromeOptions();
            options.PageLoadStrategy = PageLoadStrategy.Eager;
            return new ChromeDriver(options);
        });

        //Helpers
        services.AddScoped<BaseHelper>();
        services.AddScoped<AuthHelper>();
        services.AddScoped<InventoryListHelper>();
        services.AddScoped<APIHelper>();
        
        //Allure
        services.AddScoped<AllureReportHelper>();

        //REST
        services.AddScoped<RestAPIHelper>();

        return services.BuildServiceProvider();
    }

}
