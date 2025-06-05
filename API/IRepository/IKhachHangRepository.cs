using Data.Models;

namespace API.IRepository
{
    public interface IKhachHangRepository
    {
        Task<IEnumerable<KhachHang>> GetAllAsync();
        Task<KhachHang> GetByIdAsync(Guid id);
        Task<KhachHang> AddAsync(KhachHang entity);
        Task<bool> UpdateAsync(KhachHang entity);
        Task<bool> DeleteAsync(Guid id);
    }
}
