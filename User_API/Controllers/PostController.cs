using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using User_API.Model;
using User_API.Repo;


namespace User_API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class PostController : ControllerBase
    {
        private readonly IPost_Repo post_Repo;

        public PostController(IPost_Repo post_Repo)
        {
            this.post_Repo = post_Repo;
        }

        [HttpGet]
        [Filtter("Admin")]
        public async Task <ActionResult<List<Posts>>> GetAll()
        {
            return await post_Repo.GetAll();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Posts>> Get(int id)
        {
            var POST = await post_Repo.Get(id);
            if (POST == null)
                return NotFound();
            return POST;

        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var POST = post_Repo.Get(id);
            if (POST == null)
                return NotFound();
            post_Repo.Delete(id);
            return Ok();

        }

        [HttpPost]
        public ActionResult Create(Posts post)
        {
           // if (post.userss == Users.Id)
            post_Repo.Add(post);
            return Ok();

        }

        [HttpPut]
        public ActionResult Ubdate(int id, Posts posts)
        {
            var _post_ = post_Repo.Get(id);
            if (posts.Id != id) 
                return BadRequest("Can't Ubdate ");
            if (_post_ != null)
                post_Repo.Ubdate(posts);
                return Ok();

        }

    }

}