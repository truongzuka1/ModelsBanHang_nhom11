using API.Models.DTO;
using Application.DTOs;
using Data.IRepository;
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
    public class DiaChiKhachHangController : ControllerBase
    {
        private readonly IDiaChiKhachHangRepository _repository;

        public DiaChiKhachHangController(IDiaChiKhachHangRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DiaChiKhachHangDto>>> GetAll()
        {
            var ds = await _repository.GetAllAsync();
            return Ok(ds.Select(MapToDto));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DiaChiKhachHangDto>> GetById(Guid id)
        {
            var item = await _repository.GetByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(MapToDto(item));
        }

        [HttpGet("khachhang/{khachHangId}")]
        public async Task<ActionResult<IEnumerable<DiaChiKhachHangDto>>> GetByKhachHangId(Guid khachHangId)
        {
            var list = await _repository.GetByKhachHangIdAsync(khachHangId);
            return Ok(list.Select(MapToDto));
        }

        [HttpGet("default/{khachHangId}")]
        public async Task<ActionResult<DiaChiKhachHangDto>> GetDefault(Guid khachHangId)
        {
            var item = await _repository.GetDefaultByKhachHangIdAsync(khachHangId);
            if (item == null) return NotFound();
            return Ok(MapToDto(item));
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] DiaChiKhachHangDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var entity = MapToEntity(dto);
            var result = await _repository.CreateAsync(entity);
            if (!result) return StatusCode(500, "Không thể tạo địa chỉ");

            return Ok(new { message = "Tạo địa chỉ thành công", id = entity.DiaChiKhachHangId });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, [FromBody] DiaChiKhachHangDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) return NotFound();

            existing.SoNha = dto.SoNha;
            existing.Duong = dto.Duong;
            existing.PhuongXa = dto.PhuongXa;
            existing.QuanHuyen = dto.QuanHuyen;
            existing.ThanhPho = dto.ThanhPho;
            existing.KhachHangId = dto.KhachHangId;
            existing.TrangThai = dto.TrangThai;
            existing.IsDefault = dto.IsDefault;

            var result = await _repository.UpdateAsync(existing);
            if (!result) return StatusCode(500, "Không thể cập nhật địa chỉ");

            return Ok(new { message = "Cập nhật địa chỉ thành công" });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var result = await _repository.DeleteAsync(id);
            if (!result) return NotFound(new { message = "Địa chỉ không tồn tại hoặc đã bị xoá" });

            return Ok(new { message = "Xoá địa chỉ thành công" });
        }

        [HttpPut("set-default/{id}")]
        public async Task<ActionResult> SetDefault(Guid id)
        {
            var result = await _repository.SetDefaultAsync(id);
            if (!result) return NotFound(new { message = "Không thể đặt làm mặc định" });

            return Ok(new { message = "Đã đặt làm địa chỉ mặc định" });
        }

        private DiaChiKhachHangDto MapToDto(DiaChiKhachHang d) => new DiaChiKhachHangDto
        {
            DiaChiKhachHangId = d.DiaChiKhachHangId,
            SoNha = d.SoNha,
            Duong = d.Duong,
            PhuongXa = d.PhuongXa,
            QuanHuyen = d.QuanHuyen,
            ThanhPho = d.ThanhPho,
            KhachHangId = d.KhachHangId,
            TrangThai = d.TrangThai,
            IsDefault = d.IsDefault
        };

        private DiaChiKhachHang MapToEntity(DiaChiKhachHangDto dto) => new DiaChiKhachHang
        {
            DiaChiKhachHangId = dto.DiaChiKhachHangId,
            SoNha = dto.SoNha,
            Duong = dto.Duong,
            PhuongXa = dto.PhuongXa,
            QuanHuyen = dto.QuanHuyen,
            ThanhPho = dto.ThanhPho,
            KhachHangId = dto.KhachHangId,
            TrangThai = dto.TrangThai,
            IsDefault = dto.IsDefault
        };
    }
}
