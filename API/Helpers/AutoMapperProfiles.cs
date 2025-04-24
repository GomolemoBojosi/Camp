using API.DTOs;
using API.Entities;
using AutoMapper;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Campground, CampgroundDto>()
                .ForMember(x => x.Photos, x => x.MapFrom(src => src.Photos));
            CreateMap<Review, ReviewDto>()
                .ForMember(x => x.CampgroundId, opt => opt.Ignore());
            CreateMap<CampgroundUpdateDto, Campground>();
            CreateMap<User, UserDto>();
            CreateMap<Photo, PhotoDto>();
        }
    }
}
