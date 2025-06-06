using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repositories
{
	public class KhachHangRepository : IKhachHangRepository
	{
		private readonly DbContextApp _db;

		public KhachHangRepository(DbContextApp db)
		{
			_db = db;
		}

		public async Task<List<KhachHang>> GetAllAsync()
		{
			return await _db.KhachHangs
				.Include(kh => kh.TaiKhoan)
				.Include(kh => kh.HoaDons)
				.Include(kh => kh.DiaChiKhachHangs)
				.Include(kh => kh.GioHangs)
				.ToListAsync();
		}

		public async Task AddAsync(KhachHang khachhang)
		{
			try
			{
				await _db.KhachHangs.AddAsync(khachhang);
				await _db.SaveChangesAsync();
			}
			catch (Exception)
			{
				throw;
			}
		}

		public async Task UpdateAsync(KhachHang khachhang)
		{
			try
			{
				_db.KhachHangs.Update(khachhang);
				await _db.SaveChangesAsync();
			}
			catch (Exception)
			{
				throw;
			}
		}

		public async Task DeleteAsync(Guid id)
		{
			try
			{
				var entity = await _db.KhachHangs.FindAsync(id);
				if (entity != null)
				{
					_db.KhachHangs.Remove(entity);
					await _db.SaveChangesAsync();
				}
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}