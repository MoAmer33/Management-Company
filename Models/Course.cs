using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using day2.ValidationModel;
namespace day2.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(20)]
        [UniqueName()]
        public string Name { get; set; }
        [Required]
        [Range(50, 100)]
        public float MaxDgree { get; set; }
        [Required]
        [Remote(action: "CheckDegree", controller: "Course", AdditionalFields = "MaxDgree",ErrorMessage ="MinDgree should be less than MaxDgree")]
        public float MinDgree { get; set; }
        [Required]
        [RegularExpression(@"(2|3)",ErrorMessage ="Should be 3 or 2")]
        public int Hours { get; set; }
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public  Department? Department { get; set; }
    }
}
