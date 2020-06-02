using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void Test1()
        {
            //arrange
            var x = 5;
            var y = 2;

            //act
            var actual = x * y;

            //assert
            Assert.Equal(10, actual);
        }
    }
}
