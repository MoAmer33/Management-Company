using day2.Models;
using day2.Repositry;

namespace day2.SpecialCase
{
    public interface IDepartment:IRepositry<Department>
    {
        public List<Department> Include_Instructors_Courses();
        
    }
}
