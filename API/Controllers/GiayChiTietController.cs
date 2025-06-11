using API.IRepository;
using Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController] 
    [Route("api/[controller]")]
    public class GiayChiTietController : Controller
    {
        private readonly IGiayChiTietRepository _giayChitiet;


        public GiayChiTietController(IGiayChiTietRepository giayChitiet)
        {
            _giayChitiet = giayChitiet;

        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GiayChiTiet>>> GetGiayChiTiets()
        {
            return Ok(await _giayChitiet.getAllGiayChiTiet());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GiayChiTiet>> GetGiayChiTietById(Guid id)
        {
            return Ok(await _giayChitiet.getGiayChiTietbyID(id));
        }

        [HttpPost]
        public async Task<ActionResult<GiayChiTiet>> CreateGiayChitiet(GiayChiTiet gct ,Guid? iddegiay)
        {
            await _giayChitiet.CreateGiayChiTiet(gct, iddegiay);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateGiayChiTiet(GiayChiTiet gct, Guid? dg)
        {
            await _giayChitiet.UpdateGiayChiTiet(gct , dg);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteGiayChiTiet(Guid id)
        {
            await _giayChitiet.DeleteGiayChiTiet(id);
            return Ok();
        }
       
    }
}
