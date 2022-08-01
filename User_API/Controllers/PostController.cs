using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using User_API.Model;
using User_API.Repo;
using User_API.ViewModel;

namespace User_API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class PostController : ControllerBase
    {
        private readonly IPost_Repo post_Repo;
        private readonly IMapper _mapper;

        public PostController(IPost_Repo post_Repo, IMapper _mapper)
        {
            this.post_Repo = post_Repo;
            this._mapper = _mapper;
        }

        
        [HttpGet]
       // [Filtter("Admin")]
        public async Task <ActionResult<List<PostVM>>> GetAll()
        {
            var v = await post_Repo.GetAll();
            return _mapper.Map< List<PostVM>>(v);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PostVM>> Get(int id)
        {
            var POST = await post_Repo.Get(id);
            if (POST == null)
                return NotFound();

            return _mapper.Map<Posts, PostVM>(POST);
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
        public ActionResult Create(PostVM postvm)
        {
            var postv = _mapper.Map<Posts>(postvm);
            post_Repo.Add(postv);
            return Ok();
        }

        [HttpPut]
        public ActionResult Ubdate(int id, PostVM postvm)
        {
            var _post_ = post_Repo.Get(id);
            if (postvm.Id != id) 
                return BadRequest("Can't Ubdate ");
            if (_post_ != null)
                post_Repo.Ubdate(_mapper.Map<Posts>(postvm));
                return Ok();

        }

    }

}