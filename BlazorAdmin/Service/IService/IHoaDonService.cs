﻿using Data.Models;

namespace BlazorAdmin.Service.IService
{
    public interface IHoaDonService
    {
        Task Add(HoaDon hoaDon);
        Task<List<HoaDon>> GetAll();
        Task<HoaDon> GetById(Guid id);
        Task Update(HoaDon hoaDon);
        Task Delete(Guid id);
    }
}
