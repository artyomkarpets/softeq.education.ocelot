using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrialsSystem.UserTasksService.Domain.AggregatesModel.UserTasksAggregate
{
    public interface IUserTaskRepository
    {
        Task<string> CreateAsync(UserTask patientTask);
        Task<UserTask> UpdateeAsync(UserTask userTask);
        Task<IEnumerable<UserTask>> GetAsync(string userId, string name);
        Task<UserTask> GetByNameAsync(string name, string userId);
        Task DeleteByNameAsync(string userId, string taskName);
    }
}
