using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {  
            var book = new Book("Mellow");
            // loops 
            
            while(true)
            {
                Console.WriteLine("Enter a grade or 'q' to quit: ");
                var input = Console.ReadLine();

                if (input == "q")
                {
                    break;
                }
                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally 
                {
                    Console.WriteLine(":)");
                }
                
            }
            

            

            var stats = book.GetStatistics();     

            Console.WriteLine($"Average Grades: {stats.Average}");
            Console.WriteLine($"Highest Grade: {stats.High}");
            Console.WriteLine($"Lowest Grade: {stats.Low}");      
            Console.WriteLine($"Letter Grade: {stats.Letter}");               
        }
    }
}
