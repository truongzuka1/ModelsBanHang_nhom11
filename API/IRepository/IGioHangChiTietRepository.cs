using Data.Models;

namespace API.IRepository
{
    public interface IGioHangChiTietRepository
    {
        Task<IEnumerable<GioHangChiTiet>> GetAllAsync();
        Task<GioHangChiTiet> GetByIdAsync(Guid id);
        Task AddAsync(GioHangChiTiet entity);
        Task UpdateAsync(GioHangChiTiet entity);
        Task DeleteAsync(Guid id);
    }
}
