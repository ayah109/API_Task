using Microsoft.AspNetCore.Mvc;
using User_API.Model;

namespace User_API.Repo
{
    public interface IPost_Repo
    {

        public List<Posts> GetAll();

        public Posts Get(int id);

        public void Delete(int Id);

        public void Ubdate(Posts post);
        
        public void Add(Posts post);
    }
}