using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using User_API.Model;
using User_API.Repo;

namespace User_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UserController : ControllerBase
    {
        private readonly IUser_Repo user_Repo;
        public UserController(IUser_Repo user_Repo)
        {
            this.user_Repo = user_Repo;
        }   

        [HttpGet]
        [Filtter("Admin")] //prevent request with wrong key , for Role Header
        public async Task<ActionResult> GetAll()
        {
            var x = await user_Repo.GetAll();
            return Ok(x);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Users>> Get(int id)
        {
            var USER = user_Repo.Get(id);
            if (USER == null)
                return NotFound();
            return Ok(USER);

        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var USER = user_Repo.Get(id);
            if (USER == null)
                return NotFound();
            user_Repo.Delete(id);
            return Ok();
        }

        [HttpPost]
        public ActionResult Create(Users users)
        {
            user_Repo.Add(users);
            return Ok();
        }

        [HttpPut]
        public ActionResult Ubdate(int Id, Users users)
        {
            var _user_ = user_Repo.Get(Id);
            if (users.Id != Id) return BadRequest("Can't Ubdate ");
            if (_user_ != null)
                user_Repo.Ubdate(users);
            return Ok();
        }
    }
}
