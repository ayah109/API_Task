using AutoMapper;
using Microsoft.EntityFrameworkCore;
using User_API.Model;

namespace User_API.Repo
{
    public class User_Repo : GenRepo<Users>, IUser_Repo
    {
        public User_Repo(UserContext context, IMapper mapper) : base(context, mapper)
        {

        }
       // public async Task<List<Users>> GetAll()
      // {
       //    return _context.Users.Include(c => c.Posts).ToList();
       // }
    }


  }