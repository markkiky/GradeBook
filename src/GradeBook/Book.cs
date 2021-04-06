using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Book
    {
        // Explicit Constructor
        public Book(string name)
        {
            grades = new List<double> ();
            Name = name;
        }

        public void AddLetterGrade(char letter)
        {
           switch (letter)
           {
                case 'A': 
                    AddGrade(90);
					break;
                case 'B': 
                    AddGrade(80);
					break;
				case 'C':
					AddGrade(70);
					break;
				case 'D':
					AddGrade(60);
					break;
                default:
					AddGrade(0);
					break;
           }
        }
        // Add Grades Method
        public void AddGrade(double grade)
        {
            if (grade >= 0 && grade <= 100)
            {
                grades.Add(grade);
            }
            else
            {
				throw new ArgumentException($"invalid grade: {nameof(grade)}");
            }
        }

        public Statistics GetStatistics()
        {
            var result = new Statistics();
            result.Average = 0.0;
          
            result.High = double.MinValue;
            result.Low = double.MaxValue;

            
            for(var index= 0; index < grades.Count; index += 1)
            {
                result.High = Math.Max(grades[index], result.High);
                result.Low = Math.Min(grades[index], result.Low);
                result.Average += grades[index];
				
            }
			result.Average = result.Average / grades.Count;
			switch (result.Average)
			{
				case var d when d >= 90.0:
					result.Letter = 'A';
					break; 
				
				case var d when d >= 80.0:
					result.Letter = 'B';
					break; 

				case var d when d >= 70.0:
					result.Letter = 'C';
					break; 

				case var d when d >= 60.0:
					result.Letter = 'D';
					break; 

				default:
					result.Letter = 'F';
					break; 
			}
            
            return result;
        }
        // Fields
        public List<double> grades; 
        public string Name;
    }
}