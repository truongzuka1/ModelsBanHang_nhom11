using System;

namespace API.Models.DTO.TraHang
{
    public class ReturnItemDTO
    {
        public Guid GiayId { get; set; }
        public string TenSanPham { get; set; }
        public int SoLuongMua { get; set; }
        public int SoLuongDaTra { get; set; }
        public int SoLuongConLai { get; set; }
        public decimal Gia { get; set; }
    }
}