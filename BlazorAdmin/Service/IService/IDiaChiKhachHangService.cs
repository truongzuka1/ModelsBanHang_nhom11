using API.Models.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorAdmin.Service.IService
{
    public interface IDiaChiKhachHangService
    {
        Task<List<DiaChiKhachHangDTO>> GetAllAsync();
        Task<DiaChiKhachHangDTO> GetByIdAsync(Guid id);
        Task<List<DiaChiKhachHangDTO>> GetByKhachHangIdAsync(Guid khachHangId);
        Task<bool> CreateAsync(DiaChiKhachHangDTO dto);
        Task<bool> UpdateAsync(Guid id, DiaChiKhachHangDTO dto);
        Task<bool> DeleteAsync(Guid id);
    }
}
