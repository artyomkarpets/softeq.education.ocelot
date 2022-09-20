using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrialsSystem.UserTasksService.Domain.AggregatesModel.Base;

namespace TrialsSystem.UserTasksService.Domain.AggregatesModel.UserTasksAggregate
{
    public class UserTaskStatus : Enumeration
    {
        public static UserTaskStatus New = new(1, nameof(New));
        public static UserTaskStatus InProgress = new(2, nameof(InProgress));
        public static UserTaskStatus Completed = new(3, nameof(Completed));
        public static UserTaskStatus Reopen = new(3, nameof(Reopen));
        
        public UserTaskStatus(int id, string name)
            : base(id, name)
        {
        }
    }
}
