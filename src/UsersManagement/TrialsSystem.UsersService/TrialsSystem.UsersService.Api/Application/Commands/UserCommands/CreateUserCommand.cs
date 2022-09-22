using MediatR;
using TrialsSystem.UsersService.Infrastructure.Models.UserDTOs;

namespace TrialsSystem.UsersService.Api.Application.Commands.UserCommands
{
    public class CreateUserCommand : IRequest<Guid>
    {
        public CreateUserCommand(string email,
            string name,
            string surname,
            Guid cityId,
            DateTime birthDate,
            Guid genderId,
            string identityId)
        {
            Email = email;
            Name = name;
            Surname = surname;
            CityId = cityId;
            BirthDate = birthDate;
            GenderId = genderId;
            IdentityId = identityId;
        }

        public string Email { get; }

        public string Name { get; }

        public string Surname { get; }

        public Guid CityId { get; }

        public DateTime BirthDate { get; }
        
        public Guid GenderId { get; }

        public string IdentityId { get; }



    }
}
