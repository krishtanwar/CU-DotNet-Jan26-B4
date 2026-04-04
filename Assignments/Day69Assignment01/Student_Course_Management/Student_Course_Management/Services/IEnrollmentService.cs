using Student_Course_Management.DTOs;

namespace Student_Course_Management.Services
{
    public interface IEnrollmentService
    {
        Task<bool> Enroll(EnrollmentDto dto);
    }
}
