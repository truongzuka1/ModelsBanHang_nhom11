using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReturnController : ControllerBase
    {
        private readonly IReturnService _returnService;
        private readonly ITaiKhoanService _taiKhoanService;

        public ReturnController(IReturnService returnService, ITaiKhoanService taiKhoanService)
        {
            _returnService = returnService;
            _taiKhoanService = taiKhoanService;
        }

        [HttpGet("hoa-don/{hoaDonId}")]
        public async Task<IActionResult> GetHoaDon(Guid hoaDonId)
        {
            var hoaDon = await _returnService.GetHoaDonByIdAsync(hoaDonId);
            if (hoaDon == null) return NotFound("Hóa đơn không tồn tại.");
            return Ok(hoaDon);
        }

        [HttpGet("hoa-don/{hoaDonId}/chi-tiet")]
        public async Task<IActionResult> GetHoaDonChiTiets(Guid hoaDonId)
        {
            var chiTiets = await _returnService.GetHoaDonChiTietsByHoaDonIdAsync(hoaDonId);
            return Ok(chiTiets);
        }

        [HttpPost("create-return")]
        public async Task<IActionResult> CreateReturn([FromBody] CreateReturnRequest request)
        {
            try
            {
                // Kiểm tra tài khoản (nếu cần xác thực)
                var taiKhoan = await _taiKhoanService.GetByIdTaiKhoanAsync(request.TaiKhoanId);
                if (taiKhoan == null) return Unauthorized("Tài khoản không hợp lệ.");

                var returnHoaDon = await _returnService.CreateReturnAsync(request.HoaDonId, request.ReturnItems, request.VoucherId, request.TaiKhoanId);
                return Ok(returnHoaDon);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

    public class CreateReturnRequest
    {
        public Guid HoaDonId { get; set; }
        public List<ReturnItemRequest> ReturnItems { get; set; }
        public Guid? VoucherId { get; set; }
        public Guid TaiKhoanId { get; set; } // Thêm để xác định tài khoản xử lý trả hàng
    }

    public class ReturnItemRequest
    {
        public Guid GiayId { get; set; }
        public int SoLuongTra { get; set; }
    }
}