using AutoMapper;
using WebAPITesting.Models;

namespace WebAPITesting
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<AppUser, AppUserDto>();
            CreateMap<Movie, MovieDto>();
        }
    }
}
