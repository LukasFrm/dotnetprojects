using System;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book("My book");
            while (true)
            {

                System.Console.WriteLine("Please enter a grade or 'q' to quit");
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

                catch (ArgumentException ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
                finally
                {
                    var combinedString = string.Join(",", book.grades.ToArray());

                    System.Console.WriteLine($"Your grades are {combinedString}");
                }
            }

            var stats = book.GetStats();

            System.Console.WriteLine($"Current book category is {Book.CATEGORY}");
            System.Console.WriteLine($"Lowest grade is {stats.Low}");
            System.Console.WriteLine($"Highest grade is {stats.High}");
            System.Console.WriteLine($"Average grade is {stats.Average}");
            System.Console.WriteLine($"The letter grade is {stats.Letter}");
        }
    }
}  
 