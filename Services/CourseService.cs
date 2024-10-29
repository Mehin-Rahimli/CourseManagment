using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using CourseManagment.Models;

namespace CourseManagment.Services
{
    internal class CourseService
    {
        public static List<Group> Groups { get; set; } = new List<Group>();

        public void CreateGroup()
        {
            Groups.Add(new Group());
        }
        public void ShowAllGroups()
        {
            foreach (var group in Groups)
            {
                Console.WriteLine($"{group.No};{group.Limit};{group.Category};{group.students.Count};");
            }
        }
        public void EditGroup()
        {
            Console.WriteLine("Deyisiklik ucun qrup nomresini daxil edin");
            string exgroupno=Console.ReadLine().Trim();
            Group selectedgroup = null;
            foreach(var group in Groups)
            {
                if (group.No == exgroupno)
                {
                    selectedgroup = group;
                    break;
                }

            }
            if(selectedgroup != null)
            {
                string newGroupNo;
                bool isDublicate=false;
                do
                {
                    Console.WriteLine($"Yeni qrup nomresini daxil edin.(kohne:{selectedgroup.No})");
                    newGroupNo = Console.ReadLine().Trim();
                    foreach (var group in Groups)
                    {
                        if (group.No == newGroupNo)
                        {
                            isDublicate = true;
                            Console.WriteLine("Qrup nomresi artiq movcuddur");
                            break;
                        }
                        else
                        {
                            isDublicate=false;
                        }

                    }
                } while (isDublicate);
                selectedgroup.No=newGroupNo;
                Console.WriteLine($"Qrup nomresi deyisdirildi.{selectedgroup.No}");
            }
            else
            {
                Console.WriteLine("Daxil edilen qrup nomresi tapilmadi");
            }
            
        }


        public void ShowGroupStudents()
        {
            Console.WriteLine("Qrupun adini yazin:");
            string no = Console.ReadLine();
            Group choosengroup = null;
            foreach (var group in Groups)
            {
                if (group.No == no)
                {
                    choosengroup = group;
                    break;
                }
            }
            if (choosengroup != null)
            {
                if (choosengroup.students.Count > 0)
                {
                    foreach (var student in choosengroup.students)
                    {
                        Console.WriteLine($"{choosengroup.No} qrupundaki telebeler:\n{student.Name} {student.Surname}");
                    }
                }
                else
                {
                    Console.WriteLine($"{choosengroup.No} qrupunda hec bir telebe yoxdur");
                }


            }
            else
            {
                Console.WriteLine("Daxil edilen qrup tapilmadi");
            }
        }
        public void ShowAllStudents()
        {
            bool studentscount = false;
            foreach (var group in Groups)
            {
                if (group.students.Count > 0)
                {
                    studentscount = true;
                    Console.WriteLine($"{group.No} qrupundaki telebeler:");
                    int studentindex = 1;
                    foreach (var student in group.students)
                    {
                        Console.WriteLine($"{studentindex}.{student.Name} {student.Surname} ");
                        studentindex++;
                    }
                }
            }
            if (!studentscount)
            {
                Console.WriteLine("Qrupda hec bir telebe yoxdur");
            }
        }
       

        public void CreateStudent()
        {
            Console.WriteLine("Adinizi daxil edin:");
            string Name = Console.ReadLine().Trim();
            for (int i = 3; i < Name.Length; i++)
            {
                if (Char.IsDigit(Name[i]))
                {

                    Console.WriteLine("Duzgun ad daxil edilmedi");
                }
                else
                {
                    Name = Name.Substring(0, 1).ToUpper() + Name.Substring(1).ToLower();
                }
            }
            Console.WriteLine("Soyadinizi daxil edin:");
            string Surname = Console.ReadLine().Trim();
            for (int i = 4; i < Surname.Length; i++)
            {
                if (Char.IsDigit(Surname[i]))
                {
                    Console.WriteLine("Duzgun soyad daxil edilmedi");
                }
                else
                {
                    Surname = Surname.Substring(0, 1).ToUpper() + Surname.Substring(1).ToLower();
                }
            }
            string FullName = string.Concat(Name, " ", Surname);
            Console.WriteLine(FullName);
            Console.WriteLine("Zemanetli tehsil ucun 1,zemanetsiz tehsil ucun 2 daxil edin");
            string type = Console.ReadLine();
            bool Type;


            if (type == "1")
            {
                Type = true;
                Console.WriteLine("Zemanteli tehsil secildi");

            }
            else if (type == "2")
            {
                Type = false;
                Console.WriteLine("Zemanetsiz tehsil secildi");

            }
            else
            {
                Console.WriteLine("Yanlis deyer daxil edildi");
            }
            Console.WriteLine("Elave etmek istediyiniz qrupun adi:");
            string groupNo = Console.ReadLine();
            Group Selectedgroup = null;
            foreach (var group in Groups)
            {
                if (groupNo == group.No)
                {
                    Selectedgroup = group;
                    break;
                }
            }
            if (Selectedgroup != null)
            {
                Student student = new Student();
                student.Group = Selectedgroup;
                if (Selectedgroup.AddStudent(student))
                {
                    Console.WriteLine($"Telebe {Selectedgroup.No} adli qrupa elave olundu.");
                }
                else
                {
                    Console.WriteLine("Telebe elave oluna bilmedi,qrup doludur");
                }
            }
            else
            {
                Console.WriteLine("Qrup tapilmadi");
            }
        }

    }
}
