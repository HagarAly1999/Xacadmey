
using System.Collections.Generic;
using Xacadmey.Models;
namespace Xacadmey.Repositary
{
    public interface IinstructorRepository
    {
        List<Instructor> GetAll();
        Instructor GetById(int id);
        void Insert(Instructor course);
        void Update(Instructor course);
        void Delete(int id);

    }
}
