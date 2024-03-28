using HouseNumbers.BusinessLogic;
using HouseNumbers.BusinessLogic.Models;
using HouseNumbers.BusinessLogic.Sorting;
using Microsoft.Extensions.Options;

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
            // Get Entries from csv
            List<HouseNumberDetails> entries = parsingService.ParseCsv(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, parseSettings.FileName));

            // Get the requested SortingService based on the appsettings
            ISortingService sortingService = sortingServiceFactory.GetService(sortingSettings.Type);

            // Sort Entries in place
            sortingService.Sort(entries);

            // Print result
            Console.WriteLine(string.Join(',', entries));
        }
    }
}
