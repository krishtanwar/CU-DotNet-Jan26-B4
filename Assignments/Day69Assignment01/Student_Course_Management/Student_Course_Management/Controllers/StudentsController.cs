using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student_Course_Management.Services;
using static Student_Course_Management.DTOs.StudentDto;

namespace Student_Course_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _service;
        public StudentsController(IStudentService service) => _service = service;

        [HttpGet]

        public async Task<IActionResult> GetAll() => Ok(await _service.GetAll());

        [HttpGet("{id}")]

        public async Task<IActionResult> Get(int id)
        {
            var student = await _service.GetById(id);
            if (student == null) return NotFound();
            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateStudentDto dto)
        {
            var result = await _service.Create(dto);
            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateStudentDto dto)
        {
            var updated = await _service.Update(id, dto);
            if (!updated) return NotFound();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.Delete(id);
            if (!deleted) return NotFound();
            return Ok();
        }
    }
}
