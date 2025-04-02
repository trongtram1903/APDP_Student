using ManagerStudent.Data;
using ManagerStudent.Models;

namespace ManagerStudent.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ApplicationDbContext _context;

        public CourseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Course> GetAll() => _context.Courses.ToList();

        public Course GetById(int id) => _context.Courses.Find(id);

        public void Add(Course course)
        {
            _context.Courses.Add(course);
            Save();
        }

        public void Update(Course course)
        {
            _context.Courses.Update(course);
            Save();
        }

        public void Delete(int id)
        {
            var course = _context.Courses.Find(id);
            if (course != null)
            {
                _context.Courses.Remove(course);
                Save();
            }
        }

        public void Save() => _context.SaveChanges();
    }

}
