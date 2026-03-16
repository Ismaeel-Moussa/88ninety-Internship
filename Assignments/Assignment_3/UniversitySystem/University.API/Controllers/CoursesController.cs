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
    public class CoursesController(ICourseService courseService, ILogger<CoursesController> logger) : ControllerBase
    {
        private readonly ICourseService _courseService = courseService;
        private readonly ILogger<CoursesController> _logger = logger;

        [HttpGet]
        [ProducesResponseType(typeof(List<CourseDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public List<CourseDTO> GetAll()
        {
            _logger.LogInformation("Getting all courses");
            return _courseService.GetAll();
        }


        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CourseDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public CourseDTO GetById(int id)
        {
            _logger.LogInformation("Getting course with id {CourseId}", id);
            return _courseService.GetById(id);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public void Create([FromBody] AddCourseForm form)
        {
            _logger.LogInformation("Creating a new course with name {CourseName}", form.Name);
            _courseService.Create(form);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public void Update(int id, [FromBody] UpdateCourseForm form)
        {
            _logger.LogInformation("Updating course with id {CourseId}", id);
            _courseService.Update(id, form);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public void Delete(int id)
        {
            _logger.LogInformation("Deleting course with id {CourseId}", id);
            _courseService.Delete(id);
        }
    }
}
