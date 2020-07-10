using System;
using System.Data.SqlTypes;
using System.Diagnostics;
using Xunit;

namespace Tdd.Katas.StringCalculatorLib.Tests
{
    public class StringCalculatorTests
    {

        //[Fact]
        //public void Add_whenEmptyInput_then0()
        //{
        //    var stringCalculator = new StringCalculator();

        //    var actual = stringCalculator.Add("");

        //    Assert.Equal(0, actual);
        //}
        //[Fact]
        //public void Add_when1Input_then1Output()
        //{
        //    var stringCalculator=new  StringCalculator();

        //    var actual = stringCalculator.Add("1");

        //    Assert.Equal(1, actual);
        //}

        //[Fact]
        //public void Add_when1_2_Input_then3Output()
        //{
        //    var stringCalculator = new StringCalculator();

        //    var actual = stringCalculator.Add("1,2");

        //    Assert.Equal(3, actual);
        //}

        //[Fact]
        //public void Add_when1_2_3Input_then6Output()
        //{
        //    var stringCalculator = new StringCalculator();

        //    var actual = stringCalculator.Add("1,2,3");

        //    Assert.Equal(6, actual);
        //}

        //[Fact]
        //public void Add_when8_Inputs_thenSumOutput()
        //{
        //    var stringCalculator = new StringCalculator();

        //    var actual = stringCalculator.Add("1,1,1,1,1,1,1,1");

        //    Assert.Equal(8, actual);
        //}

        [Theory]
        [InlineData("", 0)]
        [InlineData("2", 2)]
        [InlineData("3,4", 7)]
        [InlineData("1,1,1", 3)]
        [InlineData("1,1,1,1,1,1,1", 7)]
        public void Add(string numbers, int expected)
        {
            var stringCalculator = new StringCalculator();

            var actual = stringCalculator.Add(numbers);

            Assert.Equal(expected, actual);
        }


        [Theory]
        [InlineData("1\n2", 3)]
        [InlineData("1\n2,3", 6)]
        [InlineData("1\n2,3\n1\n1\n1", 9)]
        public void Add_NewLine_and_Coma(string numbers, int expected)
        {
            var stringCalculator = new StringCalculator();

            var actual = stringCalculator.Add(numbers);

            Assert.Equal(expected, actual);
        }


        //[Fact]
        //public void Add_whenDifferentDelimiter_Semicolon_thenSumOutput()
        //{
        //    var stringCalculator = new StringCalculator();

        //    var actual = stringCalculator.Add("//;\n1;2");

        //    Assert.Equal(3, actual);
        //}

        //[Fact]
        //public void Add_whenDifferentDelimiter_Pipe_thenSumOutput()
        //{
        //    var stringCalculator = new StringCalculator();

        //    var actual = stringCalculator.Add("//|\n1|2");

        //    Assert.Equal(3, actual);
        //}

        //[Fact]
        //public void Add_whenDifferentDelimiter_Pipe_and_multipleinputs_thenSumOutput()
        //{
        //    var stringCalculator = new StringCalculator();

        //    var actual = stringCalculator.Add("//|\n1|2|1|1|1|1");

        //    Assert.Equal(7, actual);
        //}

        [Theory]
        [InlineData("//;\n1;2", 3)]
        [InlineData("//|\n1|2", 3)]
        [InlineData("//|\n1|2|1|1|1|1", 7)]
        public void Add_DifferentDelimiter(string numbers, int expected)
        {
            var stringCalculator = new StringCalculator();

            var actual = stringCalculator.Add(numbers);

            Assert.Equal(expected, actual);
        }


        [Fact]
        public void Add_when1InputIsNegative_ThenThrowException()
        {
            var stringCalculator = new StringCalculator();

            // act - assert
            var exception = Assert.Throws<Exception>(() => stringCalculator.Add("-1"));

            // assert
            Assert.Equal("negatives not allowed -1", exception.Message);
        }


        [Theory]
        [InlineData("//;\n-1;2", "negatives not allowed -1")]
        [InlineData("//|\n1|-2", "negatives not allowed -2")]
        [InlineData("//|\n1|2|1|1|-44|1", "negatives not allowed -44")]
        [InlineData("//|\n1|2|-11|1|-44|1", "negatives not allowed -11,-44")]
        public void Add_negative_throwException(string numbers, string expected)
        {
            var stringCalculator = new StringCalculator();

            // act - assert
            var exception = Assert.Throws<Exception>(() => stringCalculator.Add(numbers));

            // assert
            Assert.Equal(expected, exception.Message);
        }

        // number  6 on the document
        [Fact]
        public void Add_whenMultiInputAreNegative_ThenShowAllOfThemInExceptionMessage()
        {
            //arrange 
            var stringCalculator = new StringCalculator();

            // act - assert
            var exception = Assert.Throws<Exception>(() => stringCalculator.Add("-1,3,-4"));

            // assert
            Assert.Equal("negatives not allowed -1,-4", exception.Message);
        }

