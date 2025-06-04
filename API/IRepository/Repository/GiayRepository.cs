using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.IRepository.Repository
{
    public class GiayRepository : IGiayRepository
    {
        private readonly DbContextApp _context;

        public GiayRepository(DbContextApp context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Giay>> GetAllAsync()
        {
            try
            {
                return await _context.Giays.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách giày.", ex);
            }
        }

        public async Task<Giay?> GetByIdAsync(Guid id)
        {
            try
            {
                return await _context.Giays.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy giày với ID = {id}.", ex);
            }
        }

        public async Task AddAsync(Giay giay)
        {
            try
            {
                await _context.Giays.AddAsync(giay);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm mới giày.", ex);
            }
        }

        public async Task UpdateAsync(Giay giay)
        {
            try
            {
                _context.Giays.Update(giay);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật giày.", ex);
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            try
            {
                var giay = await _context.Giays.FindAsync(id);
                if (giay != null)
                {
                    _context.Giays.Remove(giay);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi xóa giày với ID = {id}.", ex);
            }
        }
    }
}
