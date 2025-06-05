using API.IRepository;
using API.IService;
using Data.Models;

namespace API.Service
{
    public class TheLoaiGiayService : ITheLoaiGiayService
    {
        private readonly ITheLoaiGiayRepository _theLoaiGiayRepository;

        public TheLoaiGiayService(ITheLoaiGiayRepository theLoaiGiayRepository)
        {
            _theLoaiGiayRepository = theLoaiGiayRepository;
        }

        public async Task<IEnumerable<TheLoaiGiay>> GetAllAsync()
        {
            return await _theLoaiGiayRepository.GetAllAsync();
        }

        public async Task<TheLoaiGiay> GetByIdAsync(Guid id)
        {
            return await _theLoaiGiayRepository.GetByIdAsync(id);
        }

        public async Task<TheLoaiGiay> AddAsync(TheLoaiGiay theLoaiGiay)
        {
            return await _theLoaiGiayRepository.AddAsync(theLoaiGiay);
        }

        public async Task<TheLoaiGiay> UpdateAsync(TheLoaiGiay theLoaiGiay)
        {
            return await _theLoaiGiayRepository.UpdateAsync(theLoaiGiay);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _theLoaiGiayRepository.DeleteAsync(id);
        }

        public async Task<TheLoaiGiay> GetTheLoaiByGiayChiTietIdAsync(Guid giayChiTietId)
        {
            return await _theLoaiGiayRepository.GetTheLoaiByGiayChiTietIdAsync(giayChiTietId);
        }
    }
}