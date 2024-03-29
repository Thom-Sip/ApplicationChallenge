using BenchmarkDotNet.Attributes;
using HouseNumbers.BusinessLogic.Models;
using HouseNumbers.BusinessLogic.Parsing;
using HouseNumbers.BusinessLogic.Sorting;

namespace HouseNumbers.Benchmark
{
    public class HouseNumberBenchmarking
    {
        BubbleSortService BubbleSortService { get; init; }
        QuickSortService QuickSortService { get; init; }
        ParsingService ParsingService { get; init; }
        List<HouseNumber> Housenumbers { get; init; }
        ParseSettings ParseSettings { get; init; }

        public HouseNumberBenchmarking()
        {
            BubbleSortService = new BubbleSortService();
            QuickSortService = new QuickSortService();

            ParseSettings = new ParseSettings
            {
                AllowDuplicates = false,
                FileName = "dataset_Assessment_Dev_MA_25032024.csv",
                ColumnDelimiterType = ColumnDelimiterType.Both,
                SuffixValidationRegex = "^[A-Za-z]{1,2}$"
            };

            ParsingService = new ParsingService();
            Housenumbers = ParsingService.ParseCsv(ParseSettings);
        }

        [Benchmark]
        public void Parsing() => ParsingService.ParseCsv(ParseSettings);

        [Benchmark]
        public void Sorting__BubbleSort() => BubbleSortService.Sort(new List<HouseNumber>(Housenumbers), SortOrder.Ascending);

        [Benchmark]
        public void Sorting__QuickSort() => QuickSortService.Sort(new List<HouseNumber>(Housenumbers), SortOrder.Ascending);
    }
}
