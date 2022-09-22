using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrialSystem.Shared.UsersService.Models;

namespace TrialsSystem.IdentityService.Infrastructure.Services
{
    public interface IUsersGatewayService
    {
        Task CreateUser(CreateUserRequest userRequest);
        Task<IEnumerable<IdNameDto>> GetCities();
        Task<IEnumerable<IdNameDto>> GetGenders();


    }
}
