using System.Reflection.Metadata.Ecma335;
using AutoMapper;
using MediatR;
using TrialsSystem.UsersService.Domain.AggregatesModel.UserAggregate;
using TrialsSystem.UsersService.Infrastructure.Models.UserDTOs;

namespace TrialsSystem.UsersService.Api.Application.Commands.UserCommands
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserResponse>
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        public CreateUserCommandHandler(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CreateUserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user
                = await _repository.CreateAsync(
                   new User(request.Email, request.Name, request.Surname, request.CityId, request.GenderId,
                   request.BirthDate));

            return _mapper.Map<CreateUserResponse>(user);
        }
    }
}
