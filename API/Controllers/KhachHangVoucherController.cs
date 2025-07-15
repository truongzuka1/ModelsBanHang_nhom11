using API.IRepository;
using Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class KhachHangVoucherController : ControllerBase
	{
		private readonly IKhachHangVoucherRepo _repo;
		private readonly IThongBaoRepository _thongBaoRepo;

		public KhachHangVoucherController(
			IKhachHangVoucherRepo repo,
			IThongBaoRepository thongBaoRepo)
		{
			_repo = repo;
			_thongBaoRepo = thongBaoRepo;
		}

		// ✅ Lấy toàn bộ liên kết
		[HttpGet]
		public async Task<ActionResult<IEnumerable<KhachHangVoucher>>> GetAll()
		{
			var list = await _repo.GetAllAsync();
			return Ok(list);
		}

		// ✅ Lấy theo VoucherId
		[HttpGet("by-voucher/{voucherId}")]
		public async Task<ActionResult<IEnumerable<KhachHangVoucher>>> GetByVoucher(Guid voucherId)
		{
			var list = await _repo.GetByVoucherIdAsync(voucherId);
			return Ok(list);
		}

		// ✅ Lấy theo KhachHangId
		[HttpGet("by-khachhang/{khachHangId}")]
		public async Task<ActionResult<IEnumerable<KhachHangVoucher>>> GetByKhachHang(Guid khachHangId)
		{
			var list = await _repo.GetByKhachHangIdAsync(khachHangId);
			return Ok(list);
		}

		// ✅ Gán 1 voucher cho 1 khách hàng
		[HttpPost("assign-one")]
		public async Task<IActionResult> AssignOne(KhachHangVoucher model)
		{
			var success = await _repo.AddAsync(model);
			if (!success) return Conflict("Khách hàng đã có voucher này.");

			await _thongBaoRepo.ThemThongBaoAsync($"🎁 Gán voucher {model.VoucherId} cho KH {model.KhachHangId}");
			return Ok("Đã gán voucher.");
		}

		// ✅ Gán 1 voucher cho danh sách khách hàng
		[HttpPost("assign-multiple")]
		public async Task<IActionResult> AssignMultiple(Guid voucherId, List<Guid> khachHangIds)
		{
			await _repo.AddMultipleAsync(voucherId, khachHangIds);

			await _thongBaoRepo.ThemThongBaoAsync($"🎁 Gán voucher {voucherId} cho {khachHangIds.Count} khách hàng.");
			return Ok("Đã gán voucher cho nhiều khách hàng.");
		}

		// ✅ Xoá liên kết voucher - khách hàng
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(Guid id)
		{
			var result = await _repo.DeleteAsync(id);
			if (!result) return NotFound();

			await _thongBaoRepo.ThemThongBaoAsync($"🗑️ Xoá gán voucher của KHVoucherId: {id}");
			return NoContent();
		}
	}
}
