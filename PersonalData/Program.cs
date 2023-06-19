using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonalData.Model.Context;
using PersonalData.Business;
using PersonalData.Business.Implementations;
using PersonalData.Repository;
using Serilog;
using EvolveDb;
using MySql.Data.MySqlClient;
using PersonalData.Repository.Generic;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

// Add services to the container.

builder.Services.AddControllers();

// Add connection to database
var connection = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<MySQLContext>(options =>
{
    options.UseMySql(connection, ServerVersion.AutoDetect(connection));
});

// Versioning API
builder.Services.AddApiVersioning(setup =>
{
    setup.DefaultApiVersion = new ApiVersion(1, 0);
    setup.AssumeDefaultVersionWhenUnspecified = true;
    setup.ReportApiVersions = true;
});

builder.Services.AddVersionedApiExplorer(setup =>
{
    setup.GroupNameFormat = "'v'VVV";
    setup.SubstituteApiVersionInUrl = true;
});

// Dependency injection
builder.Services
    .AddScoped<IPersonBusiness, PersonBusiness>()
    .AddScoped<IBookBusiness, BookBusiness>()
    .AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    MigrateDatabase(connection);
}

void MigrateDatabase(string connection)
{
    try
    {
        var evolveConnection = new MySqlConnection(connection);
        var evolve = new Evolve(evolveConnection, msg => Log.Information(msg))
        {
            Locations = new List<string> { "db/migrations", "db/dataset" },
            IsEraseDisabled = true
        };
        evolve.Migrate();
    }
    catch (Exception ex)
    {
        Log.Error("Database migration failed", ex);
        throw;
    }
}

app.UseAuthorization();

app.MapControllers();

app.Run();

