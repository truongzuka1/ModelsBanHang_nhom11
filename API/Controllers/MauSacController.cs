using API.IRepository;
using API.Models.DTO;
using Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MauSacController : ControllerBase
    {
        private readonly IMauSacRepository _mauSacRepository;

        public MauSacController(IMauSacRepository mauSacRepository)
        {
            _mauSacRepository = mauSacRepository;
        }

        // GET: api/MauSac
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MauSacDTO>>> GetAll()
        {
            var list = await _mauSacRepository.GetAllAsync();
            var dtos = list.Select(x => new MauSacDTO
            {
                MauSacId = x.MauSacId,
                TenMau = x.TenMau,
                MoTa = x.MoTa,
                TrangThai = x.TrangThai
            });

            return Ok(dtos);
        }

        // GET: api/MauSac/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<MauSacDTO>> GetById(Guid id)
        {
            var item = await _mauSacRepository.GetByIdAsync(id);
            if (item == null) return NotFound();

            var dto = new MauSacDTO
            {
                MauSacId = item.MauSacId,
                TenMau = item.TenMau,
                MoTa = item.MoTa,
                TrangThai = item.TrangThai
            };

            return Ok(dto);
        }

        // POST: api/MauSac
        [HttpPost]
        public async Task<ActionResult> Create(MauSacDTO dto)
        {
            var mauSac = new MauSac
            {
                TenMau = dto.TenMau,
                MoTa = dto.MoTa,
                TrangThai = dto.TrangThai
            };

            await _mauSacRepository.AddAsync(mauSac);
            return Ok();
        }

        // PUT: api/MauSac
        [HttpPut]
        public async Task<ActionResult> Update(MauSacDTO dto)
        {
            var mauSac = new MauSac
            {
                MauSacId = dto.MauSacId,
                TenMau = dto.TenMau,
                MoTa = dto.MoTa,
                TrangThai = dto.TrangThai
            };

            var result = await _mauSacRepository.UpdateAsync(mauSac);
            if (result == null) return NotFound();

            return Ok();
        }

        // DELETE: api/MauSac/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var result = await _mauSacRepository.DeleteAsync(id);
            if (!result) return NotFound();

            return Ok();
        }

        // POST: api/MauSac/{giayChiTietId}/add-mausac/{mauSacId}
        [HttpPost("{giayChiTietId}/add-mausac/{mauSacId}")]
        public async Task<ActionResult> AddMauSacToGiayChiTiet(Guid giayChiTietId, Guid mauSacId)
        {
            var result = await _mauSacRepository.AddMauSacToGiayChiTiet(giayChiTietId, mauSacId);
            if (!result) return BadRequest("Không thể thêm màu sắc vào giày chi tiết.");
            return Ok();
        }

        // DELETE: api/MauSac/{giayChiTietId}/remove-mausac/{mauSacId}
        [HttpDelete("{giayChiTietId}/remove-mausac/{mauSacId}")]
        public async Task<ActionResult> RemoveMauSacFromGiayChiTiet(Guid giayChiTietId, Guid mauSacId)
        {
            var result = await _mauSacRepository.RemoveMauSacFromGiayChiTiet(giayChiTietId, mauSacId);
            if (!result) return BadRequest("Không thể xoá màu sắc khỏi giày chi tiết.");
            return Ok();
        }

        // GET: api/MauSac/giaychitiet/{giayChiTietId}
        [HttpGet("giaychitiet/{giayChiTietId}")]
        public async Task<ActionResult<IEnumerable<MauSacDTO>>> GetMauSacsByGiayChiTietId(Guid giayChiTietId)
        {
            var list = await _mauSacRepository.GetMauSacsByGiayIdAsync(giayChiTietId);
            var dtos = list.Select(x => new MauSacDTO
            {
                MauSacId = x.MauSacId,
                TenMau = x.TenMau,
                MoTa = x.MoTa,
                TrangThai = x.TrangThai
            });

            return Ok(dtos);
        }
    }
}
