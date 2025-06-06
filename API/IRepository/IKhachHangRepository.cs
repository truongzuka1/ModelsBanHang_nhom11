using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Models;

namespace Data.Repositories
{
	public interface IKhachHangRepository
	{
		Task<List<KhachHang>> GetAllAsync(); 
		Task AddAsync(KhachHang khachhang);
		Task UpdateAsync(KhachHang khachhang);
		Task DeleteAsync(Guid id);
	}
}