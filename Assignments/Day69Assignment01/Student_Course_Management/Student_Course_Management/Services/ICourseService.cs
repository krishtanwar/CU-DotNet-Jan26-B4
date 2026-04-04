using static Student_Course_Management.DTOs.CourseDto;

namespace Student_Course_Management.Services
{
    public interface ICourseService
    {
        Task<List<CourseResponseDto>> GetAll();
        Task<CourseResponseDto> GetById(int id);
        Task<CourseResponseDto> Create(CreateCourseDto dto);
        Task<bool> Update(int id, UpdateCourseDto dto);
        Task<bool> Delete(int id);
    }
}
