using System;
using System.ComponentModel.DataAnnotations;

namespace API.Models.DTO
{
    public class GiayChiTietDTO
    {
        public Guid GiayChiTietId { get; set; }

        [Required]
        public Guid GiayId { get; set; }

        public Guid? ChatLieuId { get; set; }
        public Guid? KichCoId { get; set; }
        public Guid? MauSacId { get; set; }
        public Guid? ThuongHieuId { get; set; }
        public Guid? KieuDangId { get; set; }
        public Guid? DeGiayId { get; set; }
        public Guid? TheLoaiGiayId { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Số lượng phải >= 0")]
        public int SoLuongCon { get; set; }

        public string AnhGiay { get; set; }

        public DateTime NgayTao { get; set; }
        public DateTime NgaySua { get; set; }

        [Range(0, float.MaxValue, ErrorMessage = "Giá phải >= 0")]
        public float Gia { get; set; }

        public string? MoTa { get; set; }

        public bool TrangThai { get; set; }

        // OPTIONAL: Có thể thêm tên để hiển thị nếu bạn cần render giao diện dễ hơn
        public string? TenGiay { get; set; }
        public string? TenMauSac { get; set; }
        public string? TenKichCo { get; set; }
        public string? TenChatLieu { get; set; }
        public string? TenThuongHieu { get; set; }
        public string? TenKieuDang { get; set; }
        public string? TenDeGiay { get; set; }
        public string? TenTheLoai { get; set; }

        // OPTIONAL: Danh sách ảnh
        public List<string>? DanhSachAnh { get; set; }
    }
}
