using Application.Interfaces;
using Application.Mapping;
using Application.Services;
using ConsultaAlumnos.Domain.Interfaces;
using ConsultaAlumnos.Infrastructure.Data;
using Domain.Entities;
using Domain.Interfaces;
using Infraestructure.Data;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IDriverServices, DriverServices>();
builder.Services.AddScoped<IDriverRepository, DriverRepository>();
builder.Services.AddScoped<ITravelServices, TravelServices>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IPassengerRepository, PassengerRepository>();
builder.Services.AddScoped<IPassengerService, PassengerServices>();
//builder.Services.AddScoped<ITravelRepository, TravelRepository>();
builder.Services.AddScoped<IRepositoryBase<Travel>, EfRepository<Travel>>();
builder.Services.AddScoped<IRepositoryBase<Driver>, EfRepository<Driver>>();
builder.Services.AddScoped<IRepositoryBase<Client>, EfRepository<Client>>();
builder.Services.AddScoped<IRepositoryBase<Passenger>, EfRepository<Passenger>>();
builder.Services.AddScoped<DriverMapping>();
builder.Services.AddScoped<TravelMapping>();
builder.Services.AddScoped<ClientMapping>();
builder.Services.AddScoped<PassengerMapping>();


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
