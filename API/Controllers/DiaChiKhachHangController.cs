using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiaChiKhachHangController : ControllerBase
    {
        private readonly DbContextApp _context;

        public DiaChiKhachHangController(DbContextApp context)
        {
            _context = context;
        }

        // GET: api/DiaChiKhachHang
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DiaChiKhachHang>>> GetAll()
        {
            return await _context.diaChiKhachHangs
                .Include(d => d.KhachHang)
                .ToListAsync();
        }

        // GET: api/DiaChiKhachHang/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<DiaChiKhachHang>> GetById(Guid id)
        {
            var diaChi = await _context.diaChiKhachHangs
                .Include(d => d.KhachHang)
                .FirstOrDefaultAsync(d => d.DiaChiKhachHangId == id);

            if (diaChi == null)
            {
                return NotFound();
            }

            return diaChi;
        }

        // POST: api/DiaChiKhachHang
        [HttpPost]
        public async Task<ActionResult<DiaChiKhachHang>> Create(DiaChiKhachHang diaChi)
        {
            if (!_context.KhachHangs.Any(kh => kh.KhachHangId == diaChi.khachHangId))
            {
                return BadRequest("KhachHangId không tồn tại.");
            }

            diaChi.DiaChiKhachHangId = Guid.NewGuid();
            _context.diaChiKhachHangs.Add(diaChi);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = diaChi.DiaChiKhachHangId }, diaChi);
        }

        // PUT: api/DiaChiKhachHang/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, DiaChiKhachHang diaChi)
        {
            if (id != diaChi.DiaChiKhachHangId)
                return BadRequest("ID không trùng khớp.");

            var existing = await _context.diaChiKhachHangs.FindAsync(id);
            if (existing == null)
                return NotFound();

            existing.TenDiaChi = diaChi.TenDiaChi;
            existing.MoTa = diaChi.MoTa;
            existing.TrangThai = diaChi.TrangThai;
            existing.khachHangId = diaChi.khachHangId;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/DiaChiKhachHang/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var diaChi = await _context.diaChiKhachHangs.FindAsync(id);
            if (diaChi == null)
                return NotFound();

            _context.diaChiKhachHangs.Remove(diaChi);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}

