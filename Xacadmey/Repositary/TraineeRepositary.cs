using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Xacadmey.Models;

namespace Xacadmey.Repositary
{
    public class TraineeRepositary:ITraineeRepository
    {
        Academy context;/*=new Academy();*/
        public TraineeRepositary(Academy _context)
        {
            context = _context;
        }
        public List<Trainee> GetAll()
        {
            return context.Traineess.Include(x=>x.Department).ToList();

        }
        public Trainee GetById(int id)
        {
            return context.Traineess.FirstOrDefault(t => t.Id == id);
        }
        public void Insert(Trainee t) { 
         
            context.Traineess.Add(t);
            context.SaveChanges();
        
        }
        public void Update( Trainee t)

        {
            Trainee old= context.Traineess.FirstOrDefault(x=>x.Id == t.Id);
            old.Name = t.Name;
            old.Address = t.Address;
            old.Image = t.Image;
            old.DepartmentId   = t.DepartmentId;
            context.SaveChanges();

        }
        public void Delete(int id) { 
        
         Trainee old= GetById(id);
         context.Traineess.Remove(old);
         context.SaveChanges();
        
        }
    }
}
