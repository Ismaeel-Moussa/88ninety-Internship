
using University.Data.AppDbContext;
using University.Data.Entities;

namespace University.Data.Repository
{
    public class StudentRepository(UniversityDbContext context) : IStudentRepository
    {
        private readonly UniversityDbContext _context = context;

        public List<Student> GetAll()
        {
            return [.. _context.Students];
        }

        public Student GetById(int id)
        {
            return _context.Students.Find(id);
        }

        public void Add(Student student)
        {
            ArgumentNullException.ThrowIfNull(student);
            _context.Students.Add(student);

        }

        public void Update(Student student)
        {
            ArgumentNullException.ThrowIfNull(student);
            _context.Students.Update(student);
        }

        public void Delete(Student student)
        {
            ArgumentNullException.ThrowIfNull(student);
            _context.Students.Remove(student);
        }

        public Boolean IsEmailExists(string email)
        {
            return _context.Students.Any(s => s.Email == email);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

    }

    public interface IStudentRepository
    {
        List<Student> GetAll();
        Student GetById(int id);
        void Add(Student student);
        void Update(Student student);
        void Delete(Student student);
        Boolean IsEmailExists(string email);
        void SaveChanges();
    }
}
