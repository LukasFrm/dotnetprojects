﻿using System;
using static GradeBook.Book;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {

            IBook book = new DiskBook("My book");
            book.GradeAdded += OnGradeAdded;

            EnterGrades(book);

            var stats = book.GetStats();
            System.Console.WriteLine($"Lowest grade is {stats.Low}");
            System.Console.WriteLine($"Highest grade is {stats.High}");
            System.Console.WriteLine($"Average grade is {stats.Average}");
            System.Console.WriteLine($"The letter grade is {stats.Letter}");
        }

        private static void EnterGrades(IBook book)
        {
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
                    System.Console.WriteLine($"***********");
                }
            }
        }

        static void OnGradeAdded(object sender, EventArgs args) {
            Console.WriteLine("A grade was added");
        }
    }
}  
 