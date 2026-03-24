using StudentDataLayer.Models;
using StudentDataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDataLayer.Services
{
    internal class StudentServices : IStudentServices
    {
        private IStudentRepository _repository {  get; set; }
        public StudentServices(IStudentRepository repository)
        {
            _repository = repository;   
        }
        //IStudentRepository repository = new ListRepository();
        public void AddStudent(Student student)
        {
            if (student != null)
            {
                if (student.Grade < 0 || student.Grade > 100) throw new ArgumentException("" +
                    "The Range for Grades is 0 to 100");

                _repository.AddStudent(student);
            }
        }

        public IEnumerable<Student> GetStudents()
        {
            return _repository.GetStudents();
        }

        public void RemoveStudent(int id)
        {
            _repository.RemoveStudent(id);
        }

        public void UpdateStudent(int id,string name,int grade)
        {
            
            
                if (grade < 0 || grade > 100) throw new ArgumentException("" +
                    "The Range for Grades is 0 to 100");

                _repository.UpdateStudent(id,name,grade);
            
        }
    }
}

