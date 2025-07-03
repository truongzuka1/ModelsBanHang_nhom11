using API.Models.DTO;
using static BlazorAdmin.Components.Pages.Admin.SanPham.SanPhamChiTiet;

namespace BlazorAdmin.Service.IService
{
    public interface IGiayChiTietService
    {
        Task<List<GiayChiTietDTO>> GetAllAsync();
        Task<GiayChiTietDTO> GetByIdAsync(Guid id);
        Task<List<GiayChiTietDTO>> GetByGiayIdAsync(Guid giayId);
        Task<GiayChiTietDTO> CreateAsync(GiayChiTietDTO obj);
        Task<List<GiayChiTietDTO>> CreateMultipleAsync(List<GiayChiTietDTO> list);
        Task<GiayChiTietDTO> UpdateAsync(Guid id, GiayChiTietDTO obj);
        Task<bool> DeleteAsync(Guid id);
    }
}
