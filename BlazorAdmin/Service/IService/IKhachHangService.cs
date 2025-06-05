using Data.Models;

namespace BlazorAdmin.Service.IService
{
    public interface IKhachHangService
    {
        Task<IEnumerable<KhachHang>> GetAllAsync();
        Task<KhachHang> GetByIdAsync(Guid id);
        Task<KhachHang> CreateAsync(KhachHang khachHang);
        Task UpdateAsync(Guid id, KhachHang khachHang);
        Task DeleteAsync(Guid id);
    }
}
