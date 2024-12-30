using day2.Models;
using day2.Repositry;

namespace day2.SpecialCase
{
    public interface IInstructors:IRepositry<Instructor>
    {
        //Get Instructor for Specific Course
        public Instructor GetInstructorByCourseId(int courseId);
        public List<Instructor> Include_Department_Courses();
        public List<Instructor> GetSpecificInstructor(string name);
        public Instructor GetInstructor_Include_Department_Courses(int id);

    }
}
