using API.IRepository;
using API.Models;
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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Anh>>> GetAll()
        {
            var result = await _anhRepository.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Anh>> GetById(Guid id)
        {
            var result = await _anhRepository.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }
    }
}