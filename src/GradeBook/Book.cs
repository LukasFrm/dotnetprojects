using System;
using System.Collections.Generic;

namespace GradeBook {
    class Book
    {
        public Book(string name)
        {
            grades = new List<double>();
            this.name = name;
        }
        public void AddGrade(double grade)
        {
            grades.Add(grade);
        }

        public void ShowStats()
        {
            var result = 0.0;
            var highGrade = double.MinValue;
            var lowGrade = double.MaxValue;

            foreach (var number in grades)
            {
                highGrade = Math.Max(number, highGrade);
                lowGrade = Math.Min(number, lowGrade);
                result += number;
            }
            result /= grades.Count;

            System.Console.WriteLine($"Lowest grade is {lowGrade}");
            System.Console.WriteLine($"Highest grade is {highGrade}");
            System.Console.WriteLine($"Average result is {result:N1}");

        }

        public void setName(string bookName)
        {
            name = bookName;
        }
        private List<double> grades;
        public string name;

    }
}