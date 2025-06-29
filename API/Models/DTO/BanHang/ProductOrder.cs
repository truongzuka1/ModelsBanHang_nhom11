namespace API.Models.DTO.BanHang
{
    public class ProductOrder
    {
        public Guid GiayChiTietId { get; set; }
        public string TenGiay { get; set; } = "";
        public string? Size { get; set; }
        public string? Img { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal OldPrice { get; set; }
        public decimal NewPrice => Price;
    }
}
