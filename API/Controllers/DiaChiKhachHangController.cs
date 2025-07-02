using API.Models.DTO;
using Data.IRepository;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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

        // GET: api/DiaChiKhachHang
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DiaChiKhachHangDTO>>> GetAll()
        {
            var ds = await _repository.GetAllAsync();
            var result = new List<DiaChiKhachHangDTO>();

            foreach (var item in ds)
            {
                result.Add(new DiaChiKhachHangDTO
                {
                    DiaChiKhachHangId = item.DiaChiKhachHangId,
                    TenDiaChi = item.TenDiaChi,
                    KhachHangId = item.khachHangId,
                    TrangThai = item.TrangThai
                });
            }

            return Ok(result);
        }

        // GET: api/DiaChiKhachHang/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<DiaChiKhachHangDTO>> GetById(Guid id)
        {
            var item = await _repository.GetByIdAsync(id);
            if (item == null) return NotFound();

            var dto = new DiaChiKhachHangDTO
            {
                DiaChiKhachHangId = item.DiaChiKhachHangId,
                TenDiaChi = item.TenDiaChi,
                KhachHangId = item.khachHangId,
                TrangThai = item.TrangThai
            };

            return Ok(dto);
        }

        // GET: api/DiaChiKhachHang/khachhang/{khachHangId}
        [HttpGet("khachhang/{khachHangId}")]
        public async Task<ActionResult<IEnumerable<DiaChiKhachHangDTO>>> GetByKhachHangId(Guid khachHangId)
        {
            var list = await _repository.GetByKhachHangIdAsync(khachHangId);
            var result = new List<DiaChiKhachHangDTO>();

            foreach (var item in list)
            {
                result.Add(new DiaChiKhachHangDTO
                {
                    DiaChiKhachHangId = item.DiaChiKhachHangId,
                    TenDiaChi = item.TenDiaChi,
                    KhachHangId = item.khachHangId,
                    TrangThai = item.TrangThai
                });
            }

            return Ok(result);
        }

        // POST: api/DiaChiKhachHang
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] DiaChiKhachHangDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var entity = new DiaChiKhachHang
            {
                DiaChiKhachHangId = Guid.NewGuid(),
                TenDiaChi = dto.TenDiaChi,
                khachHangId = dto.KhachHangId,
                TrangThai = dto.TrangThai
            };

            var result = await _repository.CreateAsync(entity);
            if (!result) return StatusCode(500, "Không thể tạo địa chỉ");

            return Ok(new { message = "Tạo địa chỉ thành công", id = entity.DiaChiKhachHangId });
        }

        // PUT: api/DiaChiKhachHang/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, [FromBody] DiaChiKhachHangDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) return NotFound();

            existing.TenDiaChi = dto.TenDiaChi;
            existing.khachHangId = dto.KhachHangId;
            existing.TrangThai = dto.TrangThai;

            var result = await _repository.UpdateAsync(existing);
            if (!result) return StatusCode(500, "Không thể cập nhật địa chỉ");

            return Ok(new { message = "Cập nhật thành công" });
        }

        // DELETE: api/DiaChiKhachHang/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var result = await _repository.DeleteAsync(id);
            if (!result) return NotFound(new { message = "Địa chỉ không tồn tại hoặc đã bị xoá" });

            return Ok(new { message = "Xoá địa chỉ thành công" });
        }
    }
}
