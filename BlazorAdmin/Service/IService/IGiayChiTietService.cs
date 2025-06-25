using API.Models.DTO;

namespace BlazorAdmin.Service.IService
{
    public interface IGiayChiTietService
    {
        Task<List<GiayChiTietDTO>> GetAllAsync();
        Task<GiayChiTietDTO> GetByIdAsync(Guid id);
        Task<List<GiayChiTietDTO>> GetByGiayIdAsync(Guid giayId);
        Task CreateAsync(GiayChiTietDTO obj);
        Task CreateMultipleAsync(List<GiayChiTietDTO> list);
        Task DeleteAsync(Guid id);
    }
}
