namespace ConsoleApp1
{

   
    class Person :Object      // every class  is defined upon object classwhich is a superclass
    {
        string name = string.Empty;
        public void displaynName()
        {
            Console.WriteLine(this.name);
        }
        public void Setname(string name)
        {
            this.name = name;       //left side data member and right side parameter
            //personName=name;

        }
        private int age;

        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        public int Mobile { get; set; }     //auto implemented property without any data member or business logic



    }
    //partial class Person
    //{
    //    public  void display2()
    //    {
    //        Console.WriteLine("display2");
    //    }
    //}
    class Employee
    {
        int id;

        public string Name { get; set; }

        private string department;

        public string Department
        {
            get { return department; }
            set
            {
                if (value == "Accounts" || value == "Sales" || value == "IT")
                    department = value;
            }
        }

        private int salary;

        public int Salary
        {
            get { return salary; }
            set
            {
                if (value >= 50000 && value <= 90000)
                    salary = value;
            }
        }

        public void display()
        {
            Console.WriteLine($"Name of the employee is: {Name} with department: {Department} and salary: {Salary}");
        }


    }
    internal class ClassDemo
    {
         public static void Main(string[] args)
        
        {
            //Console.WriteLine();
            //Person person1=new Person();
            ////every class has some predefined functions in it
            //person1.Setname("krish");
            //person1.displaynName();

            //person1.Age = 10;
            Employee emp = new Employee();
            emp.Name = "krish";
            emp.Department = "Sales";
            emp.Salary = 62000;
            emp.display();

         }
    }
}
