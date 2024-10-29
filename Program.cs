using CourseManagment.Models;
using CourseManagment.Services;
using System.Threading.Tasks.Dataflow;

namespace CourseManagment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CourseService courseService = new CourseService();
            string answer;
            do
            {
                Console.WriteLine("\n1.Yeni qrup yarat.\n2.Qruplarin siyahisini goster.\n3.Qrup uzerinde duzelis et.\n4.Butun telebelerin siyahisini goster.\n5.Qrupdaki telebelerin siyahisini goster.\n6.Telebe yarat\n\n\n0.Cixis.");
                answer=Console.ReadLine().Trim();
                switch(answer)
                {
                    case "1":
                        courseService.CreateGroup();
                        Console.WriteLine($"Secmek istediyiniz kateqoriyani daxil edin:\n1.Programlasdirma\n2.Sistem Administratorlugu\n3.Dizayn");
                        string category=Console.ReadLine();
                        ChooseCategory course = 0;
                        Group group = new Group();
                        Console.WriteLine("Tehsil onlinedirsa 1,eyanidirse 2 secin");
                        string isonline = Console.ReadLine(); 
                        if (isonline == "1")
                        {
                            group.IsOnline = true;
                            group.Limit = 15;
                            Console.WriteLine("Online tehsil secildi");
                        }
                        else if (isonline == "2")
                        {
                           group.IsOnline= false;
                            group.Limit = 10;
                            Console.WriteLine("Eyani tehsil secildi");
                        }
                        else
                        {
                            Console.WriteLine("Duzgun deyer daxil edilmedi");
                        }

                        //isonline olani sil burda yarat
                        if (category == "1")
                        {
                            course = ChooseCategory.Programming;
                            Console.WriteLine("Proqramlasdirma qrupu yaradildi");
                            string groupno="P"+Group.count;
                            group.No=groupno;
                            Group.count++;
                            Console.WriteLine($"Grup No:{group.No}");
                            CourseService.Groups.Add(group);



                        }
                        else if (category == "2")
                        {
                            course = ChooseCategory.SystemAdministration;
                            Console.WriteLine("Sistem Administratorlugu qrupu yaradildi");
                            string groupno ;
                            groupno = "S" + Group.count;
                            group.No = groupno;
                            Group.count++;
                            Console.WriteLine($"Grup No:{group.No}");
                            CourseService.Groups.Add(group);
                        }
                        else if (category == "3")
                        {
                             course = ChooseCategory.Design;
                            Console.WriteLine("Dizayn qrupu yaradildi");
                            string groupno = "D" + Group.count;
                            group.No = groupno;
                            Group.count++;
                            Console.WriteLine($"Grup No:{group.No}");
                            CourseService.Groups.Add(group);
                        }
                        else
                        {
                            Console.WriteLine("Duzgun daxil edilmedi");
                        }
                        break;

                        case "2":
                        courseService.ShowAllGroups();
                        Console.WriteLine("Butun qrup melumatlari:");

                        break;
                    case "3":
                        courseService.EditGroup();
                        break;
                    case "4":
                        courseService.ShowAllStudents();
                        break;
                    case "5":
                        courseService.ShowGroupStudents();
                        break;
                    case "6":
                        courseService.CreateStudent();

                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Yanlis deyer");
                        break;


                }

            }while(answer!="0");
        }
    }
}
