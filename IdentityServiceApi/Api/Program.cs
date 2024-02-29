using Dal.FriendRequests;
using Dal.Friendships;
using Dal.RefreshTokens;
using Dal.Rights;
using Dal.Roles;
using Dal.Sessions;
using Dal.UserProfiles;
using Dal.Users;
using Logic.UserProfiles.Managers;
using Logic.Users.Managers;
using Microsoft.AspNetCore.Mvc.Formatters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter());
    options.ReturnHttpNotAcceptable = true;
    options.RespectBrowserAcceptHeader = true;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// adding dal refs
builder.Services.AddSingleton<IFriendRequestRepository, FriendRequestRepository>();
builder.Services.AddSingleton<IFriendshipRepository, FriendshipRepository>();
builder.Services.AddSingleton<IRefreshTokenRepository, RefreshTokenRepository>();
builder.Services.AddSingleton<IRightRepository, RightRepository>();
builder.Services.AddSingleton<IRoleRepository, RoleRepository>();
builder.Services.AddSingleton<ISessionRepository, SessionRepository>();
builder.Services.AddSingleton<IUserProfileRepository, UserProfileRepository>();
builder.Services.AddSingleton<IUserRepository, UserRepository>();

// adding logic refs
builder.Services.AddSingleton<IUserProfileLogicManager, UserProfileLogicManager>();
builder.Services.AddSingleton<IUserLogicManager, UserLogicManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
