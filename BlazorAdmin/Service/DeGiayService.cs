using BlazorAdmin.Service.IService;
using Data.Models;
using System.Net.Http.Json;

namespace BlazorAdmin.Service
{
    public class DeGiayService : IDeGiayService
    {
        private readonly HttpClient _httpClient;

        public DeGiayService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("api/Degiays");
        }

        public async Task<IEnumerable<DeGiay>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<DeGiay>>("api/DeGiays")
                   ?? new List<DeGiay>();
        }

        public async Task<DeGiay> GetByIdAsync(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<DeGiay>($"api/DeGiays/{id}");
        }

        public async Task CreateAsync(DeGiay deGiay)
        {
            var response = await _httpClient.PostAsJsonAsync("api/DeGiays", deGiay);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateAsync(DeGiay deGiay)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/DeGiays/{deGiay.DeGiayId}", deGiay);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteAsync(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"api/DeGiays/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}