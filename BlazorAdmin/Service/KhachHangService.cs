using BlazorAdmin.Service.IService;
using Data.Models;
using System.Net.Http.Json;

public class KhachHangService : IKhachHangService
{
    private readonly HttpClient _httpClient;
    public KhachHangService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("api");
    }

    public async Task<List<KhachHang>> GetAll() =>
        await _httpClient.GetFromJsonAsync<List<KhachHang>>("api/KhachHang") ?? new();

    public async Task<KhachHang?> GetById(Guid id) =>
        await _httpClient.GetFromJsonAsync<KhachHang>($"api/KhachHang/{id}");

    public async Task Create(KhachHang khachHang)
    {
        var response = await _httpClient.PostAsJsonAsync("api/KhachHang", khachHang);
        response.EnsureSuccessStatusCode();
    }

    public async Task Update(KhachHang khachHang)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/KhachHang/{khachHang.KhachHangId}", khachHang);
        response.EnsureSuccessStatusCode();
    }

    public async Task Delete(Guid id)
    {
        var response = await _httpClient.DeleteAsync($"api/KhachHang/{id}");
        response.EnsureSuccessStatusCode();
    }

}
