using Data.Models;

namespace BlazorAdmin.Service.IService
{
    public interface IGiayChiTietService
    {
        Task<IEnumerable<GiayChiTiet>> GetAllAsync();
        Task<GiayChiTiet> GetByIdAsync(Guid id);
        Task CreateAsync(GiayChiTiet gct, Guid? idDeGiay);
        Task UpdateAsync(GiayChiTiet gct, Guid? idDeGiay);
        Task DeleteAsync(Guid id);
    }
}
