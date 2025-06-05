using Data.Models;

namespace API.IRepository
{
    public interface IGiayChiTietRepository
    {
        Task<IEnumerable<GiayChiTiet>> getAllGiayChiTiet();
        Task<GiayChiTiet> getGiayChiTietbyID(Guid id);
        Task CreateGiayChiTiet(GiayChiTiet gct, Guid? iddegiay);
        Task UpdateGiayChiTiet(GiayChiTiet gct , Guid? iddegiay);
        Task DeleteGiayChiTiet(Guid id);
    }
}
