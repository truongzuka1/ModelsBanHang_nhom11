using Data.Models;

namespace BlazorAdmin.Service.IService
{
    public interface IChiTietHoaDonService
    {
        Task<IEnumerable<HoaDonChiTiet>> GetAllHDCTAsync();
        Task<IEnumerable<HoaDonChiTiet>> GetByHoaDonChiTietIdAsync(Guid hdctID);
        Task<HoaDonChiTiet> GetByIdHDCTAsync(Guid IdCTHD);
        Task<HoaDonChiTiet> GetByHoaDonChiTietvaGiayAsync(Guid hdctID, Guid giayId);
    }
}
