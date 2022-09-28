using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace TrialsSystem.IdentityService.Api.Extensions
{
    public static class AuthenticationExtensions
    {
        public static IServiceCollection AddTSAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            // accepts any access token issued by identity server
            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
                {
                    options.Authority = configuration.GetConnectionString("Authority");
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                         
                        ValidateAudience = false,
                        ValidateIssuer = false,
                        AuthenticationType = "at+jwt",
                        SaveSigninToken = true,
                        
                    };
                });


            //  services.AddSingleton<IConfigureOptions<JwtBearerOptions>, ConfigureJwtBearerOptions>();

            // adds an authorization policy to make sure the token is for scope 'identity'
            services.AddAuthorization(options =>
            {
                options.AddPolicy("AllowAnonymous", builder =>
                {
                    builder.RequireClaim("scope", "identity");
                });
                options.AddPolicy("AllowAnonymousAndAuthorized", builder =>
                {
                    builder.RequireAssertion(context => context.User.HasClaim(claim => claim.Type == "scope" && claim.Value == "identity") ||
                                                        context.User.Identity.IsAuthenticated);
                });
                options.AddPolicy("AuthorizedUser", builder =>
                {
                    builder.RequireAuthenticatedUser();
                });
            });

            return services;
        }
        public static IServiceCollection AddTSCors(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors(options =>
            {
                var origins = configuration.GetValue<string>("AllowedOrigins").Split(';').ToList();

                options.AddDefaultPolicy(builder =>
                {
                    builder.WithOrigins(origins.ToArray())
                        .SetIsOriginAllowedToAllowWildcardSubdomains()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            return services;
        }
    }
}
