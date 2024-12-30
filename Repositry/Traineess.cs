using day2.Models;
using day2.SpecialCase;
using Microsoft.EntityFrameworkCore;

namespace day2.Repositry
{
    public class Traineess:ITrainee
    {
        public Context context;

        public Traineess(Context context)
        {
            this.context = context;
        }
        public void Add(Trainee _trainee)
        {
            this.context.Add(_trainee);
        }

        public void Delete(Trainee _trainee)
        {
            this.context.Remove(_trainee);
        }
        public List<Trainee> GetAll()
        {
            return this.context.Trainee.ToList();
        }

        public Trainee GetById(int id)
        {
            return this.context.Trainee.FirstOrDefault(c => c.Id == id);
        }

        public void Update(Trainee _trainee)
        {
            this.context.Update(_trainee);
        }
        public void Save()
        {
            context.SaveChanges();
        }

        public string GetTrianeeName(int id)
        {
            return context.Trainee.FirstOrDefault(T => T.Id == id).Name;
        }
    }
}
