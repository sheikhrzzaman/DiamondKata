using System;
using DiamondKata.Services;
using DiamondKata.Validations;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace DiamondKata
{
    public static class Startup
    {
        public static IServiceCollection ConfigureServices()
        {
            var services = new ServiceCollection();

            Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File($"NewDay-DiamondPrint-{DateTime.Now:yyyy-MM-dd-HH-mm-ss}.log")
            .CreateLogger();

            services.AddLogging(configure => configure.AddSerilog());

            services.AddSingleton<IConsoleApplication, ConsoleApplication>();
            services.AddSingleton<IValidator<string>, PrintDiamondValidator>();
            services.AddSingleton<IDiamondService, DiamondService>();

            services.AddSingleton<ILetterNumberService, LetterNumberService>();

            return services;
        }
    }
}