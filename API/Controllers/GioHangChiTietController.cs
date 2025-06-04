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

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] GioHangChiTiet model)
        {
            await _repository.AddAsync(model);
            return CreatedAtAction(nameof(GetById), new { id = model.GioHangChiTietId }, model);
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
