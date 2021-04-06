using System;
using Xunit;

namespace GradeBook.Tests
{

    public class TypeTests
    {
        [Fact]
        public void StringsBehaveLikeValueTypes()
        {   
            string name = "Scott";
            var upper = MakeUpperCase(name);
            Assert.Equal("Scott", name);
            Assert.Equal("SCOTT", upper);
        }
        public string MakeUpperCase(string parameter)
        {
            return parameter.ToUpper();
        }
        [Fact]
        public void ValueTypesAlsoPass()
        {
            var x = GetInt();
            SetInt(ref x);
            Assert.Equal(42, x);
        }
        public int GetInt()
        {
            return 3;
        }
        public void SetInt(ref int x)
        {
            x = 42;
        }
        [Fact]
        public void CSharpCanPassByRef()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(ref book1, "New Book");

            Assert.Equal("New Book", book1.Name);
        }

        private void GetBookSetName(ref Book book, string name)
        {
            book = new Book(name);
        }
        [Fact]
        public void CSharpIsPassByValue()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Book");

            Assert.Equal("Book 1", book1.Name);
        }

        private void GetBookSetName(Book book, string name)
        {
            book = new Book(name);
        }
        [Fact]
        public void CanSetNameFromReference()
        {
            var book1 = GetBook("Book 1");
            SetName(book1, "New Book");

            Assert.Equal("New Book", book1.Name);
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            Assert.Equal("Book 1", book1.Name);
            Assert.NotSame(book1, book2);


        }

        [Fact]
        public void TwoVarsCanReferenceSameObject()
        {
            var book1 = GetBook("Book 1");
            var book2 = book1;

            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2));


        }

        void SetName(Book book, string name)
        {
            book.Name = name;
        }
        Book GetBook(string name)
        {
            return new Book(name);
        }
    }
}
