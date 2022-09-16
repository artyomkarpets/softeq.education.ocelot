using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrialsSystem.UsersService.Infrastructure.Models.DeviceDtos
{
    public class DeviceResponse
    {
        public string SerialNumber { get; set; }
        public string Model { get; set; }
        public string FirmwareModel { get; set; }

    }
}
