using AutoWrapper.Wrappers;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using University.Core.DTOs;
using University.Core.Forms;
using University.Core.Services;

namespace University.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController(IStudentService studentService, ILogger<StudentsController> logger) : ControllerBase
    {
        private readonly IStudentService _studentService = studentService;
        private readonly ILogger<StudentsController> _logger = logger;

        [HttpGet]
        [ProducesResponseType(typeof(List<StudentDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ApiResponse GetAll()
        {       
            _logger.LogInformation("Getting all students");
            return new ApiResponse(_studentService.GetAll());
        }


        [HttpGet("{id}")]
        [ProducesResponseType(typeof(StudentDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ApiResponse GetById(int id)
        {
            _logger.LogInformation("Getting student with id {StudentId}", id);
            return new ApiResponse( _studentService.GetById(id));
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ApiResponse Create([FromBody] AddStudentForm form)
        {
            _logger.LogInformation("Creating a new student with name {StudentName}", form.Name);
            _studentService.Create(form);
            return new ApiResponse("Student created successfully");
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ApiResponse Update(int id, [FromBody] UpdateStudentForm form)
        {
            _logger.LogInformation("Updating student with id {StudentId}", id);
            _studentService.Update(id, form);
            return new ApiResponse("Student updated successfully");
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ApiResponse Delete(int id)
        {
            _logger.LogInformation("Deleting student with id {StudentId}", id);
            _studentService.Delete(id);
            return new ApiResponse("Student deleted successfully");
        }
    }
}
