using Data.Models;
using Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhachHangController : ControllerBase
    {
        private readonly IKhachHangRepository _khachHangRepository;

        public KhachHangController(IKhachHangRepository khachHangRepository)
        {
            _khachHangRepository = khachHangRepository;
        }

        // GET: api/KhachHang
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var khachHangs = await _khachHangRepository.GetAllAsync();
            return Ok(khachHangs);
        }

        // GET: api/KhachHang/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var kh = await _khachHangRepository.GetByIdAsync(id);
            if (kh == null) return NotFound();
            return Ok(kh);
        }

        // POST: api/KhachHang
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] KhachHang khachHang)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _khachHangRepository.AddAsync(khachHang);
            return CreatedAtAction(nameof(GetById), new { id = khachHang.KhachHangId }, khachHang);
        }

        // PUT: api/KhachHang/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] KhachHang khachHang)
        {
            if (id != khachHang.KhachHangId) return BadRequest("ID không khớp");
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var exists = await _khachHangRepository.ExistsAsync(id);
            if (!exists) return NotFound();

            await _khachHangRepository.UpdateAsync(khachHang);
            return NoContent();
        }

        // DELETE: api/KhachHang/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var exists = await _khachHangRepository.ExistsAsync(id);
            if (!exists) return NotFound();

            await _khachHangRepository.DeleteAsync(id);
            return NoContent();
        }

        // GET: api/KhachHang/email/{email}
        [HttpGet("email/{email}")]
        public async Task<IActionResult> GetByEmail(string email)
        {
            var kh = await _khachHangRepository.GetByEmailAsync(email);
            if (kh == null) return NotFound();
            return Ok(kh);
        }

        // GET: api/KhachHang/phone/{soDienThoai}
        [HttpGet("phone/{soDienThoai}")]
        public async Task<IActionResult> GetBySoDienThoai(string soDienThoai)
        {
            var kh = await _khachHangRepository.GetBySoDienThoaiAsync(soDienThoai);
            if (kh == null) return NotFound();
            return Ok(kh);
        }
    }
}
