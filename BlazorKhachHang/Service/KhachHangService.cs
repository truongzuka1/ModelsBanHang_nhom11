using Data.Models;
using BlazorKhachHang.Service.IService;
using BlazorKhachHang.Components.Pages;

namespace BlazorKhachHang.Service
{
    // hahaha
    public class KhachHangService : IKhachHangService
    {
        private readonly HttpClient _httpClient;

        public KhachHangService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task Create(KhachHang khachHang)
        {
            await _httpClient.PostAsJsonAsync("api/KhachHang", khachHang);
        }

        public async Task Delete(Guid id)
        {
            await _httpClient.DeleteAsync("api/KhachHang/" + id);
        }

        public async Task<List<KhachHang>> GetAll()
        {
            return await _httpClient.GetFromJsonAsync<List<KhachHang>>("api/KhachHang") ?? new();
        }

        public async Task<KhachHang?> GetById(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<KhachHang>($"api/KhachHang/{id}");
        }

        public async Task Update(KhachHang khachHang)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/KhachHang/{khachHang.KhachHangId}", khachHang);
            response.EnsureSuccessStatusCode();
        }
        public async Task<List<KhachHang>> SearchKhachHangAsync(string keyword)
        {
            var result = await _httpClient.GetFromJsonAsync<List<KhachHang>>(
                $"api/KhachHang/search?keyword={Uri.EscapeDataString(keyword)}");
            return result ?? new List<KhachHang>();
        }
    }
}
