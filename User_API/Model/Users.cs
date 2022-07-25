using System.ComponentModel.DataAnnotations;

namespace User_API.Model
{
    public class Users
    {
        [Key]
        public int Id { get; set; }

        public string First_Name { get; set; }

        public string Last_Name { get; set; }

        public ICollection<Posts>? Posts { get; set; }

    }
}
