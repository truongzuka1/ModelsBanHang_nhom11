using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Anh
    {
        public Guid AnhId { get; set; }
        public string DuongDan { get; set; }
        public string TenAnh { get; set; }
        public bool TrangThai { get; set; }
        public virtual ICollection<GiayChiTiet> GiayChiTiets { get; set; } = new List<GiayChiTiet>();

        public Anh()
        {
            AnhId = Guid.NewGuid();
            TrangThai = true;
        }
    }
}
