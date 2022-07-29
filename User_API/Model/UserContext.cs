using Microsoft.EntityFrameworkCore;

namespace User_API.Model
{
    public class UserContext :DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options) { }
        public DbSet<Users> Users {get; set;}

        public DbSet<Posts> Posts {get; set;}


    }

}


    
