

﻿using API.IRepository;
using API.IRepository.Repository;


using Data.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Đăng ký DbContext (chỉ 1 lần duy nhất)
builder.Services.AddDbContext<DbContextApp>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Đăng ký các Repository
builder.Services.AddScoped<IGiayChiTietRepository, GiayChiTietRepository>();
builder.Services.AddScoped<IDeGiayRepository, DeGiayRepository>();
builder.Services.AddScoped<INhanVienRepository, NhanVienRepository>();
builder.Services.AddScoped<IVoucherRepo, VoucherRepo>();
builder.Services.AddScoped<IHoaDonRepo, HoaDonRepo>();

builder.Services.AddDbContext<DbContextApp>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});


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
