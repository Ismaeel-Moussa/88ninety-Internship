
using University.Data.AppDbContext;
using University.Data.Entities;

namespace University.Data.Repository
{
    public class CourseRepository(UniversityDbContext context) : ICourseRepository
    {
        private readonly UniversityDbContext _context = context;

        public List<Course> GetAll()
        {
            return [.. _context.Courses];
        }

        public Course GetById(int id)
        {
            return _context.Courses.Find(id);
        }

        public void Add(Course Course)
        {
            ArgumentNullException.ThrowIfNull(Course);
            _context.Courses.Add(Course);

        }

        public void Update(Course Course)
        {
            ArgumentNullException.ThrowIfNull(Course);
            _context.Courses.Update(Course);
        }

        public void Delete(Course Course)
        {
            ArgumentNullException.ThrowIfNull(Course);
            _context.Courses.Remove(Course);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

    }

    public interface ICourseRepository
    {
        List<Course> GetAll();
        Course GetById(int id);
        void Add(Course Course);
        void Update(Course Course);
        void Delete(Course Course);
        void SaveChanges();
    }
}
