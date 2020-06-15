using System;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book("SomeBook");

            double doubleVal;
            char charVal;
            book.Name = "Jason's Gradebook";

            do
            {
                Console.Write($"What grade would you like to add to {book.Name} (Q quits): ");
                var input = Console.ReadLine();
                input.ToUpper();

                if (Char.TryParse(input, out charVal))
                    book.AddGrade(charVal);
                else if (Double.TryParse(input, out doubleVal))
                    book.AddGrade(doubleVal);
            } while (charVal != 'Q');

            book.ShowStatistics();
            Console.ReadLine();
        }
    }
}