using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using HouseNumbers.BusinessLogic.Models;
using HouseNumbers.BusinessLogic.Parsing;
using HouseNumbers.BusinessLogic.Sorting;
using Microsoft.Extensions.Options;

namespace HouseNumbers.Benchmark
{
    public class HouseNumberBenchmarking
    {
        BubbleSortService BubbleSortService { get; init; }
        QuickSortService QuickSortService { get; init; }
        ParsingService StaticParsingService { get; init; }
        ParsingService RegexParsingService { get; init; }
        List<HouseNumberDetails> Housenumbers { get; init; }

        public HouseNumberBenchmarking()
        {
            BubbleSortService = new BubbleSortService();
            QuickSortService = new QuickSortService();

            var staticParseSettings = new ParseSettings
            {
                AllowDuplicates = false,
                FileName = "dataset_Assessment_Dev_MA_25032024.csv",
                ColumnDelimiterType = ColumnDelimiterType.Both,
                SuffixValidationType = SuffixValidationType.Static,
                StaticSuffixValidation = new StaticSuffixValidation
                {
                    AllowedCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
                    MaxCharacters = 2
                }
            };

            var regexParseSettings = new ParseSettings
            {
                AllowDuplicates = false,
                FileName = "dataset_Assessment_Dev_MA_25032024.csv",
                ColumnDelimiterType = ColumnDelimiterType.Both,
                SuffixValidationType = SuffixValidationType.Regex,
                RegexSuffixValidation = new RegexSuffixValidation
                {
                    Regex = "^[A-Za-z]{1,2}$"
                }
            };
 
            StaticParsingService = new ParsingService(Options.Create(staticParseSettings));
            RegexParsingService = new ParsingService(Options.Create(regexParseSettings));
            Housenumbers = RegexParsingService.ParseCsv();
        }

        [Benchmark]
        public void Sorting__QuickSort() => QuickSortService.Sort(new List<HouseNumberDetails>(Housenumbers));

        [Benchmark]
        public void Sorting__BubbleSort() => BubbleSortService.Sort(new List<HouseNumberDetails>(Housenumbers));

        [Benchmark]
        public void Parsing__Static() => StaticParsingService.ParseCsv();

        [Benchmark]
        public void Parsing__Regex() => RegexParsingService.ParseCsv();
    }

    public class Program
    {
        public static void Main()
        {
            BenchmarkRunner.Run<HouseNumberBenchmarking>();
        }
    }
}
