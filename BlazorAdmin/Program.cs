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
builder.Services.AddHttpClient("voucher", client =>
{
    client.BaseAddress = new Uri("https://localhost:7246/");
});

builder.Services.AddScoped<INhanVienService, NhanVienService>();
builder.Services.AddScoped<IVoucherService, VoucherServiceRepo>();
builder.Services.AddScoped<IChiTietHoaDonService, ChiTietHoaDonService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UseSwagger();                          // Dùng Swagger
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
