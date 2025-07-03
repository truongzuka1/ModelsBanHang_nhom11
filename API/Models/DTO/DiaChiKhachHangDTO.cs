using System;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class DiaChiKhachHangDto
    {
        public Guid DiaChiKhachHangId { get; set; }

        [Required]
        [StringLength(100)]
        public string SoNha { get; set; }

        [Required]
        [StringLength(100)]
        public string Duong { get; set; }

        [StringLength(100)]
        public string PhuongXa { get; set; }

        [StringLength(100)]
        public string QuanHuyen { get; set; }

        [StringLength(100)]
        public string ThanhPho { get; set; }

        public Guid KhachHangId { get; set; }

        public bool TrangThai { get; set; } = true;

        public bool IsDefault { get; set; } = false;

        public string DiaChiDayDu => $"{SoNha}, {Duong}, {PhuongXa}, {QuanHuyen}, {ThanhPho}".Trim(' ', ',');
    }

}
