using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Pappion.API.Configurations;
using Pappion.API.Helpers;
using Pappion.Application;
using Pappion.Application.Interfaces;
using Pappion.Domain.Entities;
using Pappion.Infrastructure;
using Pappion.Infrastructure.Auth;
using Pappion.Infrastructure.Repository;
using System.Text;
using MediatR;
using Pappion.API.Contexts;
using Pappion.API.Middlewares;
using Pappion.Application.Common.Behaviors;
using Pappion.Application.Interfaces.Contexts;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.OpenApi.Models;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Configuration
    .AddJsonFile("appsettings.json")
    .AddJsonFile($"appsettings.{EnvironmentHelper.GetCurrentEnvironment()}.json", optional: true)
    .AddEnvironmentVariables();

DatabaseConfiguration databaseConfiguration = new DatabaseConfiguration();
builder.Configuration.GetSection("DatabaseConfiguration").Bind(databaseConfiguration);
string connectionString = ConnectionStringHelper.GetMySlqConnectionString(databaseConfiguration);

// Add services to the container.


builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IHttpContextResolver, HttpContextResolver>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
 {
     {
           new OpenApiSecurityScheme
             {
                 Reference = new OpenApiReference
                 {
                     Type = ReferenceType.SecurityScheme,
                     Id = "Bearer"
                 }
             },
             new string[] {}
     }
 });
});
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Resident", policy =>
    {
        policy.RequireClaim("role", "Resident");
    });
});
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey
        (Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"])),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = false,
        ValidateIssuerSigningKey = true
    };
});
builder.Services.AddScoped<IJwtProvider, JwtProvider>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddDbContext<PappionDbContext>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString), b => b.MigrationsAssembly("Pappion.Infrastructure"));
});

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IPasswordService, PasswordService>();
builder.Services.AddScoped<IImageService, ImageService>();

builder.Services.AddValidatorsFromAssembly(typeof(IGenericRepository<>).Assembly);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddTransient<ExceptionHandlingMiddleware>();

builder.Services.AddScoped(serviceProvider => serviceProvider.GetRequiredService<IHttpContextResolver>().ResolveUserContext()!);


builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(IGenericRepository<>).Assembly);
    cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
});

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
app.UseAuthentication();
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseAuthorization();
app.MapControllers();

app.Run();
