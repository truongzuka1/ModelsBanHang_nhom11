using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.IRepository.Repository
{
    public class KichCoRepository : IKichCoRepository
    {
        private readonly DbContextApp _context;

        public KichCoRepository(DbContextApp context)
        {
            _context = context;
        }

        public async Task<IEnumerable<KichCo>> GetAllAsync()
        {
            return await _context.KichCos.ToListAsync();
        }

        public async Task<KichCo> GetByIdAsync(Guid id)
        {
            return await _context.KichCos.FindAsync(id);
        }

        public async Task<KichCo> AddAsync(KichCo kichCo)
        {
            kichCo.KichCoId = Guid.NewGuid();
            _context.KichCos.Add(kichCo);
            await _context.SaveChangesAsync();
            return kichCo;
        }

        public async Task<KichCo> UpdateAsync(KichCo kichCo)
        {
            var existing = await _context.KichCos.FindAsync(kichCo.KichCoId);
            if (existing == null) return null;

            existing.TenKichCo = kichCo.TenKichCo;
            existing.MoTa = kichCo.MoTa;
            existing.TrangThai = kichCo.TrangThai;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var kichCo = await _context.KichCos.FindAsync(id);
            if (kichCo == null) return false;
            _context.KichCos.Remove(kichCo);
            await _context.SaveChangesAsync();
            return true;
        }

        // Thêm kích cỡ vào GiayChiTiet
        public async Task<bool> AddKichCoToGiayChiTiet(Guid giayChiTietId, Guid kichCoId)
        {
            var giayChiTiet = await _context.GiayChiTiets.FindAsync(giayChiTietId);
            var kichCo = await _context.KichCos.FindAsync(kichCoId);
            if (giayChiTiet == null || kichCo == null) return false;

            // Nếu đã có rồi thì không thêm nữa
            if (giayChiTiet.KichCoId == kichCoId) return false;

            giayChiTiet.KichCoId = kichCoId;
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> RemoveKichCoFromGiayChiTiet(Guid giayChiTietId, Guid kichCoId)
        {
            var giayChiTiet = await _context.GiayChiTiets.FindAsync(giayChiTietId);
            if (giayChiTiet == null || giayChiTiet.KichCoId != kichCoId) return false;
            _context.GiayChiTiets.Remove(giayChiTiet);
            await _context.SaveChangesAsync();
            return true;
        }

        // Lấy danh sách kích cỡ của 1 giày chi tiết (thường chỉ 1, nhưng giữ nguyên kiểu dữ liệu cho linh hoạt)
        public async Task<IEnumerable<KichCo>> GetKichCosByGiayIdAsync(Guid giayChiTietId)
        {
            var giayChiTiet = await _context.GiayChiTiets
                .Include(x => x.KichCo)
                .FirstOrDefaultAsync(x => x.GiayChiTietId == giayChiTietId);

            if (giayChiTiet == null || giayChiTiet.KichCo == null)
                return new List<KichCo>();

            return new List<KichCo> { giayChiTiet.KichCo };
        }
    }
}