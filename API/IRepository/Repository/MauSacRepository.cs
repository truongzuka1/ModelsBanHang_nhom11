using API.IRepository;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repository
{
    public class MauSacRepository : IMauSacRepository
    {
        private readonly DbContextApp _context;

        public MauSacRepository(DbContextApp context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MauSac>> GetAllAsync()
        {
            return await _context.MauSacs.ToListAsync();
        }

        public async Task<MauSac> GetByIdAsync(Guid id)
        {
            return await _context.MauSacs.FindAsync(id);
        }

        public async Task<MauSac> AddAsync(MauSac mauSac)
        {
            _context.MauSacs.Add(mauSac);
            await _context.SaveChangesAsync();
            return mauSac;
        }

        public async Task<MauSac> UpdateAsync(MauSac mauSac)
        {
            var existing = await _context.MauSacs.FindAsync(mauSac.MauSacId);
            if (existing == null) return null;

            existing.TenMau = mauSac.TenMau;
            existing.MoTa = mauSac.MoTa;
            existing.TrangThai = mauSac.TrangThai;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var mauSac = await _context.MauSacs.FindAsync(id);
            if (mauSac == null) return false;

            _context.MauSacs.Remove(mauSac);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AddMauSacToGiayChiTiet(Guid giayChiTietId, Guid mauSacId)
        {
            var giayChiTiet = await _context.GiayChiTiets
                .Include(g => g.MauSac)
                .FirstOrDefaultAsync(g => g.GiayChiTietId == giayChiTietId);

            var mauSac = await _context.MauSacs.FindAsync(mauSacId);

            if (giayChiTiet == null || mauSac == null)
                return false;

            giayChiTiet.MauSac = mauSac;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RemoveMauSacFromGiayChiTiet(Guid giayChiTietId, Guid mauSacId)
        {
            var giayChiTiet = await _context.GiayChiTiets
                .Include(g => g.MauSac)
                .FirstOrDefaultAsync(g => g.GiayChiTietId == giayChiTietId);

            if (giayChiTiet == null || giayChiTiet.MauSac?.MauSacId != mauSacId)
                return false;

            giayChiTiet.MauSac = null;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<MauSac>> GetMauSacsByGiayIdAsync(Guid giayChiTietId)
        {
            var giayChiTiet = await _context.GiayChiTiets
                .Include(g => g.MauSac)
                .FirstOrDefaultAsync(g => g.GiayChiTietId == giayChiTietId);

            if (giayChiTiet?.MauSac == null) return Enumerable.Empty<MauSac>();

            return new List<MauSac> { giayChiTiet.MauSac };
        }
    }
}
