using FluentValidation;
using TrialsSystem.UsersService.Infrastructure.Models.UserDTOs;
using TrialSystem.Shared.UsersService.Models;

namespace TrialsSystem.UsersService.Api.Application.Validation
{
    public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
    {
        public CreateUserRequestValidator()
        {
            RuleFor(u => u.BirthDate)
                .Must(u => u < DateTime.Now.AddYears(-18)).WithMessage("The participant should be older than 18 years.");
        }
    }
}
