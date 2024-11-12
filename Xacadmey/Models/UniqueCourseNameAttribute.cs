using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Xacadmey.Models
{
    public class UniqueCourseName : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Academy context = new Academy();

            Course crsform = (Course)validationContext.ObjectInstance;
            string newCourse = value.ToString();
            if (value == null)
                return null;


            if (crsform.Id > 0)
            {
                Course wantedit = context.Courses.FirstOrDefault(c=>c.Id == crsform.Id);
                if (newCourse == wantedit.Name)
                {
                    return ValidationResult.Success;

                }

            }
            Course crsdb = context.Courses.FirstOrDefault(s => s.Name == newCourse);
            if (crsdb != null)
            {
                return new ValidationResult("Name must be unique");
            }
            return ValidationResult.Success;
        }
    }
}


