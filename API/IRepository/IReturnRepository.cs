using Data.Models;

namespace API.IRepository
{
    public interface IReturnRepository
    {
        Task<HoaDon> GetHoaDonByIdAsync(Guid hoaDonId);
        Task<List<HoaDonChiTiet>> GetHoaDonChiTietsByHoaDonIdAsync(Guid hoaDonId);
        Task<HoaDon> CreateReturnHoaDonAsync(HoaDon hoaDon);
        Task<HoaDonChiTiet> CreateHoaDonChiTietAsync(HoaDonChiTiet chiTiet);
        Task<Voucher> GetValidVoucherAsync(Guid? voucherId);
        Task UpdateHoaDonAsync(HoaDon hoaDon);
        Task<TaiKhoan> GetTaiKhoanByIdAsync(Guid taiKhoanId); // Thêm để lấy thông tin tài khoản
    }
}
