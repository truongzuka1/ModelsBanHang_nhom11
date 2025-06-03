using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class GiayDotGiamGia
    {
        [Key]
        public Guid GiayDotGiamGiaId { get; set; }
        public Guid ? GiamGiaId { get; set; }
        public Guid ? GiayId { get; set; }
        public virtual Giay Giay { get; set; }
        public virtual GiamGia GiamGia { get; set; }
       
    }
}
