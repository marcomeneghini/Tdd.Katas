using System;
using System.Collections.Generic;
using Xunit;

namespace Tdd.Katas.PrimeFactorsLib.Tests
{
    public class PrimeFactorsTests
    {
        [Fact]
        public void Generate_when1_then1()
        {
            List<int> expected = new List<int>() {1};
            var actual = PrimeFactors.Generate(1);


            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Generate_when2_then2()
        {
            List<int> expected = new List<int>() {2};
            var actual = PrimeFactors.Generate(2);


            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Generate_when3_then3()
        {
            List<int> expected = new List<int>() {3};
            var actual = PrimeFactors.Generate(3);


            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Generate_when4_then2_2()
        {
            List<int> expected = new List<int>() {2, 2};
            var actual = PrimeFactors.Generate(4);


            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Generate_when6_then2_3()
        {
            List<int> expected = new List<int>() {2, 3};
            var actual = PrimeFactors.Generate(6);


            Assert.Equal(expected, actual);
        }


        [Fact]
        public void Generate_when8_then2_2_2()
        {
            List<int> expected = new List<int>() {2, 2, 2};
            var actual = PrimeFactors.Generate(8);


            Assert.Equal(expected, actual);



        }

        [Fact]
        public void Generate_when9_then3_3()
        {
            List<int> expected = new List<int>() {3,3 };
            var actual = PrimeFactors.Generate(9);


            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Generate_when19_then19()
        {
            List<int> expected = new List<int>() { 19};
            var actual = PrimeFactors.Generate(19);


            Assert.Equal(expected, actual);
        }
    }
}
