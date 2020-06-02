﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace GradeBook
{
    class Book
    {
        private List<double> grades { get; set; }
        private string name;

        public Book(string name)
        {
            grades = new List<double>();
            this.name = name;
        }

        public void AddGrade(double grade)
        {
            grades.Add(grade);
        }

        public void ShowStatistics()
        {
            LowGrade();
            HighGrade();
            Average();
        }

        public void LowGrade()
        {
            double lowGrade = double.MaxValue;
            foreach (var grade in grades)
            {
                if (grade < lowGrade)
                {
                    lowGrade = grade;
                }
            }
            Console.WriteLine($"Low: {lowGrade}");
        }

        public void HighGrade()
        {
            var highGrade = double.MinValue;
            foreach (var grade in grades)
            {
                if (highGrade < grade)
                {
                    highGrade = grade;
                }
            }
            Console.WriteLine($"High: {highGrade}");
        }

        public void Average()
        {
            Console.WriteLine($"Average: {grades.Average()}");
        }
    }
}