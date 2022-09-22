using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrialsSystem.IdentityService.Infrastructure.Services
{
    public class UsersGatewayService : IUsersGatewayService
    {
        private readonly HttpClient _client;

        public UsersGatewayService(HttpClient client)
        {
            _client = client;
        }

       // public async Task<>
    }
}
