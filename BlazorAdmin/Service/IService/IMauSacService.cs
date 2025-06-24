using API.Models.DTO;

namespace BlazorAdmin.Service.IService
{
    public interface IMauSacService
    {
        Task<List<MauSacDTO>> GetAllAsync();
        Task<MauSacDTO> GetByIdAsync(Guid id);
        Task<bool> CreateAsync(MauSacDTO dto);
        Task<bool> UpdateAsync(MauSacDTO dto);
        Task<bool> DeleteAsync(Guid id);

        Task<bool> AddMauSacToGiayChiTiet(Guid giayChiTietId, Guid mauSacId);
        Task<bool> RemoveMauSacFromGiayChiTiet(Guid giayChiTietId, Guid mauSacId);
        Task<List<MauSacDTO>> GetMauSacsByGiayIdAsync(Guid giayChiTietId);

    }
}
