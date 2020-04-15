using System;

namespace GradeBook
{
    class Program
    {
        public delegate void StringDelegate(string text);
        static void ToUpperCase(string text) => Console.WriteLine(text.ToUpper());
        static void ToLowerCase(string text) => Console.WriteLine(text.ToLower());
        static void Main(string[] args)
        {
            StringDelegate log1 = ToUpperCase;
            log1("This is uppercase");
            StringDelegate log2 = ToLowerCase;
            log2("This is lowercase");

            Book book = new Book("My book");
            book.GradeAdded += OnGradeAdded;


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

                    System.Console.WriteLine($"Your grades are: {combinedString}");
                }
            }

            var stats = book.GetStats();

            System.Console.WriteLine($"Current book category is {Book.CATEGORY}");
            System.Console.WriteLine($"Lowest grade is {stats.Low}");
            System.Console.WriteLine($"Highest grade is {stats.High}");
            System.Console.WriteLine($"Average grade is {stats.Average}");
            System.Console.WriteLine($"The letter grade is {stats.Letter}");
        }

        static void OnGradeAdded(object sender, EventArgs args) {
            Console.WriteLine("A grade was added");
        }
    }
}  
 