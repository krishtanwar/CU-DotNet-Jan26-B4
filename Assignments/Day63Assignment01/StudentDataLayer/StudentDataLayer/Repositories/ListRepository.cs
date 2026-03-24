using StudentDataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDataLayer.Repositories
{
    internal class ListRepository : IStudentRepository
    {
        private readonly List<Student> students=new List<Student>();
        public void AddStudent(Student student)
        {
            students.Add(student);
        }

        public IEnumerable<Student> GetStudents()
        {
            return students;
        }

        public void RemoveStudent(int id)
        {
            var existing=students.FirstOrDefault(x=>x.StudentId==id);
            if (existing != null)
            {
                students.Remove(existing);
            }
        }

        public void UpdateStudent(int id,string name,int grade)
        {
            var existing = students.FirstOrDefault(x => x.StudentId == id);
            if (existing != null)
            {
                existing.Name= name;
                existing.Grade= grade;
            }
        }
    }
}
