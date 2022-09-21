using IdentityServer4.Models;
using IdentityServer4.Stores;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrialsSystem.IdentityService.Domain.Entities;
using TrialsSystem.IdentityService.Domain.Mappers;

namespace TrialsSystem.IdentityService.Domain.Stores
{
    public class PersistedGrantStore : IPersistedGrantStore
    {
        private IMongoCollection<PersistedGrantEntity> _collection;

        public PersistedGrantStore(IMongoDatabase database)
        {
            _collection = database.GetCollection<PersistedGrantEntity>("PersistedGrants");
        }

        public async Task StoreAsync(PersistedGrant grant)
        {
            var filter = Builders<PersistedGrantEntity>.Filter.Eq(c => c.Key, grant.Key);
            var entity = await _collection.Find(filter).FirstOrDefaultAsync();

            if (entity == null)
            {
                await _collection.InsertOneAsync(grant.ToEntity());
            }
            else
            {
                grant.UpdateEntity(entity);
                await _collection.FindOneAndReplaceAsync(filter, entity);
            }
        }

        public async Task<PersistedGrant> GetAsync(string key)
        {
            var filter = Builders<PersistedGrantEntity>.Filter.Eq(c => c.Key, key);

            var persistedGrantEntity = await _collection.Find(filter).FirstOrDefaultAsync();
            return persistedGrantEntity.ToModel();
        }

        public async Task<IEnumerable<PersistedGrant>> GetAllAsync(PersistedGrantFilter filter)
        {
            var dbFilter = BuildFilterDefinition(filter);

            var persistedGrantEntities = await _collection.Find(dbFilter).ToListAsync();
            return persistedGrantEntities.Select(p => p.ToModel());
        }

        public async Task RemoveAsync(string key)
        {
            var filter = Builders<PersistedGrantEntity>.Filter.Eq(c => c.Key, key);

            await _collection.DeleteOneAsync(filter);
        }

        public async Task RemoveAllAsync(PersistedGrantFilter filter)
        {
            var dbFilter = BuildFilterDefinition(filter);

            await _collection.DeleteManyAsync(dbFilter);
        }

        private static FilterDefinition<PersistedGrantEntity> BuildFilterDefinition(PersistedGrantFilter filter)
        {
            var dbFilter = Builders<PersistedGrantEntity>.Filter.Empty;
            if (!string.IsNullOrEmpty(filter.ClientId))
                dbFilter &= Builders<PersistedGrantEntity>.Filter.Eq(c => c.ClientId, filter.ClientId);
            if (!string.IsNullOrEmpty(filter.SessionId))
                dbFilter &= Builders<PersistedGrantEntity>.Filter.Eq(c => c.SessionId, filter.SessionId);
            if (!string.IsNullOrEmpty(filter.SubjectId))
                dbFilter &= Builders<PersistedGrantEntity>.Filter.Eq(c => c.SubjectId, filter.SubjectId);
            if (!string.IsNullOrEmpty(filter.Type))
                dbFilter &= Builders<PersistedGrantEntity>.Filter.Eq(c => c.Type, filter.Type);
            return dbFilter;
        }
    }
}
