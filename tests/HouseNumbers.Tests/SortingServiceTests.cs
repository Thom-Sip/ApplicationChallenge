using FluentAssertions;
using HouseNumbers.BusinessLogic.Models;
using HouseNumbers.BusinessLogic.Sorting;
using Xunit;

namespace HouseNumbers.Tests
{
    public class SortingServiceTests
    {
        BubbleSortService BubbleSortService { get; init; }

        QuickSortService QuickSortService { get; set; }

        public SortingServiceTests()
        {
            BubbleSortService = new BubbleSortService();
            QuickSortService = new QuickSortService();
        }

        [Theory]
        [MemberData(nameof(SortingTestData))]
        public void BubbleSortTests<T>(List<HouseNumberDetails> input, List<HouseNumberDetails> expected)
        {
            // Sort dataset using BubbleSortService
            BubbleSortService.Sort(input);

            // make sure they sorted input matches the expected output
            string.Join(',', input).Should().Be(string.Join(',', expected));
        }

        [Theory]
        [MemberData(nameof(SortingTestData))]
        public void QuickSortTests(List<HouseNumberDetails> input, List<HouseNumberDetails> expected)
        {
            // Sort dataset using QuickSortService
            QuickSortService.Sort(input);

            // make sure they sorted input matches the expected output
            string.Join(',', input).Should().Be(string.Join(',', expected));
        }

        public static IEnumerable<object[]> SortingTestData()
        {
            List<object[]> data =
            [
                [
                    new List<HouseNumberDetails>
                    {
                        new() { Number = 2, Suffix = "A" },
                        new() { Number = 1, Suffix = "B" },
                        new() { Number = 2, Suffix = "B" },
                        new() { Number = 1 },
                        new() { Number = 1, Suffix = "A" },
                        new() { Number = 2 },
                    },
                    new List<HouseNumberDetails>
                    {
                        new() { Number = 1 },
                        new() { Number = 1, Suffix = "A" },
                        new() { Number = 1, Suffix = "B" },
                        new() { Number = 2 },
                        new() { Number = 2, Suffix = "A" },
                        new() { Number = 2, Suffix = "B" },
                    }
                ],
                [
                    new List<HouseNumberDetails>
                    {
                        new() { Number = 2, Suffix = "A" },
                        new() { Number = 1 },
                        new() { Number = 2 },
                    },
                    new List<HouseNumberDetails>
                    {
                        new() { Number = 1 },
                        new() { Number = 2 },
                        new() { Number = 2, Suffix = "A" },
                    }
                ]
            ];

            return data;
        }
    }
}