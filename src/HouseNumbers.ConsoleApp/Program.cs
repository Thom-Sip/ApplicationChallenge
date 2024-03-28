﻿using HouseNumbers.BusinessLogic;
using HouseNumbers.BusinessLogic.Models;
using HouseNumbers.BusinessLogic.Sorting;
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
            SetupDependencyInjection(builder.Services, configuration);

            using IHost host = builder.Build();
            ServiceLifeTime(host.Services);
        }

        static void SetupDependencyInjection(IServiceCollection services, IConfigurationRoot configuration)
        {
            services.AddScoped<IConfiguration>(_ => configuration);

            services.AddScoped<IParsingService, ParsingService>();
            services.AddSingleton<SortingServiceFactory>();
            services.AddSingleton<ConsoleApp>();

            services.AddOptions<ParseSettings>()
                .Bind(configuration.GetSection(nameof(ParseSettings)));

            services.AddOptions<SortingSettings>()
                .Bind(configuration.GetSection(nameof(SortingSettings)));
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
