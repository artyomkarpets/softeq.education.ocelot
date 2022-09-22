using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrialSystem.Shared.UsersService.Models
{
    public class CreateUserRequest
    {
        public string Email { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime BirthDate { get; set; }

        public Guid CityId { get; set; }

        public Guid GenderId { get; set; }

        public string IdentityId { get; set; }

    }
}
