using HouseNumbers.BusinessLogic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HouseNumbers.App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .AddJsonFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "appsettings.json"))
                .AddEnvironmentVariables()
                .Build();

            HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

            builder.Services.AddScoped<IConfiguration>(_ => configuration);
            builder.Services.AddScoped<IParsingService, ParsingService>();
            builder.Services.AddScoped<ISortingService, BubbleSortService>();
            builder.Services.AddSingleton<ConsoleApp>();

            using IHost host = builder.Build();
            ServiceLifeTime(host.Services);
        }

        static void ServiceLifeTime(IServiceProvider hostProvider)
        {
            using IServiceScope serviceScope = hostProvider.CreateScope();
            IServiceProvider provider = serviceScope.ServiceProvider;

            var app = hostProvider.GetRequiredService<ConsoleApp>();
            app.Run();
        }
    }
}
