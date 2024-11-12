using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Xacadmey.Models;

namespace Xacadmey.Repositary
{
    public class CourseRepository : ICourseRepository
    {
        private readonly Academy _context;

        public CourseRepository(Academy context)
        {
            _context = context;
        }

        public List<Course> GetAll()
        {
            return _context.Courses.Include(x => x.Department).ToList();
        }

        public Course GetById(int id)
        {
            return _context.Courses.FirstOrDefault(c => c.Id == id);
        }

        public void Insert(Course course)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();
        }

        public void Update(Course course)
        {
            _context.Courses.Update(course);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var course = GetById(id);
            if (course != null)
            {
                _context.Courses.Remove(course);
                _context.SaveChanges();
            }
        }
    }

}
