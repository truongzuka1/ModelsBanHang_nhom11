using API.Models.DTO;

namespace BlazorKhachHang.Service.IService
{
    public interface IGioHangService
    {
        Task<GioHangDTO> LayTheoTaiKhoanAsync(Guid taiKhoanId);
        Task CapNhatSoLuong(Guid chiTietId, int soLuong);
        Task XoaSanPham(Guid chiTietId);
    }
}
