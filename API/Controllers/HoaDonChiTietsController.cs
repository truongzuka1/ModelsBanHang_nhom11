using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data.Models;
using API.IRepository;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoaDonChiTietsController : ControllerBase
    {
        private readonly IChiTietHoaDonRepository _repository;

        public HoaDonChiTietsController(IChiTietHoaDonRepository context)
        {
            _repository = context;
        }

        // GET: api/HoaDonChiTiets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HoaDonChiTiet>>> GetHoaDonChiTiets()
        {
            var result = await _repository.GetAllHDCTAsync();
            return Ok(result);
        }

        // GET: api/HoaDonChiTiets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HoaDonChiTiet>> GetHoaDonChiTiet(Guid id)
        {
            var item = await _repository.GetByIdHDCTAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }


    }
}
