using BlazorAdmin.Service.IService;
using Data.Models;
using System.Net.Http;
using System.Net.Http.Json;

namespace BlazorAdmin.Service
{
    public class GiayChiTietService : IGiayChiTietService
    {
        private readonly HttpClient _httpClient;

        public GiayChiTietService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<GiayChiTiet>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<GiayChiTiet>>("api/GiayChiTiet");
        }

        public async Task<GiayChiTiet> GetByIdAsync(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<GiayChiTiet>($"api/GiayChiTiet/{id}");
        }

        public async Task CreateAsync(GiayChiTiet gct, Guid? idDeGiay)
        {
            var url = idDeGiay.HasValue
                ? $"api/GiayChiTiet?idDeGiay={idDeGiay}"
                : "api/GiayChiTiet";
            var response = await _httpClient.PostAsJsonAsync(url, gct);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateAsync(GiayChiTiet gct, Guid? idDeGiay)
        {
            var url = idDeGiay.HasValue
                ? $"api/GiayChiTiet/{gct.GiayChiTietId}?idDeGiay={idDeGiay}"
                : $"api/GiayChiTiet/{gct.GiayChiTietId}";
            var response = await _httpClient.PutAsJsonAsync(url, gct);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteAsync(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"api/GiayChiTiet/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}