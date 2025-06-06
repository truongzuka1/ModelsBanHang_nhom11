using API.IService;
using BlazorAdmin.Service.IService;
using Data.Models;
using System.Net.Http.Json;

namespace BlazorAdmin.Service
{
    public class TheLoaiGiayService : ITheLoaiGiayService
    {
        private readonly HttpClient _httpClient;

        public TheLoaiGiayService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("theloaigiay");
        }

        public async Task<IEnumerable<TheLoaiGiay>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<TheLoaiGiay>>("api/TheLoaiGiay")
                   ?? new List<TheLoaiGiay>();
        }

        public async Task<TheLoaiGiay> GetByIdAsync(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<TheLoaiGiay>($"api/TheLoaiGiay/{id}");
        }
        public async Task<TheLoaiGiay> AddAsync(TheLoaiGiay theLoaiGiay)
        {
            var response = await _httpClient.PostAsJsonAsync("api/TheLoaiGiay", theLoaiGiay);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<TheLoaiGiay>();
        }
        public async Task<TheLoaiGiay> UpdateAsync(TheLoaiGiay theLoaiGiay)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/TheLoaiGiay/{theLoaiGiay.TheLoaiGiayId}", theLoaiGiay);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<TheLoaiGiay>();
        }
        public async Task<bool> DeleteAsync(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"api/TheLoaiGiay/{id}");
            response.EnsureSuccessStatusCode();
            return true;
        }

        public async Task<TheLoaiGiay> GetTheLoaiByGiayChiTietIdAsync(Guid giayChiTietId)
        {
            return await _httpClient.GetFromJsonAsync<TheLoaiGiay>($"api/TheLoaiGiay/giaychitiet/{giayChiTietId}");
        }
    }
}