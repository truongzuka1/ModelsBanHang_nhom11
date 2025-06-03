using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class TaiKhoan_ChucVu
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid ChucVuId { get; set; }

        [Required]
        public Guid TaiKhoanId { get; set; }

        public ChucVu ChucVu { get; set; }
        public TaiKhoan TaiKhoan { get; set; }
    }
}
