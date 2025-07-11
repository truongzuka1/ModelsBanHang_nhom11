using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class HoaDon
    {
        [Key]
        public Guid HoaDonId { get; set; } = Guid.NewGuid();

        public Guid TaiKhoanId { get; set; }
        public Guid ? KhachHangId { get; set; }
        public Guid HinhThucThanhToanId { get; set; }
        public Guid ? VoucherId { get; set; }


        [MaxLength(50)]
        public string TenCuaKhachHang { get; set; }

        [MaxLength(20)]
        public string SDTCuaKhachHang { get; set; }

        [MaxLength(50)]
        public string EmailCuaKhachHang { get; set; }

        public DateTime NgayTao { get; set; }
        public DateTime NgayNhanHang { get; set; }

        public float TongTienSauKhiGiam { get; set; }

        public string TrangThai { get; set; }

        [MaxLength(200)]
        public string GhiChu { get; set; }

        public Voucher ? voucher { get; set; }
        public TaiKhoan taiKhoan { get; set; }
        public HinhThucThanhToan hinhThucThanhToan {  get; set; }
        public KhachHang? khachHang { get; set; }
        public virtual ICollection<HoaDonChiTiet> HoaDonChiTiets { get; set; } = new List<HoaDonChiTiet>();
        

    }

}
