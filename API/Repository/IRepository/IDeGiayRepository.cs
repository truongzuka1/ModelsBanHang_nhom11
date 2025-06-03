using Data.Models;

namespace API.Repository.IRepository
{
    public interface IDeGiayRepository
    {
        Task<IEnumerable<DeGiay>> GetAllDegiay();
        Task<DeGiay> GetDeGiay(Guid? id);
        Task CreateDeGiay(DeGiay deGiay);
        Task UpdateDeGiay(DeGiay deGiay);
        Task DeleteDeGiay(Guid id);
    }
}
