using BlazorAdmin.Service.IService;
using Data.Models;

namespace BlazorAdmin.Service
{
    public class DiaChiKhachHangService : IDiaChiKhachHangService
    {
        private readonly HttpClient _httpClient;
        private const string baseUrl = "api/DiaChiKhachHang";

        public DiaChiKhachHangService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<DiaChiKhachHang>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<DiaChiKhachHang>>(baseUrl);
        }

        public async Task<DiaChiKhachHang> GetByIdAsync(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<DiaChiKhachHang>($"{baseUrl}/{id}");
        }

        public async Task<DiaChiKhachHang> CreateAsync(DiaChiKhachHang diaChi)
        {
            var response = await _httpClient.PostAsJsonAsync(baseUrl, diaChi);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<DiaChiKhachHang>();
        }

        public async Task UpdateAsync(Guid id, DiaChiKhachHang diaChi)
        {
            var response = await _httpClient.PutAsJsonAsync($"{baseUrl}/{id}", diaChi);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteAsync(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"{baseUrl}/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
