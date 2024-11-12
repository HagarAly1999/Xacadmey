using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Xacadmey.Models
{
    public class Trainee
    {
        public int Id { get; set; }
        [Required]
        [MinLength(3,ErrorMessage ="Name must be greater than 3 letters")]
        [MaxLength(20, ErrorMessage = "Name must be less than 20 letters")]
        [UniqueName]
        public string Name { get; set; }
        [RegularExpression(@"\w+\.(jpg|png)",ErrorMessage ="Image must be jpg or png")]
        public string Image { get; set; }
        [Required]
        //[RegularExpression(@"(Alex|Assuit)")]
        public string Address { get; set; }
        [Required]

        public int Grade { get; set; }

        [ForeignKey("Department")]
        [Display(Name = "Department Name")]
        public int DepartmentId { get; set; }
        public virtual Department ? Department { get; set; }
    }
}
