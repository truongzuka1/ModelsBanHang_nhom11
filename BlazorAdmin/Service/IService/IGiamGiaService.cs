using Data.Models;

namespace BlazorAdmin.Service.IService
{
    public interface IGiamGiaService
    {
        Task<IEnumerable<GiamGia>> GetAllAsync();
        Task<GiamGia> GetByIdAsync(Guid id);
        Task<GiamGia> AddAsync(GiamGia giamGia);
        Task<GiamGia> UpdateAsync(GiamGia giamGia);
        Task<bool> DeleteAsync(Guid id);

        Task<bool> AddGiayToDotGiamGia(Guid giamGiaId, Guid giayId);
        Task<bool> RemoveGiayFromDotGiamGia(Guid giamGiaId, Guid giayId);
    }
}