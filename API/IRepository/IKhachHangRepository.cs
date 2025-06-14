using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Models;

namespace Data.Repositories
{
	public interface IKhachHangRepository
	{
        Task<IEnumerable<KhachHang>> GetAllAsync();
        Task<KhachHang?> GetByIdAsync(Guid id);
        Task<KhachHang?> GetByEmailAsync(string email);
        Task<KhachHang?> GetBySoDienThoaiAsync(string soDienThoai);
        Task AddAsync(KhachHang khachHang);
        Task UpdateAsync(KhachHang khachHang);
        Task DeleteAsync(Guid id);
        Task<bool> ExistsAsync(Guid id);
    }
}