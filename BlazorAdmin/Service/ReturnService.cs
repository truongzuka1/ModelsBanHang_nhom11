using API.Controllers;
using API.IRepository;
using BlazorAdmin.Service.IService;
using Data.Models;

namespace BlazorAdmin.Service
{
    public class ReturnService : IReturnService
    {
        private readonly IReturnRepository _returnRepository;
        private readonly ITaiKhoanService _taiKhoanService;

        public ReturnService(IReturnRepository returnRepository, ITaiKhoanService taiKhoanService)
        {
            _returnRepository = returnRepository;
            _taiKhoanService = taiKhoanService;
        }

        public async Task<HoaDon> GetHoaDonByIdAsync(Guid hoaDonId)
        {
            return await _returnRepository.GetHoaDonByIdAsync(hoaDonId);
        }

        public async Task<List<HoaDonChiTiet>> GetHoaDonChiTietsByHoaDonIdAsync(Guid hoaDonId)
        {
            return await _returnRepository.GetHoaDonChiTietsByHoaDonIdAsync(hoaDonId);
        }

        public async Task<HoaDon> CreateReturnAsync(Guid hoaDonId, List<ReturnItemRequest> returnItems, Guid? voucherId, Guid taiKhoanId)
        {
            // Kiểm tra tài khoản
            var taiKhoan = await _taiKhoanService.GetByIdTaiKhoanAsync(taiKhoanId);
            if (taiKhoan == null)
                throw new Exception("Tài khoản không hợp lệ.");

            var hoaDonGoc = await _returnRepository.GetHoaDonByIdAsync(hoaDonId);
            if (hoaDonGoc == null || hoaDonGoc.TrangThai == "TraHang")
                throw new Exception("Hóa đơn không hợp lệ hoặc đã được trả hàng.");

            // Tính tổng tiền trả hàng
            var chiTiets = await _returnRepository.GetHoaDonChiTietsByHoaDonIdAsync(hoaDonId);
            float tongTienTra = 0;
            foreach (var item in returnItems)
            {
                var chiTiet = chiTiets.FirstOrDefault(c => c.GiayId == item.GiayId);
                if (chiTiet == null || item.SoLuongTra > chiTiet.SoLuongSanPham)
                    throw new Exception($"Sản phẩm {item.GiayId} không hợp lệ hoặc số lượng trả vượt quá số lượng mua.");
                tongTienTra += (float)chiTiet.Gia * item.SoLuongTra;
            }

            // Áp dụng voucher nếu có
            float phanTramGiam = 0;
            if (voucherId.HasValue)
            {
                var voucher = await _returnRepository.GetValidVoucherAsync(voucherId.Value);
                if (voucher != null)
                    phanTramGiam = voucher.PhanTram;
            }
            float tongTienSauGiam = tongTienTra * (1 - phanTramGiam / 100);

            // Tạo hóa đơn trả hàng
            var returnHoaDon = new HoaDon
            {
                HoaDonId = hoaDonId,
                TaiKhoanId = taiKhoanId, // Sử dụng tài khoản xử lý
                KhachHangId = hoaDonGoc.KhachHangId,
                HinhThucThanhToanId = hoaDonGoc.HinhThucThanhToanId,
                VoucherId = voucherId,
                TenCuaKhachHang = hoaDonGoc.TenCuaKhachHang,
                SDTCuaKhachHang = hoaDonGoc.SDTCuaKhachHang,
                EmailCuaKhachHang = hoaDonGoc.EmailCuaKhachHang,
                NgayTao = DateTime.Now,
                NgayNhanHang = DateTime.Now,
                TongTienSauKhiGiam = tongTienSauGiam,
                TrangThai = "TraHang",
                GhiChu = $"Hóa đơn trả hàng từ {hoaDonId} bởi tài khoản {taiKhoan.TaikhoanId}"
            };

            // Thêm chi tiết trả hàng
            returnHoaDon.HoaDonChiTietsId = returnItems.Select(item => new HoaDonChiTiet
            {
                GiayId = item.GiayId,
                SoLuongSanPham = item.SoLuongTra,
                Gia = chiTiets.First(c => c.GiayId == item.GiayId).Gia,
                TrangThai = true
            }).ToList();

            // Lưu hóa đơn trả hàng
            await _returnRepository.CreateReturnHoaDonAsync(returnHoaDon);
            foreach (var chiTiet in returnHoaDon.HoaDonChiTietsId)
            {
                await _returnRepository.CreateHoaDonChiTietAsync(chiTiet);
            }

            // Cập nhật trạng thái hóa đơn gốc
            hoaDonGoc.TrangThai = "DaTraHang";
            await _returnRepository.UpdateHoaDonAsync(hoaDonGoc);

            return returnHoaDon;
        }
    }
}
