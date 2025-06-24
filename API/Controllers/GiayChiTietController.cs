using API.IRepository;
using API.Models.DTO;
using Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GiayChiTietController : ControllerBase
    {
        private readonly IGiayChiTietRepository _giayChiTietRepository;

        public GiayChiTietController(IGiayChiTietRepository giayChiTietRepository)
        {
            _giayChiTietRepository = giayChiTietRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GiayChiTiet>>> GetAll()
        {
            var list = await _giayChiTietRepository.GetAllAsync();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GiayChiTiet>> GetById(Guid id)
        {
            var item = await _giayChiTietRepository.GetByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] GiayChiTietDTO dto)
        {
            var entity = new GiayChiTiet
            {
                ChatLieuId = dto.ChatLieuId,
                KichCoId = dto.KichCoId,
                MauSacId = dto.MauSacId,
                ThuongHieuId = dto.ThuongHieuId,
                KieuDangId = dto.KieuDangId,
                DeGiayId = dto.DeGiayId,
                TheLoaiGiayId = dto.TheLoaiGiayId,
                SoLuongCon = dto.SoLuongCon,
                Gia = dto.Gia,
                MoTa = dto.MoTa,
                AnhGiay = dto.AnhGiay,
                TrangThai = dto.TrangThai,
                GiayId = dto.GiayId
            };

            var result = await _giayChiTietRepository.CreateAsync(entity);
            if (!result) return BadRequest("Thêm thất bại");
            return Ok("Thêm thành công");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, [FromBody] GiayChiTietDTO dto)
        {
            var entity = new GiayChiTiet
            {
                ChatLieuId = dto.ChatLieuId,
                KichCoId = dto.KichCoId,
                MauSacId = dto.MauSacId,
                ThuongHieuId = dto.ThuongHieuId,
                KieuDangId = dto.KieuDangId,
                DeGiayId = dto.DeGiayId,
                TheLoaiGiayId = dto.TheLoaiGiayId,
                SoLuongCon = dto.SoLuongCon,
                Gia = dto.Gia,
                MoTa = dto.MoTa,
                AnhGiay = dto.AnhGiay,
                TrangThai = dto.TrangThai,
                GiayId = dto.GiayId
            };

            var result = await _giayChiTietRepository.UpdateAsync(id, entity);
            if (!result) return NotFound("Không tìm thấy giày chi tiết để cập nhật");
            return Ok("Cập nhật thành công");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var result = await _giayChiTietRepository.DeleteAsync(id);
            if (!result) return NotFound("Không tìm thấy giày chi tiết để xoá");
            return Ok("Xoá thành công");
        }

        [HttpGet("by-giay/{giayId}")]
        public async Task<ActionResult<IEnumerable<GiayChiTiet>>> GetByGiayId(Guid giayId)
        {
            var list = await _giayChiTietRepository.GetByGiayIdAsync(giayId);
            return Ok(list);
        }
    }
}
