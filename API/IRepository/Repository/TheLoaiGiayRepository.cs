using API.Models;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.IRepository.Repository
{
    public class NhanVienRepository : INhanVienRepository
    {
        private readonly DbContextApp _db;

        public NhanVienRepository(DbContextApp db)
        {
            _db = db;
        }

        public async Task CreateNhanVien(NhanVien nhanVien)
        {
            try
            {
                if (nhanVien.TaikhoanId == Guid.Empty)
                {
                    nhanVien.TaikhoanId = null;
                }

                if (nhanVien.ChucVuId == null || nhanVien.ChucVuId == Guid.Empty)
                {
                    nhanVien.ChucVuId = Guid.Parse("22222222-2222-2222-2222-222222222222");
                }

                nhanVien.NgayCapNhatCuoiCung = DateTime.Now;

                _db.NhanViens.Add(nhanVien);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi tạo nhân viên: {ex.Message}");
            }
        }

        public async Task DeleteNhanVienAsync(Guid nhanVienId)
        {
            try
            {
                var nhanVien = await GetByIdNhanVienAsync(nhanVienId);
                if (nhanVien != null)
                {
                    _db.NhanViens.Remove(nhanVien);
                    await _db.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi xoá nhân viên: {ex.Message}");
            }
        }

        public async Task<List<NhanVien>> GetAllNhanVienAsync()
        {
            return await _db.NhanViens.ToListAsync();
        }

        public async Task<NhanVien> GetByIdNhanVienAsync(Guid nhanVienId)
        {
            try
            {
                return await _db.NhanViens.FindAsync(nhanVienId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi tìm nhân viên theo ID: {ex.Message}");
            }
        }

        public async Task UpdateNhanVienAsync(NhanVien nhanVien)
        {
            try
            {
                nhanVien.NgayCapNhatCuoiCung = DateTime.Now;
                _db.NhanViens.Update(nhanVien);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật nhân viên: {ex.Message}");
            }
        }
    }
}
