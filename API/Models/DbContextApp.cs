using API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class DbContextApp : DbContext
    {
        public DbContextApp()
        {
            
        }

        public DbContextApp(DbContextOptions options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        {
    

            optionsBuilder.UseSqlServer(@"Data Source=.;Initial Catalog=DuanNhom11ModelsBanHang;Trusted_Connection=True;Integrated Security=True;TrustServerCertificate=True");



        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<GiayDotGiamGia>()
      .HasKey(gdg => gdg.GiayDotGiamGiaId);

            // Quan hệ GiayDotGiamGia - Giay (N-1)
            modelBuilder.Entity<GiayDotGiamGia>()
                .HasOne(gdg => gdg.Giay)
                .WithMany(g => g.GiayDotGiamGias)
                .HasForeignKey(gdg => gdg.GiayId);

            // Quan hệ GiayDotGiamGia - GiamGia (N-1)
            modelBuilder.Entity<GiayDotGiamGia>()
                .HasOne(gdg => gdg.GiamGia)
                .WithMany(g => g.GiayDotGiamGias)
                .HasForeignKey(gdg => gdg.GiamGiaId);
            modelBuilder.Entity<ChucVu>()
        .HasMany(cv => cv.nhanViens)
        .WithOne(nv => nv.ChucVu)
        .HasForeignKey(nv => nv.ChucVuId)
        .OnDelete(DeleteBehavior.Restrict);

            // Seed dữ liệu cứng: Admin và Nhân viên
            modelBuilder.Entity<ChucVu>().HasData(
                new ChucVu
                {
                    ChucVuId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    TenChucVu = "Admin",
                    MotaChucVu = "Quản trị hệ thống",
                    TrangThai = 1
                },
                new ChucVu
                {
                    ChucVuId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    TenChucVu = "NhanVien",
                    MotaChucVu = "Nhân viên bán hàng",
                    TrangThai = 1
                });
           
        

                    modelBuilder.Entity<NhanVien>()
                .HasOne(nv => nv.TaiKhoan)
                .WithMany()
                .HasForeignKey(nv => nv.TaikhoanId)
                .OnDelete(DeleteBehavior.Restrict);




            // NhanVien - ChucVu
            modelBuilder.Entity<NhanVien>()
                .HasOne(nv => nv.ChucVu)
                .WithMany(cv => cv.nhanViens)
                .HasForeignKey(nv => nv.ChucVuId)
                .OnDelete(DeleteBehavior.Restrict);


            // NhanVien - TaiKhoan
         

            //hoadon-taikhoan

            modelBuilder.Entity<HoaDon>()

                .HasOne(h => h.taiKhoan)
                .WithMany(t => t.hoaDons)
                .HasForeignKey(h => h.TaiKhoanId)
                .OnDelete(DeleteBehavior.Restrict); 
            //hoadon-Khachhang
            modelBuilder.Entity<HoaDon>()
                .HasOne(h => h.khachHang)
                .WithMany(t => t.HoaDons)

                .HasForeignKey(h => h.KhachHangId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<HoaDon>()

                .HasOne(h => h.hinhThucThanhToan)
                .WithMany(t => t.HoaDons)

                .HasForeignKey(h => h.HinhThucThanhToanId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<HoaDon>()

                .HasOne(h => h.voucher)
                .WithMany(t => t.HoaDons) 

                .HasForeignKey(h => h.VoucherId)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<KhachHang>()
           .HasOne(kh => kh.TaiKhoan)
           .WithMany()
           .HasForeignKey(kh => kh.TaiKhoanId)
           .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<HoaDonChiTiet>()
    .Property(x => x.Gia)
    .HasColumnType("decimal(18,2)");
        }
        public DbSet<KhachHang> KhachHangs { get; set; }

        public DbSet<TaiKhoan> TaiKhoans { get; set; }
        public DbSet<ChucVu> ChucVus { get; set; }
        public DbSet<NhanVien> NhanViens { get; set; }

        public DbSet<Giay> Giays { get; set; }
        public DbSet<GiayChiTiet> GiayChiTiets { get; set; }
        public DbSet<ChatLieu> ChatLieus { get; set; }
        public DbSet<MauSac> MauSacs { get; set; }
        public DbSet<KichCo> KichCos { get; set; }
        public DbSet<DeGiay> DeGiays { get; set; }
        public DbSet<Voucher> Vouchers { get; set; }
        public DbSet<GiamGia> GiamGias { get; set; }
        public DbSet<GiayDotGiamGia> GiayDotGiamGias { get; set; }
        public DbSet<ThuongHieu> ThuongHieus { get; set; }
        public DbSet<KieuDang> KieuDangs { get; set; }
        public DbSet<TheLoaiGiay> TheLoaiGiays { get; set; }
        public DbSet<Anh> Anhs { get; set; }
        public DbSet<HoaDon> HoaDons { get; set; }
        public DbSet<HoaDonChiTiet> HoaDonChiTiets { get; set; }
        public DbSet<GioHang> GioHangs { get; set; }
        public DbSet<GioHangChiTiet> GioHangChiTiets { get; set; }
        public DbSet<HinhThucThanhToan> hinhThucThanhToans { get; set; }
        public DbSet<DiaChiKhachHang> diaChiKhachHangs { get; set; }


    }
}
