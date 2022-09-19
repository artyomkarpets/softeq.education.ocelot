using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrialsSystem.UsersService.Domain.AggregatesModel.DeviceAggregate;
using TrialsSystem.UsersService.Domain.AggregatesModel.UserAggregate;

namespace TrialsSystem.UsersService.Infrastructure.Contexts
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Gender> Genders { get; set; }

        public DbSet<Device> Devices { get; set; }
        public DbSet<DeviceType> DeviceTypes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }


    }
}
