using Data.Models;

namespace API.IRepository
{
    public interface IGiamGiaRepository
    {
        Task<List<GiamGia>> GetAll();
        Task<GiamGia> GetById(Guid GiamGiaId);
        Task Create(GiamGia GiamGia);
        Task Update(GiamGia GiamGia);
        Task Delete(Guid GiamGiaId);
    }
}
