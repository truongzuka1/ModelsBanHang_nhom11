using API.Models.DTO;
using BlazorAdmin.Service.IService;
using System.Net.Http;
using System.Net.Http.Json;

namespace BlazorAdmin.Service
{
    public class DiaChiKhachHangService : IDiaChiKhachHangService
    {
        private readonly HttpClient _httpClient;

        public DiaChiKhachHangService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<DiaChiKhachHangDTO>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<DiaChiKhachHangDTO>>("api/DiaChiKhachHang");
        }

        public async Task<DiaChiKhachHangDTO> GetByIdAsync(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<DiaChiKhachHangDTO>($"api/DiaChiKhachHang/{id}");
        }

        public async Task<List<DiaChiKhachHangDTO>> GetByKhachHangIdAsync(Guid khachHangId)
        {
            return await _httpClient.GetFromJsonAsync<List<DiaChiKhachHangDTO>>($"api/DiaChiKhachHang/khachhang/{khachHangId}");
        }

        public async Task<bool> CreateAsync(DiaChiKhachHangDTO dto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/DiaChiKhachHang", dto);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAsync(Guid id, DiaChiKhachHangDTO dto)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/DiaChiKhachHang/{id}", dto);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"api/DiaChiKhachHang/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
