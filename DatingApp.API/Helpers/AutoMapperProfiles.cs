using System.Linq;
using AutoMapper;
using DatingApp.API.DTOs;
using DatingApp.API.Models;

namespace DatingApp.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForListDTO>()
                .ForMember(dest => dest.PhotoURL, opt => 
                    opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).URL))
                .ForMember(dest => dest.Age, opt =>
                    opt.MapFrom(src => src.DateOfBirth.CalculateAge()));
            CreateMap<User, UserForDetailsDTO>()
                .ForMember(dest => dest.PhotoURL, opt => 
                    opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).URL))
                .ForMember(dest => dest.Age, opt =>
                    opt.MapFrom(src => src.DateOfBirth.CalculateAge()));
            CreateMap<Photo, PhotosForDetailsDTO>();
        }
    }
}