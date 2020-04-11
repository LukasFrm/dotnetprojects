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
            book.ShowStats();
        }
    }
}  
 