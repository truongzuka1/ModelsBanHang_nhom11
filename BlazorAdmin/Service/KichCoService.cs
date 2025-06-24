using BlazorAdmin.Service.IService;
using API.Models.DTO;
using System.Net.Http.Json;

namespace BlazorAdmin.Service
{
    public class KichCoService : IKichCoService
    {
        private readonly HttpClient _httpClient;

        public KichCoService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("kichco");
        }

        public async Task<List<KichCoDTO>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<KichCoDTO>>("api/KichCo")
                   ?? new List<KichCoDTO>();
        }

        public async Task<KichCoDTO> GetByIdAsync(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<KichCoDTO>($"api/KichCo/{id}");
        }

        public async Task<bool> CreateAsync(KichCoDTO dto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/KichCo", dto);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAsync(KichCoDTO dto)
        {
            var response = await _httpClient.PutAsJsonAsync("api/KichCo", dto);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"api/KichCo/{id}");
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> AddKichCoToGiayChiTiet(Guid giayChiTietId, Guid kichCoId)
        {
            var response = await _httpClient.PostAsync($"api/KichCo/{giayChiTietId}/add-kichco/{kichCoId}", null);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> RemoveKichCoFromGiayChiTiet(Guid giayChiTietId, Guid kichCoId)
        {
            var response = await _httpClient.DeleteAsync($"api/KichCo/{giayChiTietId}/remove-kichco/{kichCoId}");
            return response.IsSuccessStatusCode;
        }

        public async Task<List<KichCoDTO>> GetKichCosByGiayIdAsync(Guid giayChiTietId)
        {
            return await _httpClient.GetFromJsonAsync<List<KichCoDTO>>($"api/KichCo/giaychitiet/{giayChiTietId}")
                   ?? new List<KichCoDTO>();
        }
    }
}
