using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace TrialSystem.Shared.MongoConfigurations
{
    public static class MongoExtensions
    {
        public static IServiceCollection AddMongoDatabase(this IServiceCollection services, string connectionString)
        {
            var url = MongoUrl.Create(connectionString);
            var client = new MongoClient(url);

            services
                .AddScoped(database => client.GetDatabase(url.DatabaseName));
            return services;
        }

        public static IServiceCollection AddMongoCollection<T>(this IServiceCollection services, string connectionString, string collectionName) where T : class
        {
            var url = MongoUrl.Create(connectionString);
            var client = new MongoClient(url);
            var database = client.GetDatabase(url.DatabaseName);
            var collection = database.GetCollection<T>(collectionName);

            services.AddScoped(provider => collection);
            return services;
        }

    }
}