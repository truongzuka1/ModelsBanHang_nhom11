using Data.IRepository;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class DiaChiKhachHangRepository : IDiaChiKhachHangRepository
    {
        private readonly DbContextApp _context;

        public DiaChiKhachHangRepository(DbContextApp context)
        {
            _context = context;
        }

        public async Task<List<DiaChiKhachHang>> GetAllAsync()
        {
            return await _context.diaChiKhachHangs
                .Where(d => d.TrangThai)
                .Include(d => d.KhachHang)
                .ToListAsync();
        }

        public async Task<DiaChiKhachHang> GetByIdAsync(Guid id)
        {
            return await _context.diaChiKhachHangs
                .Include(d => d.KhachHang)
                .FirstOrDefaultAsync(d => d.DiaChiKhachHangId == id && d.TrangThai);
        }

        public async Task<List<DiaChiKhachHang>> GetByKhachHangIdAsync(Guid khachHangId)
        {
            return await _context.diaChiKhachHangs
                .Where(d => d.KhachHangId == khachHangId && d.TrangThai)
                .ToListAsync();
        }

        public async Task<DiaChiKhachHang> GetDefaultByKhachHangIdAsync(Guid khachHangId)
        {
            return await _context.diaChiKhachHangs
                .FirstOrDefaultAsync(d => d.KhachHangId == khachHangId && d.TrangThai && d.IsDefault);
        }

        public async Task<bool> CreateAsync(DiaChiKhachHang diaChi)
        {
            try
            {
                diaChi.DiaChiKhachHangId = Guid.NewGuid();
                await _context.diaChiKhachHangs.AddAsync(diaChi);
                await _context.SaveChangesAsync();
                return true;
            }
            catch { return false; }
        }

        public async Task<bool> UpdateAsync(DiaChiKhachHang diaChi)
        {
            try
            {
                _context.diaChiKhachHangs.Update(diaChi);
                await _context.SaveChangesAsync();
                return true;
            }
            catch { return false; }
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var diaChi = await _context.diaChiKhachHangs.FindAsync(id);
            if (diaChi == null) return false;

            diaChi.TrangThai = false;
            _context.diaChiKhachHangs.Update(diaChi);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> SetDefaultAsync(Guid id)
        {
            var diaChi = await GetByIdAsync(id);
            if (diaChi == null) return false;

            var danhSach = await GetByKhachHangIdAsync(diaChi.KhachHangId);

            foreach (var d in danhSach)
            {
                d.IsDefault = false;
                await UpdateAsync(d);
            }

            diaChi.IsDefault = true;
            await UpdateAsync(diaChi);

            return true;
        }
    }
}
