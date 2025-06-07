using BlazorAdmin.Service.IService;
using API.Models;
using System.Net.Http;
using System.Net.Http.Json;
using Data.Models;

public class KhachHangService : IKhachHangService
{
    private readonly HttpClient _httpClient;

    public KhachHangService(HttpClient httpClient)
    {
        _httpClient = httpClient;
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

    public Task<TaiKhoan?> GetByUsername(string username)
    {
        throw new NotImplementedException();
    }
}
