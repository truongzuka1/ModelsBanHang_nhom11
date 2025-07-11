namespace API.Models.DTO
{
    public class GiayChiTietDTO
    {
        public Guid GiayChiTietId { get; set; }
        public Guid GiayId { get; set; }
        public Guid? MauSacId { get; set; }
        public Guid? KichCoId { get; set; }
        public string? TenGiay { get; set; }
        public float Gia { get; set; }
        public int SoLuongCon { get; set; }
        public string? MoTa { get; set; }
        public bool TrangThai { get; set; }
        public string ? size { get; set; }
        public string? TenMau { get; set; }
        public string? AnhGiay { get; set; }
        public DateTime NgayTao { get; set; } = DateTime.Now;
        public DateTime NgaySua { get; set; } = DateTime.Now;
    }
}
