using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Xacadmey.Models;
using Xacadmey.Repositary;

namespace Xacadmey.Controllers
{
   public class CourseController : Controller
    {
        ICourseRepository courseRepository;
        IDepartmentRepository departmentRepository;
        public CourseController(ICourseRepository Crs_Rep, IDepartmentRepository Dept_Rep)
        {
            courseRepository = Crs_Rep;
            departmentRepository = Dept_Rep;
        }
       

        public IActionResult ReadCoursesList()
        {
            List<Course> courses = courseRepository.GetAll();

                 return View(courses);
        }
        [HttpGet]
        public IActionResult CreateNewCourse()
        {
            ViewData["DeptList"] = departmentRepository.GetAll();

            return View();
        }
        [HttpPost]
        public IActionResult CreateNewCourse(Course course) {

            if (ModelState.IsValid == true) {
                if (course.DepartmentId != 0) {
                    try
                    {
                        courseRepository.Insert(course);
                        return RedirectToAction("ReadCoursesList");
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("", ex.Message);

                    }

                }
                else
                {
                    ModelState.AddModelError("DepartmentId", "select department");
                }


            }
            ViewData["DeptList"] = departmentRepository.GetAll();

            return View(course);

        }
        [HttpGet]
        public IActionResult EditCourse(int id) {
        
         Course cr= courseRepository.GetById(id);
          ViewData["DeptList"] = departmentRepository.GetAll();
         return View(cr);


        }
        [HttpPost]
        public IActionResult EditCourse(Course course) {

            if (ModelState.IsValid == true) {

                if (course.DepartmentId != 0) {
                    try
                    {
                        courseRepository.Update(course);
                        return RedirectToAction("ReadCoursesList");
                    }
                    catch (Exception ex) { 
                     
                        ModelState.AddModelError("",ex.Message);
                    
                    }
                
                  
                }
                else
                {
                    ModelState.AddModelError("DepartmentId", "select department");
                }
            }
            ViewData["DeptList"] = departmentRepository.GetAll();
            return View(course);


        }
        public ActionResult DeleteCourse(int id) {
        
             courseRepository.Delete(id);

            return RedirectToAction("ReadCoursesList");
        }
        /* Academy context=new Academy();



         public IActionResult ReadCoursesList()
         {
             List<Course> courses = context.Courses.Include(x=>x.Department).ToList();

             return View(courses);
         }
         [HttpGet]
         public IActionResult CreateNewCourse()
         {

             var department = context.Departments.
                 Select(d=>new SelectListItem
                 {
                     Value=d.Id.ToString(),
                     Text=d.Name,    
                 }).ToList();

             ViewBag.DepartmentId = department;
             return View();
         }
         [HttpPost]
         public IActionResult CreateNewCourse(Course course) { 





            context.Courses.Add(course);
            context.SaveChanges();

        //     List<Course> courses = context.Courses.Include(x => x.Department).ToList();

        //     return View("ReadCoursesList", courses);
             return RedirectToAction("ReadCoursesList");
         }
         [HttpGet]
         public IActionResult EditCourse(int id) { 
             Course cr=context.Courses.Find(id);
             var department = context.Departments.
                 Select(d => new SelectListItem
                 {
                     Value = d.Id.ToString(),
                     Text = d.Name,
                 }).ToList();







             ViewBag.DepartmentId = department;
             return View(cr);

         }
         [HttpPost]
         public IActionResult EditCourse(Course cc) { 
             context.Courses.Update(cc);
             context.SaveChanges();
             return View(cc);
         }
         public IActionResult DeleteCourse(int id) {

             Course cr = context.Courses.Find(id);
             context.Courses.Remove(cr);
             context.SaveChanges();
             //var courses= context.Courses.ToList();
             //return View("ReadCoursesList", courses);
             return RedirectToAction("ReadCoursesList");

         }

         /*
         public IActionResult Edit(int id)
         {   


             ViewBag.depts=context.Departments.ToList<Department>();
             Course c=context.Courses.FirstOrDefault(c => c.Id==id);

             return View(c);
         }
         public IActionResult SaveEdit(int id , Course cc)
         {
             Course cr = context.Courses.FirstOrDefault(c => c.Id == id);
             cr.Name = cc.Name;
             cr.DepartmentId = cc.DepartmentId;

             cr.Degree = cc.Degree;
             context.SaveChanges();
             return RedirectToAction("Details", "Departments", new {id=cr.DepartmentId});

         }
         public IActionResult Index() {
          List<Course>courses = context.Courses.ToList();
          return View(courses);


         }*/

    }
}
