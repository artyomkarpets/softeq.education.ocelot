using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrialsSystem.UsersService.Domain.AggregatesModel.Base;
using TrialsSystem.UsersService.Domain.AggregatesModel.DeviceAggregate;

namespace TrialsSystem.UsersService.Domain.AggregatesModel.UserAggregate
{
    public class User : Entity
    {
        public User(string email, string name, string surname, Guid cityId, Guid genderId, DateTime birthDate)
        {
            Email = email;
            Name = name;
            Surname = surname;
            CityId = cityId;
            BirthDate = BirthDate;
            GenderId = genderId;
        }

        public string Email { get; private set; }

        public string Name { get; private set; }

        public string Surname { get; private set; }

        private Guid CityId { get; set; }

        [ForeignKey("CityId")]
        public virtual City City { get; private set; }

        private Guid GenderId { get; set; }

        [ForeignKey("GenderId")]
        public virtual Gender Gender { get; private set; }

        public DateTime BirthDate { get; private set; }

        public decimal? Weight { get; private set; }
        public decimal? Height { get; private set; }

        public ICollection<Device> Devices { get; set; }

        public void SetWeight(decimal weight)
        {
            Weight = weight;
        }

        public void SetHeight(decimal height)
        {
            Height = height;
        }

    }
}
