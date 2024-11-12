using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Xacadmey.Models;
using Xacadmey.Repositary;
namespace Xacadmey.Controllers
{
    public class InstructorController : Controller
    {
        //Academy context=new Academy();
        IinstructorRepository _instructorRepository;
        ICourseRepository courseRepository;
        IDepartmentRepository departmentRepository;

        public InstructorController(IinstructorRepository iR, ICourseRepository Cr, IDepartmentRepository ID)
        {
            _instructorRepository = iR;
            courseRepository = Cr;
            departmentRepository = ID;
            
        }
        public IActionResult ReadInstructorList()
        {
            //List<Instructor> inst = context.Instructors.ToList();
            List<Instructor>insta= _instructorRepository.GetAll();
            return View(insta);
        }
        [HttpGet]
        public IActionResult CreateNewInstructor()
        {

            ViewData["DeptList"] = departmentRepository.GetAll();

            ViewData["CourseList"]=courseRepository.GetAll();
            return View();

            //    var departments = context.Departments
            //          .Select(d => new SelectListItem
            //          {
            //              Value = d.Id.ToString(), // assuming Id is the department ID
            //              Text = d.Name // assuming Name is the department name
            //          })
            //          .ToList();

            //    ViewBag.Departments = departments; 

            //    var course = context.Courses
            //         .Select(x => new SelectListItem
            //         {
            //             Value = x.Id.ToString(), // assuming Id is the department ID
            //             Text = x.Name // assuming Name is the department name
            //         })
            //         .ToList();

            //    ViewBag.CourseId =course; return View();
            //
        }
        
        [HttpPost]
        public IActionResult CreateNewInstructor(Instructor s)
        {
            if (ModelState.IsValid == true)
            {
                if (s.DepartmentId != 0&&s.CourseId!=0)
                {
                    try
                    {
                        _instructorRepository.Insert(s);
                        return RedirectToAction("ReadInstructorList");
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("", ex.Message);

                    }

                }
                else
                {
                    ModelState.AddModelError("DepartmentId", "select department");
                    ModelState.AddModelError("CourseId", "select course");
                }


            }
            ViewData["DeptList"] = departmentRepository.GetAll();
            ViewData["CourseList"] = courseRepository.GetAll();
            return View(s);

         
        }
        [HttpGet]
        public IActionResult EditInstructor(int id) {

           Instructor ss = _instructorRepository.GetById(id);
           ViewData["DeptList"] = departmentRepository.GetAll();
           ViewData["CourseList"] = courseRepository.GetAll();
            return View(ss);
        }
        [HttpPost]
        public IActionResult EditInstructor(Instructor x)
        {
            if (ModelState.IsValid == true)
            {
                if (x.DepartmentId != 0 && x.CourseId != 0)
                {
                    try
                    {
                        _instructorRepository.Update(x);
                        return RedirectToAction("ReadInstructorList");
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("", ex.Message);

                    }

                }
                else
                {
                    ModelState.AddModelError("DepartmentId", "select department");
                    ModelState.AddModelError("CourseId", "select course");
                }


            }
            ViewData["DeptList"] = departmentRepository.GetAll();
            ViewData["CourseList"] = courseRepository.GetAll();
            return View(x);
        }

        public IActionResult DeleteInstructor(int id)
        {
           
               _instructorRepository.Delete(id);

                return RedirectToAction("ReadInstructorList");
        }






        //public IActionResult GetInstrutorDetails()
        //{
        //    List<Instructor>inst_data=context.Instructors.Include(x=>x.Course).ThenInclude(p=>p.Department).ToList();

        //    return View("ShowInstructorData",inst_data);
        //}
        //public IActionResult detailbyId(int id)
        //{
        //    Instructor s = context.Instructors.FirstOrDefault(s => s.Id == id);
        //    return View("detailid",s);
            
        //}
        //public IActionResult Details()
        //{
        //    List<string> branches = new List<string>();
        //    branches.Add("assuit");
        //    branches.Add("alex");
        //    branches.Add("smart");
        //    ViewData["bran"] = branches;
        //    ViewData["msg"] = "Hello from Acadmy";
        //   Instructor stud = context.Instructors.FirstOrDefault();
        //    return View("Details", stud);

        //}
        //public IActionResult DetailsWithVM()
        //{
        //    List<string> branches = new List<string>();
        //    branches.Add("assuit");
        //    branches.Add("alex");
        //    branches.Add("smart");
           
        //    Instructor stud = context.Instructors.FirstOrDefault();
        //    Department dept= context.Departments.FirstOrDefault();
        //    InstructorWithBranchListViewModel INSVM= new InstructorWithBranchListViewModel();
        //    INSVM.InsName=stud.Name;
        //    INSVM.InsImage=stud.Image;
        //    INSVM.branches= branches;
        //    INSVM.DeptManagerName = dept.ManagerName;
        //    INSVM.temp = 5;
        //    if (INSVM.temp >0)
        //    {
        //        INSVM.color = "Red";
        //    }
        //    else
        //    {
        //        INSVM.color = "Blue";
        //    }
        //    INSVM.Msg = "Hello from vm";
        //    return View("DetailsWithVM", INSVM);

        //}
    }
}
