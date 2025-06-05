using Data.Models;

namespace API.IRepository
{
    public interface IDiaChiKhachHangRepository
    {
        Task<IEnumerable<DiaChiKhachHang>> GetAllAsync();
        Task<DiaChiKhachHang> GetByIdAsync(Guid id);
        Task<DiaChiKhachHang> AddAsync(DiaChiKhachHang entity);
        Task<bool> UpdateAsync(DiaChiKhachHang entity);
        Task<bool> DeleteAsync(Guid id);
    }
}
