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
        public void BubbleSortAscendingTests<T>(List<HouseNumber> input, List<HouseNumber> expected)
        {
            // Sort dataset using BubbleSortService
            BubbleSortService.Sort(input, SortOrder.Ascending);

            // make sure the sorted input matches the expected output
            string.Join(',', input).Should().Be(string.Join(',', expected));
        }

        [Theory]
        [MemberData(nameof(SortingTestData))]
        public void BubbleSortDescendingTests<T>(List<HouseNumber> input, List<HouseNumber> expected)
        {
            // Sort dataset using BubbleSortService
            BubbleSortService.Sort(input, SortOrder.Descending);

            // make sure the sorted input matches the expected output
            expected.Reverse();
            string.Join(',', input).Should().Be(string.Join(',', expected));
        }

        [Theory]
        [MemberData(nameof(SortingTestData))]
        public void QuickSortAscendingTests(List<HouseNumber> input, List<HouseNumber> expected)
        {
            // Sort dataset using QuickSortService
            QuickSortService.Sort(input, SortOrder.Ascending);

            // make sure the sorted input matches the expected output
            string.Join(',', input).Should().Be(string.Join(',', expected));
        }

        [Theory]
        [MemberData(nameof(SortingTestData))]
        public void QuickSortDescendingTests(List<HouseNumber> input, List<HouseNumber> expected)
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
                    new List<HouseNumber>
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
                    new List<HouseNumber>
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
                    new List<HouseNumber>
                    {
                        new() { Number = 2, Suffix = "A" },
                        new() { Number = 1 },
                        new() { Number = 2 },
                    },
                    new List<HouseNumber>
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