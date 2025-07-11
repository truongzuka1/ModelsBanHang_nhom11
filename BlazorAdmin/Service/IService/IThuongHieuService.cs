﻿using Data.Models;

namespace BlazorAdmin.Service.IService
{
    public interface IThuongHieuService
    {
        Task<List<ThuongHieu>> GetAllAsync();
        Task<ThuongHieu> GetByIdAsync(Guid id);
        Task CreateAsync(ThuongHieu obj);
        Task UpdateAsync(ThuongHieu obj);
        Task DeleteAsync(Guid id);
    }
}
