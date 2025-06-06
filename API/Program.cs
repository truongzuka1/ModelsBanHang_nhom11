using API.IRepository;
using API.IRepository.Repository;
using API.Repository;
using Data.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Đăng ký DbContext (chỉ 1 lần duy nhất)
builder.Services.AddDbContext<DbContextApp>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Đăng ký Repository
builder.Services.AddScoped<IAnhRepository, AnhRepository>();
builder.Services.AddScoped<IChatLieuRepository, ChatLieuRepository>();
builder.Services.AddScoped<IDeGiayRepository, DeGiayRepository>();
builder.Services.AddScoped<IGiamGiaRepository, GiamGiaRepository>();
builder.Services.AddScoped<IGiayRepository, GiayRepository>();
builder.Services.AddScoped<IGiayChiTietRepository, GiayChiTietRepository>();
builder.Services.AddScoped<IGioHangRepository, GioHangRepository>();
builder.Services.AddScoped<IGioHangChiTietRepository, GioHangChiTietRepository>();
builder.Services.AddScoped<IHoaDonRepo, HoaDonRepo>();
builder.Services.AddScoped<IKichCoRepository, KichCoRepository>();
builder.Services.AddScoped<INhanVienRepository, NhanVienRepository>();
builder.Services.AddScoped<IThuongHieuRepository, ThuongHieuRepository>();
builder.Services.AddScoped<IVoucherRepo, VoucherRepo>();
builder.Services.AddScoped<ITheLoaiGiayRepository, TheLoaiGiayRepository>();

builder.Services.AddScoped<ITaiKhoanRepository, TaiKhoanRepository>();
builder.Services.AddScoped<IChucVuRepository, ChucVuRepository>();

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