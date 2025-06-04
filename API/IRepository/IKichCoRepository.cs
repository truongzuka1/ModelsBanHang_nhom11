using Data.Models;
using System.Security.Cryptography;

namespace API.IRepository
{
    public interface IKichCoRepository
    {
        Task<List<KichCo>> GetAllKichCo();
        Task<KichCo> GetByIdKichCo(Guid KichCoId);
        Task CreateKichCo(KichCo kichco);
        Task UpdateKichCo(KichCo kichco);
        Task DeleteKichCo(Guid KichCoId);
    }
}
