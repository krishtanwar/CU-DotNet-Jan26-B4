using StudentDataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDataLayer.Services
{
    internal interface IStudentServices
    {
        void AddStudent(Student student);
        void RemoveStudent(int id);
        void UpdateStudent(int id,string name,int grade);
        public IEnumerable<Student> GetStudents();
    }
}
