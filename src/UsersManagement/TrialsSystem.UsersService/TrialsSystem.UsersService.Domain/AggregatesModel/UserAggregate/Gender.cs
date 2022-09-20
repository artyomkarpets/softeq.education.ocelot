using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrialsSystem.UsersService.Domain.AggregatesModel.Base;

namespace TrialsSystem.UsersService.Domain.AggregatesModel.UserAggregate
{
    public class Gender : ValueObject
    {
        public Gender(string name, Guid id)
        {
            Id = id;
            Name = name;

        }

        public string Name { get; set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
        }
    }
}
