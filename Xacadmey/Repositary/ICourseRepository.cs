using System.Collections.Generic;
using Xacadmey.Models;

namespace Xacadmey.Repositary
{
    public interface ICourseRepository
    {
        List<Course> GetAll();
        Course GetById(int id);
        void Insert(Course course);
        void Update(Course course);
        void Delete(int id);
    }

}
