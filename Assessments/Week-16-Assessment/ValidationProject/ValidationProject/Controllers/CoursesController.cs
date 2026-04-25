using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ValidationProject.Common;
using ValidationProject.Data;
using ValidationProject.DTOs;
using ValidationProject.Models;
using ValidationProject.Services;

namespace ValidationProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService _courseService;
        private readonly IValidator<CreateCourseDto> _createValidator;
        private readonly IValidator<GetByIdDto> _getByIdValidator;
        private readonly IValidator<UpdateDto> _updateValidator;

        public CoursesController(
            ICourseService courseService,
            IValidator<CreateCourseDto> createValidator,
            IValidator<GetByIdDto> getByIdValidator,
            IValidator<UpdateDto> updateValidator)
        {
            _courseService = courseService;
            _createValidator = createValidator;
            _getByIdValidator = getByIdValidator;
            _updateValidator = updateValidator;
        }

        // GET: api/Courses
        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<Course>>>> GetCourse()
        {
            var courses = await _courseService.GetAll();
            return Ok(new ApiResponse<IEnumerable<Course>>
            {
                Success = true,
                Message = "Courses retrieved successfully",
                Data = courses
            });
        }

        // GET: api/Courses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<Course>>> GetCourse(int id)
        {
            try
            {
                var getByIdDto = new GetByIdDto { Id = id };
                var validationResult = await _getByIdValidator.ValidateAsync(getByIdDto);
                if (!validationResult.IsValid)
                {
                    return BadRequest(new ApiResponse<Course>
                    {
                        Success = false,
                        Message = "Validation failed",
                        Data = null
                    });
                }

                var course = await _courseService.GetByID(id);
                if (course == null)
                {
                    return NotFound(new ApiResponse<Course>
                    {
                        Success = false,
                        Message = "Course not found",
                        Data = null
                    });
                }

                return Ok(new ApiResponse<Course>
                {
                    Success = true,
                    Message = "Course retrieved successfully",
                    Data = course
                });
            }
            catch
            {
                return NotFound(new ApiResponse<Course>
                {
                    Success = false,
                    Message = "An error occurred while retrieving the course",
                    Data = null
                });
            }
        }

        // PUT: api/Courses/5
        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse<Course>>> PutCourse(int id, UpdateDto updateDto)
        {
            var validationResult = await _updateValidator.ValidateAsync(updateDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(new ApiResponse<Course>
                {
                    Success = false,
                    Message = "Validation failed",
                    Data = null
                });
            }

            var course = new Course
            {
                Id = id,
                Title = updateDto.Title,
                Price = updateDto.Price,
                Description = updateDto.Description,
                Duration = updateDto.Duration

            };

            var updated = await _courseService.Update(course);
            if (updated == null)
            {
                return NotFound(new ApiResponse<Course>
                {
                    Success = false,
                    Message = "Course not found",
                    Data = null
                });
            }

            return Ok(new ApiResponse<Course>
            {
                Success = true,
                Message = "Course updated successfully",
                Data = updated
            });
        }

        // POST: api/Courses
        [HttpPost]
        public async Task<ActionResult<ApiResponse<Course>>> PostCourse(CreateCourseDto createDto)
        {
            var validationResult = await _createValidator.ValidateAsync(createDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(new ApiResponse<Course>
                {
                    Success = false,
                    Message = "Validation failed",
                    Data = null
                });
            }

            var course = new Course
            {
                Title = createDto.Title,
                Price = createDto.Price,
                Description = createDto.Description,
                Duration = createDto.Duration
            };

            var created = await _courseService.Create(course);
            return CreatedAtAction(nameof(GetCourse), new { id = created.Id }, new ApiResponse<Course>
            {
                Success = true,
                Message = "Course created successfully",
                Data = created
            });
        }

        // DELETE: api/Courses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<string>>> DeleteCourse(int id)
        {
            var deleted = await _courseService.Delete(id);
            if (!deleted)
            {
                return NotFound(new ApiResponse<string>
                {
                    Success = false,
                    Message = "Course not found",
                    Data = null
                });
            }

            return Ok(new ApiResponse<string>
            {
                Success = true,
                Message = "Course deleted successfully",
                Data = null
            });
        }
    }
}
