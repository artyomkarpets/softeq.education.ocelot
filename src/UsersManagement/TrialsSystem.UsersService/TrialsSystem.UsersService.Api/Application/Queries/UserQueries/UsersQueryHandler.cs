using AutoMapper;
using MediatR;
using TrialsSystem.UsersService.Domain.AggregatesModel.UserAggregate;
using TrialsSystem.UsersService.Infrastructure.Models.UserDTOs;

namespace TrialsSystem.UsersService.Api.Application.Queries.UserQueries
{
    public class UsersQueryHandler : IRequestHandler<UsersQuery, IEnumerable<GetUsersResponse>>
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public UsersQueryHandler(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetUsersResponse>> Handle(UsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _repository.GetAllAsync(new UsersQuerySettings(request.Skip, request.Take));
            return _mapper.Map<IEnumerable<GetUsersResponse>>(users);
        }
    }
}
