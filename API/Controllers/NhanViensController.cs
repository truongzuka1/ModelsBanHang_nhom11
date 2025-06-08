using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data.Models;
using Data.Models;
using API.IRepository;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhanViensController : ControllerBase
    {
        private readonly INhanVienRepository _repository;

        public NhanViensController(INhanVienRepository context)
        {
            _repository = context;
        }

        // GET: api/NhanViens
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NhanVien>>> GetNhanViens()
        {
            return Ok(await _repository.GetAllNhanVienAsync());
        }

        // GET: api/NhanViens/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NhanVien>> GetNhanVien(Guid id)
        {
            return Ok(await _repository.GetByIdNhanVienAsync(id));
        }

        // PUT: api/NhanViens/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNhanVien(Guid id, NhanVien nhanVien)
        {
            await _repository.UpdateNhanVienAsync(nhanVien);
            return Ok();
        }

        // POST: api/NhanViens
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<NhanVien>> PostNhanVien([FromBody] NhanVien nhanVien)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _repository.CreateNhanVien(nhanVien);
            return Ok();
        }


        // DELETE: api/NhanViens/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNhanVien(Guid id)
        {
            await _repository.DeleteNhanVienAsync(id);
            return Ok();
        }

        [HttpGet("tk/{taikhoanId}")]
        public async Task<ActionResult<NhanVien>> GetNhanVienByTaiKhoanId(Guid taikhoanId)
        {
            var nhanVien = await _repository.GetIdNhanVienTaiKhoan(taikhoanId);
            if (nhanVien == null)
            {
                return NotFound();
            }

            return Ok(nhanVien);
        }
    }
}
