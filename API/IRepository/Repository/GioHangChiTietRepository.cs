using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace API.IRepository.Repository
{
    public class GioHangChiTietRepository : IGioHangChiTietRepository
    {
        private readonly DbContextApp _context;

        public GioHangChiTietRepository(DbContextApp context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GioHangChiTiet>> GetAllAsync()
        {
            return await _context.GioHangChiTiets
                .Include(x => x.GioHang)
                .Include(x => x.GiayChiTiet)
                .ToListAsync();
        }

        public async Task<GioHangChiTiet> GetByIdAsync(Guid id)
        {
            return await _context.GioHangChiTiets
                .Include(x => x.GioHang)
                .Include(x => x.GiayChiTiet)
                .FirstOrDefaultAsync(x => x.GioHangChiTietId == id);
        }

        public async Task AddAsync(GioHangChiTiet entity)
        {
            await _context.GioHangChiTiets.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(GioHangChiTiet entity)
        {
            _context.GioHangChiTiets.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _context.GioHangChiTiets.FindAsync(id);
            if (entity != null)
            {
                _context.GioHangChiTiets.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
