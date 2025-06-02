using System;
using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class GioHangChiTiet
    {
        [Key]
        public Guid GioHangChiTietId { get; set; }

        public Guid GioHangId { get; set; }

        public Guid GiayChiTietId { get; set; }

        public int SoLuongSanPham { get; set; }

        public decimal Gia { get; set; }

        // Tính toán tự động tránh lưu dữ liệu thừa hoặc sai lệch
        public decimal ThanhTien => Gia * SoLuongSanPham;

        public DateTime NgayTao { get; set; } = DateTime.Now;

        public DateTime NgayCapNhat { get; set; } = DateTime.Now;

        public bool TrangThai { get; set; }
        public virtual GioHang GioHang { get; set; }
        public virtual GiayChiTiet GiayChiTiet { get; set; }
    }
}
