using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace TrialsSystem.ApiGatewayService.Api.Extentions
{
    public static class AuthenticationExtensions
    {
        public static IServiceCollection AddTSAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            // accepts any access token issued by identity server
            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddCookie(cfg => cfg.SlidingExpiration = true)
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
                {
                    options.Authority = configuration.GetConnectionString("TokenAuthority");
                    options.RequireHttpsMetadata = false;
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
       
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        //todo: update it for production
                        ValidateAudience = false,
                        ValidateIssuer = false,
                        AuthenticationType = "at+jwt",
                        SaveSigninToken = true,
                    };
                });


            var multiSchemePolicy = new AuthorizationPolicyBuilder(
                                        CookieAuthenticationDefaults.AuthenticationScheme,
                                        JwtBearerDefaults.AuthenticationScheme)
                                      .RequireAuthenticatedUser()
                                      .Build();

            // adds an authorization policy to make sure the token is for scope 'identity'
            services.AddAuthorization(options =>
            {
                options.AddPolicy("AllowAnonymous", builder =>
                {
                    builder.RequireClaim("scope", "identity");
                });

                options.AddPolicy("AuthorizedUser", builder =>
                {
                    builder.RequireAuthenticatedUser();
                    builder.RequireClaim("scope", "trial");
                });

                options.DefaultPolicy = multiSchemePolicy;
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
