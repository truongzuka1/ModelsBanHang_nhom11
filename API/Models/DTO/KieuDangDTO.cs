using System.ComponentModel.DataAnnotations;

namespace API.Models.DTO
{
    public class KieuDangDTO
    {
        [Key]
        public Guid KieuDangId { get; set; }
        [Required]
        [StringLength(50)]
        [RegularExpression(@"^[a-zA-Z0-9\s]+$", ErrorMessage = "Tên không được chứa ký tự đặc biệt.")]
        public string TenKieuDang { get; set; }
        public string MoTa { get; set; }
        public bool TrangThai { get; set; }
    }
}
