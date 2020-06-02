using System;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book("Jason's Gradebook");
            book.AddGrade(55.3);
            book.AddGrade(68.9);
            book.AddGrade(98.5);
            book.AddGrade(105);

            book.ShowStatistics();
        }
    }
}
