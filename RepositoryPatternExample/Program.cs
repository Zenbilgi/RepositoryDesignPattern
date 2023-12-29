﻿global using RepositoryPatternExample.Models;
using Microsoft.EntityFrameworkCore;
using RepositoryPatternExample.Data;
using RepositoryPatternExample.Services.WeatherForecastService;
using RepositoryPatternExample.Services.CustomerService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddScoped<IWeatherForecastService, WeatherForecastService>();
//builder.Services.AddScoped<IWeatherForecastService, WeatherForecastServiceExtended>();
builder.Services.AddScoped<IWeatherForecastService, WeatherForecastServiceDbContext>();
builder.Services.AddScoped<ICustomerService, CustomerServiceDbContext>();
//builder.Services.AddSingleton<IWeatherForecastService, WeatherForecastServiceDbContext>();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionString));

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

