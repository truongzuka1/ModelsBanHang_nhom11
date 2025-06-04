<<<<<<< Updated upstream
using API.Repository;
using API.Repository.IRepository;
=======

using API.IRepository;
using API.IRepository.Repository;
using API.Repository;
using API.Repository.IRepository;

>>>>>>> Stashed changes
using Data.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DbContextApp>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddScoped<IGiayChiTietRepository, GiayChiTietRepository>();
builder.Services.AddScoped<IDeGiayRepository , DeGiayRepository>();

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
