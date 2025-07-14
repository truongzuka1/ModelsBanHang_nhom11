using API.IRepository;
using API.Models.DTO;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                size = entity.KichCo?.size ?? 0,
                Gia = entity.Gia,
                SoLuongCon = entity.SoLuongCon,
                SoLuongDat = 1, // Giá trị mặc định vì GiayChiTiet không có SoLuongDat
                MoTa = entity.MoTa,
                TrangThai = entity.TrangThai,
                AnhGiay = entity.Anhs.FirstOrDefault()?.DuongDan,
                NgayTao = entity.NgayTao,
                NgaySua = entity.NgaySua
            };
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GiayChiTietDTO>>> GetAll()
        {
            try
            {
                var entities = await _repo.GetAllAsync();
                var dtos = entities.Select(MapToDTO);
                return Ok(dtos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Lỗi khi lấy dữ liệu: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var entity = await _repo.GetByIdAsync(id);
            if (entity == null) return NotFound();
            return Ok(MapToDTO(entity));
        }

        [HttpGet("giay/{giayId}")]
        public async Task<IActionResult> GetByGiayId(Guid giayId)
        {
            var entities = await _repo.GetByGiayIdAsync(giayId);
            return Ok(entities.Select(MapToDTO));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] GiayChiTietDTO dto)
        {
            if (dto.GiayId == Guid.Empty)
            {
                return BadRequest("GiayId là bắt buộc.");
            }

            var entity = new GiayChiTiet
            {
                GiayId = dto.GiayId,
                KichCoId = dto.KichCoId,
                MauSacId = dto.MauSacId,
                Gia = dto.Gia,
                SoLuongCon = dto.SoLuongCon,
                MoTa = dto.MoTa,
                TrangThai = dto.TrangThai,
                NgayTao = DateTime.UtcNow,
                NgaySua = DateTime.UtcNow
            };

            var createdEntity = await _repo.AddAsync(entity);
            return CreatedAtAction(nameof(GetById), new { id = createdEntity.GiayChiTietId }, MapToDTO(createdEntity));
        }

        [HttpPost("multiple")]
        public async Task<IActionResult> CreateMultiple([FromBody] List<GiayChiTietDTO> dtos)
        {
            if (dtos == null || !dtos.Any())
            {
                return BadRequest("Danh sách DTO không được rỗng.");
            }

            var entities = dtos.Select(dto => new GiayChiTiet
            {
                GiayId = dto.GiayId,
                KichCoId = dto.KichCoId,
                MauSacId = dto.MauSacId,
                Gia = dto.Gia,
                SoLuongCon = dto.SoLuongCon,
                MoTa = dto.MoTa,
                TrangThai = dto.TrangThai,
                NgayTao = DateTime.UtcNow,
                NgaySua = DateTime.UtcNow
            }).ToList();

            var createdEntities = await _repo.AddMultipleReturnAsync(entities);
            return Ok(createdEntities.Select(MapToDTO));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] GiayChiTietDTO dto)
        {
            var existingEntity = await _repo.GetByIdAsync(id);
            if (existingEntity == null) return NotFound();

            existingEntity.KichCoId = dto.KichCoId;
            existingEntity.MauSacId = dto.MauSacId;
            existingEntity.Gia = dto.Gia;
            existingEntity.SoLuongCon = dto.SoLuongCon;
            existingEntity.MoTa = dto.MoTa;
            existingEntity.TrangThai = dto.TrangThai;
            existingEntity.NgaySua = DateTime.UtcNow;

            var updatedEntity = await _repo.UpdateAsync(existingEntity);
            return Ok(MapToDTO(updatedEntity));
        }
    }
}