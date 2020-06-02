using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook
{
    public class Statistics
    {
        public double Average;
        public double High;
        public double Low;

        public Statistics()
        {
            Average = 0;
            High = double.MinValue;
            Low = double.MaxValue;
        }
    }
}
