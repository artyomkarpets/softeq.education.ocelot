using AutoMapper;
using TrialsSystem.UserTasksService.Domain.AggregatesModel.UserTasksAggregate;
using TrialsSystem.UserTasksService.Infrastructure.Models;

namespace TrialsSystem.UserTasksService.Infrastructure.Mapping
{
    public class UserTaskMappingProfile : Profile
    {
        public UserTaskMappingProfile()
        {
            CreateMap<UserTask, UserTaskResponse>()
                .ForMember(dest => dest.Status,
                    opt => opt.MapFrom(x => x.Status.Name));
        }
    }
}
