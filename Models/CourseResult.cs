using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace day2.Models
{
    public class CourseResult
    {
        public int Id { get; set; }
        public string DgreeOfTrainee { get; set; }
        [ForeignKey("Course")]
        public int CourseId { get; set; }
        [ForeignKey("Trainee")]
        public int  TraineeId { get; set; }

        public Course Course { get; set; }
        public Trainee Trainee { get; set; }
    }
}
