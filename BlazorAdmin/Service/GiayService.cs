using BlazorAdmin.Service.IService;
using Data.Models;

namespace BlazorAdmin.Service
{
    public class GiayService : IGiayService
    {
        private readonly HttpClient _httpClient;

        public GiayService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Giay>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Giay>>("/api/Giays");
        }

        public async Task<Giay> GetByIdAsync(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<Giay>($"/api/Giays/{id}");
        }

        public async Task CreateAsync(Giay obj)
        {
            await _httpClient.PostAsJsonAsync("/api/Giays", obj);
        }

        public async Task UpdateAsync(Giay obj)
        {
            var response = await _httpClient.PutAsJsonAsync($"/api/Giays/{obj.GiayId}", obj);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteAsync(Guid id)
        {
            await _httpClient.DeleteAsync($"/api/Giays/{id}");
        }
    }
}
