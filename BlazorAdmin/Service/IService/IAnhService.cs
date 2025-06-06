using API.Models;
using Microsoft.AspNetCore.Components.Forms;

namespace BlazorAdmin.Service.IService
{
    public interface IAnhService
    {
        Task<List<Anh>> GetAllAsync();
        Task<Anh> GetByIdAsync(Guid id);
        Task<Anh> UploadAsync(IBrowserFile file, string tenAnh);
        Task<Anh> UpdateAsync(Anh anh);
        Task<Anh> UpdateFileAsync(Guid id, IBrowserFile file, string tenAnh);
        Task<bool> DeleteAsync(Guid id);
    }
}