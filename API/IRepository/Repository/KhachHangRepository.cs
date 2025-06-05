using Data.Models;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace API.IRepository.Repository
{
    public class KhachHangRepository : IKhachHangRepository
    {
        private readonly DbContextApp _context;

        public KhachHangRepository(DbContextApp context)
        {
            _context = context;
        }

        public async Task<IEnumerable<KhachHang>> GetAllAsync()
        {
            return await _context.KhachHangs
                .Include(k => k.TaiKhoan)
                .Include(k => k.DiaChiKhachHangs)
                .Include(k => k.GioHangs)
                .Include(k => k.HoaDons)
                .ToListAsync();
        }

        public async Task<KhachHang> GetByIdAsync(Guid id)
        {
            return await _context.KhachHangs
                .Include(k => k.TaiKhoan)
                .Include(k => k.DiaChiKhachHangs)
                .Include(k => k.GioHangs)
                .Include(k => k.HoaDons)
                .FirstOrDefaultAsync(k => k.KhachHangId == id);
        }

        public async Task<KhachHang> AddAsync(KhachHang entity)
        {
            entity.KhachHangId = Guid.NewGuid();
            entity.NgayTao = DateTime.UtcNow;
            entity.NgayCapNhatCuoiCung = DateTime.UtcNow;

            _context.KhachHangs.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> UpdateAsync(KhachHang entity)
        {
            var existing = await _context.KhachHangs.FindAsync(entity.KhachHangId);
            if (existing == null) return false;

            existing.HoTen = entity.HoTen;
            existing.Email = entity.Email;
            existing.SoDienThoai = entity.SoDienThoai;
            existing.NgaySinh = entity.NgaySinh;
            existing.TrangThai = entity.TrangThai;
            existing.TaiKhoanId = entity.TaiKhoanId;
            existing.NgayCapNhatCuoiCung = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var khachHang = await _context.KhachHangs.FindAsync(id);
            if (khachHang == null) return false;

            _context.KhachHangs.Remove(khachHang);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
