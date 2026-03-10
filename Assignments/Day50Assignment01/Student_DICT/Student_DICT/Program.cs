namespace Student_DICT
{
        class Student
        {
            public int StuId { get; set; }
            public string SName { get; set; }

            public Student(int id, string name)
            {
                StuId = id;
                SName = name;
            }
            public override bool Equals(object? obj)
            {
                var x = obj as Student;
                return this.StuId == x?.StuId && this.SName == x?.SName;
            }
            public override int GetHashCode()
            {
                return HashCode.Combine(StuId, SName);
            }
        }
        class StudManagement
        {
            public static Dictionary<Student, int> records = new Dictionary<Student, int>();


            public static void AddStudent(Student student, int marks)
            {
                if (records.ContainsKey(student))
                {
                    if (marks > records[student])
                        Console.WriteLine($"Student {student.SName} already exists. Updating marks.");
                    records[student] = marks;
                }
                else
                {
                    records.Add(student, marks);
                }
            }
            public static void DisplayRecords()
            {
                foreach (var record in records)
                {
                    Console.WriteLine($"Student Id: {record.Key.StuId}  Student Name: {record.Key.SName}  Student Marks: {record.Value}");
                }
            }
        }
        internal class Program
        {

            static void Main(string[] args)
            {
                Console.WriteLine("Hello, World!");
                Student s1 = new Student(1, "Krish");
                Student s2 = new Student(2, "Upkaar");
                Student s3 = new Student(3, "stud3");
                Student s4 = new Student(3, "stud3");

                StudManagement.AddStudent(s1, 90);
                StudManagement.AddStudent(s2, 91);
                StudManagement.AddStudent(s3, 92);
                StudManagement.AddStudent(s4, 93);

                StudManagement.DisplayRecords();
            }
        }
}