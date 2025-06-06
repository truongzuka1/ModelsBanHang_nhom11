using Data.Models;

namespace API.IService
{
    public interface ITheLoaiGiayService
    {
        Task<IEnumerable<TheLoaiGiay>> GetAllAsync();
        Task<TheLoaiGiay> GetByIdAsync(Guid id);
        Task<TheLoaiGiay> AddAsync(TheLoaiGiay theLoaiGiay);
        Task<TheLoaiGiay> UpdateAsync(TheLoaiGiay theLoaiGiay);
        Task<bool> DeleteAsync(Guid id);
        Task<TheLoaiGiay> GetTheLoaiByGiayChiTietIdAsync(Guid giayChiTietId);
    }
}