//using API.Models.DTO;
//using Data.Models;

//namespace API.IService
//{
//    public interface IKichCoService
//    {
//        Task<List<KichCoDTO>> GetAllAsync();
//        Task<KichCoDTO> GetByIdAsync(Guid id);
//        Task<bool> CreateAsync(KichCoDTO dto);
//        Task<bool> UpdateAsync(KichCoDTO dto);
//        Task<bool> DeleteAsync(Guid id);

//        Task<bool> AddKichCoToGiayChiTiet(Guid giayChiTietId, Guid kichCoId);
//        Task<bool> RemoveKichCoFromGiayChiTiet(Guid giayChiTietId, Guid kichCoId);
//        Task<List<KichCoDTO>> GetKichCosByGiayIdAsync(Guid giayChiTietId);
//    }
//}