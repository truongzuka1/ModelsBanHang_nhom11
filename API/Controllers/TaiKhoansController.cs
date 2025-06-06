using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data.Models;
using API.IRepository;
using NuGet.Protocol.Core.Types;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaiKhoansController : ControllerBase
    {
        private readonly ITaiKhoanRepository _context;

        public TaiKhoansController(ITaiKhoanRepository context)
        {
            _context = context;
        }

        // GET: api/TaiKhoans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaiKhoan>>> GetTaiKhoans()
        {
           return Ok( await _context.GetAllTaiKhoanAsync() );
        }

        // GET: api/TaiKhoans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaiKhoan>> GetTaiKhoan(Guid id)
        {
            return Ok(await _context.GetByIdTaiKhoanAsync(id));
        }

        // PUT: api/TaiKhoans/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaiKhoan(Guid id, TaiKhoan taiKhoan)
        {
           await _context.UpdateTaiKhoanAsync(taiKhoan);
            return Ok();
        }

        // POST: api/TaiKhoans
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TaiKhoan>> PostTaiKhoan(TaiKhoan taiKhoan)
        {
            await _context.CreateTaiKhoanAsync(taiKhoan);
            return Ok();
        }

        // DELETE: api/TaiKhoans/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaiKhoan(Guid id)
        {
           await _context.DeleteTaiKhoanAsync(id);  
            return Ok();
        }

        [HttpGet("username/{username}")]
        public async Task<ActionResult<TaiKhoan>> GetTaiKhoanByUsername(string username)
        {
            var taiKhoan = await _context.GetByUsernameAsync(username);
            if (taiKhoan == null)
            {
                return NotFound();
            }
            return Ok(taiKhoan);
        }



    }
}
