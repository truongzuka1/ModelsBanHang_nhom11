using Data.Models;

namespace API.IRepository
{
    public interface IMauSacRepository
    {
        Task<IEnumerable<MauSac>> GetAllAsync();
        Task<MauSac> GetByIdAsync(Guid id);
        Task<MauSac> AddAsync(MauSac mauSac);
        Task<MauSac> UpdateAsync(MauSac mauSac);
        Task<bool> DeleteAsync(Guid id);

        Task<bool> AddMauSacToGiayChiTiet(Guid giayChiTietId, Guid mauSacId);
        Task<bool> RemoveMauSacFromGiayChiTiet(Guid giayChiTietId, Guid mauSacId);
        Task<IEnumerable<MauSac>> GetMauSacsByGiayIdAsync(Guid giayChiTietId);
    }
}
