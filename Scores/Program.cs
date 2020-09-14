using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using BusinessLogic;
using BusinessLogic.SumNumber;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Model;
using Services;
using Services.File;
using Services.FileLocationRestService;
using MediatR;
using Microsoft.Extensions.Configuration;
using Model.Options;

namespace Scores
{
    class Program
    {
        public static IConfiguration configuration;

        static async Task Main(string[] args)
        {
            configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
                .AddJsonFile("appsettings.json", false)
                .Build();

            var builder = new HostBuilder()
                .ConfigureServices((hostContext, services) =>
                {

                    services.AddLogging(configure => configure.AddConsole())
                        .AddTransient<ScoresApp>()
                        .AddScoped<IFileProcessor, FileProcessor>()
                        .AddScoped<CDataAccessLayer>().AddScoped<IFileLocationProvider, CDataAccessLayer>(s => s.GetService<CDataAccessLayer>())
                        .AddScoped<FileLocationService>().AddScoped<IFileLocationProvider, FileLocationService>(s => s.GetService<FileLocationService>())
                        .AddScoped<IFlowProvider, FlowProvider>()
                        .AddMediatR(Assembly.GetExecutingAssembly())
                        .AddTransient<IRequestHandler<SumNumberCommand, Unit>, SumNumberCommandHandler>()
                        .AddSingleton<IConfiguration>(configuration)
                        .AddDbContext<VaronisTestContext>(options =>
                        {
                            options.UseSqlServer("Data Source=localhost;Initial Catalog=Varonis-Test;User ID=sa;Password=Abcd1234");
                        });
                }).UseConsoleLifetime();

            var host = builder.Build();
            

            using (var serviceScope = host.Services.CreateScope())
            {
                var services = serviceScope.ServiceProvider;

                try
                {
                    var myService = services.GetRequiredService<ScoresApp>();
                    await myService.Run();

                    Console.WriteLine("Success");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error Occured");
                }
            }
        }
    }
}
