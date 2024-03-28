using FluentAssertions;
using HouseNumbers.BusinessLogic.Models;
using System.Collections;
using Xunit;

namespace HouseNumbers.Tests
{
    public class HouseNumberDetailsTests
    {
        [Theory]
        [MemberData(nameof(HouseNumberDetailsTestData))]
        public void CompareShouldReturnCorrectResult(HouseNumberDetails first, HouseNumberDetails? second, int result)
        {
            first.CompareTo(second).Should().Be(result);
        }

        public static IEnumerable<object[]?> HouseNumberDetailsTestData()
        {
            List<object[]?> data =
            [
                // First input is greater than 2nd input
                [
                    new HouseNumberDetails { Number = 1 },
                    null,
                    1
                ],
                [
                    new HouseNumberDetails { Number = 2 },
                    new HouseNumberDetails { Number = 1 },
                    1
                ],
                [
                    new HouseNumberDetails { Number = 2, Suffix = "B" },
                    new HouseNumberDetails { Number = 2, Suffix = "A" },
                    1
                ],
                [
                    new HouseNumberDetails { Number = 2, Suffix = "A" },
                    new HouseNumberDetails { Number = 2 },
                    1
                ],
                // Inputs are equal
                [
                    new HouseNumberDetails { Number = 1 },
                    new HouseNumberDetails { Number = 1 },
                    0
                ],
                [
                    new HouseNumberDetails { Number = 1, Suffix = "A" },
                    new HouseNumberDetails { Number = 1, Suffix = "A" },
                    0
                ],
                // First input is smaller than 2nd input
                [
                    new HouseNumberDetails { Number = 1 },
                    new HouseNumberDetails { Number = 2 },
                    -1
                ],
                [
                    new HouseNumberDetails { Number = 2, Suffix = "A" },
                    new HouseNumberDetails { Number = 2, Suffix = "B" },
                    -1
                ],
                [
                    new HouseNumberDetails { Number = 2 },
                    new HouseNumberDetails { Number = 2, Suffix = "A" },
                    -1
                ],
            ];

            return data;
        }
    }
}
