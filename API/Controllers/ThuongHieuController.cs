using API.IRepository;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ThuongHieuController : ControllerBase
    {
        private readonly IThuongHieuRepository _thuongHieuRepository;

        public ThuongHieuController(IThuongHieuRepository thuongHieuRepository)
        {
            _thuongHieuRepository = thuongHieuRepository;
        }

        // GET: api/ThuongHieu
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await _thuongHieuRepository.GetAllAsync();
            return Ok(list);
        }

        // GET: api/ThuongHieu/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var entity = await _thuongHieuRepository.GetByIdAsync(id);
            if (entity == null) return NotFound();
            return Ok(entity);
        }

        // POST: api/ThuongHieu
        [HttpPost]
        public async Task<IActionResult> Create(ThuongHieu thuongHieu)
        {
            thuongHieu.ThuongHieuId = Guid.NewGuid();
            await _thuongHieuRepository.AddAsync(thuongHieu);
            return Ok();
        }

        // PUT: api/ThuongHieu/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, ThuongHieu thuongHieu)
        {
            var existing = await _thuongHieuRepository.GetByIdAsync(id);
            if (existing == null) return NotFound();

            existing.TenThuongHieu = thuongHieu.TenThuongHieu;
            existing.Email = thuongHieu.Email;
            existing.SDT = thuongHieu.SDT;
            existing.DiaChi = thuongHieu.DiaChi;
            existing.MoTa = thuongHieu.MoTa;
            existing.TrangThai = thuongHieu.TrangThai;

            await _thuongHieuRepository.UpdateAsync(existing);
            return Ok();
        }

        // DELETE: api/ThuongHieu/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _thuongHieuRepository.DeleteAsync(id);
            return Ok();
        }
    }
}
