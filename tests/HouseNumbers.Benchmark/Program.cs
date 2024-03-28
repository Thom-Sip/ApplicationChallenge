using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using HouseNumbers.BusinessLogic;
using HouseNumbers.BusinessLogic.Models;
using HouseNumbers.BusinessLogic.Sorting;
using Microsoft.Extensions.Options;

namespace HouseNumbers.Benchmark
{
    public class HouseNumberBenchmarking
    {
        BubbleSortService BubbleSortService { get; init; }
        QuickSortService QuickSortService { get; init; }
        ParsingService ParsingService { get; init; }
        List<HouseNumberDetails> Housenumbers { get; init; }

        public HouseNumberBenchmarking()
        {
            BubbleSortService = new BubbleSortService();
            QuickSortService = new QuickSortService();

            var parseSettingsOptions = Options.Create( 
                new ParseSettings
                {
                    AllowDuplicates = false,
                    // Relative Path from benchmark output dir to input file.
                    // Not the cleanest solution, but this prevents us from duplicating the input file into 2 projects
                    FileName = "../../../../../src/HouseNumbers.ConsoleApp/dataset_Assessment_Dev_MA_25032024.csv"
                });

            ParsingService = new ParsingService(parseSettingsOptions);
            Housenumbers = ParsingService.ParseCsv();
        }

        [Benchmark]
        public void QuickSort() => QuickSortService.Sort(new List<HouseNumberDetails>(Housenumbers));

        [Benchmark]
        public void BubbleSort() => BubbleSortService.Sort(new List<HouseNumberDetails>(Housenumbers));
    }

    public class Program
    {
        public static void Main()
        {
            BenchmarkRunner.Run<HouseNumberBenchmarking>();
        }
    }
}
