using API.IRepository;
using API.Models.DTO;
using Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GiayController : ControllerBase
    {
        private readonly IGiayRepository _giayRepo;

        public GiayController(IGiayRepository giayRepo)
        {
            _giayRepo = giayRepo;
        }

        // Helper để map sang GiayDTO
        private GiayDTO MapToDTO(Giay giay)
        {
            return new GiayDTO
            {
                GiayId = giay.GiayId,
                TenGiay = giay.TenGiay,
                TrangThai = giay.TrangThai,
                NgayTao = giay.NgayTao,
                ThuongHieuId = giay.ThuongHieuId,
                ChatLieuId = giay.ChatLieuId,
                TheLoaiGiayId = giay.TheLoaiGiayId,
                DeGiayId = giay.DeGiayId,
                KieuDangId = giay.KieuDangId,
                TenThuongHieu = giay.ThuongHieu?.TenThuongHieu,
                TenChatLieu = giay.ChatLieu?.TenChatLieu,
                TenTheLoaiGiay = giay.TheLoaiGiay?.TenTheLoai,
                TenDeGiay = giay.DeGiay?.TenDeGiay,
                TenKieuDang = giay.KieuDang?.TenKieuDang,
                ChiTietGiays = giay.GiayChiTiets.Select(ct => new GiayChiTietDTO
                {
                    // TODO: map các trường cần thiết nếu có
                }).ToList()
            };
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var giays = await _giayRepo.GetAllAsync();
            var dtoList = giays.Select(MapToDTO).ToList();
            return Ok(dtoList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var giay = await _giayRepo.GetByIdAsync(id);
            if (giay == null) return NotFound();

            return Ok(MapToDTO(giay));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] GiayDTO dto)
        {
            var giay = new Giay
            {
                TenGiay = dto.TenGiay,
                TrangThai = dto.TrangThai,
                ThuongHieuId = dto.ThuongHieuId,
                ChatLieuId = dto.ChatLieuId,
                TheLoaiGiayId = dto.TheLoaiGiayId,
                DeGiayId = dto.DeGiayId,
                KieuDangId = dto.KieuDangId,
            };

            var created = await _giayRepo.AddAsync(giay);
            return CreatedAtAction(nameof(GetById), new { id = created.GiayId }, MapToDTO(created));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] GiayDTO dto)
        {
            var giay = new Giay
            {
                GiayId = id,
                TenGiay = dto.TenGiay,
                TrangThai = dto.TrangThai,
                ThuongHieuId = dto.ThuongHieuId,
                ChatLieuId = dto.ChatLieuId,
                TheLoaiGiayId = dto.TheLoaiGiayId,
                DeGiayId = dto.DeGiayId,
                KieuDangId = dto.KieuDangId,
            };

            var updated = await _giayRepo.UpdateAsync(giay);
            if (updated == null) return NotFound();

            return Ok(MapToDTO(updated));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _giayRepo.DeleteAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string keyword)
        {
            var results = await _giayRepo.SearchByTenAsync(keyword);
            return Ok(results.Select(MapToDTO).ToList());
        }
    }
}
