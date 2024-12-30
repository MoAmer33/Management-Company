using day2.Models;

namespace day2.Repositry
{
    public interface IRepositry<T>
    {

        public void Add(T SpecificRepo);
        public T GetById(int id);
        public List<T> GetAll();
        public void Update(T SpecificRepo);
        public void Delete(T SpecificRepo);
        public void Save();
    }
}
