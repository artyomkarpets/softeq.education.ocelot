using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrialsSystem.UsersService.Domain.AggregatesModel.UserAggregate;
using TrialsSystem.UsersService.Infrastructure.Models.BaseDtos;
using TrialsSystem.UsersService.Infrastructure.Models.UserDTOs;

namespace TrialsSystem.UsersService.Infrastructure.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, GetUsersResponse>()
                .ForMember(dest => dest.CityName,
                    opt =>
                        opt.MapFrom(x => x.City.Name))
                .ForMember(dest => dest.GenderName,
                    opt =>
                        opt.MapFrom(x => x.Gender.Name));


            CreateMap<City, IdNameDto>();
            CreateMap<Gender, IdNameDto>();

            CreateMap<User, CreateUserResponse>();

        }
    }
}
