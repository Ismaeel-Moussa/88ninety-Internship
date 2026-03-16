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
        public List<StudentDTO> GetAll()
        {       
            _logger.LogInformation("Getting all students");
            return _studentService.GetAll();
        }


        [HttpGet("{id}")]
        [ProducesResponseType(typeof(StudentDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public StudentDTO GetById(int id)
        {
            _logger.LogInformation("Getting student with id {StudentId}", id);
            return _studentService.GetById(id);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public void Create([FromBody] AddStudentForm form)
        {
            _logger.LogInformation("Creating a new student with name {StudentName}", form.Name);
            _studentService.Create(form);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public void Update(int id, [FromBody] UpdateStudentForm form)
        {
            _logger.LogInformation("Updating student with id {StudentId}", id);
            _studentService.Update(id, form);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public void Delete(int id)
        {
            _logger.LogInformation("Deleting student with id {StudentId}", id);
            _studentService.Delete(id);
        }
    }
}
