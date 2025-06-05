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

        // GET: api/giamgia
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GiamGia>>> GetAll()
        {
            var result = await _giamGiaRepository.GetAllAsync();
            return Ok(result);
        }

        // GET: api/giamgia/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<GiamGia>> GetById(Guid id)
        {
            var result = await _giamGiaRepository.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        // POST: api/giamgia
        [HttpPost]
        public async Task<ActionResult<GiamGia>> Create(GiamGia giamGia)
        {
            var created = await _giamGiaRepository.AddAsync(giamGia);
            return CreatedAtAction(nameof(GetById), new { id = created.GiamGiaId }, created);
        }

        // PUT: api/giamgia/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<GiamGia>> Update(Guid id, GiamGia giamGia)
        {
            if (id != giamGia.GiamGiaId)
                return BadRequest("Id mismatch");

            var updated = await _giamGiaRepository.UpdateAsync(giamGia);
            if (updated == null) return NotFound();

            return Ok(updated);
        }

        // DELETE: api/giamgia/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleted = await _giamGiaRepository.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }

        // POST: api/giamgia/{giamGiaId}/add-giay/{giayId}
        [HttpPost("{giamGiaId}/add-giay/{giayId}")]
        public async Task<IActionResult> AddGiayToDotGiamGia(Guid giamGiaId, Guid giayId)
        {
            var added = await _giamGiaRepository.AddGiayToDotGiamGia(giamGiaId, giayId);
            if (!added) return BadRequest("Unable to add giay to dot giam gia (maybe already added or not found)");
            return Ok();
        }

        // DELETE: api/giamgia/{giamGiaId}/remove-giay/{giayId}
        [HttpDelete("{giamGiaId}/remove-giay/{giayId}")]
        public async Task<IActionResult> RemoveGiayFromDotGiamGia(Guid giamGiaId, Guid giayId)
        {
            var removed = await _giamGiaRepository.RemoveGiayFromDotGiamGia(giamGiaId, giayId);
            if (!removed) return NotFound();
            return Ok();
        }
    }
}