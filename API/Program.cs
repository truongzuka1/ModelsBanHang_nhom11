<<<<<<< HEAD
using API.IRepository.Repository;
using API.IRepository;
=======
using API.Repository;
using API.Repository.IRepository;
>>>>>>> 57f4e0e97e8167b8074d442aed1855af67d265df
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

builder.Services.AddDbContext<DbContextApp>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<INhanVienRepository, NhanVienRepository>();

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
