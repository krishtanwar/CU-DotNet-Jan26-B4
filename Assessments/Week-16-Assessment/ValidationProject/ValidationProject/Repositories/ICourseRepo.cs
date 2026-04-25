using ValidationProject.Models;

namespace ValidationProject.Repositories
{
    public interface ICourseRepo
    {
        Task<IEnumerable<Course>> GetAll();
        Task<Course> GetByID(int id);
        Task<Course> Update(Course c);
        Task<Course> Create(Course c);
        Task<bool> Delete(int id);
    }
}
