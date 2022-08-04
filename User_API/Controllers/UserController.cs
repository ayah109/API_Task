using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using User_API.Model;
using User_API.Repo;
using User_API.ViewModel;

namespace User_API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]

    public class UserController : ControllerBase
    {
        private readonly IUser_Repo user_Repo;
        private readonly IMapper _mapper;
        public UserController(IUser_Repo user_Repo, IMapper _mapper)
        {
            this.user_Repo = user_Repo;
            this._mapper = _mapper;
        }   

        [HttpGet]
        //[Filtter("Admin")] //prevent request with wrong key , for Role Header
        public async Task<ActionResult <List<UserVM>>> GetAll()
        {
            var x = await user_Repo.GetAll<UserVM>();
            return x;
        }

     


        [HttpGet("{id}")]
        public async Task<ActionResult<UserVM>> Get(int id)
        {
            var USER = await user_Repo.Get<UserVM>(id);
            if (USER == null)
                return NotFound();
            return USER;

        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
           // var USER = user_Repo.Get(id);
           // if (USER == null)
             //   return NotFound();
            await user_Repo.Delete(id);
            //return Ok();
        }

        [HttpPost]
        public async Task Create(UserVM uservm)
        {
            var userv = _mapper.Map<Users>(uservm);
            await user_Repo.Add(userv);
        }

        [HttpPut]
        public async Task Ubdate(int Id, UserVM uservm)
        {
            
               await user_Repo.Ubdate(_mapper.Map<Users>(uservm));
         
        }
    }
}
