using User_API.Model;

namespace User_API.Repo
{
    public class Post_Repo : IPost_Repo
    {
        private List<Posts> Posts { get; set; }
        private UserContext Post_context;

        public Post_Repo(UserContext context)
        {
            Post_context = context;
        }

        public List<Posts> GetAll()
        {
            List<Posts> Post;

            Post = Post_context.Set<Posts>().ToList();

            return Post;
        }

        public Posts Get(int id)
        {
            Posts Posts;
            try
            {
                Posts = Post_context.Find<Posts>(id);
            }
            catch (Exception)
            {
                throw;
            }
            return Posts;
        }

        public void Delete(int Id)
        {
            Posts _temp = Get(Id);
            if (_temp != null)
            {
                Post_context.Remove<Posts>(_temp);
                Post_context.SaveChanges();
            }
        }

        public void Ubdate(Posts post)
        {
            Posts _temp = Get(post.PostId);
            if (_temp != null)
            {
                _temp.PostId = post.PostId;
                _temp.Title = post.Title;
                _temp.UserId = post.UserId;
                _temp.userss = post.userss;

                Post_context.Update<Posts>(_temp);
                Post_context.SaveChanges();
            }

        }

        public void Add(Posts post)
        {
            Post_context.Add<Posts>(post);
            Post_context.SaveChanges();

        }
    }

}


