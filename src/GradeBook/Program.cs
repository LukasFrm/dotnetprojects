using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var grades = new List<double>() { 12.8, 12.21, 21.333};
            var result = .0;


            foreach (var number in grades)
            {
                result += number;
            }

            result /=  grades.Count;
            System.Console.WriteLine($"The average grade is:{result:N2}");
        }
    }
}  
