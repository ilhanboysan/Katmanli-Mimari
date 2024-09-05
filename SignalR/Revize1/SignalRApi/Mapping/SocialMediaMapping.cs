using AutoMapper;
using SignalR.DtoLayer.AboutDto;
using SignalR.DtoLayer.SocialMediaDto;
using SignalR.EntityLayer.Entities;
namespace SignalRApi.Mapping
{
    public class SocialMediaMapping:Profile
    {
        public SocialMediaMapping()
        {
            CreateMap<SocialMedia,ResultSocialMediaDto>().ReverseMap();
            CreateMap<SocialMedia,CreateSoicalMediaDto>().ReverseMap();
            CreateMap<SocialMedia,UpdateSocialMediaDto>().ReverseMap();
            CreateMap<SocialMedia,GetSocialMediaDto>().ReverseMap();
        }
    }
}
