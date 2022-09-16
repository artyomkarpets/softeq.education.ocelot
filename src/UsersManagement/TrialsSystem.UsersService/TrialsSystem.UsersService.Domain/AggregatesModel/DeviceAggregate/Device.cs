using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrialsSystem.UsersService.Domain.AggregatesModel.Base;
using TrialsSystem.UsersService.Domain.AggregatesModel.UserAggregate;

namespace TrialsSystem.UsersService.Domain.AggregatesModel.DeviceAggregate
{
    public class Device : Entity
    {
        public string SerialNumber { get; set; }

        public string Model { get; set; }

        public string FirmwareVersion { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
