using API.Models.DTO;
using BlazorAdmin.Service.IService;
using System.Net.Http.Json;

namespace BlazorAdmin.Service
{
    public class GiayChiTietService : IGiayChiTietService
    {
        private readonly HttpClient _httpClient;

		public GiayChiTietService(IHttpClientFactory httpClientFactory)
		{
			_httpClient = httpClientFactory.CreateClient("giaychitiet");
		}

		public async Task<List<GiayChiTietDTO>> GetAllAsync()
        {
            var result = await _httpClient.GetFromJsonAsync<List<GiayChiTietDTO>>("api/GiayChiTiet");
            return result ?? new List<GiayChiTietDTO>();
        }

        public async Task<GiayChiTietDTO?> GetByIdAsync(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<GiayChiTietDTO>($"api/GiayChiTiet/{id}");
        }

        public async Task<List<GiayChiTietDTO>> GetByGiayIdAsync(Guid giayId)
        {
            var result = await _httpClient.GetFromJsonAsync<List<GiayChiTietDTO>>($"api/GiayChiTiet/by-giay/{giayId}");
            return result ?? new List<GiayChiTietDTO>();
        }

        public async Task<bool> CreateAsync(GiayChiTietDTO dto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/GiayChiTiet", dto);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAsync(Guid id, GiayChiTietDTO dto)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/GiayChiTiet/{id}", dto);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"api/GiayChiTiet/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
