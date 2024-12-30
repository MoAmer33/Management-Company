using day2.Models;
using day2.SpecialCase;
using Microsoft.EntityFrameworkCore;

namespace day2.Repositry
{
    public class Coursess : ICourse
    {
        public Context context;

        public Coursess(Context context)
        {
            this.context = context;
        }
        public void Add(Course _course)
        {
            this.context.Add(_course);
        }

        public void Delete(Course _course)
        {
            this.context.Remove(_course);
        }
        public List<Course> GetAll()
        {
            return this.context.Courses.ToList();
        }

        public Course GetById(int id)
        {
            return this.context.Courses.FirstOrDefault(c => c.Id == id);
        }

        public void Update(Course _course)
        {
            this.context.Update(_course);
        }
        public void Save()
        {
            context.SaveChanges();
        }

        public List<Course> IncludeDepartments()
        {
            return this.context.Courses.Include(c=>c.Department).ToList();
        }


    }
}
