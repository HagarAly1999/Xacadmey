using System.Collections.Generic;
using Xacadmey.Models;

namespace Xacadmey.Repositary
{
    public interface IDepartmentRepository
    {
        List<Department> GetAll();
       
        Department GetById(int id);
        void Insert(Department dept);
        void Update(int id, Department dept);
        public void Delete(int id);

    }
}