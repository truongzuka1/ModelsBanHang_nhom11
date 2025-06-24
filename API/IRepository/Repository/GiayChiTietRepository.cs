using API.IRepository;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace API.Repository
{
    public class GiayChiTietRepository : IGiayChiTietRepository
    {
        private readonly DbContextApp _context;

        public GiayChiTietRepository(DbContextApp context)
        {
            _context = context;
        }

        public async Task<List<GiayChiTiet>> GetAllAsync()
        {
            return await _context.GiayChiTiets
                .Include(x => x.Giay)
                .Include(x => x.MauSac)
                .Include(x => x.KichCo)
                .Include(x => x.ChatLieu)
                .ToListAsync();
        }

        public async Task<GiayChiTiet?> GetByIdAsync(Guid id)
        {
            return await _context.GiayChiTiets
                .Include(x => x.Giay)
                .Include(x => x.MauSac)
                .Include(x => x.KichCo)
                .Include(x => x.ChatLieu)
                .FirstOrDefaultAsync(x => x.GiayChiTietId == id);
        }

        public async Task<bool> CreateAsync(GiayChiTiet entity)
        {
            entity.GiayChiTietId = Guid.NewGuid();
            entity.NgayTao = DateTime.UtcNow;
            entity.NgaySua = DateTime.UtcNow;

            _context.GiayChiTiets.Add(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateAsync(Guid id, GiayChiTiet updated)
        {
            var existing = await _context.GiayChiTiets.FindAsync(id);
            if (existing == null) return false;

            existing.ChatLieuId = updated.ChatLieuId;
            existing.KichCoId = updated.KichCoId;
            existing.MauSacId = updated.MauSacId;
            existing.ThuongHieuId = updated.ThuongHieuId;
            existing.KieuDangId = updated.KieuDangId;
            existing.DeGiayId = updated.DeGiayId;
            existing.TheLoaiGiayId = updated.TheLoaiGiayId;
            existing.SoLuongCon = updated.SoLuongCon;
            existing.Gia = updated.Gia;
            existing.MoTa = updated.MoTa;
            existing.AnhGiay = updated.AnhGiay;
            existing.TrangThai = updated.TrangThai;
            existing.NgaySua = DateTime.UtcNow;

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await _context.GiayChiTiets.FindAsync(id);
            if (entity == null) return false;

            _context.GiayChiTiets.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<GiayChiTiet>> GetByGiayIdAsync(Guid giayId)
        {
            return await _context.GiayChiTiets
                .Where(x => x.GiayId == giayId)
                .Include(x => x.Giay)
                .Include(x => x.MauSac)
                .Include(x => x.KichCo)
                .Include(x => x.ChatLieu)
                .ToListAsync();
        }
    }
}
