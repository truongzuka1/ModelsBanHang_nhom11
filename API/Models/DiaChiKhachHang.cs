using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class DiaChiKhachHang
    {
        [Key]
        public Guid DiaChiKhachHangId { get; set; } = Guid.NewGuid();
        [Required]
        [StringLength(50)]
        [RegularExpression(@"^[a-zA-ZÀÁÂÃÈÉÊÌÍÒÓÔÕÙÚĂĐĨŨƠƯàáâãèéêìíòóôõùúăđĩũơưẠ-ỹ\s0-9]+$", ErrorMessage = "Tên chỉ được chứa chữ cái tiếng Việt, số và khoảng trắng")]
        public string TenDiaChi { get; set; }
        public Guid khachHangId { get; set; }
        public string MoTa { get; set; }
       
        public bool TrangThai { get; set; } = true;

        public KhachHang KhachHang { get; set; }


    }
}
