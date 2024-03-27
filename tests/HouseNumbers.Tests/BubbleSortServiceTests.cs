using FluentAssertions;
using HouseNumbers.BusinessLogic;
using HouseNumbers.BusinessLogic.Models;

namespace HouseNumbers.Tests
{
    public class BubbleSortServiceTests
    {
        ISortingService service { get; init; }

        public BubbleSortServiceTests()
        {
            service = new BubbleSortService();
        }

        [Theory]
        [ClassData(typeof(SortingTestData))]
        public void ResultShouldBeSorted(List<HouseNumberDetails> input, List<HouseNumberDetails> expected)
        {
            // Convert expected result to string for easy comparison
            var outputAString = string.Join(',', expected);

            // sort the input
            service.Sort(input);

            // convert sorted input to string
            var sortedInputString = string.Join(',', input);

            // make sure they match
            sortedInputString.Should().Be(outputAString);
        }
    }

    public class SortingTestData() : IEnumerable<object[]>
    {
        private static readonly List<object[]> _data =
        [
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
            ],
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
        ];

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
    }
}