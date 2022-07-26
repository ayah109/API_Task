using User_API.Model;

namespace User_API.Repo
{
    public class User_Repo : GenRepo<Users>, IUser_Repo
    {
        public User_Repo(UserContext context) : base(context)
        {

        }


    }
}


