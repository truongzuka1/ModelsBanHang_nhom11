using Microsoft.AspNetCore.Mvc;
using API.IRepository;
using Data.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoucherController : ControllerBase
    {
        private readonly IVoucherRepo _voucherRepo;

        public VoucherController(IVoucherRepo voucherRepo)
        {
            _voucherRepo = voucherRepo;
        }

        // GET: api/Voucher
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Voucher>>> GetAllVouchers()
        {
            var vouchers = await _voucherRepo.GetAll();
            return Ok(vouchers);
        }

        // GET: api/Voucher/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Voucher>> GetVoucherById(Guid id)
        {
            var voucher = await _voucherRepo.GetById(id);
            if (voucher == null)
                return NotFound();

            return Ok(voucher);
        }

        // POST: api/Voucher
        [HttpPost]
        public async Task<ActionResult<Voucher>> CreateVoucher(Voucher voucher)
        {
            await _voucherRepo.Create(voucher);
            return CreatedAtAction(nameof(GetVoucherById), new { id = voucher.VoucherId }, voucher);
        }

        // PUT: api/Voucher/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVoucher(Guid id, Voucher voucher)
        {
            if (id != voucher.VoucherId)
                return BadRequest("ID mismatch");

            await _voucherRepo.Update(voucher);
            return NoContent();
        }

        // DELETE: api/Voucher/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVoucher(Guid id)
        {
            var result = await _voucherRepo.Delete(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
