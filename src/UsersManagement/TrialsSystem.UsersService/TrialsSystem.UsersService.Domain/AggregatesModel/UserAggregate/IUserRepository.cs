using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrialsSystem.UsersService.Domain.AggregatesModel.UserAggregate
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync(UsersQuerySettings settings);

        Task<User> CreateAsync(User user);
    }
}
