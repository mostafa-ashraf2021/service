using AutoMapper;
using ContextLib.DTOs;
using ContextLib.Entites;

namespace WebService.AutoMapper
{
    public class ServiceProfile : Profile
    {
        public ServiceProfile(){
            CreateMap<ServiceModel,UserService>();
            //CreateMap<UserService,ServiceModel>();

        }
    }
}
