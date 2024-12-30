using day2.Models;
using day2.Repositry;

namespace day2.SpecialCase
{
    public interface ICourse:IRepositry<Course>
    {
        public List<Course> IncludeDepartments();
    }
}
