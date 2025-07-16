using System.ComponentModel.DataAnnotations;

namespace API.Models.DTO
{
    public class GiamGiaCreateDTO
    {
        public Guid GiamGiaId { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(50)]
        [RegularExpression(@"^[a-zA-ZÀÁÂÃÈÉÊÌÍÒÓÔÕÙÚĂĐĨŨƠƯàáâãèéêìíòóôõùúăđĩũơưẠ-ỹ\s0-9]+$", ErrorMessage = "Tên chỉ được chứa chữ cái tiếng Việt, số và khoảng trắng")]
        public string TenGiamGia { get; set; }

        public string? SanPhamKhuyenMai { get; set; }

        [Range(0, 100, ErrorMessage = "Phần trăm khuyến mãi phải nằm trong khoảng 0 đến 100.")]
        public float PhanTramKhuyenMai { get; set; }

        [Required]
        public DateTime NgayBatDau { get; set; }

        [Required]
        public DateTime NgayKetThuc { get; set; }

        public bool TrangThai { get; set; }

        public List<Guid> GiayIds { get; set; } = new();
    }
}
