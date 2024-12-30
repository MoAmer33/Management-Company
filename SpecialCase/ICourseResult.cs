using day2.Models;
using day2.Repositry;

namespace day2.SpecialCase
{
    public interface ICourseResult:IRepositry<CourseResult>
    {
        public List<CourseResult> Include_Trainee_Course_InCase_CourseId(int id);
        public List<CourseResult> Include_Trainee_Course_InCase_TraineeId(int id);
        public List<CourseResult> Include_Trainee_Course_Class();
    }
}
