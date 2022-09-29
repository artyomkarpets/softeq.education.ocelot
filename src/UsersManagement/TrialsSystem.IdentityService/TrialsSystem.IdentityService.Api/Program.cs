using IdentityServer4.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TrialsSystem.IdentityService.Api.Extensions;
using TrialsSystem.IdentityService.Api.Mapping;
using TrialsSystem.IdentityService.Api.Profiles;
using TrialsSystem.IdentityService.Infrastructure;
using TrialsSystem.IdentityService.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddTSIdentity(builder.Configuration)
    .AddTSIdentityServer(builder.Configuration)
    .AddInkaIdentityPasswordPolicy()
    .AddTSAuthentication(builder.Configuration)
    .AddTSCors(builder.Configuration);

builder.Services.AddControllersWithViews();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IProfileService, ProfileService>();

builder.Services.AddHttpClient<IUsersGatewayService, UsersGatewayService>(httpClient =>
{
    httpClient.BaseAddress = new Uri(builder.Configuration.GetConnectionString(ConnectionStrings.UsersService));

});

builder.Services.AddHttpClient<IUserTasksGatewayService, UserTasksGatewayService>(httpClient =>
{
    httpClient.BaseAddress = new Uri(builder.Configuration.GetConnectionString(ConnectionStrings.UserTasksService));

});

builder.Services.AddAutoMapper(mc => mc.AddProfile(new MappingProfile()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.UseCors();
app.UseIdentityServer();


app.UseCookiePolicy(new CookiePolicyOptions { MinimumSameSitePolicy = SameSiteMode.Lax });

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
    endpoints.MapControllers();
});


app.Run();
