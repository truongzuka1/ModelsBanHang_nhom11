using Data.Models;

namespace API.IRepository
{
    public interface ITheLoaiGiayRepository
    {
        Task<List<TheLoaiGiay>> GetAllTheLoai();
        Task<TheLoaiGiay> GetByIdTheLoai(Guid TheLoaiGiayId);
        Task CreateTheLoai(TheLoaiGiay theloaigiay);
        Task UpdateTheLoai(TheLoaiGiay theloaigiay);
        Task DeleteTheLoai(Guid TheLoaiGiayId);
    }
}
