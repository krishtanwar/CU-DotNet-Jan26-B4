using Student_Course_Management.Models;

namespace Student_Course_Management.Repository
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAll();
        Task<Student> GetById(int id);
        Task Add(Student student);
        Task Update(Student student);
        Task Delete(Student student);
    }
}
