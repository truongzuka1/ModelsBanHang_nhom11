using BlazorAdmin.Service.IService;
using Data.Models;

namespace BlazorAdmin.Service
{
    public class KhachHangService : IKhachHangService
    {
        private readonly HttpClient _httpClient;
        private const string baseUrl = "api/KhachHang";

        public KhachHangService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<KhachHang>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<KhachHang>>(baseUrl);
        }

        public async Task<KhachHang> GetByIdAsync(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<KhachHang>($"{baseUrl}/{id}");
        }

        public async Task<KhachHang> CreateAsync(KhachHang khachHang)
        {
            var response = await _httpClient.PostAsJsonAsync(baseUrl, khachHang);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<KhachHang>();
        }

        public async Task UpdateAsync(Guid id, KhachHang khachHang)
        {
            var response = await _httpClient.PutAsJsonAsync($"{baseUrl}/{id}", khachHang);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteAsync(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"{baseUrl}/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
