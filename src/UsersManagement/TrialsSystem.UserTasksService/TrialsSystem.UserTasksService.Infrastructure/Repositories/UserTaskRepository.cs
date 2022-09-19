using MongoDB.Driver;
using System.Threading.Tasks;
using TrialsSystem.UserTasksService.Domain.AggregatesModel.UserTasksAggregate;
using TrialsSystem.UserTasksService.Infrastructure.Exceptions;

namespace TrialsSystem.UserTasksService.Infrastructure.Repositories
{
    public class UserTaskRepository : IUserTaskRepository
    {
        private readonly IMongoCollection<UserTask> _collection;

        public UserTaskRepository(IMongoCollection<UserTask> collection)
        {
            _collection = collection;
        }

        public async Task<string> CreateAsync(UserTask patientTask)
        {
            try
            {
                await _collection.InsertOneAsync(patientTask);

                return patientTask.Id;
            }
            catch (MongoWriteException me)
            {
                throw new UserTaskConflictException("User task has already existed", me);
            }
            catch (MongoException e)
            {
                throw new InvalidOperationException("internal_error", e);
            }
        }

        public async Task<UserTask> UpdateeAsync(UserTask userTask)
        {
            try
            {
                var builder = Builders<UserTask>.Filter;
                var filter = builder.Eq(q => q.UserId, userTask.UserId)
                             & builder.Eq(q => q.Name, userTask.Name);

                var options = new FindOneAndReplaceOptions<UserTask>
                {
                    ReturnDocument = ReturnDocument.After
                };

                var result = await _collection.FindOneAndReplaceAsync(filter, userTask, options);

                return result;
            }
            catch (MongoException e)
            {
                throw new InvalidOperationException("internal_error", e);
            }
        }

        public async Task<IEnumerable<UserTask>> GetAsync(string userId, string name)
        {
            var builder = Builders<UserTask>.Filter;
            var filter = builder.Eq(q => q.UserId, userId);

            if (name != null)
            {
                filter &= builder.Eq(q => q.Name, name);
            }

            return await _collection.Find(filter).ToListAsync();
        }

        public async Task<UserTask> GetByIdAsync(string id, string userId)
        {
            var builder = Builders<UserTask>.Filter;
            var filter = builder.Eq(q => q.Id, id) & builder.Eq(q => q.UserId, userId);

            return await _collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task DeleteByNameAsync(string patientId, string taskName)
        {
            var builder = Builders<UserTask>.Filter;
            var filter = builder.Eq(x => x.UserId, patientId);
            filter &= builder.Eq(x => x.Name, taskName);

            await _collection.DeleteManyAsync(filter);
        }

    }


}
