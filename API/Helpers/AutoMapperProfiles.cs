
using API.DTOs;
using API.Entities;
using API.Extensions;
using AutoMapper;

namespace API.Helpers;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<AppUser, MemberDto>()
            .ForMember( d=> d.Age, o => o.MapFrom ( s => s.DateOfBirth.CalculateAge()))
            .ForMember( d => d.PhotoUrl,
                o => o.MapFrom(
                    s => s.Photos.FirstOrDefault(
                        x => x.IsMain)!.Url)); // '!' will set to null if there is no photo which is OK as per this App
        CreateMap<Photo, PhotoDto>();
    }
}
