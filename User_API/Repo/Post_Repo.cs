using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using User_API.Model;
using User_API.ViewModel;

namespace User_API.Repo
{
    public class Post_Repo : GenRepo<Posts>, IPost_Repo
    {
        public Post_Repo(UserContext context) : base(context)
        {

        }
        public async Task<List<Posts>> GetAll()
        {
            return _context.Posts.Include(c => c.userss).ToList();
        }

    }
}

