using System;
using System.ComponentModel.DataAnnotations;

namespace API.Models.DTO
{
    public class GiayChiTietDTO
    {
        public Guid GiayChiTietId { get; set; }
        [Required(ErrorMessage = "GiayId là bắt buộc")]
        public Guid GiayId { get; set; }
        public Guid? MauSacId { get; set; }
        public Guid? KichCoId { get; set; }
        public string? TenGiay { get; set; }
        [Range(0, float.MaxValue, ErrorMessage = "Giá phải lớn hơn hoặc bằng 0")]
        public float Gia { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Số lượng còn phải lớn hơn hoặc bằng 0")]
        public int SoLuongCon { get; set; }
        public string? MoTa { get; set; }
        public bool TrangThai { get; set; }
        public int size { get; set; }
        public string? TenMau { get; set; }
        public string? AnhGiay { get; set; }
        public DateTime NgayTao { get; set; } = DateTime.Now;
        public DateTime NgaySua { get; set; } = DateTime.Now;
        [Range(1, int.MaxValue, ErrorMessage = "Số lượng đặt phải lớn hơn hoặc bằng 1")]
        public int SoLuongDat { get; set; } = 1;
    }
}