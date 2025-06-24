using System.ComponentModel.DataAnnotations;

namespace API.Models.DTO
{
    public class GiayDTO
    {
        public Guid GiayId { get; set; } = Guid.NewGuid();

        [Required]
        public string TenGiay { get; set; }

        public bool TrangThai { get; set; }
        public DateTime NgayTao { get; set; }

        public string? MoTa { get; set; }
        public Guid? DanhMucId { get; set; }
        public Guid? ChatLieuId { get; set; }
        public Guid? ThuongHieuId { get; set; }

        // 🎯 Danh sách chi tiết giày
        public List<GiayChiTietDTO> ChiTietGiay { get; set; } = new();
    }

}
