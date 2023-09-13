using AutoMapper;
using WebAPITesting.Models;

namespace WebAPITesting
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<User, UserDto>();
            CreateMap<Movie, MovieDto>();
        }
    }
}
