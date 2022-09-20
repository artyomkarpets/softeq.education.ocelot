using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrialsSystem.UserTasksService.Infrastructure.Models
{
    public class CreateUserTaskRequest
    {
        public string Name { get; set; }
        public string UserId { get; set; }

        public Dictionary<string, string> AdditionalProperties { get; set; }
    }
}
