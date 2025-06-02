using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhachHangController : ControllerBase
    {
        private readonly DbContextApp _context;

        public KhachHangController(DbContextApp context)
        {
            _context = context;
        }

        // GET: api/KhachHang
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KhachHang>>> GetAllKhachHang()
        {
            return await _context.Set<KhachHang>()
                .Include(k => k.TaiKhoan)
                .Include(k => k.HoaDons)
                .Include(k => k.GioHangs)
                .Include(k => k.DiaChiKhachHangs)
                .ToListAsync();
        }

        // GET: api/KhachHang/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<KhachHang>> GetKhachHang(Guid id)
        {
            var khachHang = await _context.Set<KhachHang>()
                .Include(k => k.TaiKhoan)
                .Include(k => k.HoaDons)
                .Include(k => k.GioHangs)
                .Include(k => k.DiaChiKhachHangs)
                .FirstOrDefaultAsync(k => k.KhachHangId == id);

            if (khachHang == null)
            {
                return NotFound();
            }

            return khachHang;
        }

        // POST: api/KhachHang
        [HttpPost]
        public async Task<ActionResult<KhachHang>> CreateKhachHang(KhachHang khachHang)
        {
            khachHang.KhachHangId = Guid.NewGuid();
            khachHang.NgayTao = DateTime.UtcNow;
            khachHang.NgayCapNhatCuoiCung = DateTime.UtcNow;

            _context.KhachHangs.Add(khachHang);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetKhachHang), new { id = khachHang.KhachHangId }, khachHang);
        }

        // PUT: api/KhachHang/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateKhachHang(Guid id, KhachHang khachHang)
        {
            if (id != khachHang.KhachHangId)
            {
                return BadRequest("ID không trùng khớp.");
            }

            var khachHangExist = await _context.KhachHangs.FindAsync(id);
            if (khachHangExist == null)
            {
                return NotFound();
            }

            // Update thủ công các field
            khachHangExist.HoTen = khachHang.HoTen;
            khachHangExist.Email = khachHang.Email;
            khachHangExist.SoDienThoai = khachHang.SoDienThoai;
            khachHangExist.NgaySinh = khachHang.NgaySinh;
            khachHangExist.TrangThai = khachHang.TrangThai;
            khachHangExist.TaiKhoanId = khachHang.TaiKhoanId;
            khachHangExist.NgayCapNhatCuoiCung = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/KhachHang/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKhachHang(Guid id)
        {
            var khachHang = await _context.KhachHangs.FindAsync(id);
            if (khachHang == null)
            {
                return NotFound();
            }

            _context.KhachHangs.Remove(khachHang);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

