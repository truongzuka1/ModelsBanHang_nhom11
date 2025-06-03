using Data.Models;

namespace API.IRepository
{
    public interface IVoucherRepo
    {
        Task<List<Voucher>> GetAll();
        Task<Voucher> GetById(Guid id);
        Task Add(Voucher hs);
        Task Update(Voucher hs);
        Task Delete(Guid id);
    }

}
