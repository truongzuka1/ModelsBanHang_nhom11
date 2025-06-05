using BlazorAdmin.Components;
using BlazorAdmin.Service;
using BlazorAdmin.Service.IService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("https://localhost:7246/")
});

// Đăng ký HTTP Clients
builder.Services.AddHttpClient("voucher", client =>
{
    client.BaseAddress = new Uri("https://localhost:7246/");
});

builder.Services.AddHttpClient("hoadon", client =>
{
    client.BaseAddress = new Uri("https://localhost:7246/");
});

// Đăng ký Service
builder.Services.AddScoped<INhanVienService, NhanVienService>();
builder.Services.AddScoped<IVoucherService, VoucherServiceRepo>();
builder.Services.AddScoped<IHoaDonService, HoaDonServiceRepo>(); 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
