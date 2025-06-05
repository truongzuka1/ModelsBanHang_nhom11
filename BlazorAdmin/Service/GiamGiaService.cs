using API.IRepository;
using API.IService;
using Data.Models;

namespace API.Service
{
    public class GiamGiaService : IGiamGiaService
    {
        private readonly IGiamGiaRepository _giamGiaRepository;

        public GiamGiaService(IGiamGiaRepository giamGiaRepository)
        {
            _giamGiaRepository = giamGiaRepository;
        }

        public async Task<IEnumerable<GiamGia>> GetAllAsync()
        {
            return await _giamGiaRepository.GetAllAsync();
        }

        public async Task<GiamGia> GetByIdAsync(Guid id)
        {
            return await _giamGiaRepository.GetByIdAsync(id);
        }

        public async Task<GiamGia> AddAsync(GiamGia giamGia)
        {
            return await _giamGiaRepository.AddAsync(giamGia);
        }

        public async Task<GiamGia> UpdateAsync(GiamGia giamGia)
        {
            return await _giamGiaRepository.UpdateAsync(giamGia);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _giamGiaRepository.DeleteAsync(id);
        }

        public async Task<bool> AddGiayToDotGiamGia(Guid giamGiaId, Guid giayId)
        {
            return await _giamGiaRepository.AddGiayToDotGiamGia(giamGiaId, giayId);
        }

        public async Task<bool> RemoveGiayFromDotGiamGia(Guid giamGiaId, Guid giayId)
        {
            return await _giamGiaRepository.RemoveGiayFromDotGiamGia(giamGiaId, giayId);
        }
    }
}