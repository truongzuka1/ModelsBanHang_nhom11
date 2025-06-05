using API.IService;
using API.Service;
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
builder.Services.AddHttpClient("voucher", client =>
{
    client.BaseAddress = new Uri("https://localhost:7246/");
});
builder.Services.AddScoped<INhanVienService, NhanVienService>();
builder.Services.AddScoped<IAnhService, AnhService>();
builder.Services.AddScoped<IChatLieuService, ChatLieuService>();
builder.Services.AddScoped<IGiayService, GiayService>();
builder.Services.AddScoped<IHoaDonService, HoaDonService>();
builder.Services.AddScoped<IThuongHieuService, ThuongHieuService>();
builder.Services.AddScoped<IVoucherService, VoucherService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
