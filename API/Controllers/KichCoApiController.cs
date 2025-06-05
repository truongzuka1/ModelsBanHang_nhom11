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
    public class KichCoApiController : Controller
    {
        private readonly IKichCoRepository _kichCoRepository;

        public KichCoApiController(IKichCoRepository kichCoRepository)
        {
            _kichCoRepository = kichCoRepository;
        }

        // Lấy toàn bộ kích cỡ
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KichCo>>> GetAllKichCo()
        {
            return Ok(await _kichCoRepository.GetAllAsync());
        }

        // Lấy kích cỡ theo ID
        [HttpGet("{id}")]
        public async Task<ActionResult<KichCo>> GetKichCoById(Guid id)
        {
            var kichCo = await _kichCoRepository.GetByIdAsync(id);
            if (kichCo == null) return NotFound();
            return Ok(kichCo);
        }

        // Thêm kích cỡ mới
        [HttpPost]
        public async Task<ActionResult<KichCo>> CreateKichCo([FromBody] KichCo kichCo)
        {
            var created = await _kichCoRepository.AddAsync(kichCo);
            return CreatedAtAction(nameof(GetKichCoById), new { id = created.KichCoId }, created);
        }

        // Sửa kích cỡ
        [HttpPut("{id}")]
        public async Task<ActionResult<KichCo>> UpdateKichCo(Guid id, [FromBody] KichCo kichCo)
        {
            if (id != kichCo.KichCoId) return BadRequest("Id mismatch");
            var updated = await _kichCoRepository.UpdateAsync(kichCo);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        // Xóa kích cỡ
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteKichCo(Guid id)
        {
            var result = await _kichCoRepository.DeleteAsync(id);
            if (!result) return NotFound();
            return Ok();
        }

        // Thêm kích cỡ vào GiayChiTiet
        [HttpPost("add-to-giaychitiet")]
        public async Task<ActionResult> AddKichCoToGiayChiTiet(Guid giayChiTietId, Guid kichCoId)
        {
            var result = await _kichCoRepository.AddKichCoToGiayChiTiet(giayChiTietId, kichCoId);
            if (!result) return BadRequest("Thêm kích cỡ vào GiayChiTiet thất bại.");
            return Ok();
        }

        // Xóa kích cỡ khỏi GiayChiTiet
        [HttpDelete("remove-from-giaychitiet")]
        public async Task<ActionResult> RemoveKichCoFromGiayChiTiet(Guid giayChiTietId, Guid kichCoId)
        {
            var result = await _kichCoRepository.RemoveKichCoFromGiayChiTiet(giayChiTietId, kichCoId);
            if (!result) return BadRequest("Xóa kích cỡ khỏi GiayChiTiet thất bại.");
            return Ok();
        }

        // Lấy danh sách kích cỡ của một GiayChiTiet (thường chỉ 1)
        [HttpGet("giaychitiet/{giayChiTietId}")]
        public async Task<ActionResult<IEnumerable<KichCo>>> GetKichCosByGiayChiTietId(Guid giayChiTietId)
        {
            var kichCos = await _kichCoRepository.GetKichCosByGiayIdAsync(giayChiTietId);
            return Ok(kichCos);
        }
    }
}