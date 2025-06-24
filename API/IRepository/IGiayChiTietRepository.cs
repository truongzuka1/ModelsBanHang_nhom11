using Data.Models;

namespace API.IRepository
{
    public interface IGiayChiTietRepository
    {
        Task<List<GiayChiTiet>> GetAllAsync();
        Task<GiayChiTiet?> GetByIdAsync(Guid id);
        Task<bool> CreateAsync(GiayChiTiet entity);
        Task<bool> UpdateAsync(Guid id, GiayChiTiet entity);
        Task<bool> DeleteAsync(Guid id);
        Task<List<GiayChiTiet>> GetByGiayIdAsync(Guid giayId);
    }
}
