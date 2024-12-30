using day2.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace day2.ViewModel
{
    public class Helper
    {
        public List<Instructor> ins = new List<Instructor>();
        public Instructor instr = new Instructor();
        public Instructor Instructor { get; set; }=new Instructor();
        public Course  Course{ get; set; }
        public List<Course> courses=new List<Course>();
        public List<Department> departments=new List<Department>();
    }
}
