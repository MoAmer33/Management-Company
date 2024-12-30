using day2.Models;
using day2.SpecialCase;
using Microsoft.EntityFrameworkCore;

namespace day2.Repositry
{
    public class Instructorss : IInstructors
    {
        public Context context;

        public Instructorss(Context context)
        {
            this.context = context;
        }
        public void Add(Instructor _instructor)
        {
            this.context.Add(_instructor);
        }

        public void Delete(Instructor _instructor)
        {
            this.context.Remove(_instructor);
        }
        public List<Instructor> GetAll()
        {
            return this.context.Instructors.ToList();
        }

        public Instructor GetById(int id)
        {
            return this.context.Instructors.FirstOrDefault(c => c.Id == id);
        }

        public void Update(Instructor _instructor)
        {
            this.context.Update(_instructor);
        }
        public void Save()
        {
            context.SaveChanges();
        }

        public Instructor GetInstructorByCourseId(int courseId)
        {
          return context.Instructors.FirstOrDefault(ins => ins.CourseId == courseId);
        }

        public List<Instructor> Include_Department_Courses()
        {
            return context.Instructors.Include(i => i.Department).Include(i => i.Course).ToList();
        }


        public List<Instructor> GetSpecificInstructor(string name)
        {
            return context.Instructors.Where(ins => ins.name.Contains(name)).ToList();
        }

        public Instructor GetInstructor_Include_Department_Courses(int id)
        {
            return context.Instructors.Include(i => i.Department).Include(i => i.Course).ToList().FirstOrDefault(ins => ins.Id == id);
        }


        //Special Cases
        //Get Instructor for Specific Course

    }
}
