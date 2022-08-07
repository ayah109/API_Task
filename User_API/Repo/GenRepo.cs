using Microsoft.EntityFrameworkCore;
using User_API.Model;
using AutoMapper;
using User_API.ViewModel;
using AutoMapper.QueryableExtensions;
using System.Linq;

namespace User_API.Repo
{
    public interface IGenRepo<T> where T : class, IBaseModel
    {

        public Task<List<TVM>> GetAll<TVM>();

        public Task<TVM> Get<TVM>(int id) where TVM :class , IBaseModel;

        public Task<T> Add(T user, int UserId);

        public Task<T> Ubdate(T user, int UserId);

        public Task Delete(int id);

    }
    public class GenRepo<T> : IGenRepo<T> where T : class , IBaseModel
    {

        DateTime now = DateTime.Now;

        public UserContext _context;
        public readonly IMapper _mapper;

        public GenRepo(UserContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<TVM>>GetAll<TVM>() 
        {
            return  _context.Set<T>().ProjectTo<TVM>(_mapper.ConfigurationProvider).ToList();
        }

        public async Task<TVM>? Get<TVM>(int id) where TVM :class , IBaseModel
        {
            return _context.Set<T>().ProjectTo<TVM>(_mapper.ConfigurationProvider).FirstOrDefault(x => x.Id == id);
        }

        public async Task Delete(int id)
        {
            var _temp =await _context.Set<T>().FirstOrDefaultAsync(c => c.Id ==  id);
           _context.Set<T>().Remove(_temp);
           await _context.SaveChangesAsync();
        }


        public async Task<T> Ubdate(T obj, int UserId)
        {
            Type type = obj.GetType();
            var prob1 = type.GetProperty("UbdateDate");
            prob1?.SetValue(obj, now);

            var prob2 = type.GetProperty("UbdateBy");
            prob2?.SetValue(obj, UserId);

            _context.Set<T>().Update(obj);
           await _context.SaveChangesAsync();
            return obj;
        }
        public async Task<T> Add(T obj, int UserId)
        {
            Type type = obj.GetType();
            var prob1 = type.GetProperty("CreatDate");
            prob1?.SetValue(obj, now);

            var prob2 = type.GetProperty("CreatBy");
            prob2?.SetValue(obj, UserId);

            await _context.Set<T>().AddAsync(obj);
            await _context.SaveChangesAsync();
            return obj;

        }
    }
}
