using FluentAssertions;
using HouseNumbers.BusinessLogic.Models;
using Xunit;

namespace HouseNumbers.Tests
{
    public class HouseNumberTests
    {
        [Theory]
        [MemberData(nameof(HouseNumberDetailsTestData))]
        public void CompareShouldReturnCorrectResult(HouseNumber first, HouseNumber? second, int result)
        {
            first.CompareTo(second).Should().Be(result);
        }

        public static IEnumerable<object?[]> HouseNumberDetailsTestData()
        {
            List<object?[]> data =
            [
                // First input is greater than 2nd input
                [
                    new HouseNumber { Number = 1 },
                    null,
                    1
                ],
                [
                    new HouseNumber { Number = 2 },
                    new HouseNumber { Number = 1 },
                    1
                ],
                [
                    new HouseNumber { Number = 2, Suffix = "B" },
                    new HouseNumber { Number = 2, Suffix = "A" },
                    1
                ],
                [
                    new HouseNumber { Number = 2, Suffix = "BB" },
                    new HouseNumber { Number = 2, Suffix = "BA" },
                    1
                ],
                [
                    new HouseNumber { Number = 2, Suffix = "A" },
                    new HouseNumber { Number = 2 },
                    1
                ],
                // Inputs are equal
                [
                    new HouseNumber { Number = 1 },
                    new HouseNumber { Number = 1 },
                    0
                ],
                [
                    new HouseNumber { Number = 1, Suffix = "A" },
                    new HouseNumber { Number = 1, Suffix = "A" },
                    0
                ],
                // First input is smaller than 2nd input
                [
                    new HouseNumber { Number = 1 },
                    new HouseNumber { Number = 2 },
                    -1
                ],
                [
                    new HouseNumber { Number = 2, Suffix = "A" },
                    new HouseNumber { Number = 2, Suffix = "B" },
                    -1
                ],
                [
                    new HouseNumber { Number = 2 },
                    new HouseNumber { Number = 2, Suffix = "A" },
                    -1
                ],
            ];

            return data;
        }
    }
}
