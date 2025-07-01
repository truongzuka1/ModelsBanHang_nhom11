using API.Models.DTO;
using API.IRepository;
using Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnhApiController : ControllerBase
    {
        private readonly IAnhRepository _anhRepository;

        public AnhApiController(IAnhRepository anhRepository)
        {
            _anhRepository = anhRepository;
        }

        // GET: api/AnhApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnhDTO>>> GetAll()
        {
            var result = await _anhRepository.GetAllAsync();
            var dtoList = result.Select(anh => new AnhDTO
            {
                AnhId = anh.AnhId,
                GiayChiTietId = anh.GiayChiTietId,
                DuongDan = anh.DuongDan,
                TenAnh = anh.TenAnh,
                TrangThai = anh.TrangThai
            }).ToList();

            return Ok(dtoList);
        }

        // GET: api/AnhApi/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<AnhDTO>> GetById(Guid id)
        {
            var anh = await _anhRepository.GetByIdAsync(id);
            if (anh == null) return NotFound();

            var dto = new AnhDTO
            {
                AnhId = anh.AnhId,
                GiayChiTietId = anh.GiayChiTietId,
                DuongDan = anh.DuongDan,
                TenAnh = anh.TenAnh,
                TrangThai = anh.TrangThai
            };

            return Ok(dto);
        }

        // POST: api/AnhApi/upload
        [HttpPost("upload")]
        public async Task<ActionResult<AnhDTO>> Upload([FromForm] AnhUploadDTO dto)
        {
            if (dto.File == null || dto.File.Length == 0)
                return BadRequest("File ảnh không hợp lệ.");

            var uploadedAnh = await _anhRepository.UploadAsync(dto.File, dto.TenAnh);

            if (uploadedAnh == null) return BadRequest("Upload thất bại.");

            uploadedAnh.GiayChiTietId = dto.GiayChiTietId;
            await _anhRepository.UpdateAsync(uploadedAnh); // Cập nhật liên kết với GiayChiTiet

            var resultDto = new AnhDTO
            {
                AnhId = uploadedAnh.AnhId,
                GiayChiTietId = uploadedAnh.GiayChiTietId,
                DuongDan = uploadedAnh.DuongDan,
                TenAnh = uploadedAnh.TenAnh,
                TrangThai = uploadedAnh.TrangThai
            };

            return Ok(resultDto);
        }

        // PUT: api/AnhApi/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<AnhDTO>> Update(Guid id, [FromBody] AnhDTO dto)
        {
            if (id != dto.AnhId) return BadRequest("ID không khớp.");

            var model = new Anh
            {
                AnhId = dto.AnhId,
                GiayChiTietId = dto.GiayChiTietId,
                DuongDan = dto.DuongDan,
                TenAnh = dto.TenAnh,
                TrangThai = dto.TrangThai
            };

            var updated = await _anhRepository.UpdateAsync(model);
            if (updated == null) return NotFound();

            var resultDto = new AnhDTO
            {
                AnhId = updated.AnhId,
                GiayChiTietId = updated.GiayChiTietId,
                DuongDan = updated.DuongDan,
                TenAnh = updated.TenAnh,
                TrangThai = updated.TrangThai
            };

            return Ok(resultDto);
        }

        // PUT: api/AnhApi/update-file/{id}
        [HttpPut("update-file/{id}")]
        public async Task<ActionResult<AnhDTO>> UpdateFile(Guid id, [FromForm] AnhUploadDTO dto)
        {
            var updated = await _anhRepository.UpdateFileAsync(id, dto.File, dto.TenAnh);
            if (updated == null) return NotFound();

            updated.GiayChiTietId = dto.GiayChiTietId;
            await _anhRepository.UpdateAsync(updated); // Cập nhật liên kết nếu cần

            var resultDto = new AnhDTO
            {
                AnhId = updated.AnhId,
                GiayChiTietId = updated.GiayChiTietId,
                DuongDan = updated.DuongDan,
                TenAnh = updated.TenAnh,
                TrangThai = updated.TrangThai
            };

            return Ok(resultDto);
        }

        // DELETE: api/AnhApi/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _anhRepository.DeleteAsync(id);
            if (!result) return NotFound();
            return Ok(new { message = "Xóa ảnh thành công." });
        }
    }
}
