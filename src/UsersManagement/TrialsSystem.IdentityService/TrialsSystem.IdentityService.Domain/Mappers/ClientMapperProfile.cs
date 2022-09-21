using System.Collections.Generic;
using System.Security.Claims;
using AutoMapper;

namespace TrialsSystem.IdentityService.Domain.Mappers
{
    /// <summary>
    /// Defines entity/model mapping for clients.
    /// </summary>
    /// <seealso cref="AutoMapper.Profile" />
    public class ClientMapperProfile : Profile
    {
        public ClientMapperProfile()
        {
            CreateMap<Entities.Property, KeyValuePair<string, string>>()
                .ReverseMap();

            CreateMap<Entities.ClientEntity, IdentityServer4.Models.Client>()
                .ForMember(dest => dest.ProtocolType, opt => opt.Condition(srs => srs != null))
                .ReverseMap();

            CreateMap<Entities.Claim, IdentityServer4.Models.ClientClaim>(MemberList.None)
                .ConstructUsing(src => new IdentityServer4.Models.ClientClaim(src.Type, src.Value, ClaimValueTypes.String))
                .ReverseMap();

            CreateMap<Entities.SecretEntity, IdentityServer4.Models.Secret>(MemberList.Destination)
                .ForMember(dest => dest.Type, opt => opt.Condition(srs => srs != null))
                .ReverseMap();
        }
    }
}