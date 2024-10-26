using Application.Interfaces;
using Application.Mapping;
using Application.Services;
using SchoolArrival.Domain.Interfaces;
using SchoolArrival.Infrastructure.Data;
using Domain.Entities;
using Domain.Interfaces;
using Infraestructure.Data;
using Infraestructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(setupAction =>
{
    setupAction.AddSecurityDefinition("SchoolArrival", new OpenApiSecurityScheme() 
    {
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        Description = "Acá pegar el token generado al loguearse."
    });

    setupAction.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "SchoolArrival" } 
                }, new List<string>() }
    });
});

builder.Services.AddAuthentication("Bearer") 
    .AddJwtBearer(options => 
    {
        options.TokenValidationParameters = new()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Authentication:Issuer"],
            ValidAudience = builder.Configuration["Authentication:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["Authentication:SecretForKey"]))
        };
    }
);


builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddScoped<ITravelRepository, TravelRepository>();
builder.Services.AddScoped<IDriverRepository, DriverRepository>();
builder.Services.AddScoped<ITravelServices, TravelServices>();
builder.Services.AddScoped<ISchoolServices, SchoolServices>();
builder.Services.AddScoped<ICustomAuthenticationServices, AuthenticationServices>();
builder.Services.AddScoped<IRepositoryBase<School>, EfRepository<School>>();
builder.Services.AddScoped<IRepositoryBase<Travel>, EfRepository<Travel>>();
builder.Services.AddScoped<IRepositoryBase<Driver>, EfRepository<Driver>>();
builder.Services.AddScoped<IRepositoryBase<Passenger>, EfRepository<Passenger>>();
builder.Services.AddScoped<IRepositoryBase<Admin>, EfRepository<Admin>>();
builder.Services.AddScoped<IRepositoryBase<User>, EfRepository<User>>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<TravelMapping>();
builder.Services.AddScoped<SchoolMapping>();
builder.Services.AddScoped<UserMapping>();

builder.Services.AddDbContext<TravelArrivalDbContext>(options => options.UseSqlite(builder.Configuration["ConnectionStrings:SchoolArrivalDBConnectionString"]));

builder.Services.Configure<AuthenticationServiceOptions>(
    builder.Configuration.GetSection(AuthenticationServiceOptions.Authentication));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
