using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using Xunit;

namespace GradeBook.Tests
{
    public class StringTests
    {
        [Fact]
        public void StringBehavesLikeValueTypes()
        {
            string name = "Jason";
            name = MakeUppercase(name);
            Assert.Equal("JASON", name);
        }

        private string MakeUppercase(string parameter)
        {
            return parameter.ToUpper();
        }
    }
}
