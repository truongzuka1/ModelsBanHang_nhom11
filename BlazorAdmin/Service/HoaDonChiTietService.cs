using BlazorAdmin.Service.IService;
using Data.Models;

namespace BlazorAdmin.Service
{
    public class HoaDonChiTietService : IHoaDonChiTietService
    {
        private readonly HttpClient _httpClient;

        public HoaDonChiTietService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<HoaDonChiTiet>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<HoaDonChiTiet>>("api/HoaDonChiTiets");
        }
    }
}