        //7. Using TDD, Add a method to StringCalculator
        //called public int GetCalledCount()
        //that returns how many times Add() was invoked.
        //    Remember - Start with a failing (or even non compiling) test.
        [Fact]
        public void GetCalledCount_when1Add_returns1()
        {
            //arrange 
            var stringCalculator = new StringCalculator();

            stringCalculator.Add("1");
            int actual = stringCalculator.GetCalledCount();

            Assert.Equal(1, actual);
        }

        [Fact]
        public void GetCalledCount_when5Add_returns5()
        {
            //arrange 
            var stringCalculator = new StringCalculator();

            stringCalculator.Add("1");
            stringCalculator.Add("1,3");
            stringCalculator.Add("//|\n1|2|1|1|44|1");
            stringCalculator.Add("//|\n1|2|11|1|44|1");
            stringCalculator.Add("1");
            int actual = stringCalculator.GetCalledCount();

            Assert.Equal(5, actual);
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(5, 5)]
        public void GetCalledCount(int timesAddCalled, int expected)
        {
            //arrange 
            var stringCalculator = new StringCalculator();
            for (int i = 0; i < timesAddCalled; i++)
            {
                stringCalculator.Add("1,3,4");
            }

            int actual = stringCalculator.GetCalledCount();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void AddOccurredEvent_when1_thenEvent1()
        {
            //arrange 
            var stringCalculator = new StringCalculator();

            string giveninput = null;
            stringCalculator.AddOccurred += delegate(string input,
                int result)
            {
                giveninput = input;
            };

            stringCalculator.Add("1");


            Assert.Equal("1", giveninput);
        }

        [Theory]
        [InlineData("", 0)]
        [InlineData("2", 2)]
        [InlineData("3,4", 7)]
        [InlineData("1,1,1", 3)]
        [InlineData("1,1,1,1,1,1,1", 7)]
        [InlineData("1\n2", 3)]
        [InlineData("1\n2,3", 6)]
        [InlineData("1\n2,3\n1\n1\n1", 9)]
        [InlineData("//;\n1;2", 3)]
        [InlineData("//|\n1|2", 3)]
        [InlineData("//|\n1|2|1|1|1|1", 7)]
        public void AddOccurredEvent(string numbers, int sum)
        {
            //arrange 
            var stringCalculator = new StringCalculator();

            string evtInput = null;
            int evtSum = 0;
            stringCalculator.AddOccurred += delegate(string input,
                int result)
            {
                evtInput = input;
                evtSum = result;
            };

            stringCalculator.Add(numbers);


            Assert.Equal(numbers, evtInput);
            Assert.Equal(sum, evtSum);
        }

        //9. Numbers bigger than 1000 should be ignored, for example:
        //2 + 1001 == 2
        [Theory]
        [InlineData("1001", 0)]
        [InlineData("2,1002", 2)]
        [InlineData("3,4,5000", 7)]
        [InlineData("1,1,1,8000", 3)]
        public void Add_whenBT1000_Ignore(string numbers,int expected)
        {
            var stringCalculator = new StringCalculator();

            var actual = stringCalculator.Add(numbers);

            Assert.Equal(expected, actual);
        }

        //10. Delimiters can be of any length with the following format:
        //“//[delimiter]\n”
        //for example:
        //“//[***]\n1***2***3” == 6

        [Theory]
        [InlineData("//;;\n1;;2", 3)]
        [InlineData("//||\n1||2", 3)]
        [InlineData("//||\n1||2||1||1||1||1", 7)]
        public void Add_DelimiterAnyLenght(string numbers, int expected)
        {
            var stringCalculator = new StringCalculator();

            var actual = stringCalculator.Add(numbers);

            Assert.Equal(expected, actual);
        }

        //11. Allow multiple delimiters like this:
        //“//[delim1][delim2]\n”
        //for example
        //“//[*][%]\n1*2%3” == 6.
        [Theory]
        [InlineData("//[;][?]\n1;2", 3)]
        [InlineData("//[;][?]\n1?2", 3)]
        [InlineData("//[;][?]\n1;2?1?1?1;1", 7)]
        public void Add_MultipleDelimiter(string numbers, int expected)
        {
            var stringCalculator = new StringCalculator();

            var actual = stringCalculator.Add(numbers);

            Assert.Equal(expected, actual);
        }

        //12. make sure you can also handle multiple delimiters with length longer than one char
        //for example
        //“//[**][%%]\n1**2%%3” == 6

        [Theory]
        [InlineData("//[;;][?]\n1;;2", 3)]
        [InlineData("//[;;][?]\n1?2", 3)]
        [InlineData("//[;;][?]\n1;;2?1?1?1;;1", 7)]
        public void Add_MultipleDelimiterAnyLenght(string numbers, int expected)
        {
            var stringCalculator = new StringCalculator();

            var actual = stringCalculator.Add(numbers);

            Assert.Equal(expected, actual);
        }
    }

 
     
    
}
