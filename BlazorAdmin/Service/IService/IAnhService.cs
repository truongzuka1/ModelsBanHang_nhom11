using Data.Models;
using Microsoft.AspNetCore.Http;

namespace API.IService
{
    public interface IAnhService
    {
        Task<IEnumerable<Anh>> GetAllAsync();
        Task<Anh> GetByIdAsync(Guid id);
        Task<Anh> UploadAsync(IFormFile file, string tenAnh);
        Task<Anh> UpdateAsync(Anh anh);
        Task<Anh> UpdateFileAsync(Guid id, IFormFile file, string tenAnh);
        Task<bool> DeleteAsync(Guid id);
    }
}