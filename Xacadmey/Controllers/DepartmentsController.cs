using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Xacadmey.Models;
using Xacadmey.ViewModel;

namespace Xacadmey.Controllers
{

    //CRUD  Create Read Update Delete
    public class DepartmentsController : Controller
    {
        Academy context=new Academy();
    /*    public IActionResult NewDepartment()
        {
                return View();
        }
        public IActionResult SaveNewDepartment()
        {
            return View();
        }*/
        public IActionResult ReadDepartmentList()
        {
            List<Department>deps=context.Departments.ToList();

            return View(deps);
        }
        [HttpGet ]
        public IActionResult CreateDepartment()
        {
            return View();

        }
        [HttpPost]
        public IActionResult CreateDepartment(Department department)
        {
            context.Departments.Add(department);
            context.SaveChanges();
            return RedirectToAction("ReadDepartmentList");
        }

        #region Update
        //Update
        [HttpGet]

        public IActionResult EditDepartment(int id)
        {
            Department dep= context.Departments.Find(id);

            return View(dep);
        }
        [HttpPost]
        public IActionResult EditDepartment(Department dep)
        {
                 context.Departments.Update(dep);
                 context.SaveChanges();
                 return View(dep);
        }

        #endregion

        #region Delete
        //Update

        public IActionResult DeleteDepartment(int id)
        {
            Department dep = context.Departments.Find(id);
             context.Departments.Remove(dep);
             context.SaveChanges();


           var list= context.Departments.ToList();
            return View("ReadDepartmentList", list);
        }
    
        #endregion





        public IActionResult Details(int id)
        {
           Department dept = context.Departments.FirstOrDefault(d => d.Id == id);
          return View(dept);

        }
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
