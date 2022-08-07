using Microsoft.AspNetCore.Mvc;
using User_API.Model;

namespace User_API.Repo
{
    public interface IPost_Repo : IGenRepo<Posts>
    {
        public Task<List<Posts>> Search(int page, int size, string search);
        

        }
}