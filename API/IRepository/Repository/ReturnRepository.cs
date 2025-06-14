using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace API.IRepository.Repository
{
    public class ReturnRepository
    {
        private readonly DbContextApp _context;
        public ReturnRepository(DbContextApp context)
        {
            _context = context;
        }
        public async Task<HoaDon> GetHoaDonByIdAsync(Guid hoaDonId)
        {
            return await _context.HoaDons
                .Include(h => h.HoaDonChiTietsId)
                .ThenInclude(h => h.Giays)
                .Include(h => h.khachHang)
                .Include(h => h.voucher)
                .Include(h => h.taiKhoan)
                .FirstOrDefaultAsync(h => h.HoaDonId == hoaDonId);
        }

        public async Task<List<HoaDonChiTiet>> GetHoaDonChiTietsByHoaDonIdAsync(Guid hoaDonId)
        {
            return await _context.HoaDonChiTiets
                .Where(h => h.HoaDonId == hoaDonId)
                .Include(h => h.Giays)
                .ToListAsync();
        }

        public async Task<HoaDon> CreateReturnHoaDonAsync(HoaDon hoaDon)
        {
            _context.HoaDons.Add(hoaDon);
            await _context.SaveChangesAsync();
            return hoaDon;
        }

        public async Task<HoaDonChiTiet> CreateHoaDonChiTietAsync(HoaDonChiTiet chiTiet)
        {
            _context.HoaDonChiTiets.Add(chiTiet);
            await _context.SaveChangesAsync();
            return chiTiet;
        }

        public async Task<Voucher> GetValidVoucherAsync(Guid? voucherId)
        {
            if (!voucherId.HasValue) return null;
            return await _context.Vouchers
                .FirstOrDefaultAsync(v => v.VoucherId == voucherId && v.TrangThai && v.NgayBatDau <= DateTime.Now && v.NgayKetThuc >= DateTime.Now && v.SoLuong > 0);
        }

        public async Task UpdateHoaDonAsync(HoaDon hoaDon)
        {
            _context.HoaDons.Update(hoaDon);
            await _context.SaveChangesAsync();
        }

        public async Task<TaiKhoan> GetTaiKhoanByIdAsync(Guid taiKhoanId)
        {
            return await _context.TaiKhoans.FirstOrDefaultAsync(t => t.TaikhoanId == taiKhoanId);
        }
    }
}
