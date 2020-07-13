using System;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace Tdd.Katas.RomanNumbersLib.Tests
{
    public class RomanNumbersGeneratorTests
    {
        [Fact]
        public void Generate_when1_thenI()
        {
            var actual = RomanNumbersGenerator.Generate(1);

            Assert.Equal("I", actual);
        }

        [Fact]
        public void Generate_when2_thenII()
        {
            var actual = RomanNumbersGenerator.Generate(2);

            Assert.Equal("II", actual);
        }

        [Theory]
        [InlineData(1,"I")]
        [InlineData(2, "II")]
        [InlineData(3, "III")]
        [InlineData(4, "IV")]
        [InlineData(5, "V")]
        [InlineData(6, "VI")]
        [InlineData(7, "VII")]
        [InlineData(8, "VIII")]
        [InlineData(9, "IX")]
        [InlineData(10, "X")]
        public void Generate_1to10(int number, string expected)
        {
            var actual = RomanNumbersGenerator.Generate(number);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(11, "XI")]
        [InlineData(12, "XII")]
        [InlineData(13, "XIII")]
        [InlineData(14, "XIV")]
        [InlineData(15, "XV")]
        [InlineData(16, "XVI")]
        [InlineData(17, "XVII")]
        [InlineData(18, "XVIII")]
        [InlineData(19, "XIX")]
        [InlineData(20, "XX")]
        public void Generate_11to20(int number, string expected)
        {
            var actual = RomanNumbersGenerator.Generate(number);

            Assert.Equal(expected, actual);
        }
    }
}
