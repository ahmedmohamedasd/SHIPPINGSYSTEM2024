using Application;
using Application.Setting;
using Serilog;
using Infrastructure;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

Log.Logger = new LoggerConfiguration()
           .MinimumLevel.Debug()
           .WriteTo.File("logs/Log.txt", rollingInterval: RollingInterval.Day)
           .CreateLogger();
var config = builder.Configuration;

builder.Services.AddControllers();
builder.Services.AddApplication();
builder.Services.Configure<Settings>(builder.Configuration.GetSection("Settings"));
builder.Services.AddInfrastructure(config);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
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
