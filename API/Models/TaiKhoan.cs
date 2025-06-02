using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class TaiKhoan
    {
        [Key]
        public Guid TaikhoanId { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9\s]+$", ErrorMessage = "Tên đăng nhập không hợp lệ")]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Họ và tên không hợp lệ")]
        public string Hovaten { get; set; }

        [Required]
        [RegularExpression(@"^(Nam|Nữ)$", ErrorMessage = "Giới tính phải là Nam hoặc Nữ")]
        public string Gioitinh { get; set; }

        [Required]
        [RegularExpression(@"^0\d{9,10}$", ErrorMessage = "Số điện thoại không hợp lệ")]
        public string Sdt { get; set; }

        public string Diachi { get; set; }

        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string Email { get; set; }

        [Required]
        public DateTime Ngaysinh { get; set; }

        [Required]
        public DateTime Ngaytaotaikhoan { get; set; }

        public int Trangthai { get; set; }
        public virtual ICollection<HoaDon> HoaDons { get; set; }
        public virtual ICollection<TaiKhoan_ChucVu> TaiKhoan_ChucVus { get; set; }

    }


}
