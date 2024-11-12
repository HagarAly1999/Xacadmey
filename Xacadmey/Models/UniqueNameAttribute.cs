using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Xacadmey.Models
{
    public class UniqueNameAttribute:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
                return null;

            Academy context = new Academy();
            string newTrainee = value.ToString();
            Trainee  trform = (Trainee)validationContext.ObjectInstance;
          
          


            if (trform.Id > 0)
            {
                Trainee wantedit = context.Traineess.FirstOrDefault(c => c.Id == trform.Id);
                if (newTrainee == wantedit.Name)
                {
                    return ValidationResult.Success;

                }

            }
            Trainee Trdb = context.Traineess.FirstOrDefault(s => s.Name == newTrainee);
            if (Trdb != null)
            {
                return new ValidationResult("Name must be unique");
            }
            return ValidationResult.Success;
        }
    }
}



