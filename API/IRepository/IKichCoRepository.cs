using Data.Models;
using System.Security.Cryptography;

namespace API.IRepository
{
    public interface IKichCoRepository
    {
        Task<IEnumerable<KichCo>> GetAllAsync();
        Task<KichCo> GetByIdAsync(Guid id);
        Task<KichCo> AddAsync(KichCo kichCo);
        Task<KichCo> UpdateAsync(KichCo kichCo);
        Task<bool> DeleteAsync(Guid id);

        // Thêm kích cỡ vào GiayChiTiet (giày chi tiết nào có những kích cỡ nào)
        Task<bool> AddKichCoToGiayChiTiet(Guid giayChiTietId, Guid kichCoId);
        Task<bool> RemoveKichCoFromGiayChiTiet(Guid giayChiTietId, Guid kichCoId);
        Task<IEnumerable<KichCo>> GetKichCosByGiayIdAsync(Guid giayChiTietId);
    }
}
