using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TrialsSystem.UsersService.Domain.AggregatesModel.UserAggregate;
using TrialsSystem.UsersService.Infrastructure.Contexts;

namespace TrialsSystem.UsersService.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _context;

        public UserRepository(UserContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllAsync(UsersQuerySettings settings)
        {

            return await _context.Users.Include(x => x.Devices)
                    .Include(x => x.City)
                    .Include(x => x.Gender)
                    .OrderBy(x => x.Email)
                    .Skip(settings.Skip)
                    .Take(settings.Take)
                    .ToListAsync();
        }

        public async Task<User> CreateAsync(User user)
        {
            _context.Users.Add(user);

            await _context.Entry(user).Reference(x => x.City).LoadAsync();
            await _context.Entry(user).Reference(x => x.Gender).LoadAsync();

            await SaveAsync();

            return user;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
