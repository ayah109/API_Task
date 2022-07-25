using Microsoft.AspNetCore.Mvc;
using User_API.Model;

namespace User_API.Repo
{
    public interface IUser_Repo
    {
        public List<Users> GetAll();

        public Users Get(int id);

        public void Add(Users user);

        public void Ubdate(Users user);

        public void Delete(int id);

    }
}