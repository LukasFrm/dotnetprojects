namespace GradeBook
{

    class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book("My book");
            book.AddGrade(2.5);
            book.AddGrade(92);
            book.AddGrade(12);
            var stats = book.GetStats();

            System.Console.WriteLine($"Lowest grade is {stats.Low}");
            System.Console.WriteLine($"Highest grade is {stats.High}");
            System.Console.WriteLine($"Average grade is {stats.Average}");
        }
    }
}  
 