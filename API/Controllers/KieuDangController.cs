using API.IRepository;
using API.Models.DTO;
using Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KieuDangController : ControllerBase
    {
        private readonly IKieuDangRepository _repo;

        public KieuDangController(IKieuDangRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await _repo.GetAllAsync();
            return Ok(list.Select(k => new KieuDangDTO
            {
                KieuDangId = k.KieuDangId,
                TenKieuDang = k.TenKieuDang,
                MoTa = k.MoTa,
                TrangThai = k.TrangThai
            }));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var k = await _repo.GetByIdAsync(id);
            if (k == null) return NotFound();

            return Ok(new KieuDangDTO
            {
                KieuDangId = k.KieuDangId,
                TenKieuDang = k.TenKieuDang,
                MoTa = k.MoTa,
                TrangThai = k.TrangThai
            });
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search(string keyword)
        {
            var result = await _repo.SearchByNameAsync(keyword);
            return Ok(result.Select(k => new KieuDangDTO
            {
                KieuDangId = k.KieuDangId,
                TenKieuDang = k.TenKieuDang,
                MoTa = k.MoTa,
                TrangThai = k.TrangThai
            }));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] KieuDangDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var kieuDang = new KieuDang
            {
                KieuDangId = Guid.NewGuid(),
                TenKieuDang = dto.TenKieuDang,
                MoTa = dto.MoTa,
                TrangThai = dto.TrangThai
            };

            var created = await _repo.AddAsync(kieuDang);
            return Ok(created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] KieuDangDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var kieuDang = new KieuDang
            {
                KieuDangId = id,
                TenKieuDang = dto.TenKieuDang,
                MoTa = dto.MoTa,
                TrangThai = dto.TrangThai
            };

            var updated = await _repo.UpdateAsync(kieuDang);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _repo.DeleteAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}
