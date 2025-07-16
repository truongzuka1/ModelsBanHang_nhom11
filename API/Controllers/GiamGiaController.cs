using API.IRepository;
using API.Models.DTO;
using Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GiamGiaController : ControllerBase
    {
        private readonly IGiamGiaRepository _giamGiaRepository;
        private readonly IThongBaoRepository _thongBaoRepository;

        public GiamGiaController(IGiamGiaRepository giamGiaRepository, IThongBaoRepository thongBaoRepository)
        {
            _giamGiaRepository = giamGiaRepository;
            _thongBaoRepository = thongBaoRepository;
        }

        // GET: api/GiamGia
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GiamGia>>> GetAll()
        {
            var result = await _giamGiaRepository.GetAllAsync();
            return Ok(result);
        }

        // GET: api/GiamGia/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<GiamGia>> GetById(Guid id)
        {
            var result = await _giamGiaRepository.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        // POST: api/GiamGia
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] GiamGiaCreateDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var giamGia = new GiamGia
            {
                GiamGiaId = dto.GiamGiaId,
                TenGiamGia = dto.TenGiamGia,
                SanPhamKhuyenMai = dto.SanPhamKhuyenMai,
                PhanTramKhuyenMai = dto.PhanTramKhuyenMai,
                NgayBatDau = dto.NgayBatDau,
                NgayKetThuc = dto.NgayKetThuc,
                TrangThai = dto.TrangThai,
                GiayDotGiamGias = dto.GiayIds.Select(id => new GiayDotGiamGia
                {
                    GiayDotGiamGiaId = Guid.NewGuid(),
                    GiayId = id,
                    GiamGiaId = dto.GiamGiaId
                }).ToList()
            };

            var created = await _giamGiaRepository.AddAsync(giamGia);

            await _thongBaoRepository.ThemThongBaoAsync($"🎯 Thêm đợt giảm giá: {giamGia.TenGiamGia}");

            return CreatedAtAction(nameof(GetById), new { id = created.GiamGiaId }, created);
        }

        // PUT: api/GiamGia/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<GiamGia>> Update(Guid id, [FromBody] GiamGia giamGia)
        {
            if (id != giamGia.GiamGiaId)
                return BadRequest("Id mismatch");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await _giamGiaRepository.UpdateAsync(giamGia);
            if (updated == null) return NotFound();

            await _thongBaoRepository.ThemThongBaoAsync($"✏️ Cập nhật đợt giảm giá: {giamGia.TenGiamGia}");

            return Ok(updated);
        }

        // DELETE: api/GiamGia/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var giamGia = await _giamGiaRepository.GetByIdAsync(id);
            if (giamGia == null) return NotFound();

            var deleted = await _giamGiaRepository.DeleteAsync(id);
            if (!deleted) return BadRequest();

            await _thongBaoRepository.ThemThongBaoAsync($"🗑️ Đã xoá đợt giảm giá: {giamGia.TenGiamGia}");

            return NoContent();
        }

        // POST: api/GiamGia/{giamGiaId}/add-giay/{giayId}
        [HttpPost("{giamGiaId}/add-giay/{giayId}")]
        public async Task<IActionResult> AddGiayToDotGiamGia(Guid giamGiaId, Guid giayId)
        {
            var added = await _giamGiaRepository.AddGiayToDotGiamGia(giamGiaId, giayId);
            if (!added)
                return BadRequest("Không thể thêm giày vào đợt giảm giá (đã tồn tại hoặc không tìm thấy)");

            await _thongBaoRepository.ThemThongBaoAsync($"➕ Thêm giày vào đợt giảm giá ID: {giamGiaId}");

            return Ok();
        }

        // DELETE: api/GiamGia/{giamGiaId}/remove-giay/{giayId}
        [HttpDelete("{giamGiaId}/remove-giay/{giayId}")]
        public async Task<IActionResult> RemoveGiayFromDotGiamGia(Guid giamGiaId, Guid giayId)
        {
            var removed = await _giamGiaRepository.RemoveGiayFromDotGiamGia(giamGiaId, giayId);
            if (!removed) return NotFound();

            await _thongBaoRepository.ThemThongBaoAsync($"➖ Gỡ giày khỏi đợt giảm giá ID: {giamGiaId}");

            return Ok();
        }
    }
}
