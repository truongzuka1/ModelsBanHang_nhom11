﻿using System.ComponentModel.DataAnnotations;

namespace API.Models.DTO
{
    public class KieuDangDTO
    {
        [Key]
        public Guid KieuDangId { get; set; }
        [Required]
        [StringLength(50)]
        [RegularExpression(@"^[a-zA-ZÀÁÂÃÈÉÊÌÍÒÓÔÕÙÚĂĐĨŨƠƯàáâãèéêìíòóôõùúăđĩũơưẠ-ỹ\s0-9]+$", ErrorMessage = "Tên chỉ được chứa chữ cái tiếng Việt, số và khoảng trắng")]
        public string TenKieuDang { get; set; }
        public string MoTa { get; set; }
        public bool TrangThai { get; set; }
    }
}
