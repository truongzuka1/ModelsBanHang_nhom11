using API.IRepository;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GioHangChiTietController : ControllerBase
    {
        private readonly IGioHangChiTietRepository _repository;

        public GioHangChiTietController(IGioHangChiTietRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _repository.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var item = await _repository.GetByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost("AddToCart")]
        public async Task<IActionResult> AddToCart([FromBody] GioHangChiTiet model)
        {
            if (model.SoLuongSanPham <= 0)
                return BadRequest("Số lượng sản phẩm phải lớn hơn 0");

            var existingItem = await _repository.GetByGioHangVaGiayChiTietAsync(model.GioHangId, model.GiayId);
            if (existingItem != null)
            {
                existingItem.SoLuongSanPham += model.SoLuongSanPham;
                existingItem.NgayCapNhat = DateTime.Now;
                await _repository.UpdateAsync(existingItem);
                return Ok(existingItem);
            }
            else
            {
                model.GioHangChiTietId = Guid.NewGuid();
                model.NgayTao = DateTime.Now;
                model.NgayCapNhat = DateTime.Now;
                model.TrangThai = true;
                await _repository.AddAsync(model);
                return CreatedAtAction(nameof(GetById), new { id = model.GioHangChiTietId }, model);
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] GioHangChiTiet model)
        {
            if (id != model.GioHangChiTietId) return BadRequest();
            await _repository.UpdateAsync(model);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}
