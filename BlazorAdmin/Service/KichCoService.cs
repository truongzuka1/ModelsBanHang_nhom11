using API.IRepository;
using API.IService;
using Data.Models;

namespace API.Service
{
    public class KichCoService : IKichCoService
    {
        private readonly IKichCoRepository _kichCoRepository;

        public KichCoService(IKichCoRepository kichCoRepository)
        {
            _kichCoRepository = kichCoRepository;
        }

        public async Task<IEnumerable<KichCo>> GetAllAsync()
        {
            return await _kichCoRepository.GetAllAsync();
        }

        public async Task<KichCo> GetByIdAsync(Guid id)
        {
            return await _kichCoRepository.GetByIdAsync(id);
        }

        public async Task<KichCo> AddAsync(KichCo kichCo)
        {
            return await _kichCoRepository.AddAsync(kichCo);
        }

        public async Task<KichCo> UpdateAsync(KichCo kichCo)
        {
            return await _kichCoRepository.UpdateAsync(kichCo);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _kichCoRepository.DeleteAsync(id);
        }

        public async Task<bool> AddKichCoToGiayChiTiet(Guid giayChiTietId, Guid kichCoId)
        {
            return await _kichCoRepository.AddKichCoToGiayChiTiet(giayChiTietId, kichCoId);
        }

        public async Task<bool> RemoveKichCoFromGiayChiTiet(Guid giayChiTietId, Guid kichCoId)
        {
            return await _kichCoRepository.RemoveKichCoFromGiayChiTiet(giayChiTietId, kichCoId);
        }

        public async Task<IEnumerable<KichCo>> GetKichCosByGiayIdAsync(Guid giayChiTietId)
        {
            return await _kichCoRepository.GetKichCosByGiayIdAsync(giayChiTietId);
        }
    }
}