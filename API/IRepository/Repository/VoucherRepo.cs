using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace API.IRepository.Repository
{
    public class VoucherRepo : IVoucherRepo
    {
        private readonly DbContextApp _context;
        public VoucherRepo(DbContextApp context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task Create(Voucher voucher)
        {
            _context.Vouchers.Add(voucher);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Delete(Guid id)
        {
            var voucher = await _context.Vouchers.FindAsync(id);
            if (voucher == null)
            {
                return false; // Return false if the voucher does not exist
            }

            _context.Vouchers.Remove(voucher);
            await _context.SaveChangesAsync();
            return true; // Return true if the voucher was successfully deleted
        }

        public async Task<List<Voucher>> GetAll() => await _context.Vouchers.ToListAsync();


        public async Task<Voucher> GetById(Guid id) => await _context.Vouchers.FindAsync(id) ?? throw new KeyNotFoundException("Voucher not found with the provided ID.");

        public async Task Update(Voucher voucher)
        {
            _context.Vouchers.Update(voucher);
            await _context.SaveChangesAsync();
        }
    }
}
