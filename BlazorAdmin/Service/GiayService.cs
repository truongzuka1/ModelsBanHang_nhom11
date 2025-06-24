using API.Models.DTO;
using BlazorAdmin.Service.IService;
using System.Net.Http.Json;

namespace BlazorAdmin.Service
{
    public class GiayService : IGiayService
    {
        private readonly HttpClient _httpClient;

        public GiayService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<GiayDTO>> GetAllAsync()
        {
            var result = await _httpClient.GetFromJsonAsync<List<GiayDTO>>("api/Giay");
            return result ?? new();
        }

        public async Task<GiayDTO> GetByIdAsync(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<GiayDTO>($"api/Giay/{id}");
        }

        public async Task<Guid?> CreateAsync(GiayDTO dto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Giay", dto);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Guid>();
            }
            return null;
        }

        public async Task<bool> UpdateAsync(GiayDTO dto)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Giay/{dto.GiayId}", dto);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"api/Giay/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
