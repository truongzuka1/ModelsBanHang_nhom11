using Data.Models;

namespace API.IRepository
{
    public interface IGiayRepository
    {
        Task<IEnumerable<Giay>> GetAllAsync();
        Task<Giay?> GetByIdAsync(Guid id);
        Task AddAsync(Giay giay);
        Task UpdateAsync(Giay giay);
        Task DeleteAsync(Guid id);
        Task GetByIdWithGiamGiaAsync(Guid id);
    }
}
