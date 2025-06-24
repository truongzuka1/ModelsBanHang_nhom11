using System.ComponentModel.DataAnnotations;

namespace API.Models.DTO
{
    public class KichCoDTO
    {
        public Guid KichCoId { get; set; }
        public string TenKichCo { get; set; }
        public float CanNang { get; set; }
        public decimal Gia { get; set; }
    }
}
