//using API.IRepository;
//using Data.Models;
//using Microsoft.EntityFrameworkCore;

//namespace API.IRepository.Repository
//{
//    public class GiayChiTietRepository : IGiayChiTietRepository
//    {
//        private readonly DbContextApp _db;
//        private readonly IDeGiayRepository _deGiayRepository;

//        public GiayChiTietRepository(DbContextApp db, IDeGiayRepository deGiayRepository)
//        {
//            _db = db;
//            _deGiayRepository = deGiayRepository;
//        }

        

//        public async Task CreateGiayChiTiet(GiayChiTiet gct ,Guid? iddegiay)
//        {
//            try
//            {
//                gct.DeGiayId = _deGiayRepository.GetDeGiay(iddegiay).Result.DeGiayId;
//                _db.GiayChiTiets.Add(gct);
//                await _db.SaveChangesAsync();
//            }
//            catch (Exception)
//            {

//                throw;
//            }
//        }

        

//        public async Task DeleteGiayChiTiet(Guid id)
//        {
//            try
//            {
//                var gctdel = await _db.FindAsync<GiayChiTiet>(id);
//                if (gctdel != null)
//                {
//                    _db.Remove(gctdel);
//                    await _db.SaveChangesAsync();
//                }
                
//            }
//            catch (Exception)
//            {

//                throw;
//            }
//        }

        

//        public async Task<IEnumerable<GiayChiTiet>> getAllGiayChiTiet()
//        {
//            return await _db.GiayChiTiets
//            .Include(x => x.Giay)
//            .Include(x => x.ChatLieu)
//            .Include(x => x.KichCo)
//            .Include(x => x.MauSac)
//            .Include(x => x.ThuongHieu)
//            .Include(x => x.KieuDang)
//            .Include(x => x.DeGiay)
//            .Include(x => x.TheLoaiGiay)
//            .Include(x => x.Anhs)
//            .ToListAsync();
//        }

        

//        public async Task<GiayChiTiet> getGiayChiTietbyID(Guid id)
//        {
//            return await _db.GiayChiTiets.FindAsync(id);
//        }

        

//        public async Task UpdateGiayChiTiet(GiayChiTiet gct, Guid? iddegiay)
//        {
//            try
//            {
//                gct.DeGiayId = _deGiayRepository.GetDeGiay(iddegiay).Result.DeGiayId;
//                _db.GiayChiTiets.Update(gct);
//                await _db.SaveChangesAsync();
//            }
//            catch (Exception)
//            {

//                throw;
//            }
//        }
//    }
//}
