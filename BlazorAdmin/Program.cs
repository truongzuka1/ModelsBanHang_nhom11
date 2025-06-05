using BlazorAdmin.Components;
using BlazorAdmin.Service;
using BlazorAdmin.Service.IService;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
});

builder.Services.AddEndpointsApiExplorer();   
builder.Services.AddSwaggerGen();             

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
builder.Services.AddScoped<IVoucherService, VoucherService>();
builder.Services.AddScoped<IHoaDonService, HoaDonService>(); 
builder.Services.AddScoped<IChiTietHoaDonService, ChiTietHoaDonService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
    app.UseSwagger();                          // D�ng Swagger
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
