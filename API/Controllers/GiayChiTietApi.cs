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

        public GiayChiTietApi(IGiayChiTietRepository giayChitiet, IDeGiayRepository degiay, IAnhRepository anhRepository)
        {
            _giayChitiet = giayChitiet;
            _degiay = degiay;
            _anhRepository = anhRepository;

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
        [HttpPost("upload")]
        public async Task<IActionResult> UploadAnh([FromForm] IFormFile file, [FromForm] string tenAnh)
        {
            if (file == null || file.Length == 0)
                return BadRequest("Chưa chọn file ảnh.");

            var anh = await _anhRepository.UploadAsync(file, tenAnh);
            if (anh == null)
                return StatusCode(500, "Không upload được ảnh.");

            return Ok(anh);
        }
        // the  ảnh vào giầy chi tiết
        [HttpPost("{giayChiTietId}/add-anh")]
        public async Task<IActionResult> AddAnhToGiayChiTiet(Guid giayChiTietId, [FromQuery] Guid anhId)
        {
            var giayChiTiet = await _giayChitiet.getGiayChiTietbyID(giayChiTietId);
            if (giayChiTiet == null) return NotFound("Không tìm thấy GiayChiTiet");

            var anh = await _anhRepository.GetByIdAsync(anhId);
            if (anh == null) return NotFound("Không tìm thấy ảnh");

            giayChiTiet.AnhId = anhId;
            await _giayChitiet.UpdateGiayChiTiet(giayChiTiet, null);

            return Ok(giayChiTiet);
        }
        // Sửa file ảnh (upload file mới thay ảnh cũ)
        [HttpPut("{id}/file")]
        public async Task<IActionResult> UpdateFile(Guid id, [FromForm] IFormFile file, [FromForm] string tenAnh)
        {
            var result = await _anhRepository.UpdateFileAsync(id, file, tenAnh);
            if (result == null) return NotFound();
            return Ok(result);
        }

        // Xóa ảnh
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await _anhRepository.DeleteAsync(id);
            if (!success) return NotFound();
            return Ok();
        }
    }
}
