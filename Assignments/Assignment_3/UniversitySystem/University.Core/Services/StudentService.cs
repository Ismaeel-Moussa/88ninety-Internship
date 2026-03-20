using Microsoft.Extensions.Logging;
using University.Core.DTOs;
using University.Core.Exceptions;
using University.Core.Forms;
using University.Core.Validations;
using University.Data.Entities;
using University.Data.Repository;

namespace University.Core.Services
{
    public class StudentService(IStudentRepository studentRepository, ILogger<StudentService> logger) : IStudentService
    {
        private readonly IStudentRepository _studentRepository = studentRepository;
        private readonly ILogger<StudentService> _logger = logger;

        public List<StudentDTO> GetAll()
        {
            var students = _studentRepository.GetAll();

            return [.. students.Select(s => new StudentDTO()
            {
                Id = s.Id,
                Name = s.Name,
                Email = s.Email
            })];

        }

        public StudentDTO GetById(int id)
        {
            if (id < 0)
            {
                _logger.LogError("Invalid student id {StudentId} for get by id", id);
                throw new ArgumentOutOfRangeException(nameof(id), "Student id cannot be negative");
            }

            var student = _studentRepository.GetById(id);
            if (student == null)
            {
                _logger.LogError("Student with id {StudentId} not found", id);
                throw new NotFoundException("Student not found");
            }

            return new StudentDTO()
            {
                Id = student.Id,
                Name = student.Name,
                Email = student.Email
            };
        }

        public void Create(AddStudentForm form)
        {
            if (form == null)
            {
                _logger.LogError("Add student form is null");
                throw new ArgumentNullException(nameof(form));
            }

            var validation = FormValidator.Validate(form);
            if (!validation.IsValid)
            {
                _logger.LogWarning("Validation failed for add student form: {Errors}", validation.Errors);
                throw new BusinessException(validation.Errors);
            }
            
            if (_studentRepository.IsEmailExists(form.Email))
            {
                _logger.LogWarning("Email {Email} already exists", form.Email);
                throw new BusinessException("Email already exists");
            }

            var student = new Student()
            {
                Name = form.Name,
                Email = form.Email
            };

            _studentRepository.Add(student);
            _studentRepository.SaveChanges();
            _logger.LogInformation("Student created");

        }

        public void Update(int id, UpdateStudentForm form)
        {
            if (form == null)
            {
                _logger.LogError("Update student form is null for student id {StudentId}", id);
                throw new ArgumentNullException(nameof(form));
            }
            if (id < 0)
            {
                _logger.LogError("Invalid student id {StudentId} for update", id);
                throw new ArgumentOutOfRangeException(nameof(id), "Student id cannot be negative");
            }

            var validation = FormValidator.Validate(form);
            if (!validation.IsValid)
            {
                _logger.LogWarning("Validation failed for update student form for student id {StudentId}: {Errors}", id, validation.Errors);
                throw new BusinessException(validation.Errors);
            }

            var student = _studentRepository.GetById(id);

            if (student == null)
            {
                _logger.LogError("Student with id {StudentId} not found for update", id);
                throw new NotFoundException("Student not found");
            }

            if (student.Email != form.Email && _studentRepository.IsEmailExists(form.Email))
            {
                _logger.LogWarning("Email {Email} already exists", form.Email);
                throw new BusinessException("Email already exists");
            }

            student.Name = form.Name;
            student.Email = form.Email;

            _studentRepository.Update(student);
            _studentRepository.SaveChanges();
            _logger.LogInformation("Student with id {StudentId} updated", student.Id);


        }

        public void Delete(int id)
        {
            if (id < 0)
            {
                _logger.LogError("Invalid student id {StudentId} for delete", id);
                throw new ArgumentOutOfRangeException(nameof(id), "Student id cannot be negative");
            }

            var student = _studentRepository.GetById(id);
            if (student == null)
            {
                _logger.LogError("Student with id {StudentId} not found for delete", id);
                throw new NotFoundException("Student not found");
            }


            _studentRepository.Delete(student);
            _studentRepository.SaveChanges();
            _logger.LogInformation("Student with id {StudentId} deleted", student.Id);


        }

    }

    public interface IStudentService
    {
        List<StudentDTO> GetAll();
        StudentDTO GetById(int id);
        void Create(AddStudentForm form);
        void Update(int id, UpdateStudentForm form);
        void Delete(int id);
    }
}
