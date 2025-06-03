using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace API.IRepository.Repository
{
    public class VoucherRepo : IVoucherRepo
    {
        private readonly DbContextApp _context;

        public VoucherRepo(DbContextApp context)
        {
            _context = context;
        }

        public async Task Add(Voucher hs)
        {
            _context.Vouchers.Add(hs);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var voucher = await GetById(id);
            _context.Vouchers.Remove(voucher);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Voucher>> GetAll() => await _context.Vouchers.ToListAsync();

        public async Task<Voucher> GetById(Guid id)
            => await _context.Vouchers.FindAsync(id) ?? throw new KeyNotFoundException("Voucher not found.");

        public async Task Update(Voucher hs)
        {
            _context.Vouchers.Update(hs);
            await _context.SaveChangesAsync();
        }
    }
}
