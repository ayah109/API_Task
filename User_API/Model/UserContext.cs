using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Services.UserAccountMapping;
using User_API.Auth;

namespace User_API.Model
{
    public class UserContext : IdentityDbContext<Users, UserRoles, int>
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options) { }
       
        public DbSet<Users> Users {get; set;}

        public DbSet<Posts> Posts {get; set;}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }

}

