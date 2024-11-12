using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Xacadmey.Models;
using Xacadmey.Repositary;
using Xacadmey.ViewModel;

namespace Xacadmey.Controllers
{
    public class TraineeController : Controller
    {
        // Academy context = new Academy();
        ITraineeRepository traineeRepository;

        IDepartmentRepository departmentRepository;
        public TraineeController(ITraineeRepository _TranRep,IDepartmentRepository _DeptRep)
        {
            traineeRepository = _TranRep;//new TraineeRepositary();
            departmentRepository = _DeptRep;//new DepartmentRepositary();
        }
    
         //public IActionResult TraineeCourseResult(int id, object context)
         //{
         //    try
         //    {

         //        List<CourseResult> courses = context.CourseResults.Include(x => x.Trainee).Include(y => y.Course).Where(T => T.TraineeId == id).ToList();
         //        List<TraineeGetbyidViewModel> ListOfModel = new List<TraineeGetbyidViewModel>();

         //        foreach (var course in courses) {
         //            TraineeGetbyidViewModel tranieViModel = new TraineeGetbyidViewModel();
         //            tranieViModel.TraineeDegree = course.Degree;
         //            tranieViModel.TraineeName = course.Trainee.Name;
         //            tranieViModel.CourseName = course.Course.Name;

         //            if (course.Degree > 25)
         //            {
         //                tranieViModel.Color = "green";
         //                tranieViModel.Status = "pass";
         //            }
         //            else
         //            {
         //                tranieViModel.Color = "red";
         //                tranieViModel.Status = "fail";
         //            }

         //            ListOfModel.Add(tranieViModel);

         //        }
         //        return View(ListOfModel);

         //    }
         //    catch (System.Exception ex)
         //    {

         //        throw;
         //    }
         //}
        [HttpGet]

        //public IActionResult New()
        //{
        //    // ViewData["DeptList"] = context.Departments.ToList();
        //     ViewData["DeptList"] = departmentRepositary.GetAll();
        //    return View("New");
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult SaveNew(Trainee tr)
        //{

        //    if (ModelState.IsValid == true)
        //    {
        //        if (tr.DepartmentId != 0)
        //        {


        //            try
        //            {
        //                traineeRepositary.Insert(tr);
        //                context.Traineess.Add(tr);
        //               context.SaveChanges();

        //                return RedirectToAction("Index");
        //            }
        //            catch (Exception e)
        //            {
        //                ModelState.AddModelError("", e.Message);
        //            }
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("DepartmentId", "select department");
        //        }
        //    }
        //         ViewData["DeptList"] = context.Departments.ToList();
        //        //ViewData["DeptList"] = departmentRepositary.GetAll();
        //        return View("New",tr);


        //}
        //public IActionResult Index()
        //{
        //     List<Trainee> trainees = context.Traineess.Include(X=>X.Department).ToList();
        //    //List<Trainee> trainees=traineeRepositary.GetAll();
        //    return View(trainees);
        //}
        [Authorize]
        public IActionResult ReadTraineeslist()
        {
            List<Trainee> trainees = traineeRepository.GetAll();
            return View(trainees);
        }
        [HttpGet]
        public IActionResult CreateNewTrainee()
        {
            //var department = context.Departments.
            //    Select(d => new SelectListItem
            //    {
            //        Value = d.Id.ToString(),
            //        Text = d.Name
            //    }
            //    ).ToList();
            //ViewBag.DepartmentId = department;
            ViewData["DeptList"] = departmentRepository.GetAll();

            return View();
        }
        [HttpPost]
        public IActionResult CreateNewTrainee(Trainee trainee)
        {

            if (ModelState.IsValid == true)
            {
                if (trainee.DepartmentId != 0)
                {


                    try
                    {
                        //context.Traineess.Add(trainee);
                        //context.SaveChanges();
                        traineeRepository.Insert(trainee);

                        return RedirectToAction("ReadTraineeslist");
                    }
                    catch (Exception e)
                    {
                        ModelState.AddModelError("", e.Message);
                    }
                }
                else
                {
                    ModelState.AddModelError("DepartmentId", "select department");
                }
            }
            ViewData["DeptList"] = departmentRepository.GetAll();
          //  ViewData["DeptList"] = context.Departments.ToList();
            //var department = context.Departments.
            //  Select(d => new SelectListItem
            //  {
            //      Value = d.Id.ToString(),
            //      Text = d.Name
            //  }
            //  ).ToList();
            //ViewBag.DepartmentId = department;


            return View(trainee);
          
        }
        [HttpGet]
        public IActionResult EditTrainee(int id) {


            Trainee trainee= traineeRepository.GetById(id);
            ViewData["DeptList"] = departmentRepository.GetAll();
            //Trainee trainee = context.Traineess.Find(id);

            //var department = context.Departments.
            //Select(d => new SelectListItem
            //{
            //    Value = d.Id.ToString(),
            //    Text = d.Name
            //}
            //).ToList();
            //ViewBag.DepartmentId = department;
            return View(trainee);
        }
        [HttpPost]

        public IActionResult EditTrainee(Trainee tr)
        {
            if (ModelState.IsValid == true)
            {
                if (tr.DepartmentId != 0)
                {


                    try
                    {
                        //context.Traineess.Update(tr);
                        //context.SaveChanges();
                      traineeRepository.Update(tr);

                        return RedirectToAction("ReadTraineeslist");
                    }
                    catch (Exception e)
                    {
                        ModelState.AddModelError("", e.Message);
                    }
                }
                else
                {
                    ModelState.AddModelError("DepartmentId", "select department");
                }
            }
             ViewData["DeptList"] = departmentRepository.GetAll();
            //var department = context.Departments.
            //  Select(d => new SelectListItem
            //  {
            //      Value = d.Id.ToString(),
            //      Text = d.Name
            //  }
            //  ).ToList();
               //    ViewBag.DepartmentId = department;


            return View(tr);
        }
    
        public ActionResult DeleteTrainee(int id)
        {

            //Trainee t = context.Traineess.Find(id);
            //context.Traineess.Remove(t);
            //context.SaveChanges();
            traineeRepository.Delete(id);
            return RedirectToAction("ReadTraineeslist");
        }
    }
}

