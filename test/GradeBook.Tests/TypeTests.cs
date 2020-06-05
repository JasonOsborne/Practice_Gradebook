using System;
using Xunit;

namespace GradeBook.Tests
{
    public delegate string WriteLogDelegate(string logMessage);
 
    public class TypeTests
    {
        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
            WriteLogDelegate log;

            log = new WriteLogDelegate(ReturnMessage);

            var result = log("hi");
            Assert.Equal("hi", result);
        }

        private string ReturnMessage(string message)
        {
            return message;
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            //arrange
            var book1 = GetBook("Book1");
            var book2 = GetBook("Book2");

            //assert
            Assert.Equal("Book1", book1.Name);
            Assert.Equal("Book2", book2.Name);
        }

        [Fact]
        public void SameObjectPointerTest()
        {
            //arrange
            var book1 = GetBook("Book1");
            var book2 = book1;

            //assert
            Assert.Same(book1, book2);
        }

        [Fact]
        public void NameCheck()
        {
            //arrange
            var book1 = GetBook("Book1");
            //assert
            Assert.Equal("Book1", book1.Name);
        }

        [Fact]
        public void GetSetBookName()
        {
            var book1 = GetBook("Book1");
            //arrange
            GetBookSetName(ref book1, "New Name");

            //assert
            Assert.Equal("New Name", book1.Name);
        }

        [Fact]
        public void PassByValAndPassByRef()
        {
            var x = GetInt();
            Assert.Equal(3, x);

            SetInt(ref x);
            Assert.Equal(42, x);
        }

        private void SetInt(ref int x)
        {
            x = 42;
        }

        private int GetInt()
        {
            return 3;
        }

        private void GetBookSetName(ref Book book, string name)
        {
            book = new Book(name);
        }

        private Book GetBook(string name)
        {
            return new Book(name);
        }
    }
}
