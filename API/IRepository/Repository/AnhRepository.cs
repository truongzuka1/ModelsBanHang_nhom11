using Data.Models;

namespace API.IRepository.Repository
{
    public class AnhRepository : IAnhRepository
    {
        private readonly DbContextApp _dbContext;
        public AnhRepository(DbContextApp dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Create(Anh anh)
        {
            try
            {
                _dbContext.Anhs.Add(anh);
             await  _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public Task Delete(Guid AnhId)
        {
           
        }

        public Task<List<Anh>> GetAll()
        {
        }

        public Task<Anh> GetById(Guid AnhId)
        {
           
        }

        public Task Update(Anh anh)
        {
            
        }
    }
}
