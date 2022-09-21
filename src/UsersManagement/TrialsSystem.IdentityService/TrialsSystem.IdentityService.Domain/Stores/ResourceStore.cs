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
    public class ResourceStore : IResourceStore
    {
        private IMongoCollection<IdentityResourceEntity> _identityResourceCollection;
        private IMongoCollection<ApiResourceEntity> _apiResourceCollection;
        private IMongoCollection<ApiScopeEntity> _apiScopeCollection;

        public ResourceStore(IMongoDatabase database)
        {
            _identityResourceCollection = database.GetCollection<IdentityResourceEntity>("IdentityResources");
            _apiResourceCollection = database.GetCollection<ApiResourceEntity>("ApiResources");
            _apiScopeCollection = database.GetCollection<ApiScopeEntity>("ApiScopes");
        }

        public async Task<IEnumerable<IdentityResource>> FindIdentityResourcesByScopeNameAsync(IEnumerable<string> scopeNames)
        {
            var filter = Builders<IdentityResourceEntity>.Filter.In(f => f.Name, scopeNames);

            var entities = await _identityResourceCollection.Find(filter).ToListAsync();
            return entities.Select(e => e.ToModel());
        }

        public async Task<IEnumerable<ApiScope>> FindApiScopesByNameAsync(IEnumerable<string> scopeNames)
        {
            var filter = Builders<ApiScopeEntity>.Filter.In(f => f.Name, scopeNames);

            var entities = await _apiScopeCollection.Find(filter).ToListAsync();
            return entities.Select(e => e.ToModel());
        }

        public async Task<IEnumerable<ApiResource>> FindApiResourcesByScopeNameAsync(IEnumerable<string> scopeNames)
        {
            var filter = Builders<ApiResourceEntity>.Filter.In(f => f.Name, scopeNames);

            var entities = await _apiResourceCollection.Find(filter).ToListAsync();
            return entities.Select(e => e.ToModel());
        }

        public async Task<IEnumerable<ApiResource>> FindApiResourcesByNameAsync(IEnumerable<string> apiResourceNames)
        {
            if (apiResourceNames == null) throw new ArgumentNullException(nameof(apiResourceNames));

            var filter = Builders<ApiResourceEntity>.Filter.In(f => f.Name, apiResourceNames);

            var entities = await _apiResourceCollection.Find(filter).ToListAsync();
            return entities.Select(e => e.ToModel());
        }

        public async Task<IdentityServer4.Models.Resources> GetAllResourcesAsync()
        {
            var identityResources = await _identityResourceCollection.Find(
                Builders<IdentityResourceEntity>.Filter.Empty).ToListAsync();

            var apiResources = await _apiResourceCollection.Find(
                Builders<ApiResourceEntity>.Filter.Empty).ToListAsync();

            var apiScopes = await _apiScopeCollection.Find(
                Builders<ApiScopeEntity>.Filter.Empty).ToListAsync();

            return new IdentityServer4.Models.Resources(
                identityResources.Select(s => s.ToModel()),
                apiResources.Select(s => s.ToModel()),
                apiScopes.Select(s => s.ToModel())
            );
        }
    }
}
