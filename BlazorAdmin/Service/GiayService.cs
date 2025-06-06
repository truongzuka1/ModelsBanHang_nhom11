using BlazorAdmin.Service.IService;
using Data.Models;
using System.Net.Http.Json;

namespace BlazorAdmin.Service
{
    public class GiayService : IGiayService
    {
        private readonly HttpClient _httpClient;

        public GiayService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("giay");
        }

        public async Task<List<Giay>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Giay>>("api/Giay")
                   ?? new List<Giay>();
        }

        public async Task<Giay> GetByIdAsync(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<Giay>($"api/Giay/{id}");
        }

        public async Task CreateAsync(Giay obj)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Giay", obj);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateAsync(Giay obj)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Giay/{obj.GiayId}", obj);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteAsync(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"api/Giay/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}