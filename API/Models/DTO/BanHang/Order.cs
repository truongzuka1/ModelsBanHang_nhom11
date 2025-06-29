using Data.Models;

namespace API.Models.DTO.BanHang
{
    public class Order
    {
        public List<ProductOrder> Products { get; set; } = new();
        public KhachHang? Customer { get; set; }
        public DiaChiKhachHang? Address { get; set; }
    }
}
