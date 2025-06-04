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
    public class HoaDonChiTietsController : ControllerBase
    {
        private readonly IChiTietHoaDonRepository _context;

        public HoaDonChiTietsController(IChiTietHoaDonRepository context)
        {
            _context = context;
        }

        // GET: api/HoaDonChiTiets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HoaDonChiTiet>>> GetHoaDonChiTiets()
        {
           return Ok(await _context.GetAllHDCTAsync());
        }

        // GET: api/HoaDonChiTiets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HoaDonChiTiet>> GetHoaDonChiTiet(Guid id)
        {
            return Ok(await _context.GetByIdHDCTAsync(id));
        }

      
    }
}
