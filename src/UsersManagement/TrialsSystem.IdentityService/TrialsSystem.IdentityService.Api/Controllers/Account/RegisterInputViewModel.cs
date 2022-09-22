using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TrialsSystem.IdentityService.Api.Controllers
{
    public class RegisterInputViewModel
    {
        public Guid Id { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "portal.comparePasswords")]
        public string ConfirmPassword { get; set; }


        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime BirthDate { get; set; } = DateTime.Now;

        public Guid City { get; set; }

        public Guid Gender { get; set; }

        public string ReturnUrl { get; set; }
    }
}
