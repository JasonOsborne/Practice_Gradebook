using System;
using System.Collections.Generic;
using System.Linq;

namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public class NamedObject
    {
        public string Name { get; set; }

        public NamedObject(string name)
        {
            Name = name;
        }
    }

    public class Book : NamedObject
    {
        private List<double> grades;
        private Statistics stats = new Statistics();
        public static string SUBJECT = "Science";

        public Book(string name) : base(name)
        {
            grades = new List<double>();
        }

        public event GradeAddedDelegate GradeAdded;

        public void AddGrade(double grade)
        {
            try
            {
                if (grade <= 100 && grade > 0)
                    grades.Add(grade);
                if(GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
                else throw new ArgumentException($"Invalid {nameof(grade)}.");
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                //Always executes.
            }
        }
        public void AddGrade(char grade)
        {
            grade = Char.ToUpper(grade);
            switch (grade)
            {
                case 'A':
                    grades.Add(100);
                    break;
                case 'B':
                    grades.Add(90);
                    break;
                case 'C':
                    grades.Add(80);
                    break;
                case 'D':
                    grades.Add(70);
                    break;
                case 'F':
                    grades.Add(60);
                    break;
                default:
                    break;
            }
        }

        private void SetStatistics()
        {
            var idx = 0;
            if (grades.Count > 0)
                do
                {
                    LowGrade(grades[idx]);
                    HighGrade(grades[idx]);
                    idx++;
                } while (idx < grades.Count);

            stats.Average = grades.Average();
            switch (stats.Average)
            {
                case var d when d >= 90.0:
                    stats.Letter = 'A';
                    break;
                case var d when d >= 80.0:
                    stats.Letter = 'B';
                    break;
                case var d when d >= 70.0:
                    stats.Letter = 'C';
                    break;
                case var d when d >= 60.0:
                    stats.Letter = 'D';
                    break;
                default:
                    stats.Letter = 'F';
                    break;
            }
        }

        public Statistics GetStatistics()
        {
            if (grades.Count > 0)
            {
                if (stats.Low == double.MaxValue)
                    SetStatistics();
                Console.WriteLine();
            }
            else Console.WriteLine("No grades entered.");
            return stats;
        }

        public void ShowStatistics()
        {
            if (grades.Count > 0)
            {
                if (stats.Low == double.MaxValue)
                    SetStatistics();
                Console.WriteLine($"Low: {stats.Low:N2}");
                Console.WriteLine($"High: {stats.High:N2}");
                Console.WriteLine($"Average: {stats.Average:N2}");
                Console.WriteLine($"Letter: {stats.Letter}");
            }
            else Console.WriteLine("No grades.");
        }

        private void LowGrade(double grade)
        {
            if (grade < stats.Low)
                stats.Low = grade;
        }

        private void HighGrade(double grade)
        {
            if (stats.High < grade)
                stats.High = grade;
        }
    }
}