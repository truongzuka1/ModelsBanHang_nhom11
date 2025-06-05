using API.IRepository;
using API.IService;
using API.Models;
using Microsoft.AspNetCore.Http;

namespace API.Service
{
    public class AnhService : IAnhService
    {
        private readonly IAnhRepository _anhRepository;

        public AnhService(IAnhRepository anhRepository)
        {
            _anhRepository = anhRepository;
        }

        public async Task<IEnumerable<Anh>> GetAllAsync()
        {
            return await _anhRepository.GetAllAsync();
        }

        public async Task<Anh> GetByIdAsync(Guid id)
        {
            return await _anhRepository.GetByIdAsync(id);
        }

        public async Task<Anh> UploadAsync(IFormFile file, string tenAnh)
        {
            return await _anhRepository.UploadAsync(file, tenAnh);
        }

        public async Task<Anh> UpdateAsync(Anh anh)
        {
            return await _anhRepository.UpdateAsync(anh);
        }

        public async Task<Anh> UpdateFileAsync(Guid id, IFormFile file, string tenAnh)
        {
            return await _anhRepository.UpdateFileAsync(id, file, tenAnh);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _anhRepository.DeleteAsync(id);
        }
    }
}