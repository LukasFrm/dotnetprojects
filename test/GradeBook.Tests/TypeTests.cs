using System;
using Xunit;

namespace GradeBook.Tests
{

    public delegate string WriteLogDelegate(string logMessage);
    public class TypeTests 
    {
        int count = 0;

        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
            WriteLogDelegate log = ReturnMessage;
            log += ReturnMessage;
            log += IncrementCount;

            var result = log("Some string");
            Assert.Equal("some string", result);
            Assert.Equal(3, count);
        }
        string IncrementCount(string message)
        {
            count++;
            return message.ToLower();
        }
        string ReturnMessage(string message) {
            count++;
            return message;
        }  
        
        [Fact]
        public void Test1()
        {
            var x = GetInt();
            SetInt(ref x);
            Assert.Equal(42, x);
        }

        public void SetInt(ref int z) {
            z = 42;
        }

        public int GetInt() {
            return 10;
        }

        [Fact]
        public void OutParameterTest()
        {
            var no1 = 1;
            ChangePassedValue(out no1);
            Assert.Equal(10, no1);
        }
        private void ChangePassedValue(out int arg)
        {
            arg = 0;
            arg += 10;
        }
        [Fact]
        public void TestPassingOfRefValues()
        {
            var integer1 = 10;
            var integer2 = 2;
            divideNumbersWithRef(ref integer1, integer2);
            Assert.Equal(5, integer1);
        }
        private int divideNumbersWithRef(ref int no1, int no2) {
            no1 /= no2;
            return no1;
        }

         [Fact]
        public void CSharpCanPassByRef()
        {
            var book1 = GetBook("Book 1");
            getBookRefChangeName(ref book1, "New Name");

            // Assert.NotEqual("Book 1", book1.Name);
            Assert.Equal("New Name", book1.Name);
        }
        private void getBookRefChangeName(ref InMemoryBook book, string newName)
        {
            book = new InMemoryBook(newName);
        }
        [Fact]
        public void CSharpIsPassByValue()
        {
            var book1 = GetBook("Book 1");
            getBookChangeName(book1, "New Name");

            // Assert.NotEqual("Book 1", book1.Name);
            Assert.NotEqual("New Name", book1.Name);
        }
        private void getBookChangeName(InMemoryBook book, string newName)
        {
            book = new InMemoryBook(newName);
        }
        [Fact]
        public void CanSetNameFromReference()
        {
            var book1 = GetBook("Book 1");
            changeBookName(book1, "New Name");

            Assert.NotEqual("Book 1", book1.Name);
            Assert.Equal("New Name", book1.Name);
        }
        InMemoryBook changeBookName(InMemoryBook passedBook, string newName)
        {
            passedBook.Name = newName;
            return passedBook;
        }
        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
        }

        [Fact]
        public void TwoVarsCanReferenceSameObject()
        {
            var book1 = GetBook("Book 1");
            var book2 = book1;

            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2));
        }
        InMemoryBook GetBook(string name) 
        {
            return new InMemoryBook(name);
        }


    }
}
