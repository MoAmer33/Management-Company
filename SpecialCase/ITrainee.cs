using day2.Models;
using day2.Repositry;

namespace day2.SpecialCase
{
    public interface ITrainee:IRepositry<Trainee>
    {
        public string GetTrianeeName(int id);
    }
}
