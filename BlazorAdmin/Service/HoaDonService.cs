using BlazorAdmin.Service.IService;
using Data.Models;

namespace BlazorAdmin.Service
{
    public class HoaDonService : IHoaDonService
    {
        private readonly HttpClient _httpClient;

        public HoaDonService(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient("hoadon");
        }

        public async Task Add(HoaDon hoaDon)
        {
            var response = await _httpClient.PostAsJsonAsync("api/HoaDon", hoaDon);
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<HoaDon>> GetAll() =>
            await _httpClient.GetFromJsonAsync<List<HoaDon>>("api/HoaDon");

        public async Task<HoaDon> GetById(Guid id) =>
            await _httpClient.GetFromJsonAsync<HoaDon>($"api/HoaDon/{id}");

        public async Task Update(HoaDon hoaDon)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/HoaDon/{hoaDon.HoaDonId}", hoaDon);
            response.EnsureSuccessStatusCode();
        }

        public async Task Delete(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"api/HoaDon/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
