using Data.Models;

namespace API.IService
{
    public interface IKichCoService
    {
        Task<IEnumerable<KichCo>> GetAllAsync();
        Task<KichCo> GetByIdAsync(Guid id);
        Task<KichCo> AddAsync(KichCo kichCo);
        Task<KichCo> UpdateAsync(KichCo kichCo);
        Task<bool> DeleteAsync(Guid id);

        Task<bool> AddKichCoToGiayChiTiet(Guid giayChiTietId, Guid kichCoId);
        Task<bool> RemoveKichCoFromGiayChiTiet(Guid giayChiTietId, Guid kichCoId);
        Task<IEnumerable<KichCo>> GetKichCosByGiayIdAsync(Guid giayChiTietId);
    }
}