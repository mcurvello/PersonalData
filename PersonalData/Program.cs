using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using PersonalData.Model.Context;
using PersonalData.Services;
using PersonalData.Services.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var connection = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<MySQLContext>(options =>
{
    options.UseMySql(connection, ServerVersion.AutoDetect(connection));
});

// Dependendy injection
builder.Services.AddScoped<IPersonService, PersonService>();

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

app.UseAuthorization();

app.MapControllers();

app.Run();

