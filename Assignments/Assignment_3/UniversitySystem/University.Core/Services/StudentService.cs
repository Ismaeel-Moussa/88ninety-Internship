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
            ArgumentOutOfRangeException.ThrowIfNegative(id);

            var student = _studentRepository.GetById(id)
                ?? throw new NotFoundException("Student not found");

            return new StudentDTO()
            {
                Id = student.Id,
                Name = student.Name,
                Email = student.Email
            };
        }

        public void Create(AddStudentForm form)
        {
            ArgumentNullException.ThrowIfNull(form);

            var validation = FormValidator.Validate(form);
            if (!validation.IsValid)            
                throw new BusinessException(validation.Errors);
            

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
            ArgumentNullException.ThrowIfNull(form);
            ArgumentOutOfRangeException.ThrowIfNegative(id);

            var validation = FormValidator.Validate(form);
            if (!validation.IsValid)
                throw new BusinessException(validation.Errors);

            var student = _studentRepository.GetById(id)
                    ?? throw new NotFoundException("Student not found");

            student.Name = form.Name;

            _studentRepository.Update(student);
            _studentRepository.SaveChanges();
            _logger.LogInformation("Student with id {StudentId} updated", student.Id);


        }

        public void Delete(int id)
        {
            ArgumentOutOfRangeException.ThrowIfNegative(id);

            var student = _studentRepository.GetById(id)
                    ?? throw new NotFoundException("Student not found");

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
