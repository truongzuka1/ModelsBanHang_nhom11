namespace API.Models
{
    public class ThongBao
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string NoiDung { get; set; } = string.Empty;
        public DateTime ThoiGian { get; set; } = DateTime.Now;
        public bool DaXem { get; set; } = false;
    }

}