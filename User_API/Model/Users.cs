using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace User_API.Model
{
    public class Users:IdentityUser<int>, IBaseModel
    {
        
        public string First_Name { get; set; }

        public string Last_Name { get; set; }

        public ICollection<Posts>? Posts { get; set; }

    }


   
}
