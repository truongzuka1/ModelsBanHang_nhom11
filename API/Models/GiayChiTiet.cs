using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class GiayChiTiet
    {
        [Key]
        public Guid GiayChiTietId { get; set; }

        [Required]
        public Guid GiayId { get; set; }

        public Guid ChatLieuId { get; set; }
        public Guid KichCoId { get; set; }
        public Guid MauSacId { get; set; }
        public Guid ThuongHieuId { get; set; }
        public Guid KieuDangId { get; set; }
        public Guid DeGiayId { get; set; }
        public Guid TheLoaiGiayId { get; set; }
        public Guid TaukhoanId { get; set; }
        public Guid AnhId { get; set; }

        public int SoLuongCon { get; set; }
        public string AnhGiay { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgaySua { get; set; }
        public float Gia { get; set; }
        public string MoTa { get; set; }
        public bool TrangThai { get; set; }

        public virtual Giay Giay { get; set; }
        public virtual ChatLieu ChatLieu { get; set; }
        public virtual KichCo KichCo { get; set; }
        public virtual MauSac MauSac { get; set; }
        public virtual ThuongHieu ThuongHieu { get; set; }
        public virtual KieuDang KieuDang { get; set; }
        public virtual DeGiay DeGiay { get; set; }
        public virtual TheLoaiGiay TheLoaiGiay { get; set; }
        public virtual TaiKhoan TaiKhoan { get; set; }
        public virtual Anh Anh { get; set; }
        public virtual ICollection<HoaDonChiTiet> HoaDonChiTiets { get; set; } = new List<HoaDonChiTiet>();
        public virtual ICollection<GioHangChiTiet> GioHangChiTiets { get; set; } = new List<GioHangChiTiet>();
    }
}