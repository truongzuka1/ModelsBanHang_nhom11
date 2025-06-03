using API.Repository.IRepository;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repository
{
    public class GiayChiTietRepository : IGiayChiTietRepository
    {
        private readonly DbContextApp _db;
        private readonly IDeGiayRepository _deGiayRepository;

        public GiayChiTietRepository(DbContextApp db, IDeGiayRepository deGiayRepository)
        {
            _db = db;
            _deGiayRepository = deGiayRepository;
        }

        

        public async Task CreateGiayChiTiet(GiayChiTiet gct ,Guid? iddegiay)
        {
            try
            {
                gct.DeGiayId = _deGiayRepository.GetDeGiay(iddegiay).Result.DeGiayId;
                _db.GiayChiTiets.Add(gct);
                await _db.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        

        public async Task DeleteGiayChiTiet(Guid id)
        {
            try
            {
                var gctdel = await _db.FindAsync<GiayChiTiet>(id);
                if (gctdel != null)
                {
                    _db.Remove(gctdel);
                    await _db.SaveChangesAsync();
                }
                
            }
            catch (Exception)
            {

                throw;
            }
        }

        

        public async Task<IEnumerable<GiayChiTiet>> getAllGiayChiTiet()
        {
            return await _db.GiayChiTiets.ToListAsync();
        }

        

        public async Task<GiayChiTiet> getGiayChiTietbyID(Guid id)
        {
            return await _db.GiayChiTiets.FindAsync(id);
        }

        

        public async Task UpdateGiayChiTiet(GiayChiTiet gct, Guid? iddegiay)
        {
            try
            {
                gct.DeGiayId = _deGiayRepository.GetDeGiay(iddegiay).Result.DeGiayId;
                _db.GiayChiTiets.Update(gct);
                await _db.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
