using day2.Models;
using day2.SpecialCase;
using Microsoft.EntityFrameworkCore;

namespace day2.Repositry
{
    public class Departmentss :IDepartment
    {
        public Context context;

        public Departmentss(Context context)
        {
            this.context = context;
        }
        public void Add(Department department)
        {
            this.context.Add(department);
        }

        public void Delete(Department department)
        {
            this.context.Remove(department);
        }

        public List<Department> GetAll()
        {
            return this.context.Department.ToList();
        }

        public Department GetById(int id)
        {
            return this.context.Department.FirstOrDefault(d => d.id == id);
        }
        public void Update(Department department)
        {
            this.context.Update(department);
        }
        public void Save()
        {
            this.context.SaveChanges();
        }

        public List<Department> Include_Instructors_Courses()
        {
           return this.context.Department.Include(d => d.instructors).Include(d => d.courses).ToList();
        }
    }
}
