using HouseNumbers.BusinessLogic;
using HouseNumbers.BusinessLogic.Models;
using HouseNumbers.BusinessLogic.Sorting;
using Microsoft.Extensions.Options;

namespace HouseNumbers.App
{
    public class ConsoleApp(IParsingService parsingService, ISortingService sortingService, IOptions<ParseSettings> parseSettings)
    {
        readonly IParsingService parsingService = parsingService;
        readonly ISortingService sortingService = sortingService;
        readonly ParseSettings parseSettings = parseSettings.Value;

        public void Run()
        {
            var entries = parsingService.ParseCsv(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, parseSettings.FileName));
            sortingService.Sort(entries);

            Console.WriteLine(string.Join(',', entries));
        }
    }
}
