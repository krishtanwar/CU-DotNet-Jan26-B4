namespace Employees
{
            class Employee
    {
                int id;
            public void SetId(int empid)
            {
                id = empid;
            }
            public int GetId()
            {
                return id;
            }

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
            Console.WriteLine($"Id of the Employee is: {id} and Name of the employee is: {Name} with department: {Department} and salary: {Salary}");
        }


    }
    internal class ClassDemo
    {
        public static void Main(string[] args)

        {
            Employee emp = new Employee();
            emp.Name = "krish";
            emp.Department = "Sales";
            emp.Salary = 62000;
            emp.SetId(1231);
            emp.display();
            

        }
    }
}