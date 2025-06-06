using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.IRepository;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repository
{
    public class ChucVuRepository : IChucVuRepository
    {
        private readonly DbContext _context;

        public ChucVuRepository(DbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ChucVu>> GetAllChucVuAsync()
        {
            return await _context.Set<ChucVu>().ToListAsync();
        }

        public async Task<ChucVu> GetByIdChucVuAsync(Guid id)
        {
            return await _context.Set<ChucVu>().FindAsync(id);
        }

        public async Task CreateChucVuAsync(ChucVu chucVu)
        {
            await _context.Set<ChucVu>().AddAsync(chucVu);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateChucVuAsync(ChucVu chucVu)
        {
            _context.Set<ChucVu>().Update(chucVu);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteChucVuAsync(Guid id)
        {
            var chucVu = await GetByIdChucVuAsync(id);
            if (chucVu != null)
            {
                _context.Set<ChucVu>().Remove(chucVu);
                await _context.SaveChangesAsync();
            }
        }
    }
}