using Data.Models;

namespace API.IRepository
{
    public interface  IAnhRepository
    {
        Task<List<Anh>> GetAll();
        Task<Anh> GetById(Guid AnhId);
        Task Create(Anh anh);
        Task Update(Anh anh);
        Task Delete(Guid AnhId);
    }
}
