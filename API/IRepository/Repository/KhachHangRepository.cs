using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repositories
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
                .Include(kh => kh.TaiKhoan)
                .Include(kh => kh.HoaDons)
                .Include(kh => kh.DiaChiKhachHangs)
                .Include(kh => kh.GioHangs)
                .ToListAsync();
        }

        public async Task<KhachHang?> GetByIdAsync(Guid id)
        {
            return await _context.KhachHangs
                .Include(kh => kh.TaiKhoan)
                .FirstOrDefaultAsync(kh => kh.KhachHangId == id);
        }

        public async Task<KhachHang?> GetByEmailAsync(string email)
        {
            return await _context.KhachHangs
                .FirstOrDefaultAsync(kh => kh.Email == email);
        }

        public async Task<KhachHang?> GetBySoDienThoaiAsync(string soDienThoai)
        {
            return await _context.KhachHangs
                .FirstOrDefaultAsync(kh => kh.SoDienThoai == soDienThoai);
        }

        public async Task AddAsync(KhachHang khachHang)
        {
            _context.KhachHangs.Add(khachHang);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(KhachHang khachHang)
        {
            _context.KhachHangs.Update(khachHang);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _context.KhachHangs.FindAsync(id);
            if (entity != null)
            {
                _context.KhachHangs.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(Guid id)
        {
            return await _context.KhachHangs.AnyAsync(kh => kh.KhachHangId == id);
        }
    }
}