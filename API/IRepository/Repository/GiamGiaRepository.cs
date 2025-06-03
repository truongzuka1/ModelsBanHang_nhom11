using Data.Models;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace API.IRepository.Repository
{
    public class GiamGiaRepository : IGiamGiaRepository
    {
       

        Task<List<GiamGia>> IGiamGiaRepository.GetAllGiamGia()
        {
            throw new NotImplementedException();
        }

        Task<GiamGia> IGiamGiaRepository.GetByIdGIamGIa(Guid GiamGiaId)
        {
            throw new NotImplementedException();
        }

        Task IGiamGiaRepository.UpdateGiamGia(GiamGia GiamGia)
        {
            throw new NotImplementedException();
        }
        private readonly DbContextApp _db;

        public Task CreateGIamGia(GiamGia GiamGia)
        {
            throw new NotImplementedException();
        }

        public Task DeleteGiamGIa(Guid GiamGiaId)
        {
            throw new NotImplementedException();
        }
    }
}
