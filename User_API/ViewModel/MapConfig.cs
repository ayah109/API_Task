using AutoMapper;
using User_API.Model;

namespace User_API.ViewModel
{
    public class MapConfig : Profile
    {
       public MapConfig()
        {
            CreateMap<Users,UserVM >().ReverseMap(); //reverse so the both direction
            CreateMap<Posts, PostVM>().ReverseMap(); 
        }
    }
}
