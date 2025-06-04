using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace API.IRepository.Repository
{
    public class KichCoRepository : IKichCoRepository
    {
        public KichCoRepository(DbContextApp db)
        {
            _db = db;
        }

        public Task CreateKichCo(KichCo kichco)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteKichCo(Guid KichCoId)
        {
            try
            {
                var deletekichco = await _db.KichCos.FindAsync(KichCoId);
                if (deletekichco != null)
                {
                    _db.KichCos.Remove(deletekichco);
                    await _db.SaveChangesAsync();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<List<KichCo>> GetAllKichCo()
        {
            throw new NotImplementedException();
        }

        public Task<KichCo> GetByIdKichCo(Guid KichCoId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateKichCo(KichCo kichco)
        {
            throw new NotImplementedException();
        }
        private readonly DbContextApp _db;

        
        public async Task DeleteAnh(Guid AnhId)
        {
          
        }
        public async Task CreateAnh(Anh anh)
        {
            try
            {
                _db.Add(anh);
                await _db.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
        
    }
}
