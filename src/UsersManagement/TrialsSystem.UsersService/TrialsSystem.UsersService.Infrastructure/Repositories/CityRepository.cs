using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TrialsSystem.UsersService.Domain.AggregatesModel.UserAggregate;
using TrialsSystem.UsersService.Infrastructure.Contexts;

namespace TrialsSystem.UsersService.Infrastructure.Repositories
{
    public class CityRepository : ICityRepository
    {
        private readonly UserContext _context;

        public CityRepository(UserContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<City>> GetAsync()
        {
            return await _context.Cities.ToListAsync();
        }
    }
}
