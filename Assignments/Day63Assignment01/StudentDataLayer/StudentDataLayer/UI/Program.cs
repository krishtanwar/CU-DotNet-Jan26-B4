using StudentDataLayer.Models;
using StudentDataLayer.Repositories;
using StudentDataLayer.Services;
using System.Xml;
namespace StudentDataLayer.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Console.WriteLine("Json or List(1/2)");
            var repooption = int.Parse(Console.ReadLine());

            IStudentRepository repo = null;
            if (repooption == 2)
            {
                repo = new ListRepository();
            }
            else if (repooption == 1)
            {
                repo = new JsonRepository();
            }
            IStudentServices service = new StudentServices(repo);
            while (true)
            {
                Console.WriteLine("Menu");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Remove Student");
                Console.WriteLine("3. Update Student");
                Console.WriteLine("4. Display Students");
                Console.WriteLine("5. Exit");


                Console.WriteLine("Enter Choice");
                var choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {

                        case "1":
                            Console.WriteLine("Enter ID");
                            int id = int.Parse(Console.ReadLine());

                            Console.WriteLine("Enter Name");
                            string name = Console.ReadLine();

                            Console.WriteLine("Enter Grade");
                            int grade = int.Parse(Console.ReadLine());
                            service.AddStudent(
                                new Student
                                {
                                    StudentId = id,
                                    Name = name,
                                    Grade = grade
                                });
                            break;

                        case "2":
                            Console.WriteLine("Enter Id");
                            int id1 = int.Parse(Console.ReadLine());
                            service.RemoveStudent(id1);
                            break;

                        case "3":
                            Console.WriteLine("Enter Id: ");
                            int id2 = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter New Name: ");
                            string name1 = Console.ReadLine();
                            Console.WriteLine("Enter new Grade");
                            int grade1 = int.Parse(Console.ReadLine());

                            service.UpdateStudent(id2, name1, grade1);
                            break;
                        case "4":
                            var studentlist = service.GetStudents();
                            Console.WriteLine("All Students");
                            foreach (var student in studentlist)
                            {
                                Console.WriteLine(student);
                            }

                            break;
                        case "5":
                            return;


                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }


        }
    }
}
