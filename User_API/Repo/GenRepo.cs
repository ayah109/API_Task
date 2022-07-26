using User_API.Model;

namespace User_API.Repo
{
    public interface IGenRepo<T> where T : class, IBaseModel
    {

        public List<T>? GetAll();

        public T Get(int id);

        public T Add(T user);

        public T Ubdate(T user);

        public void Delete(int id);

    }
    public class GenRepo<T> : IGenRepo<T> where T : class , IBaseModel
    {
        private readonly UserContext _context;

        public GenRepo(UserContext context)
        {
            _context = context;
        }

        public List<T>? GetAll()
        {
          return _context.Set<T>().ToList();

        }

        public T? Get(int id)
        {
            return _context.Set<T>().Find(id);
            
        }

        public void Delete(int id)
        {
            var _temp = _context.Set<T>().FirstOrDefault(c => c.Id ==  id);
           _context.Set<T>().Remove(_temp);
           _context.SaveChanges();
            
        }

        public T Ubdate(T obj)
        {
            _context.Set<T>().Update(obj);
            _context.SaveChanges();
            return obj;


        }

        public T Add(T obj)
        {
            _context.Set<T>().Add(obj);
            _context.SaveChanges();
            return obj;

        }




    }
}
