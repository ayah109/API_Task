using Microsoft.EntityFrameworkCore;
using User_API.Model;

namespace User_API.Repo
{
    public class Post_Repo : GenRepo<Posts>, IPost_Repo
    {
        public Post_Repo(UserContext context) : base(context)
        {

        }

        public new List<Posts>? GetAll()
        {
            return _context.Posts.Include(c => c.userss).ToList();
        }



    }
        
       

}


