using API.IRepository;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repository
{
    public class GiayChiTietRepository : IGiayChiTietRepository
    {
        private readonly DbContextApp _context;

        public GiayChiTietRepository(DbContextApp context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GiayChiTiet>> GetAllAsync()
        {
            return await _context.GiayChiTiets
                .Include(g => g.Giay)
                .Include(g => g.KichCo)  // Đã sửa từ Kichco -> KichCo
                .Include(g => g.MauSac)
                .Include(g => g.Anhs)
                .AsNoTracking()  // Tối ưu cho read-only
                .ToListAsync();
        }

        public async Task<GiayChiTiet?> GetByIdAsync(Guid id)
        {
            return await _context.GiayChiTiets
                .Include(g => g.Giay)
                .Include(g => g.KichCo)  // Đã sửa
                .Include(g => g.MauSac)
                .Include(g => g.Anhs)    // Thêm include ảnh
                .FirstOrDefaultAsync(x => x.GiayChiTietId == id);
        }

        public async Task<IEnumerable<GiayChiTiet>> GetByGiayIdAsync(Guid giayId)
        {
            return await _context.GiayChiTiets
                .Where(x => x.GiayId == giayId)
                .Include(g => g.Giay)
                .Include(g => g.KichCo)  // Đã sửa
                .Include(g => g.MauSac)
                .Include(g => g.Anhs)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<GiayChiTiet> AddAsync(GiayChiTiet chiTiet)
        {
            // Kiểm tra trùng lặp (tùy nhu cầu)
            if (await _context.GiayChiTiets.AnyAsync(x =>
                x.GiayId == chiTiet.GiayId &&
                x.KichCoId == chiTiet.KichCoId &&
                x.MauSacId == chiTiet.MauSacId))
            {
                throw new InvalidOperationException("Đã tồn tại sản phẩm với cùng cấu hình");
            }

            chiTiet.GiayChiTietId = Guid.NewGuid();
            chiTiet.NgayTao = DateTime.UtcNow;  // Sử dụng UTC
            chiTiet.NgaySua = DateTime.UtcNow;

            await _context.GiayChiTiets.AddAsync(chiTiet);
            await _context.SaveChangesAsync();
            return chiTiet;
        }

        public async Task<List<GiayChiTiet>> AddMultipleReturnAsync(List<GiayChiTiet> list)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                foreach (var item in list)
                {
                    item.GiayChiTietId = Guid.NewGuid();
                    item.NgayTao = DateTime.UtcNow;
                    item.NgaySua = DateTime.UtcNow;
                    await _context.GiayChiTiets.AddAsync(item);
                }
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                return list;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<GiayChiTiet?> UpdateAsync(GiayChiTiet chiTiet)
        {
            var existing = await _context.GiayChiTiets.FindAsync(chiTiet.GiayChiTietId);
            if (existing == null) return null;

            // Cập nhật toàn bộ thuộc tính
            existing.GiayId = chiTiet.GiayId;  // Thêm dòng này
            existing.KichCoId = chiTiet.KichCoId;
            existing.MauSacId = chiTiet.MauSacId;
            existing.Gia = chiTiet.Gia;
            existing.SoLuongCon = chiTiet.SoLuongCon;
            existing.MoTa = chiTiet.MoTa;
            existing.TrangThai = chiTiet.TrangThai;
            existing.NgaySua = DateTime.UtcNow;  // Sử dụng UTC

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var existing = await _context.GiayChiTiets.FindAsync(id);
            if (existing == null) return false;

            _context.GiayChiTiets.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}