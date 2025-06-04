using API.Models;
using Data.Models;

namespace API.IRepository
{
    public interface IChiTietHoaDonRepository
    {
        Task<List<HoaDonChiTiet>> GetAllHDCTAsync();
        Task<HoaDonChiTiet> GetByIdHDCTAsync(Guid IdCTHD);
    }
}
