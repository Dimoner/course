using ProfileDal;
using ProfileLogic;
using ProfileLogic.Users.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.TryAddLogic();
builder.Services.TryAddDal();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();


// /// <summary>
// /// кто с кем дружит
// /// </summary>
// public class Friend : BaseEntity
// {
//     
// }
//
// /// <summary>
// /// роли
// /// </summary>
// public class Role : BaseEntity
// {
//     public string Name { get; init; }
//     
//     public string Description { get; init; }
// }
//
// /// <summary>
// /// права
// /// </summary>
// public class Right : BaseEntity
// {
//     
// }
//
// /// <summary>
// /// токены, для перевыпуска JWT токена
// /// </summary>
// public class RefreshToken : BaseEntity
// {
//     
// }
//
// /// <summary>
// /// Кто у нас сейчас на сайте находится
// /// ?
// /// а не стоит ли это хранить на сервисе для socket???
// /// </summary>
// public class Session : BaseEntity
// {
//     
// }
//
// public abstract class BaseEntity
// {
//     /// <summary>
//     /// Guid
//     /// 1 защита от перебора
//     /// 2 они уникальный в рамках всех ID в нашей системе
//     /// </summary>
//     public Guid Id { get; init; }
// }
//
