using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Xacadmey.Models
{
    public class Course
    {

        public int Id { get; set; }
        [Required]
        [UniqueCourseName]
        public string Name { get; set; }
        [Range(minimum:50, maximum:100)]
        public int Degree { get; set; }
        public int Hours {  get; set; }
        [Range(minimum: 20, maximum: 50)]
        public int Mindegree { get; set; }
        //[ForeignKey("Department")]
        [ForeignKey("Department")]
        [Display(Name = "Department Name")]
        public int DepartmentId { get; set; }
        public virtual Department ? Department { get; set; }

    }
}
