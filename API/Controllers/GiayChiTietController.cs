using API.IRepository;
using API.Models.DTO;
using Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GiayChiTietController : ControllerBase
    {
        private readonly IGiayChiTietRepository _repo;

        public GiayChiTietController(IGiayChiTietRepository repo)
        {
            _repo = repo;
        }

        // ⚡ Mapping entity → DTO
        private GiayChiTietDTO MapToDTO(GiayChiTiet entity)
        {
            return new GiayChiTietDTO
            {
                GiayChiTietId = entity.GiayChiTietId,
                GiayId = entity.GiayId,
                KichCoId = entity.KichCoId,
                MauSacId = entity.MauSacId,
                TenGiay = entity.Giay?.TenGiay,
                TenMau = entity.MauSac?.TenMau,
                size = entity.KichCo?.size.ToString(),
                Gia = entity.Gia,
                SoLuongCon = entity.SoLuongCon,
                MoTa = entity.MoTa,
                TrangThai = entity.TrangThai,
                AnhGiay = entity.AnhGiay,
                NgayTao = entity.NgayTao,
                NgaySua = entity.NgaySua
            };
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _repo.GetAllAsync();
            return Ok(items.Select(MapToDTO));
        }
      

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var item = await _repo.GetByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(MapToDTO(item));
        }

        [HttpGet("giay/{giayId}")]
        public async Task<IActionResult> GetByGiayId(Guid giayId)
        {
            var items = await _repo.GetByGiayIdAsync(giayId);
            return Ok(items.Select(MapToDTO));
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] GiayChiTietDTO dto)
        {
            var entity = new GiayChiTiet
            {
                GiayId = dto.GiayId,
                KichCoId = dto.KichCoId,
                MauSacId = dto.MauSacId,
                Gia = dto.Gia,
                SoLuongCon = dto.SoLuongCon,
                MoTa = dto.MoTa,
                TrangThai = dto.TrangThai,
                AnhGiay = dto.AnhGiay,
                NgayTao = DateTime.Now,
                NgaySua = DateTime.Now
            };

            var created = await _repo.AddAsync(entity);
            return CreatedAtAction(nameof(GetById), new { id = created.GiayChiTietId }, MapToDTO(created));
        }

        [HttpPost("multiple")]
        public async Task<IActionResult> AddMultiple([FromBody] List<GiayChiTietDTO> listDto)
        {
            try
            {
                var entities = listDto.Select(dto => new GiayChiTiet
                {
                    GiayId = dto.GiayId,
                    KichCoId = dto.KichCoId,
                    MauSacId = dto.MauSacId,
                    Gia = dto.Gia,
                    SoLuongCon = dto.SoLuongCon,
                    MoTa = dto.MoTa,
                    TrangThai = dto.TrangThai,
                    AnhGiay = dto.AnhGiay,
                    NgayTao = DateTime.Now,
                    NgaySua = DateTime.Now
                }).ToList();

                var result = await _repo.AddMultipleAsync(entities);
                if (result) return Ok();
                return StatusCode(500, "Không thêm được danh sách");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Lỗi hệ thống: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await _repo.DeleteAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
