using Data.Models;

namespace BlazorAdmin.Service.IService
{
    public interface IGiayService
    {
        Task<List<Giay>> GetAllAsync();
        Task<Giay> GetByIdAsync(Guid id);
        Task CreateAsync(Giay obj);
        Task UpdateAsync(Giay obj);
        Task DeleteAsync(Guid id);
    }
}
