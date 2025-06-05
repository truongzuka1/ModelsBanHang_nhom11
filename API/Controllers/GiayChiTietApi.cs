using API.IRepository;
using API.IRepository.Repository;
using API.Repository;
using API.Repository.IRepository;
using Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController] 
    [Route("api/[controller]")]
    public class GiayChiTietApi : Controller
    {
        private readonly IGiayChiTietRepository _giayChitiet;
        private readonly IDeGiayRepository _degiay;
        private readonly IAnhRepository _anhRepository;
        private readonly IKichCoRepository _kichcoRepository;

        public GiayChiTietApi(IGiayChiTietRepository giayChitiet, IDeGiayRepository degiay)
        {
            _giayChitiet = giayChitiet;
            _degiay = degiay;
          
        }
        [HttpGet("giaychitiet")]
        public async Task<ActionResult<IEnumerable<GiayChiTiet>>> GetGiayChiTiets()
        {
            return Ok(await _giayChitiet.getAllGiayChiTiet());
        }
        [HttpGet("degiay")]
        public async Task<ActionResult<IEnumerable<DeGiay>>> GetDeGiayAll()
        {
            return Ok(await _degiay.GetAllDegiay());
        }
        [HttpGet("giaychitiet/{id}")]
        public async Task<ActionResult<GiayChiTiet>> GetGiayChiTietById(Guid id)
        {
            return Ok(await _giayChitiet.getGiayChiTietbyID(id));
        }
        [HttpGet("degiay/{id}")]
        public async Task<ActionResult<DeGiay>> GetDeGiayById(Guid id)
        {
            return Ok(await _degiay.GetDeGiay(id));
        }
        [HttpPost("giaychitiet")]
        public async Task<ActionResult<GiayChiTiet>> CreateGiayChitiet(GiayChiTiet gct ,Guid? iddegiay)
        {
            await _giayChitiet.CreateGiayChiTiet(gct, iddegiay);
            return Ok();
        }
        [HttpPost("degiay")]
        public async Task<ActionResult<DeGiay>> CreateDeGiay(DeGiay dg)
        {
            await _degiay.CreateDeGiay(dg);
            return Ok();
        }
        [HttpPut("giaychitiet")]
        public async Task<ActionResult> UpdateGiayChiTiet(GiayChiTiet gct, Guid? dg)
        {
            await _giayChitiet.UpdateGiayChiTiet(gct , dg);
            return Ok();
        }
        [HttpDelete("giaychitiet/{id}")]
        public async Task<ActionResult> DeleteGiayChiTiet(Guid id)
        {
            await _giayChitiet.DeleteGiayChiTiet(id);
            return Ok();
        }
        [HttpPut("degiay")]
        public async Task<ActionResult> UpdateDeGiay(DeGiay dg)
        {
            await _degiay.UpdateDeGiay(dg);
            return Ok();
        }
        [HttpDelete("degiay/{id}")]
        public async Task<ActionResult> DeleteDeGiay(Guid id)
        {
            await _degiay.DeleteDeGiay(id);
            return Ok();
        }
       
    }
}
