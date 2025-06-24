using API.Models.DTO;
using API.IRepository;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GiayController : ControllerBase
    {
        private readonly IGiayRepository _giayRepository;

        public GiayController(IGiayRepository giayRepository)
        {
            _giayRepository = giayRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var giays = await _giayRepository.GetAllAsync();
            return Ok(giays);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var giay = await _giayRepository.GetByIdAsync(id);
            if (giay == null)
                return NotFound();

            return Ok(giay);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] GiayDTO dto)
        {
            var giay = new Giay
            {
                GiayId = dto.GiayId,
                TenGiay = dto.TenGiay,
                TrangThai = dto.TrangThai
            };

            await _giayRepository.AddAsync(giay);
            return CreatedAtAction(nameof(GetById), new { id = giay.GiayId }, giay.GiayId);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] GiayDTO dto)
        {
            var existing = await _giayRepository.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            existing.TenGiay = dto.TenGiay;
            existing.TrangThai = dto.TrangThai;

            await _giayRepository.UpdateAsync(existing);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _giayRepository.DeleteAsync(id);
            return Ok();
        }
    }
}
