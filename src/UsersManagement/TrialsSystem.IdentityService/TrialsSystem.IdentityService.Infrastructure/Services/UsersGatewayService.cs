using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using TrialsSystem.IdentityService.Infrastructure.Exceptions;
using TrialSystem.Shared.UsersService.Models;

namespace TrialsSystem.IdentityService.Infrastructure.Services
{
    public class UsersGatewayService : IUsersGatewayService
    {
        private const string userUrl = "/api/v1/Users";
        private const string citiesUrl = "/api/v1/Cities";
        private const string gendersUrl = "/api/v1/Genders";


        private readonly HttpClient _client;

        public UsersGatewayService(HttpClient client)
        {
            _client = client;
        }

        public async Task CreateUser(CreateUserRequest userRequest)
        {
            var response = await _client.PostAsJsonAsync(userUrl, userRequest);

            if (!response.IsSuccessStatusCode)
            {
                throw new UsersGatewayServiceException(response.RequestMessage);
            }
        }

        public async Task<IEnumerable<IdNameDto>> GetCities()
        {
            return new List<IdNameDto>();
        }

        public async Task<IEnumerable<IdNameDto>> GetGenders()
        {
            return new List<IdNameDto>();
        }
    }
}
