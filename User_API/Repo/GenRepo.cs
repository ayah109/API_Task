using Microsoft.EntityFrameworkCore;
using User_API.Model;

namespace User_API.Repo
{
    public interface IGenRepo<T> where T : class, IBaseModel
    {

        public Task<List<T>> GetAll();

        public Task<T> Get(int id);

        public Task<T> Add(T user);

        public Task<T> Ubdate(T user);

        public Task Delete(int id);

    }
    public class GenRepo<T> : IGenRepo<T> where T : class , IBaseModel
    {
        public UserContext _context;

        public GenRepo(UserContext context)
        {
            _context = context;
        }

        public async Task<List<T>> GetAll()
        {
          return _context.Set<T>().ToList();
        }

        public async Task< T>? Get(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public async Task Delete(int id)
        {
            var _temp =await _context.Set<T>().FirstOrDefaultAsync(c => c.Id ==  id);
           _context.Set<T>().Remove(_temp);
           await _context.SaveChangesAsync();
        }


        public async Task<T> Ubdate(T obj)
        {
           _context.Set<T>().Update(obj);
           await _context.SaveChangesAsync();
            return obj;
        }
        public async Task<T> Add(T obj)
        {
            await _context.Set<T>().AddAsync(obj);
            await _context.SaveChangesAsync();
            return obj;

        }
    }
}
