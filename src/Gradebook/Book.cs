﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace GradeBook
{
    public class Book
    {
        private List<double> grades { get; set; }
        public Statistics stats;
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

        public void GetStatistics()
        {
            LowGrade();
            HighGrade();
            Average();
        }

        public double LowGrade()
        {
            foreach (var grade in grades)
            {
                if (grade < stats.Low)
                {
                    stats.Low = grade;
                }
            }
            return stats.Low;
        }

        public double HighGrade()
        {
            foreach (var grade in grades)
            {
                if (stats.High < grade)
                {
                    stats.High = grade;
                }
            }
            return stats.High;
        }

        public double Average()
        {
            stats.Average = grades.Average();
            return stats.Average;
        }
    }
}