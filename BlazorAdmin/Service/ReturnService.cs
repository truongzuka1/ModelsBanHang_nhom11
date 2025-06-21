using API.Models.DTO.TraHang;
using BlazorAdmin.Service.IService;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorAdmin.Service
{
    public class ReturnService : IReturnService
    {
        private readonly HttpClient _httpClient;

        public ReturnService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ReturnDTO>> SearchHoaDonAsync(string maHoaDon = null, string tenKhachHang = null, string sdt = null, DateTime? ngayTao = null, string trangThai = null)
        {
            var queryBuilder = new StringBuilder("api/Return?");
            var parameters = new List<string>();

            if (!string.IsNullOrEmpty(maHoaDon)) parameters.Add($"maHoaDon={Uri.EscapeDataString(maHoaDon)}");
            if (!string.IsNullOrEmpty(tenKhachHang)) parameters.Add($"tenKhachHang={Uri.EscapeDataString(tenKhachHang)}");
            if (!string.IsNullOrEmpty(sdt)) parameters.Add($"sdt={Uri.EscapeDataString(sdt)}");
            if (ngayTao.HasValue) parameters.Add($"ngayTao={Uri.EscapeDataString(ngayTao.Value.ToString("o"))}");
            if (!string.IsNullOrEmpty(trangThai)) parameters.Add($"trangThai={Uri.EscapeDataString(trangThai)}");

            queryBuilder.Append(string.Join("&", parameters));

            return await _httpClient.GetFromJsonAsync<List<ReturnDTO>>(queryBuilder.ToString()) ?? new List<ReturnDTO>();
        }

        public async Task<ReturnDTO> GetReturnInfoAsync(Guid hoaDonId)
        {
            return await _httpClient.GetFromJsonAsync<ReturnDTO>($"api/Return/{hoaDonId}") ?? new ReturnDTO();
        }

        public async Task<List<ReturnHistoryDTO>> GetReturnHistoryAsync(Guid hoaDonId)
        {
            return await _httpClient.GetFromJsonAsync<List<ReturnHistoryDTO>>($"api/Return/history/{hoaDonId}") ?? new List<ReturnHistoryDTO>();
        }

        public async Task<List<ValidateReturnResultDTO>> ValidateReturnAsync(CreateReturnDTO request)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Return/validate", request);
            return await response.Content.ReadFromJsonAsync<List<ValidateReturnResultDTO>>() ?? new List<ValidateReturnResultDTO>();
        }

        public async Task<bool> ProcessReturnAsync(CreateReturnDTO request)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Return", request);

            // Kiểm tra thành công, nếu không thì in log và trả false
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"[Blazor] ProcessReturn lỗi: {(int)response.StatusCode} - {response.ReasonPhrase}");
                return false;
            }

            // Nếu thành công, đọc kết quả true/false từ API
            return await response.Content.ReadFromJsonAsync<bool>();
        }


        public async Task<bool> DeleteReturnAsync(Guid hoaDonChiTietId)
        {
            var response = await _httpClient.DeleteAsync($"api/Return/{hoaDonChiTietId}");
            return await response.Content.ReadFromJsonAsync<bool>();
        }
    }
}