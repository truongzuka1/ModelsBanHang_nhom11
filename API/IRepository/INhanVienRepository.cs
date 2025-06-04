using API.Models;

namespace API.IRepository
{
    public interface INhanVienRepository
    {
            Task<List<NhanVien>> GetAllNhanVienAsync();
            Task<NhanVien> GetByIdNhanVienAsync(Guid NhanVienId);
            Task CreateNhanVien(NhanVien nhanVien);
            Task DeleteNhanVienAsync(Guid NhanVienId);
            Task UpdateNhanVienAsync(NhanVien nhanVien);
    }
}
