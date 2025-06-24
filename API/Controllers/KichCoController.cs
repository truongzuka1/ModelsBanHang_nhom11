using API.IRepository;
using API.Models.DTO;
using Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KichCoController : ControllerBase
    {
        private readonly IKichCoRepository _kichCoRepository;

        public KichCoController(IKichCoRepository kichCoRepository)
        {
            _kichCoRepository = kichCoRepository;
        }

        // GET: api/KichCo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KichCoDTO>>> GetAll()
        {
            var list = await _kichCoRepository.GetAllAsync();
            var dtos = list.Select(x => new KichCoDTO
            {
                KichCoId = x.KichCoId,
                TenKichCo = x.TenKichCo,
                MoTa = x.MoTa,
                TrangThai = x.TrangThai
            });

            return Ok(dtos);
        }

        // GET: api/KichCo/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<KichCoDTO>> GetById(Guid id)
        {
            var item = await _kichCoRepository.GetByIdAsync(id);
            if (item == null) return NotFound();

            var dto = new KichCoDTO
            {
                KichCoId = item.KichCoId,
                TenKichCo = item.TenKichCo,
                MoTa = item.MoTa,
                TrangThai = item.TrangThai
            };

            return Ok(dto);
        }

        // POST: api/KichCo
        [HttpPost]
        public async Task<ActionResult> Create(KichCoDTO dto)
        {
            var kichCo = new KichCo
            {
                TenKichCo = dto.TenKichCo,
                MoTa = dto.MoTa,
                TrangThai = dto.TrangThai
            };

            await _kichCoRepository.AddAsync(kichCo);
            return Ok();
        }

        // PUT: api/KichCo
        [HttpPut]
        public async Task<ActionResult> Update(KichCoDTO dto)
        {
            var kichCo = new KichCo
            {
                KichCoId = dto.KichCoId,
                TenKichCo = dto.TenKichCo,
                MoTa = dto.MoTa,
                TrangThai = dto.TrangThai
            };

            var result = await _kichCoRepository.UpdateAsync(kichCo);
            if (result == null) return NotFound();

            return Ok();
        }

        // DELETE: api/KichCo/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var result = await _kichCoRepository.DeleteAsync(id);
            if (!result) return NotFound();

            return Ok();
        }

        // POST: api/KichCo/{giayChiTietId}/add-kichco/{kichCoId}
        [HttpPost("{giayChiTietId}/add-kichco/{kichCoId}")]
        public async Task<ActionResult> AddKichCoToGiayChiTiet(Guid giayChiTietId, Guid kichCoId)
        {
            var result = await _kichCoRepository.AddKichCoToGiayChiTiet(giayChiTietId, kichCoId);
            if (!result) return BadRequest("Không thể thêm kích cỡ vào giày chi tiết.");
            return Ok();
        }

        // DELETE: api/KichCo/{giayChiTietId}/remove-kichco/{kichCoId}
        [HttpDelete("{giayChiTietId}/remove-kichco/{kichCoId}")]
        public async Task<ActionResult> RemoveKichCoFromGiayChiTiet(Guid giayChiTietId, Guid kichCoId)
        {
            var result = await _kichCoRepository.RemoveKichCoFromGiayChiTiet(giayChiTietId, kichCoId);
            if (!result) return BadRequest("Không thể xoá kích cỡ khỏi giày chi tiết.");
            return Ok();
        }

        // GET: api/KichCo/giaychitiet/{giayChiTietId}
        [HttpGet("giaychitiet/{giayChiTietId}")]
        public async Task<ActionResult<IEnumerable<KichCoDTO>>> GetKichCosByGiayChiTietId(Guid giayChiTietId)
        {
            var list = await _kichCoRepository.GetKichCosByGiayIdAsync(giayChiTietId);
            var dtos = list.Select(x => new KichCoDTO
            {
                KichCoId = x.KichCoId,
                TenKichCo = x.TenKichCo,
                MoTa = x.MoTa,
                TrangThai = x.TrangThai
            });

            return Ok(dtos);
        }
    }
}
