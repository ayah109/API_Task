using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using User_API.Model;
using User_API.ViewModel;

namespace User_API.Repo
{
    public class Post_Repo : GenRepo<Posts>, IPost_Repo
    {
        public Post_Repo(UserContext context, IMapper mapper) : base(context, mapper)
        {

        }
        // public async Task<List<Posts>> GetAll()
        // {
        //  return _context.Posts.Include(c => c.userss).ToList();
        //}

        public async Task<List<Posts>> Search(int page, int size, string search)
        {
            return _context.Posts.Where(x => x.Title.Contains(search)).Skip(page * size).Take(size).ToList();
        }

    }//refliction magic
}

