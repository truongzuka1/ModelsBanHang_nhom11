using Data.Models;

namespace BlazorAdmin.Service.IService
{
    public interface IDeGiayService
    {
        Task<IEnumerable<DeGiay>> GetAllAsync();
        Task<DeGiay> GetByIdAsync(Guid id);
        Task CreateAsync(DeGiay deGiay);
        Task UpdateAsync(DeGiay deGiay);
        Task DeleteAsync(Guid id);
    }
}
