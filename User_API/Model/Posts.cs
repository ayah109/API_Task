using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace User_API.Model
{
    public class Posts : BaseModel
    {
       
        public String Title { get; set; }

        [ForeignKey(nameof(userss))]
        public int UserId { get; set; }

        public Users? userss { get; set; }


    }
}
