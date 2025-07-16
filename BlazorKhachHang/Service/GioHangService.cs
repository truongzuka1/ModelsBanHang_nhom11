using API.Models.DTO;

namespace BlazorKhachHang.Service
{
    public class GioHangService
    {
        private readonly HttpClient _http;

        public GioHangService(HttpClient http)
        {
            _http = http;
        }

        public async Task<GioHangDTO> LayTheoTaiKhoanAsync(Guid taiKhoanId)
            => await _http.GetFromJsonAsync<GioHangDTO>($"/api/giohang/tai-khoan/{taiKhoanId}");

        public async Task CapNhatSoLuong(Guid chiTietId, int soLuong)
            => await _http.PutAsJsonAsync($"/api/giohang/cap-nhat-so-luong/{chiTietId}", soLuong);

        public async Task XoaSanPham(Guid chiTietId)
            => await _http.DeleteAsync($"/api/giohang/xoa/{chiTietId}");
    }
}
