using User_API.Model;

namespace User_API.ViewModel
{
    public class UserVM :BaseModel
    {
        public int Id { get; set; }

        public string First_Name { get; set; }

        public string Last_Name { get; set; }

        public ICollection<PostVM>? Posts { get; set; }
    }
}
