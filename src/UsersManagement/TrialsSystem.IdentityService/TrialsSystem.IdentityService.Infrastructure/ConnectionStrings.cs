using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrialsSystem.IdentityService.Infrastructure
{
    public static class ConnectionStrings
    {
        public static string IdentityDatabase = nameof(IdentityDatabase);
        public const string Issuer = nameof(Issuer);
        public const string UsersService = nameof(UsersService);
        public const string UserTasksService = nameof(UserTasksService);

    }
}
