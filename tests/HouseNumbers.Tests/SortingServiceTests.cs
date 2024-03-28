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
        public void BubbleSortAscendingTests<T>(List<HouseNumberDetails> input, List<HouseNumberDetails> expected)
        {
            // Sort dataset using BubbleSortService
            BubbleSortService.Sort(input, SortOrder.Ascending);

            // make sure the sorted input matches the expected output
            string.Join(',', input).Should().Be(string.Join(',', expected));
        }

        [Theory]
        [MemberData(nameof(SortingTestData))]
        public void BubbleSortDescendingTests<T>(List<HouseNumberDetails> input, List<HouseNumberDetails> expected)
        {
            // Sort dataset using BubbleSortService
            BubbleSortService.Sort(input, SortOrder.Descending);

            // make sure the sorted input matches the expected output
            expected.Reverse();
            string.Join(',', input).Should().Be(string.Join(',', expected));
        }

        [Theory]
        [MemberData(nameof(SortingTestData))]
        public void QuickSortAscendingTests(List<HouseNumberDetails> input, List<HouseNumberDetails> expected)
        {
            // Sort dataset using QuickSortService
            QuickSortService.Sort(input, SortOrder.Ascending);

            // make sure the sorted input matches the expected output
            string.Join(',', input).Should().Be(string.Join(',', expected));
        }

        [Theory]
        [MemberData(nameof(SortingTestData))]
        public void QuickSortDescendingTests(List<HouseNumberDetails> input, List<HouseNumberDetails> expected)
        {
            // Sort dataset using QuickSortService
            QuickSortService.Sort(input, SortOrder.Descending);

            // make sure the sorted input matches the expected output
            expected.Reverse();
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
                        new() { Number = 2, Suffix = "BB" },
                        new() { Number = 1 },
                        new() { Number = 1, Suffix = "A" },
                        new() { Number = 2 },
                        new() { Number = 2, Suffix = "BA" },
                    },
                    new List<HouseNumberDetails>
                    {
                        new() { Number = 1 },
                        new() { Number = 1, Suffix = "A" },
                        new() { Number = 1, Suffix = "B" },
                        new() { Number = 2 },
                        new() { Number = 2, Suffix = "A" },
                        new() { Number = 2, Suffix = "B" },
                        new() { Number = 2, Suffix = "BA" },
                        new() { Number = 2, Suffix = "BB" },
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