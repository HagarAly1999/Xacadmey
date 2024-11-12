using System.ComponentModel.DataAnnotations.Schema;

namespace Xacadmey.Models
{
    public class CourseResult
    {
     
            public int Id { get; set; }
            public int Degree { get; set; }
            public virtual Course Course { get; set; }
            [ForeignKey("Course")]

            public int CourseId { get; set; }
            [ForeignKey("Trainee")]
      
            public int TraineeId { get; set; }
            public virtual Trainee Trainee { get; set; }
        


    }
}
