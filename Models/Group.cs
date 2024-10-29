using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagment.Models
{
    internal class Group
    {

        public string No { get; set; }
        public static int count = 100;
        public ChooseCategory Category { get; set; }
        private int _limit;
        public bool IsOnline { get; set; }
        public List<Student> students { get; set; } = new List<Student>();
        public int Limit
        {
            get
            { return _limit; }
            set
            {
                if (IsOnline)
                {
                    _limit = 15;
                }
                else
                {
                    _limit = 10;
                }
            }
        }
        public bool AddStudent(Student student)
        {
            if (students.Count < student.Group.Limit)
            {
                students.Add(student);
                student.Group = this;
                return true;
            }
            else
            {
                Console.WriteLine("Qrup doludur");
                return false;
            }
        }


       
       

    }
}
