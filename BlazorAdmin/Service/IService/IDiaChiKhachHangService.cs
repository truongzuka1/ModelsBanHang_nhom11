using Data.Models;

namespace BlazorAdmin.Service.IService
{
    public interface IDiaChiKhachHangService
    {
        Task<IEnumerable<DiaChiKhachHang>> GetAllAsync();
        Task<DiaChiKhachHang> GetByIdAsync(Guid id);
        Task<DiaChiKhachHang> CreateAsync(DiaChiKhachHang diaChi);
        Task UpdateAsync(Guid id, DiaChiKhachHang diaChi);
        Task DeleteAsync(Guid id);
    }
}
