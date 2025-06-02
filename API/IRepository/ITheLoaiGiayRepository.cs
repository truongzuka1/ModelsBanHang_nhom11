using Data.Models;

namespace API.IRepository
{
    public interface ITheLoaiGiayRepository
    {
        Task<List<TheLoaiGiay>> GetAll();
        Task<TheLoaiGiay> GetById(Guid TheLoaiGiayId);
        Task Create(TheLoaiGiay theloaigiay);
        Task Update(TheLoaiGiay theloaigiay);
        Task Delete(Guid TheLoaiGiayId);
    }
}
