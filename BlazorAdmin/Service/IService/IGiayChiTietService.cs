using API.Models.DTO;

namespace BlazorAdmin.Service.IService
{
    public interface IGiayChiTietService
    {
        Task<List<GiayChiTietDTO>> GetAllAsync();
        Task<GiayChiTietDTO?> GetByIdAsync(Guid id);
        Task<List<GiayChiTietDTO>> GetByGiayIdAsync(Guid giayId);
        Task<bool> CreateAsync(GiayChiTietDTO dto);
        Task<bool> UpdateAsync(Guid id, GiayChiTietDTO dto);
        Task<bool> DeleteAsync(Guid id);
    }
}
