using API.IRepository;
using Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeGiaysController : Controller
    {


        private readonly IDeGiayRepository _degiay;

        public DeGiaysController(IDeGiayRepository degiay)
        {
            _degiay = degiay;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeGiay>>> GetDeGiayAll()
        {
            return Ok(await _degiay.GetAllDegiay());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DeGiay>> GetDeGiayById(Guid id)
        {
            return Ok(await _degiay.GetDeGiay(id));
        }

        [HttpPost]
        public async Task<ActionResult<DeGiay>> CreateDeGiay(DeGiay dg)
        {
            await _degiay.CreateDeGiay(dg);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateDeGiay(DeGiay dg)
        {
            await _degiay.UpdateDeGiay(dg);
            return Ok();
        }
        [HttpDelete("degia{id}")]
        public async Task<ActionResult> DeleteDeGiay(Guid id)
        {
            await _degiay.DeleteDeGiay(id);
            return Ok();
        }

        
    }
}
