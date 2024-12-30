using day2.Models;
using day2.SpecialCase;
using Microsoft.EntityFrameworkCore;

namespace day2.Repositry
{
    public class CourseResultss : ICourseResult
    {
        public Context context;

        public CourseResultss(Context context)
        {
            this.context = context;
        }
        public void Add(CourseResult course_result)
        {
            this.context.Add(course_result);
        }

        public void Delete(CourseResult course_result)
        {
            this.context.Remove(course_result);
        }
        public List<CourseResult> GetAll()
        {
            return this.context.CoursesResult.ToList();
        }

        public CourseResult GetById(int id)
        {
            return this.context.CoursesResult.FirstOrDefault(c => c.Id == id);
        }

        public void Update(CourseResult course_result)
        {
            this.context.Update(course_result);
        }
        public void Save()
        {
            context.SaveChanges();
        }
        public List<CourseResult> Include_Trainee_Course_InCase_CourseId(int CourseId)
        {
           return this.context.CoursesResult.Include(r=>r.Trainee).Include(r=>r.Course).Where(c => c.CourseId == CourseId).ToList();
        }

        public List<CourseResult> Include_Trainee_Course_Class()
        {
            return this.context.CoursesResult.Include(c => c.Course).Include(T => T.Trainee).ToList();
        }

        public List<CourseResult> Include_Trainee_Course_InCase_TraineeId(int id)
        {
            return context.CoursesResult.Include(c => c.Course).Include(T => T.Trainee).Where(c => c.TraineeId == id).ToList();
        }
    }
}
