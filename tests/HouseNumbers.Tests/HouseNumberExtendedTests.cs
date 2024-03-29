using FluentAssertions;
using HouseNumbers.BusinessLogic.Models;
using Xunit;

namespace HouseNumbers.Tests
{
    public class HouseNumberExtendedTests
    {
        [Theory]
        [MemberData(nameof(HouseNumberDetailsTestData))]
        public void CompareShouldReturnCorrectResult(HouseNumberExtended first, HouseNumberExtended? second, int result)
        {
            first.CompareTo(second).Should().Be(result);
        }

        public static IEnumerable<object?[]> HouseNumberDetailsTestData()
        {
            List<object?[]> data =
            [
                // First input is greater than 2nd input
                [
                    new HouseNumberExtended { Number = 1, Suffix= "A", SuffixExtra = 1 },
                    new HouseNumberExtended { Number = 1, Suffix = "A", },
                    1
                ],
                [
                    new HouseNumberExtended { Number = 1, Suffix = "B", SuffixExtra = 1 },
                    new HouseNumberExtended { Number = 1, Suffix = "A", SuffixExtra = 12 },
                    1
                ],
                [
                    new HouseNumberExtended { Number = 12, },
                    new HouseNumberExtended { Number = 1, Suffix = "B", SuffixExtra = 14 },
                    1
                ],
                [
                    new HouseNumberExtended { Number = 2, },
                    new HouseNumberExtended { Number = 1, Suffix = "BA" },
                    1
                ],
                [
                    new HouseNumberExtended { Number = 1, Suffix = "BB" },
                    new HouseNumberExtended { Number = 1, Suffix = "BA" },
                    1
                ],
                [
                    new HouseNumberExtended { Number = 1, Suffix = "A", SuffixExtra = 22 },
                    new HouseNumberExtended { Number = 1, Suffix = "A", SuffixExtra = 9 },
                    1
                ],
                // Inputs are equal
                [
                    new HouseNumberExtended { Number = 1, Suffix = "BB" },
                    new HouseNumberExtended { Number = 1, Suffix = "BB" },
                    0
                ],
                [
                    new HouseNumberExtended { Number = 1, Suffix = "BB", SuffixExtra = 12 },
                    new HouseNumberExtended { Number = 1, Suffix = "BB", SuffixExtra = 12 },
                    0
                ],
                // First input is smaller than 2nd input
                [
                    new HouseNumberExtended { Number = 1, Suffix = "A", SuffixExtra = 9 },
                    new HouseNumberExtended { Number = 1, Suffix = "A", SuffixExtra = 88 },
                    -1
                ],
                [
                    new HouseNumberExtended { Number = 1, Suffix = "A", SuffixExtra = 99 },
                    new HouseNumberExtended { Number = 1, Suffix = "B", },
                    -1
                ],
            ];

            return data;
        }
    }
}
