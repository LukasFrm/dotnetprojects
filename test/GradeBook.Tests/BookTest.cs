using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTest
    {
        [Fact]
        public void Test1()
        {
            // Arrange
            var book = new Book("");
            book.AddGrade(10);
            book.AddGrade(20);
            book.AddGrade(30);

            // Act 
            var result = book.GetStats();
            // Assert

            Assert.Equal(20, result.Average);
            Assert.Equal(10, result.Low);
            Assert.Equal(30, result.High);

        }
    }
}
