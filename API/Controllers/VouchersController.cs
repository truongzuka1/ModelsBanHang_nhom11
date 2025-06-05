using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Data.Models;
using API.IRepository;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VouchersController : ControllerBase
    {
        private readonly IVoucherRepo _context;

        public VouchersController(IVoucherRepo context)
        {
            _context = context;
        }

        // GET: api/Vouchers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Voucher>>> GetVouchers()
            => Ok(await _context.GetAll());

        // GET: api/Vouchers/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Voucher>> GetVoucher(Guid id)
        {
            var voucher = await _context.GetById(id);
            if (voucher == null)
                return NotFound("Voucher not found.");

            return Ok(voucher);
        }

        // PUT: api/Vouchers/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVoucher(Guid id, Voucher voucher)
        {
            if (id != voucher.VoucherId)
                return BadRequest("ID mismatch between URL and payload.");

            await _context.Update(voucher);
            return NoContent();
        }

        // POST: api/Vouchers
        [HttpPost]
        public async Task<ActionResult<Voucher>> PostVoucher(Voucher voucher)
        {
            await _context.Create(voucher);
            return CreatedAtAction(nameof(GetVoucher), new { id = voucher.VoucherId }, voucher);
        }

        // DELETE: api/Vouchers/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVoucher(Guid id)
        {
            await _context.Delete(id);
            return NoContent();
        }
    }
}
