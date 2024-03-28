using HouseNumbers.BusinessLogic.Models;
using HouseNumbers.BusinessLogic.Parsing;
using HouseNumbers.BusinessLogic.Sorting;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HouseNumbers.App
{
    public class ConsoleApp(
        IParsingService parsingService, 
        SortingServiceFactory sortingServiceFactory, 
        IOptions<ParseSettings> parseSettings,
        IOptions<SortingSettings> sortingSettings)
    {
        readonly IParsingService parsingService = parsingService;
        readonly SortingServiceFactory sortingServiceFactory = sortingServiceFactory;
        readonly ParseSettings parseSettings = parseSettings.Value;
        readonly SortingSettings sortingSettings = sortingSettings.Value;

        public void Run()
        {
            // Print Settings used
            PrintSettings(parseSettings);
            PrintSettings(sortingSettings);

            // Get Entries from csv
            List<HouseNumberDetails> entries = parsingService.ParseCsv(parseSettings);

            // Get the requested SortingService based on the appsettings
            ISortingService sortingService = sortingServiceFactory.GetService(sortingSettings.Type);

            // Sort Entries in place
            sortingService.Sort(entries);

            // Print result
            Console.WriteLine(string.Join(',', entries));
        }

        private static void PrintSettings(object settings)
        {
            var json = JsonConvert.SerializeObject(settings, Formatting.Indented, new StringEnumConverter());
            Console.WriteLine($"{settings.GetType().Name}: {Environment.NewLine}{json}");
        }
    }
}
