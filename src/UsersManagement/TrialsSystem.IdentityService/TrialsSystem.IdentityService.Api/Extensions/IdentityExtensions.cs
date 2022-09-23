using AspNetCore.Identity.Mongo;
using AspNetCore.Identity.Mongo.Model;
using IdentityServer4.AspNetIdentity;
using IdentityServer4.Services;
using IdentityServer4.Stores;
using Microsoft.AspNetCore.Identity;
using MongoDB.Bson;
using TrialsSystem.IdentityService.Domain.AggregatesModel.ApplicationUserAggregate;
using TrialsSystem.IdentityService.Domain.Stores;
using TrialsSystem.IdentityService.Infrastructure;
using TrialSystem.Shared.MongoConfigurations;

namespace TrialsSystem.IdentityService.Api.Extensions
{
    public static class IdentityExtensions
    {
        public static IServiceCollection AddTSIdentity(this IServiceCollection services, IConfiguration configuration)
        {
            var userConnectionString = configuration.GetConnectionString(ConnectionStrings.IdentityDatabase);

            services
                .AddIdentityMongoDbProvider<ApplicationUser, MongoRole, ObjectId>(options =>
                {
                    options.ConnectionString = userConnectionString;
                });

            services
                .AddIdentityCore<ApplicationUser>(options =>
                {
                    options.Lockout.AllowedForNewUsers = true;
                    options.Lockout.DefaultLockoutTimeSpan =
                        TimeSpan.FromMinutes(configuration.GetValue<double>("DefaultLockoutTime"));
                    options.Lockout.MaxFailedAccessAttempts = configuration.GetValue<int>("DefaultFailedAttempts");
                })
                .AddRoles<MongoRole>()
                .AddMongoDbStores<ApplicationUser, MongoRole, ObjectId>(options =>
                {
                    options.ConnectionString = userConnectionString;
                })
                .AddDefaultTokenProviders();

            return services;
        }

        public static IServiceCollection AddTSIdentityServer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMongoDatabase(configuration.GetConnectionString(ConnectionStrings.IdentityDatabase));

            // code below is basic setup of "Resource Owner" flow.
            // all configurations should be set to DB by scripts.
            services
                .AddIdentityServer(options =>
                {
                    options.IssuerUri = configuration.GetConnectionString(ConnectionStrings.Issuer);
                    options.Events.RaiseErrorEvents = true;
                    options.Events.RaiseFailureEvents = true;
                    options.Events.RaiseInformationEvents = true;
                    options.Events.RaiseSuccessEvents = false;

                    options.Endpoints.EnableDeviceAuthorizationEndpoint = false;
                    options.Endpoints.EnableCheckSessionEndpoint = false;

                    options.Authentication.CookieSameSiteMode = SameSiteMode.Lax;


                    //options.Cookie.HttpOnly = true;
                    //options.Cookie.SameSite = SameSiteMode.None;
                    //options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                    //10 hours by default is enough for complete a systematic evaluation (a.k.a questionnaires)
                    //options.Authentication.CookieLifetime
                })
                .AddClientStore<ClientStore>()
                .AddResourceStore<ResourceStore>()
                .AddPersistedGrantStore<PersistedGrantStore>()
                .AddDeviceFlowStore<DeviceFlowStore>()
                .AddAspNetIdentity<ApplicationUser>()
                .AddDeveloperSigningCredential();
                //.AddResourceOwnerValidator<ResourceOwnerPasswordValidator<ApplicationUser>>();

            services.ConfigureApplicationCookie(config =>
            {
                config.LoginPath = "/";
            });

            services.AddTransient<IProfileService, ProfileService<ApplicationUser>>();

            return services;
        }

        public static IServiceCollection AddInkaIdentityPasswordPolicy(this IServiceCollection services)
        {
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 8;
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+[]:";
            });

            return services;
        }

    }
}
