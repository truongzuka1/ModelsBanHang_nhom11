using API.Models;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace API.IRepository.Repository
{

    public class NhanVienRepository : INhanVienRepository
    {
        private readonly DbContextApp _db;
        public NhanVienRepository(DbContextApp db)
        {
            _db = db;
        }
        public async Task CreateNhanVien(NhanVien nhanVien)
        {
            try
            {
              
                if (nhanVien.TaikhoanId == Guid.Empty)
                {
                    nhanVien.TaikhoanId = null;
                }

              
                if (nhanVien.ChucVuId == null || nhanVien.ChucVuId == Guid.Empty)
                {
                    nhanVien.ChucVuId = Guid.Parse("22222222-2222-2222-2222-222222222222");
                }

              
                nhanVien.NgayCapNhatCuoiCung = DateTime.Now;

                _db.NhanViens.Add(nhanVien);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi tạo nhân viên: {ex.Message}");
            }
        }
        public async Task DeleteNhanVienAsync(Guid NhanVienId)
        {
            try
            {
                var FindIdNhanVien = await GetByIdNhanVienAsync(NhanVienId);
                if (FindIdNhanVien != null)
                {
                    _db.Remove<NhanVien>(FindIdNhanVien);
                    await _db.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<NhanVien>> GetAllNhanVienAsync()
        {
            return await _db.NhanViens.ToListAsync();
        }

        public async Task<NhanVien> GetByIdNhanVienAsync(Guid NhanVienId)
        {
            try
            {
                return await _db.NhanViens.FindAsync(NhanVienId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateNhanVienAsync(NhanVien nhanVien)
        {
            try
            {
                _db.NhanViens.Update(nhanVien);
                await _db.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
