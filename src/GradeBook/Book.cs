using System;
using System.Collections.Generic;

namespace GradeBook {
    public class Book
    {
        public Book(string name)
        {
            grades = new List<double>();
            Name = name;
        }
        public void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
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
                case 'E':
                    AddGrade(50);
                    break;
                case 'F':
                    AddGrade(40);
                    break;
                default:
                    AddGrade(0);
                    break;
            }
        }
        public Statistics GetStats()
        {
            var result = new Statistics();
            result.Average = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;

            var index = 0;
            while (index < grades.Count)
            {
                result.High = Math.Max(grades[index], result.High);
                result.Low = Math.Min(grades[index], result.Low);
                result.Average += grades[index];
                index++;
            }

            result.Average /= grades.Count;

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
                case var d when d >= 50.0:
                    result.Letter = 'E';
                    break;
                case var d when d >= 40.0:
                    result.Letter = 'F';
                    break;
                default:
                    result.Letter = 'F';
                    break;
            }
            return result;
        }
        public void setName(string bookName)
        {
            Name = bookName;
        }
        public List<double> grades;
        public const string CATEGORY = "Science";
        private string name;
        public string Name {
            get {
                return name;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    try
                    {
                        name = value;

                    }
                    catch (FormatException ex)
                    {
                        System.Console.WriteLine(ex.Message);
                    }
                }

            }
        }

    }
}