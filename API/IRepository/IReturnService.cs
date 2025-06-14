using API.Controllers;
using Data.Models;

namespace API.IRepository
{
    public interface IReturnService
    {
        Task<HoaDon> GetHoaDonByIdAsync(Guid hoaDonId);
        Task<List<HoaDonChiTiet>> GetHoaDonChiTietsByHoaDonIdAsync(Guid hoaDonId);
        Task<HoaDon> CreateReturnAsync(Guid hoaDonId, List<ReturnItemRequest> returnItems, Guid? voucherId, Guid taiKhoanId);
    }
}
