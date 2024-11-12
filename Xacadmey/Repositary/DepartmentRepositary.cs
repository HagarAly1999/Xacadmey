using System.Collections.Generic;
using System.Linq;
using Xacadmey.Models;

namespace Xacadmey.Repositary
{
    public class DepartmentRepositary : IDepartmentRepository
    {
        Academy context;/*=new Academy()*/
        public DepartmentRepositary(Academy _context)
        {
            context = _context;
        }

        public List<Department> GetAll()
        {
            return context.Departments.ToList ();

        }
        public Department GetById(int id)
        {
            return context.Departments.FirstOrDefault(x => x.Id == id);
        }
        public void Insert(Department dept) {
        
            context.Departments.Add(dept);
            context.SaveChanges();
        }
        public void Update(int id, Department dept)
        {
            Department Old=GetById(id);
            Old.Name = dept.Name;
            Old.ManagerName = dept.ManagerName; 
            context.SaveChanges ();
        }
        public void Delete(int id) { 
         Department old= GetById(id);
         context.Departments.Remove(old);
         context.SaveChanges();
        }
    }
}
