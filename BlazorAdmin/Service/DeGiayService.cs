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
            _httpClient = httpClientFactory.CreateClient("degiay");
        }

        public async Task<IEnumerable<DeGiay>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<DeGiay>>("api/DeGiay")
                   ?? new List<DeGiay>();
        }

        public async Task<DeGiay> GetByIdAsync(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<DeGiay>($"api/DeGiay/{id}");
        }

        public async Task CreateAsync(DeGiay deGiay)
        {
            var response = await _httpClient.PostAsJsonAsync("api/DeGiay", deGiay);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateAsync(DeGiay deGiay)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/DeGiay/{deGiay.DeGiayId}", deGiay);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteAsync(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"api/DeGiay/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}