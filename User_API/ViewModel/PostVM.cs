using User_API.Model;

namespace User_API.ViewModel
{
    public class PostVM :BaseModel
    {
      //  public int Id { get; set; }

        public String Title { get; set; }

        public int UserId { get; set; }  
    }
}
