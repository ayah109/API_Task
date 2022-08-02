using Microsoft.AspNetCore.Identity;

namespace User_API.Auth
{
    public class UserRoles : IdentityRole<int>
    {
        public const string Admin = "Admin";
        public const string User = "User";

    }
}

