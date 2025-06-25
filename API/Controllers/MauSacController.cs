using API.IRepository;
using API.Models.DTO;
using Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MauSacController : ControllerBase
    {
        private readonly IMauSacRepository _mauSacRepo;

        public MauSacController(IMauSacRepository mauSacRepo)
        {
            _mauSacRepo = mauSacRepo;
        }

        private MauSacDTO MapToDTO(MauSac ms) => new MauSacDTO
        {
            MauSacId = ms.MauSacId,
            TenMau = ms.TenMau,
            MoTa = ms.MoTa,
            TrangThai = ms.TrangThai
        };

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mauSacRepo.GetAllAsync();
            return Ok(result.Select(MapToDTO));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var ms = await _mauSacRepo.GetByIdAsync(id);
            if (ms == null) return NotFound();
            return Ok(MapToDTO(ms));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MauSacDTO dto)
        {
            var entity = new MauSac
            {
                TenMau = dto.TenMau,
                MoTa = dto.MoTa,
                TrangThai = dto.TrangThai
            };

            var created = await _mauSacRepo.AddAsync(entity);
            return CreatedAtAction(nameof(GetById), new { id = created.MauSacId }, MapToDTO(created));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] MauSacDTO dto)
        {
            var entity = new MauSac
            {
                MauSacId = id,
                TenMau = dto.TenMau,
                MoTa = dto.MoTa,
                TrangThai = dto.TrangThai
            };

            var updated = await _mauSacRepo.UpdateAsync(entity);
            if (updated == null) return NotFound();
            return Ok(MapToDTO(updated));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _mauSacRepo.DeleteAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchByTen([FromQuery] string keyword)
        {
            var result = await _mauSacRepo.SearchByTenAsync(keyword);
            return Ok(result.Select(MapToDTO));
        }
    }
}
