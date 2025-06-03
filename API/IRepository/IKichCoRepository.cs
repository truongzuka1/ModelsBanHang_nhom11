using Data.Models;
using System.Security.Cryptography;

namespace API.IRepository
{
    public interface IKichCoRepository
    {
        Task<List<KichCo>> GetAll();
        Task<KichCo> GetById(Guid KichCoId);
        Task Create(KichCo kichco);
        Task Update(KichCo kichco);
        Task Delete(Guid KichCoId);
    }
}
