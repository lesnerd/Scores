using System;
using System.Threading.Tasks;
using BusinessLogic;
using DataAccessLayer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Model;
using Model.Options;
using Services.FileLocationRestService;

namespace Scores
{
    public class ScoresApp
    {
        private readonly ILogger _logger;
        private readonly IServiceProvider _serviceProvider;
        private IFlowProvider _flowProvider;

        public ScoresApp(ILogger<ScoresApp> logger, IServiceProvider serviceProvider, IFlowProvider flowProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
            _flowProvider = flowProvider;
        }

        internal async Task Run()
        {
            _logger.LogInformation("Application {applicationEvent} at {dateTime}", "Started", DateTime.UtcNow);
            IFileLocationProvider factory = null;
            Console.WriteLine("######################################\n" +
                              "### SELECT A SOURCE FOR FILE PATHS ###\n" +
                              "######################################\n" + 
                              "1) Database\n" + 
                              "2) Rest server\n" + 
                              "3) To quit ('Q' will work as well)\n\n\n" +
                              "Select a number: \n");

            var selection = Console.ReadLine();
            switch (selection)
            {
                case "1":
                    factory = (IFileLocationProvider)_serviceProvider.GetService(typeof(CDataAccessLayer));
                    break;
                case "2":
                    factory = (IFileLocationProvider)_serviceProvider.GetService(typeof(FileLocationService));
                    break;
                case "3":
                case "Q":
                case "q":
                    Environment.Exit(0);
                    break;
                default:
                    Environment.Exit(0);
                    break;
            }
            await _flowProvider.Execute(factory);


            Console.WriteLine("PRESS <ENTER> TO EXIT");
            _logger.LogInformation("Application {applicationEvent} at {dateTime}", "Ended", DateTime.UtcNow);
            Console.ReadKey();
        }
    }
}
