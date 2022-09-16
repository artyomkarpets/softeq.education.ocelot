using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrialsSystem.UsersService.Domain.AggregatesModel.Base;
using TrialsSystem.UsersService.Domain.AggregatesModel.UserAggregate;

namespace TrialsSystem.UsersService.Domain.AggregatesModel.DeviceAggregate
{
    public class DeviceType : ValueObject
    {
        public string Name { get; set; }
        public string Code { get; set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
            yield return Code;
        }
    }
}
