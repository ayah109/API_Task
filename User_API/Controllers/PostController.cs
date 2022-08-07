using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using User_API.Model;
using User_API.Repo;
using User_API.ViewModel;

namespace User_API.Controllers
{
    [Authorize]
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
            var v = await post_Repo.GetAll<PostVM>();
            return v;

        }

        [HttpGet("Search")]
        public async Task<ActionResult<List<Posts>>> Search(int page, int size, string search)
        {
            return await post_Repo.Search(page, size, search);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PostVM>> Get(int id)
        {
            var POST = await post_Repo.Get<PostVM>(id);
            if (POST == null)
                return NotFound();

            return POST;
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
           await post_Repo.Delete(id); 
        }

        [HttpPost]
        public async Task Create(PostVM postvm)
        {
            var postv = _mapper.Map<Posts>(postvm);
            //take id from token of login 
            var idClaim = User.Claims.FirstOrDefault(x => x.Type.Equals("UserId", StringComparison.InvariantCultureIgnoreCase));
            var id_u = idClaim?.Value;
            postv.UserId= Convert.ToInt32(id_u);
            await post_Repo.Add(postv, Convert.ToInt32(id_u));
        }

        [HttpPut]
        public async Task Ubdate( PostVM postvm, int id)
        {
            var idClaim = User.Claims.FirstOrDefault(x => x.Type.Equals("UserId", StringComparison.InvariantCultureIgnoreCase));
            var id_u = idClaim?.Value;
            await post_Repo.Ubdate(_mapper.Map<Posts>(postvm), Convert.ToInt32(id_u)); 
               
        }
    }
}