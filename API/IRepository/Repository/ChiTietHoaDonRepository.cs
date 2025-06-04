using API.Models;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace API.IRepository.Repository
{
    public class ChiTietHoaDonRepository : IChiTietHoaDonRepository
    {
        private readonly DbContextApp _db;
        public ChiTietHoaDonRepository(DbContextApp db)
        {
            _db = db;
        }
        public async Task<List<HoaDonChiTiet>> GetAllHDCTAsync()
        {
            return await _db.HoaDonChiTiets.ToListAsync();
        }

        public async Task<HoaDonChiTiet> GetByIdHDCTAsync(Guid IdCTHD)
        {
            try
            {
                return await _db.HoaDonChiTiets.FindAsync(IdCTHD);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
