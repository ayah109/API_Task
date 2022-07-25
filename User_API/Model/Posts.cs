using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace User_API.Model
{
    public class Posts
    {
        [Key]
        public int PostId { get; set; }

        public String Title { get; set; }

        [ForeignKey("Users")]
        public int UserId { get; set; }

        public Users? userss { get; set; }


    }
}
