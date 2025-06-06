using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class HoaDonChiTiet
    {
        [Key]
        public Guid HoaDonChiTietId { get; set; } = Guid.NewGuid();

        public Guid GiayChiTietId { get; set; }

        public Guid HoaDonId { get; set; }

        [Range(1, int.MaxValue)]
        public int SoLuongSanPham { get; set; }
        public decimal Gia { get; set; }
        public bool TrangThai { get; set; } 
		public virtual HoaDon HoaDons { get; set; }
        public virtual Giay Giays { get; set; }
    }

}
