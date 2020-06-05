using System;
using System.Runtime.CompilerServices;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void GetStatisticsAverageTest()
        {
            //arrange
            var sut = new Book("gradebook");
            sut.AddGrade(90.3);
            sut.AddGrade(45.4);
            sut.AddGrade(33.8);

            //act
            double actual = (90.3 + 45.4 + 33.8)/3;
            var result = sut.GetStatistics();

            //assert
            Assert.Equal(actual, result.Average, 3);
            Assert.Equal(90.3, result.High);
            Assert.Equal(33.8, result.Low);
        }

        [Fact]
        public void GradeLetterCheck()
        {
            var sut = new Book("book");
            sut.AddGrade(90.3);
            var result = sut.GetStatistics();

            Assert.Equal('A', result.Letter);
        }
    }
}
