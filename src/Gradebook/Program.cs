using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Dynamic;
using System.Runtime.InteropServices.ComTypes;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book("Jason's Gradebook");
            double doubleVal;
            char charVal;

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