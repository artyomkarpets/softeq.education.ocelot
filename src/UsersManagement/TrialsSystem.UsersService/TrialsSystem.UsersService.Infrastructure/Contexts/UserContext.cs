using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
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

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Navigation(e => e.City).AutoInclude();
            modelBuilder.Entity<User>().Navigation(e => e.Gender).AutoInclude();


            modelBuilder.Entity<Gender>().HasData(
                new Gender("Male", new Guid("c7166a6d-3aaa-4b99-a9d3-9a5294a78cfc")),
                new Gender("Female", new Guid("86d01f4c-a514-4858-ac44-21e56e2d7e0c")),
                new Gender("Divers", new Guid("e50ea91e-966a-4723-a6d5-42b63d4d9c0b")));

            modelBuilder.Entity<City>().HasData(
                new City("New York", new Guid("353644da-be6a-4bb4-ac85-d5b39ffd98e9")));
        }

    }
}
