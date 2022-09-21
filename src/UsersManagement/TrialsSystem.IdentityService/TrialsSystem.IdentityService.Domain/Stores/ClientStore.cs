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
    public class ClientStore : IClientStore
    {
        private readonly IMongoCollection<ClientEntity> _collection;

        public ClientStore(IMongoDatabase database)
        {
            _collection = database.GetCollection<ClientEntity>("Clients");
        }


        public async Task<Client> FindClientByIdAsync(string clientId)
        {
            var filter = Builders<ClientEntity>.Filter.Eq(c => c.ClientId, clientId);
            var clientEntity = await _collection.Find(filter).FirstOrDefaultAsync();
            return clientEntity.ToModel();
        }
    }
}
