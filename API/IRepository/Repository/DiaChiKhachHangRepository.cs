using Data.Models;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace API.IRepository.Repository
{
    public class DiaChiKhachHangRepository : IDiaChiKhachHangRepository
    {
        private readonly DbContextApp _context;

        public DiaChiKhachHangRepository(DbContextApp context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DiaChiKhachHang>> GetAllAsync()
        {
            return await _context.diaChiKhachHangs
                .Include(d => d.KhachHang)
                .ToListAsync();
        }

        public async Task<DiaChiKhachHang> GetByIdAsync(Guid id)
        {
            return await _context.diaChiKhachHangs
                .Include(d => d.KhachHang)
                .FirstOrDefaultAsync(d => d.DiaChiKhachHangId == id);
        }

        public async Task<DiaChiKhachHang> AddAsync(DiaChiKhachHang entity)
        {
            entity.DiaChiKhachHangId = Guid.NewGuid();
            _context.diaChiKhachHangs.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> UpdateAsync(DiaChiKhachHang entity)
        {
            var existing = await _context.diaChiKhachHangs.FindAsync(entity.DiaChiKhachHangId);
            if (existing == null) return false;

            existing.TenDiaChi = entity.TenDiaChi;
            existing.MoTa = entity.MoTa;
            existing.TrangThai = entity.TrangThai;
            existing.khachHangId = entity.khachHangId;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await _context.diaChiKhachHangs.FindAsync(id);
            if (entity == null) return false;

            _context.diaChiKhachHangs.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
