using System.ComponentModel.DataAnnotations;

namespace API.Models.DTO
{
    public class MauSacDTO
    {
        public Guid MauSacId { get; set; }

        [Required]
        [StringLength(50)]
        [RegularExpression(@"^[a-zA-Z0-9\s]+$")]
        public string TenMau { get; set; }

        public string MoTa { get; set; }

        public bool TrangThai { get; set; }
    }
}
