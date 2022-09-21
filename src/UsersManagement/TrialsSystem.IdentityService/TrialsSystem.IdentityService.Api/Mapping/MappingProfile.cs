using AutoMapper;
using TrialsSystem.IdentityService.Api.Controllers;

namespace TrialsSystem.IdentityService.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterInputViewModel, RegisterViewModel>();
        }
    }
}
