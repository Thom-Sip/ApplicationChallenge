using HouseNumbers.BusinessLogic;

namespace HouseNumbers.App
{
    public class ConsoleApp
    {
        readonly IParsingService parsingService;
        readonly ISortingService sortingService;

        public ConsoleApp(IParsingService parsingService, ISortingService sortingService)
        {
            this.parsingService = parsingService;
            this.sortingService = sortingService;
        }

        public void Run()
        {
            var entries = parsingService.ParseCsv(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "dataset_Assessment_Dev_MA_25032024.csv"));
            sortingService.Sort(entries);

            for (int i = 0; i < entries.Count; i++)
                Console.WriteLine(entries[i]);
        }
    }
}
