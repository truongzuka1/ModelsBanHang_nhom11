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

        [Range(0, float.MaxValue)]
        public float Gia { get; set; }

        // Navigation properties (optional)
        public HoaDon HoaDons { get; set; }
        public GiayChiTiet GiayChiTiets { get; set; }
    }

}
