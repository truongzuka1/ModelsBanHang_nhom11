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

        public GiamGiaController(IGiamGiaRepository giamGiaRepository)
        {
            _giamGiaRepository = giamGiaRepository;
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
            // ✅ Thêm validate rõ ràng phía server
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var created = await _giamGiaRepository.AddAsync(giamGia);
            return CreatedAtAction(nameof(GetById), new { id = created.GiamGiaId }, created);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<GiamGia>> Update(Guid id, [FromBody] GiamGia giamGia)
        {
            if (id != giamGia.GiamGiaId)
                return BadRequest("Id mismatch");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updated = await _giamGiaRepository.UpdateAsync(giamGia);
            if (updated == null) return NotFound();

            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleted = await _giamGiaRepository.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }

        [HttpPost("{giamGiaId}/add-giay/{giayId}")]
        public async Task<IActionResult> AddGiayToDotGiamGia(Guid giamGiaId, Guid giayId)
        {
            var added = await _giamGiaRepository.AddGiayToDotGiamGia(giamGiaId, giayId);
            if (!added)
                return BadRequest("Không thể thêm giày vào đợt giảm giá (đã tồn tại hoặc không tìm thấy)");

            return Ok();
        }

        [HttpDelete("{giamGiaId}/remove-giay/{giayId}")]
        public async Task<IActionResult> RemoveGiayFromDotGiamGia(Guid giamGiaId, Guid giayId)
        {
            var removed = await _giamGiaRepository.RemoveGiayFromDotGiamGia(giamGiaId, giayId);
            if (!removed) return NotFound();
            return Ok();
        }
    }

}