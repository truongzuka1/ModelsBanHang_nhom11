using API.Models.DTO;
using Data.Models;

namespace BlazorAdmin.Service.IService
{
    public interface IGiayService
    {
        Task<List<GiayDTO>> GetAllAsync();
        Task<GiayDTO> GetByIdAsync(Guid id);
        Task<Guid?> CreateAsync(GiayDTO dto);
        Task<bool> UpdateAsync(GiayDTO dto);
        Task<bool> DeleteAsync(Guid id);
    }
}
