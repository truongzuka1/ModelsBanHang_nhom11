using System;
using System.ComponentModel.DataAnnotations;

namespace API.Models.DTO
{
    public class DiaChiKhachHangDTO
    {
        public Guid DiaChiKhachHangId { get; set; }  // dùng cho cập nhật, không bắt buộc khi thêm mới

        [Required(ErrorMessage = "Tên địa chỉ không được bỏ trống")]
        [StringLength(50, ErrorMessage = "Tên địa chỉ tối đa 50 ký tự")]
        [RegularExpression(@"^[a-zA-ZÀÁÂÃÈÉÊÌÍÒÓÔÕÙÚĂĐĨŨƠƯàáâãèéêìíòóôõùúăđĩũơưẠ-ỹ\s0-9]+$",
            ErrorMessage = "Tên chỉ được chứa chữ cái tiếng Việt, số và khoảng trắng")]
        public string TenDiaChi { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn khách hàng")]
        public Guid KhachHangId { get; set; }

        public bool TrangThai { get; set; } = true;
    }
}
