using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CourseManagment.Models
{
    internal class Student
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string GroupNo { get; set; }
        public  Group Group { get; set; }
        public bool Type { get; set; }
       

    }
}
