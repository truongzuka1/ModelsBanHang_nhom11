using API.IRepository;
using API.IService;
using BlazorAdmin.Service.IService;
using Data.Models;

namespace API.Service
{
    public class DeGiayService : IDeGiayService
    {
        private readonly IDeGiayRepository _deGiayRepository;

        public DeGiayService(IDeGiayRepository deGiayRepository)
        {
            _deGiayRepository = deGiayRepository;
        }

        public async Task<IEnumerable<DeGiay>> GetAllAsync()
        {
            return await _deGiayRepository.GetAllDegiay();
        }

        public async Task<DeGiay> GetByIdAsync(Guid id)
        {
            return await _deGiayRepository.GetDeGiay(id);
        }

        public async Task CreateAsync(DeGiay deGiay)
        {
            await _deGiayRepository.CreateDeGiay(deGiay);
        }

        public async Task UpdateAsync(DeGiay deGiay)
        {
            await _deGiayRepository.UpdateDeGiay(deGiay);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _deGiayRepository.DeleteDeGiay(id);
        }
    }
}