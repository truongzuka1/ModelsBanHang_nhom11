using API.Models.DTO;
using BlazorKhachHang.Service.IService;
using System.Net.Http.Json;
using static BlazorAdmin.Components.Pages.Admin.SanPham.SanPhamChiTiet;

namespace BlazorKhachHang.Service
{
    public class GiayChiTietService : IGiayChiTietService
    {
        private readonly HttpClient _httpClient;

        public GiayChiTietService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<GiayChiTietDTO>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<GiayChiTietDTO>>("api/GiayChiTiet")
                   ?? new List<GiayChiTietDTO>();
        }

        public async Task<GiayChiTietDTO> GetByIdAsync(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<GiayChiTietDTO>($"api/GiayChiTiet/{id}");
        }

        public async Task<List<GiayChiTietDTO>> GetByGiayIdAsync(Guid giayId)
        {
            return await _httpClient.GetFromJsonAsync<List<GiayChiTietDTO>>($"api/GiayChiTiet/giay/{giayId}")
                   ?? new List<GiayChiTietDTO>();
        }

        public async Task CreateAsync(GiayChiTietDTO obj)
        {
            var response = await _httpClient.PostAsJsonAsync("api/GiayChiTiet", obj);
            response.EnsureSuccessStatusCode();
        }

        public async Task<bool> CreateMultipleAsync(List<GiayChiTietDTO> list)
        {
            var response = await _httpClient.PostAsJsonAsync("api/GiayChiTiet/multiple", list);
            return response.IsSuccessStatusCode;
        }


        public async Task DeleteAsync(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"api/GiayChiTiet/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
