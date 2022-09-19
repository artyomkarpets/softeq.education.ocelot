using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrialsSystem.UserTasksService.Infrastructure.Exceptions
{
    public class UserTaskConflictException : Exception
    {
        public UserTaskConflictException(string userTaskHasAlreadyExisted, MongoWriteException me) : base(userTaskHasAlreadyExisted, me)
        {

        }
    }
}
