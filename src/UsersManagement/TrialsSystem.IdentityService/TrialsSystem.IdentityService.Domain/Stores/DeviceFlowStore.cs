using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Stores;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TrialsSystem.IdentityService.Domain.Entities;

namespace TrialsSystem.IdentityService.Domain.Stores
{
    public class DeviceFlowStore: IDeviceFlowStore
    {
        private IMongoCollection<DeviceFlowCodes> _collection;

        public DeviceFlowStore(IMongoDatabase database)
        {
            _collection = database.GetCollection<DeviceFlowCodes>("DeviceFlows");
        }

        public async Task StoreDeviceAuthorizationAsync(string deviceCode, string userCode, DeviceCode data)
        {
            var deviceFlowCodes = new DeviceFlowCodes()
            {
                DeviceCode = deviceCode,
                UserCode = userCode,
                ClientId = data.ClientId,
                SubjectId = data.Subject?.FindFirst(JwtClaimTypes.Subject).Value,
                CreationTime = data.CreationTime,
                Expiration = data.CreationTime.AddSeconds(data.Lifetime),
                Data = JsonSerializer.Serialize(data)
            };
            await _collection.InsertOneAsync(deviceFlowCodes);
        }

        public async Task<DeviceCode> FindByUserCodeAsync(string userCode)
        {
            var filter = Builders<DeviceFlowCodes>.Filter.Eq(c => c.UserCode, userCode);
            var result = await _collection.Find(filter).FirstOrDefaultAsync();
            return JsonSerializer.Deserialize<DeviceCode>(result.Data);
        }

        public async Task<DeviceCode> FindByDeviceCodeAsync(string deviceCode)
        {
            var filter = Builders<DeviceFlowCodes>.Filter.Eq(c => c.DeviceCode, deviceCode);
            var result = await _collection.Find(filter).FirstOrDefaultAsync();
            return JsonSerializer.Deserialize<DeviceCode>(result.Data);
        }

        public async Task UpdateByUserCodeAsync(string userCode, DeviceCode data)
        {
            var filter = Builders<DeviceFlowCodes>.Filter.Eq(c => c.UserCode, userCode);
            var update = Builders<DeviceFlowCodes>.Update
                .Set("ClientId", data.ClientId)
                .Set("SubjectId", data.Subject?.FindFirst(JwtClaimTypes.Subject).Value)
                .Set("CreationTime", data.CreationTime)
                .Set("Expiration", data.CreationTime.AddSeconds(data.Lifetime))
                .Set("Data", JsonSerializer.Serialize(data));

            await _collection.UpdateOneAsync(filter, update);
        }

        public async Task RemoveByDeviceCodeAsync(string deviceCode)
        {
            var filter = Builders<DeviceFlowCodes>.Filter.Eq(c => c.DeviceCode, deviceCode);
            await _collection.DeleteOneAsync(filter);
        }

    }
}
