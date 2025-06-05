using BlazorAdmin.Service.IService;
using Data.Models;

namespace BlazorAdmin.Service
{
    public class ThuongHieuService : IThuongHieuService
    {
        private readonly HttpClient _httpClient;

        public ThuongHieuService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ThuongHieu>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ThuongHieu>>("/api/ThuongHieus");
        }

        public async Task<ThuongHieu> GetByIdAsync(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<ThuongHieu>($"/api/ThuongHieus/{id}");
        }

        public async Task CreateAsync(ThuongHieu obj)
        {
            await _httpClient.PostAsJsonAsync("/api/ThuongHieus", obj);
        }

        public async Task UpdateAsync(ThuongHieu obj)
        {
            var response = await _httpClient.PutAsJsonAsync($"/api/ThuongHieus/{obj.ThuongHieuId}", obj);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteAsync(Guid id)
        {
            await _httpClient.DeleteAsync($"/api/ThuongHieus/{id}");
        }
    }
}
