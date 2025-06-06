using Data.Models;
using BlazorAdmin.Service.IService;
using Data.Models;

namespace BlazorAdmin.Service
{
    public class TaiKhoanService : ITaiKhoanService
    {
        private readonly HttpClient _httpClient;

        public TaiKhoanService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateTaiKhoanAsync(TaiKhoan tk)
        {
            await _httpClient.PostAsJsonAsync("/api/TaiKhoans", tk);
        }

        public async Task DeleteTaiKhoanAsync(Guid id)
        {
            await _httpClient.DeleteAsync("/api/TaiKhoans/" + id);
        }

        public async Task<List<TaiKhoan>> GetAllTaiKhoanAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<TaiKhoan>>("/api/TaiKhoans");
        }

        public async Task<TaiKhoan> GetByIdTaiKhoanAsync(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<TaiKhoan>($"/api/TaiKhoans/{id}");
        }

        public async Task UpdateTaiKhoanAsync(TaiKhoan tk)
        {
            await _httpClient.PutAsJsonAsync($"/api/TaiKhoans/{tk.TaikhoanId}", tk);
        }


        public async Task<TaiKhoan> GetByIdChucVuAsync(string username, string password)
        {
            var loginData = new { username, password };
            var response = await _httpClient.PostAsJsonAsync("/api/TaiKhoans/login", loginData);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<TaiKhoan>();
        }
        public async Task<TaiKhoan> GetByUsernameAsync(string username)
        {
            return await _httpClient.GetFromJsonAsync<TaiKhoan>($"/api/TaiKhoans/username/{username}");
        }
    }

}
