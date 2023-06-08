using Microsoft.EntityFrameworkCore;
using Pappion.API.Configurations;
using Pappion.API.Helpers;
using Pappion.Infrastructure;
using Pappion.Infrastructure.Interfaces;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration
    .AddJsonFile("appsettings.json")
    .AddJsonFile($"appsettings.{EnvironmentHelper.GetCurrentEnvironment()}.json", optional: true)
    .AddEnvironmentVariables();

var databaseConfiguration = new DatabaseConfiguration();
builder.Configuration.GetSection("DatabaseConfiguration").Bind(databaseConfiguration);
var connectionString = ConnectionStringHelper.GetMySlqConnectionString(databaseConfiguration);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PappionDbContext>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString), b => b.MigrationsAssembly("Pappion.Infrastructure"));
});


builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
var app = builder.Build();

if (databaseConfiguration.IsAutoMigrationEnabled)
{
    MigrationHelper.ApplyMigrations(app.Services);
}

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
