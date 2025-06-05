using API.IRepository;
using API.IService;
using BlazorAdmin.Service.IService;
using Data.Models;

namespace API.Service
{
    public class GiayChiTietService : IGiayChiTietService
    {
        private readonly IGiayChiTietRepository _giayChiTietRepository;

        public GiayChiTietService(IGiayChiTietRepository giayChiTietRepository)
        {
            _giayChiTietRepository = giayChiTietRepository;
        }

        public async Task<IEnumerable<GiayChiTiet>> GetAllAsync()
        {
            return await _giayChiTietRepository.getAllGiayChiTiet();
        }

        public async Task<GiayChiTiet> GetByIdAsync(Guid id)
        {
            return await _giayChiTietRepository.getGiayChiTietbyID(id);
        }

        public async Task CreateAsync(GiayChiTiet gct, Guid? idDeGiay)
        {
            await _giayChiTietRepository.CreateGiayChiTiet(gct, idDeGiay);
        }

        public async Task UpdateAsync(GiayChiTiet gct, Guid? idDeGiay)
        {
            await _giayChiTietRepository.UpdateGiayChiTiet(gct, idDeGiay);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _giayChiTietRepository.DeleteGiayChiTiet(id);
        }
    }
}