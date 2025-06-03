using Data.Models;

namespace API.IRepository
{
    public interface IGiamGiaRepository
    {
        Task<List<GiamGia>> GetAllGiamGia();
        Task<GiamGia> GetByIdGIamGIa(Guid GiamGiaId);
        Task CreateGIamGia(GiamGia GiamGia);
        Task UpdateGiamGia(GiamGia GiamGia);
        Task DeleteGiamGIa(Guid GiamGiaId);
    }
}
