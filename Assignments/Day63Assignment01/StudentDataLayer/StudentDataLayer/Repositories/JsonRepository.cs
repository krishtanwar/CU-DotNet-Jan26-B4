using StudentDataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace StudentDataLayer.Repositories
{
    internal class JsonRepository : IStudentRepository
    {
        string file = @"..\..\..\students.json";
        // Read data from JSON
        private List<Student> ReadFromFile()
        {
            if (!File.Exists(file))
            {
                return new List<Student>();
            }

            string json = File.ReadAllText(file);

            if (string.IsNullOrWhiteSpace(json))
                return new List<Student>();

            return JsonSerializer.Deserialize<List<Student>>(json);
        }

        // Write data to JSON
        private void WriteToFile(List<Student> students)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            string json = JsonSerializer.Serialize(students, options);
            File.WriteAllText(file, json);

        }

        // CREATE
        public void AddStudent(Student student)
        {
            var students = ReadFromFile();

            // Auto ID generation
            student.StudentId = students.Count > 0 ? students.Max(s => s.StudentId) + 1 : 1;

            students.Add(student);

            WriteToFile(students);
        }

        // READ
        public IEnumerable<Student> GetStudents()
        {
            return ReadFromFile();
        }

        // DELETE
        public void RemoveStudent(int id)
        {
            var students = ReadFromFile();

            var student = students.FirstOrDefault(s => s.StudentId == id);

            if (student != null)
            {
                students.Remove(student);
                WriteToFile(students);
            }
            else
            {
                Console.WriteLine("Student not found");
            }
        }

        // UPDATE
        public void UpdateStudent(int id, string name, int grade)
        {
            var students = ReadFromFile();

            var student = students.FirstOrDefault(s => s.StudentId == id);

            if (student != null)
            {
                student.Name = name;
                student.Grade = grade;

                WriteToFile(students);
            }
            else
            {
                Console.WriteLine("Student not found");
            }
        }
    }
}