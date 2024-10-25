using Application.Interfaces;
using Application.Mapping;
using Application.Services;
using ConsultaAlumnos.Domain.Interfaces;
using ConsultaAlumnos.Infrastructure.Data;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Models;
using Infraestructure.Data;
using Microsoft.Data.Sqlite;
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
    setupAction.AddSecurityDefinition("SchoolArrival", new OpenApiSecurityScheme() //Esto va a permitir usar swagger con el token.
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
                    Id = "SchoolArrival" } //Tiene que coincidir con el id seteado arriba en la definición
                }, new List<string>() }
    });
});

builder.Services.AddAuthentication("Bearer") //"Bearer" es el tipo de auntenticación que tenemos que elegir después en PostMan para pasarle el token
    .AddJwtBearer(options => //Acá definimos la configuración de la autenticación. le decimos qué cosas queremos comprobar. La fecha de expiración se valida por defecto.
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

builder.Services.AddScoped<IAdminServices, AdminServices>();
builder.Services.AddScoped<IDriverServices, DriverServices>();
builder.Services.AddScoped<IDriverRepository, DriverRepository>();
builder.Services.AddScoped<ITravelServices, TravelServices>();
builder.Services.AddScoped<IPassengerRepository, PassengerRepository>();
builder.Services.AddScoped<IPassengerService, PassengerServices>();
builder.Services.AddScoped<ISchoolServices, SchoolServices>();
builder.Services.AddScoped<IRepositoryBase<School>, EfRepository<School>>();
builder.Services.AddScoped<IRepositoryBase<Travel>, EfRepository<Travel>>();
builder.Services.AddScoped<IRepositoryBase<Driver>, EfRepository<Driver>>();
builder.Services.AddScoped<IRepositoryBase<Passenger>, EfRepository<Passenger>>();
builder.Services.AddScoped<IRepositoryBase<Admin>, EfRepository<Admin>>();
//
//builder.Services.AddScoped<IUserServices, UserServices>();
//builder.Services.AddScoped<IUserRepository, UserRepository>();

//
builder.Services.AddScoped<DriverMapping>();
builder.Services.AddScoped<TravelMapping>();
builder.Services.AddScoped<PassengerMapping>();
builder.Services.AddScoped<SchoolMapping>();
builder.Services.AddScoped<AdminMapping>();

builder.Services.AddDbContext<TravelArrivalDbContext>(options => options.UseSqlite(builder.Configuration["ConnectionStrings:SchoolArrivalDBConnectionString"]));

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
