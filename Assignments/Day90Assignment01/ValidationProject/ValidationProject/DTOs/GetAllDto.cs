using ValidationProject.Models;

namespace ValidationProject.DTOs
{
    public class GetAllDto
    {
       public IEnumerable<Course> Courses { get; set; }
    }
}
