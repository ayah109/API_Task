using User_API.Model;

namespace User_API
{
    public static class AddMyServeces
    {
        public static void InitServ(this IServiceCollection iserv)
        {
            iserv.AddEndpointsApiExplorer();

            iserv.AddSwaggerGen();

            iserv.AddControllers();

            iserv.AddScoped<User_API.Repo.IUser_Repo, User_API.Repo.User_Repo>();

            iserv.AddScoped<User_API.Repo.IPost_Repo, User_API.Repo.Post_Repo>();

        }

    }
}
