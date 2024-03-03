using ExampleCore.HttpLogic;
using ExampleCore.Logs;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseSerilog((hostingContext, loggerConfig) =>
{
    loggerConfig.GetConfiguration();
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddHttpRequestService();

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
