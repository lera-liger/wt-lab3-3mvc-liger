using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wt_lab3_3mvc_liger.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FullName { get; set; } = "";
        public string Faculty { get; set; } = "";
        public int Course { get; set; }
        public double AverageGrade { get; set; }
        public bool IsEnrolled { get; set; }
    }
}
