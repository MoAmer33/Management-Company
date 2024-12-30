using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace day2.Models
{
    public class Instructor
    {
        public int Id { get; set; }
        public string name { get; set; }
        public float salary { get; set; }
        public string address { get; set; }
        public string img { get; set; }

        [ForeignKey("Department")]
        public  int DepartmentId { get; set; }
        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public Department Department { get; set; }
        public Course Course { get; set; }
    }
}
