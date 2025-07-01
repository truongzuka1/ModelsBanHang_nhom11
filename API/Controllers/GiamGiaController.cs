using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.IRepository;
using Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GiamGiaController : ControllerBase
    {
        private readonly IGiamGiaRepository _giamGiaRepository;
        private readonly IThongBaoRepository _thongBaoRepository; // ✅ Thêm

        public GiamGiaController(IGiamGiaRepository giamGiaRepository, IThongBaoRepository thongBaoRepository)
        {
            _giamGiaRepository = giamGiaRepository;
            _thongBaoRepository = thongBaoRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GiamGia>>> GetAll()
        {
            var result = await _giamGiaRepository.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GiamGia>> GetById(Guid id)
        {
            var result = await _giamGiaRepository.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<GiamGia>> Create([FromBody] GiamGia giamGia)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _giamGiaRepository.AddAsync(giamGia);

            // ✅ Ghi thông báo
            await _thongBaoRepository.ThemThongBaoAsync($"🎯 Thêm đợt giảm giá: {giamGia.TenGiamGia}");

            return CreatedAtAction(nameof(GetById), new { id = created.GiamGiaId }, created);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<GiamGia>> Update(Guid id, [FromBody] GiamGia giamGia)
        {
            if (id != giamGia.GiamGiaId)
                return BadRequest("Id mismatch");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await _giamGiaRepository.UpdateAsync(giamGia);
            if (updated == null) return NotFound();

            // ✅ Ghi thông báo
            await _thongBaoRepository.ThemThongBaoAsync($"✏️ Cập nhật đợt giảm giá: {giamGia.TenGiamGia}");

            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var giamGia = await _giamGiaRepository.GetByIdAsync(id);
            if (giamGia == null) return NotFound();

            var deleted = await _giamGiaRepository.DeleteAsync(id);
            if (!deleted) return BadRequest();

            // ✅ Ghi thông báo
            await _thongBaoRepository.ThemThongBaoAsync($"🗑️ Đã xoá đợt giảm giá: {giamGia.TenGiamGia}");

            return NoContent();
        }

        [HttpPost("{giamGiaId}/add-giay/{giayId}")]
        public async Task<IActionResult> AddGiayToDotGiamGia(Guid giamGiaId, Guid giayId)
        {
            var added = await _giamGiaRepository.AddGiayToDotGiamGia(giamGiaId, giayId);
            if (!added)
                return BadRequest("Không thể thêm giày vào đợt giảm giá (đã tồn tại hoặc không tìm thấy)");

            // ✅ Ghi thông báo
            await _thongBaoRepository.ThemThongBaoAsync($"➕ Thêm giày vào đợt giảm giá ID: {giamGiaId}");

            return Ok();
        }

        [HttpDelete("{giamGiaId}/remove-giay/{giayId}")]
        public async Task<IActionResult> RemoveGiayFromDotGiamGia(Guid giamGiaId, Guid giayId)
        {
            var removed = await _giamGiaRepository.RemoveGiayFromDotGiamGia(giamGiaId, giayId);
            if (!removed) return NotFound();

            // ✅ Ghi thông báo
            await _thongBaoRepository.ThemThongBaoAsync($"➖ Gỡ giày khỏi đợt giảm giá ID: {giamGiaId}");

            return Ok();
        }
    }
}
