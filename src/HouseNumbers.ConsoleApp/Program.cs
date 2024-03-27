using HouseNumbers.BusinessLogic;

namespace HouseNumbers.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var csvParser = new ParsingService();
            var entries = csvParser.ParseCsv("D:/dataset_Assessment_Dev_MA_25032024.csv");

            var sorter = new BubbleSortService();
            sorter.Sort(entries);

            for (int i = 0; i < entries.Count; i++)
                Console.WriteLine(entries[i]);
        }
    }
}
