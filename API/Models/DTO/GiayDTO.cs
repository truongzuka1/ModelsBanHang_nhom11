namespace API.Models.DTO
{
    public class GiayDTO
    {
        public Guid GiayId { get; set; }
        public string TenGiay { get; set; }
        public string? MoTa { get; set; }
        public bool TrangThai { get; set; }
        public DateTime NgayTao { get; set; }

        public Guid? ThuongHieuId { get; set; }
        public Guid? ChatLieuId { get; set; }
        public Guid? TheLoaiGiayId { get; set; }
        public Guid? DeGiayId { get; set; }
        public Guid? KieuDangId { get; set; }

        public List<GiayChiTietDTO> ChiTietGiays { get; set; } = new();
    }
}
