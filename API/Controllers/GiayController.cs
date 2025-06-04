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
        public async Task<IActionResult> Create(Giay giay)
        {
            giay.GiayId = Guid.NewGuid();
            await _giayRepository.AddAsync(giay);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, Giay giay)
        {
            var existing = await _giayRepository.GetByIdAsync(id);
            if (existing == null) return NotFound();

            existing.TenGiay = giay.TenGiay;
            existing.TrangThai = giay.TrangThai;
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
