using API.Models.DTO;
using BlazorAdmin.Service.IService;
using System.Net.Http.Json;

namespace BlazorAdmin.Service
{
    public class MauSacService : IMauSacService
    {
        private readonly HttpClient _httpClient;

        public MauSacService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("mausac");
        }

        public async Task<List<MauSacDTO>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<MauSacDTO>>("api/MauSac")
                   ?? new List<MauSacDTO>();
        }

        public async Task<MauSacDTO> GetByIdAsync(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<MauSacDTO>($"api/MauSac/{id}");
        }

        public async Task<bool> CreateAsync(MauSacDTO dto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/MauSac", dto);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAsync(MauSacDTO dto)
        {
            var response = await _httpClient.PutAsJsonAsync("api/MauSac", dto);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"api/MauSac/{id}");
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> AddMauSacToGiayChiTiet(Guid giayChiTietId, Guid mauSacId)
        {
            var response = await _httpClient.PostAsync($"api/MauSac/{giayChiTietId}/add-mausac/{mauSacId}", null);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> RemoveMauSacFromGiayChiTiet(Guid giayChiTietId, Guid mauSacId)
        {
            var response = await _httpClient.DeleteAsync($"api/MauSac/{giayChiTietId}/remove-mausac/{mauSacId}");
            return response.IsSuccessStatusCode;
        }

        public async Task<List<MauSacDTO>> GetMauSacsByGiayIdAsync(Guid giayChiTietId)
        {
            return await _httpClient.GetFromJsonAsync<List<MauSacDTO>>($"api/MauSac/giaychitiet/{giayChiTietId}")
                   ?? new List<MauSacDTO>();
        }
    }
}
