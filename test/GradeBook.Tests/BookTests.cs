using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void BookCalculatesAnAverageGrade()
        {
           
            // arrange
            var book = new Book("");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);

            // actual
            var results = book.GetStatistics();
            

            // assert
            Assert.Equal(85.6, results.Average, 1);
            Assert.Equal(90.5, results.High, 1);
            Assert.Equal(77.3, results.Low, 1);
            Assert.Equal('A', results.Letter);
        }

        [Fact]
        public void GradeIsBetweenZeroAndHundred()
        {
            var book = new Book("Jemison"); 
            book.AddGrade(100);
            Assert.Equal(100, book.grades[0]);
        }

    }
}
