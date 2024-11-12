using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Xacadmey.Models;
using Xacadmey.Repositary;
namespace Xacadmey.Repositary
{
    public class InstructorRepository:IinstructorRepository
    {
        private readonly Academy _context;
        public InstructorRepository(Academy context)
        {
            _context = context;
        }
        public List<Instructor> GetAll()
        {
            return _context.Instructors.Include(x => x.Course).ThenInclude(x => x.Department).ToList();
        }
        public Instructor GetById(int id)
        {
            return _context.Instructors.FirstOrDefault(c => c.Id == id);
        }
        public void Insert(Instructor instructor)
        {
            _context.Instructors.Add(instructor);
            _context.SaveChanges();
        }
        public void Update(Instructor instructor)
        {
            _context.Instructors.Update(instructor);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var inst = GetById(id);
            if (inst != null)
            {
                _context.Instructors.Remove(inst);
                _context.SaveChanges();
            }
        }
    }
}
