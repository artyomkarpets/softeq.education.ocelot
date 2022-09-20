using MediatR;
using TrialsSystem.UsersService.Infrastructure.Models.UserDTOs;

namespace TrialsSystem.UsersService.Api.Application.Commands.UserCommands
{
    public class CreateUserCommand : IRequest<CreateUserResponse>
    {
        public CreateUserCommand(string email,
            string name,
            string surname,
            Guid cityId,
            DateTime birthDate,
            decimal? weight,
            decimal? height,
            Guid genderId,
            string userId)
        {
            Email = email;
            Name = name;
            Surname = surname;
            CityId = cityId;
            BirthDate = birthDate;
            Weight = weight;
            Height = height;
            GenderId = genderId;
        }

        public string Email { get; }

        public string Name { get; }

        public string Surname { get; }

        public Guid CityId { get; }

        public DateTime BirthDate { get; }

        public decimal? Weight { get; }

        public decimal? Height { get; }

        public Guid GenderId { get; }


    }
}
