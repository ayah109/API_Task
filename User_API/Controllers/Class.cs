using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using User_API.Model;
using User_API.Repo;


namespace User_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Class : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Users>> GetAll()
        {
            return User_Repo.GetAll();
        }


        [HttpGet("{id}")]
        public ActionResult<Users> Get(int id)
        {
            var USER = User_Repo.Get(id);
            if (USER == null)
                return NotFound();
            return USER;

        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
        var USER = User_Repo.Get(id);
        if (USER == null)
            return NotFound();
        User_Repo.Delete(id);
         return Ok();

        }

        [HttpPost]
        public ActionResult Create(Users users)
        {
            User_Repo.Add(users);
            return Ok();

        }

        [HttpPut]
        public ActionResult Ubdate(int Id, Users users)
        {
            var _user_ = User_Repo.Get(Id);
            if (_user_ != null)
                User_Repo.Ubdate(users);
            return Ok();

        }




    }
}
