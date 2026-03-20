using Microsoft.Extensions.Logging;
using University.Core.DTOs;
using University.Core.Exceptions;
using University.Core.Forms;
using University.Core.Validations;
using University.Data.Entities;
using University.Data.Repository;

namespace University.Core.Services
{
    public class CourseService(ICourseRepository CourseRepository, ILogger<CourseService> logger) : ICourseService
    {
        private readonly ICourseRepository _CourseRepository = CourseRepository;
        private readonly ILogger<CourseService> _logger = logger;

        public List<CourseDTO> GetAll()
        {
            var Courses = _CourseRepository.GetAll();

            return [.. Courses.Select(s => new CourseDTO()
            {
                Id = s.Id,
                Name = s.Name,
                Credit = s.Credit
            })];

        }

        public CourseDTO GetById(int id)
        {
            if (id < 0)
            {
                _logger.LogError("Invalid id {CourseId} provided", id);
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be non-negative");
            }

            var Course = _CourseRepository.GetById(id);
            if (Course == null)
            {
                _logger.LogError("Course with id {CourseId} not found", id);
                throw new NotFoundException("Course not found");
            }

            return new CourseDTO()
            {
                Id = Course.Id,
                Name = Course.Name,
                Credit = Course.Credit
            };
        }

        public void Create(AddCourseForm form)
        {
            if (form == null)
            {
                _logger.LogError("Form cannot be null");
                throw new ArgumentNullException(nameof(form), "Form cannot be null");
            }

            var validation = FormValidator.Validate(form);
            if (!validation.IsValid)
            {
                _logger.LogWarning("Form validation failed with errors: {Errors}", validation.Errors);
                throw new BusinessException(validation.Errors);
            }
            

            var Course = new Course()
            {
                Name = form.Name,
                Credit = form.Credit
            };

            _CourseRepository.Add(Course);
            _CourseRepository.SaveChanges();
            _logger.LogInformation("Course created");

        }

        public void Update(int id, UpdateCourseForm form)
        {
            if (form == null)
            {
                _logger.LogError("Form cannot be null");
                throw new ArgumentNullException(nameof(form), "Form cannot be null");
            }
            if (id < 0)
            {
                _logger.LogError("Invalid id {CourseId} provided", id);
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be non-negative");
            }

            var validation = FormValidator.Validate(form);
            if (!validation.IsValid)
            {
                _logger.LogWarning("Form validation failed with errors: {Errors}", validation.Errors);
                throw new BusinessException(validation.Errors);
            }

            var Course = _CourseRepository.GetById(id);
            if (Course == null)
            {
                _logger.LogError("Course with id {CourseId} not found", id);
                    throw new NotFoundException("Course not found");
            }

            Course.Name = form.Name;
            Course.Credit = form.Credit;

            _CourseRepository.Update(Course);
            _CourseRepository.SaveChanges();
            _logger.LogInformation("Course with id {CourseId} updated", Course.Id);


        }

        public void Delete(int id)
        {
            ArgumentOutOfRangeException.ThrowIfNegative(id);

            var Course = _CourseRepository.GetById(id)
                    ?? throw new NotFoundException("Course not found");

            _CourseRepository.Delete(Course);
            _CourseRepository.SaveChanges();
            _logger.LogInformation("Course with id {CourseId} deleted", Course.Id);


        }

    }

    public interface ICourseService
    {
        List<CourseDTO> GetAll();
        CourseDTO GetById(int id);
        void Create(AddCourseForm form);
        void Update(int id, UpdateCourseForm form);
        void Delete(int id);
    }
}
