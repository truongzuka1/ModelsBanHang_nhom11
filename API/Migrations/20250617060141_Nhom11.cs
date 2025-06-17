using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
<<<<<<<< HEAD:API/Migrations/20250616041657_huyd.cs
    public partial class huyd : Migration
========
    public partial class Nhom11 : Migration
>>>>>>>> 4168f10e50849ff8daf3c71b643e813282a1eef7:API/Migrations/20250617060141_Nhom11.cs
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChatLieus",
                columns: table => new
                {
                    ChatLieuId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenChatLieu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatLieus", x => x.ChatLieuId);
                });

            migrationBuilder.CreateTable(
                name: "ChucVus",
                columns: table => new
                {
                    ChucVuId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenChucVu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MotaChucVu = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChucVus", x => x.ChucVuId);
                });

            migrationBuilder.CreateTable(
                name: "DeGiays",
                columns: table => new
                {
                    DeGiayId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenDeGiay = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    KichCo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeGiays", x => x.DeGiayId);
                });

            migrationBuilder.CreateTable(
                name: "GiamGias",
                columns: table => new
                {
                    GiamGiaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenGiamGia = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SanPhamKhuyenMai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhanTramKhuyenMai = table.Column<float>(type: "real", nullable: false),
                    NgayBatDau = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayKetThuc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiamGias", x => x.GiamGiaId);
                });

            migrationBuilder.CreateTable(
                name: "Giays",
                columns: table => new
                {
                    GiayId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenGiay = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Giays", x => x.GiayId);
                });

            migrationBuilder.CreateTable(
                name: "hinhThucThanhToans",
                columns: table => new
                {
                    HinhThucThanhToanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenHinhThuc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hinhThucThanhToans", x => x.HinhThucThanhToanId);
                });

            migrationBuilder.CreateTable(
                name: "KichCos",
                columns: table => new
                {
                    KichCoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenKichCo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KichCos", x => x.KichCoId);
                });

            migrationBuilder.CreateTable(
                name: "KieuDangs",
                columns: table => new
                {
                    KieuDangId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenKieuDang = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KieuDangs", x => x.KieuDangId);
                });

            migrationBuilder.CreateTable(
                name: "MauSacs",
                columns: table => new
                {
                    MauSacId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenMau = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MauSacs", x => x.MauSacId);
                });

            migrationBuilder.CreateTable(
                name: "TaiKhoans",
                columns: table => new
                {
                    TaikhoanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ngaytaotaikhoan = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaiKhoans", x => x.TaikhoanId);
                });

            migrationBuilder.CreateTable(
                name: "TheLoaiGiays",
                columns: table => new
                {
                    TheLoaiGiayId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenTheLoai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TheLoaiGiays", x => x.TheLoaiGiayId);
                });

            migrationBuilder.CreateTable(
                name: "ThuongHieus",
                columns: table => new
                {
                    ThuongHieuId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenThuongHieu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SDT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThuongHieus", x => x.ThuongHieuId);
                });

            migrationBuilder.CreateTable(
                name: "GiayDotGiamGias",
                columns: table => new
                {
                    GiayDotGiamGiaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GiamGiaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GiayId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiayDotGiamGias", x => x.GiayDotGiamGiaId);
                    table.ForeignKey(
                        name: "FK_GiayDotGiamGias_GiamGias_GiamGiaId",
                        column: x => x.GiamGiaId,
                        principalTable: "GiamGias",
                        principalColumn: "GiamGiaId");
                    table.ForeignKey(
                        name: "FK_GiayDotGiamGias_Giays_GiayId",
                        column: x => x.GiayId,
                        principalTable: "Giays",
                        principalColumn: "GiayId");
                });

            migrationBuilder.CreateTable(
                name: "KhachHangs",
                columns: table => new
                {
                    KhachHangId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SoDienThoai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayCapNhatCuoiCung = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TaiKhoanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHangs", x => x.KhachHangId);
                    table.ForeignKey(
                        name: "FK_KhachHangs_TaiKhoans_TaiKhoanId",
                        column: x => x.TaiKhoanId,
                        principalTable: "TaiKhoans",
                        principalColumn: "TaikhoanId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NhanViens",
                columns: table => new
                {
                    NhanVienId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SoDienThoai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false),
                    ChucVuId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TaikhoanId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NgayCapNhatCuoiCung = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TaikhoanId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanViens", x => x.NhanVienId);
                    table.ForeignKey(
                        name: "FK_NhanViens_ChucVus_ChucVuId",
                        column: x => x.ChucVuId,
                        principalTable: "ChucVus",
                        principalColumn: "ChucVuId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NhanViens_TaiKhoans_TaikhoanId",
                        column: x => x.TaikhoanId,
                        principalTable: "TaiKhoans",
<<<<<<<< HEAD:API/Migrations/20250616041657_huyd.cs
                        principalColumn: "TaikhoanId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NhanViens_TaiKhoans_TaikhoanId1",
                        column: x => x.TaikhoanId1,
                        principalTable: "TaiKhoans",
========
>>>>>>>> 4168f10e50849ff8daf3c71b643e813282a1eef7:API/Migrations/20250617060141_Nhom11.cs
                        principalColumn: "TaikhoanId");
                });

            migrationBuilder.CreateTable(
                name: "Vouchers",
                columns: table => new
                {
                    VoucherId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenVoucher = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NgayBatDau = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayKetThuc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhanTram = table.Column<float>(type: "real", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    IdTaiKhoan = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TaikhoanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vouchers", x => x.VoucherId);
                    table.ForeignKey(
                        name: "FK_Vouchers_TaiKhoans_TaikhoanId",
                        column: x => x.TaikhoanId,
                        principalTable: "TaiKhoans",
                        principalColumn: "TaikhoanId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GiayChiTiets",
                columns: table => new
                {
                    GiayChiTietId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GiayId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ChatLieuId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    KichCoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MauSacId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ThuongHieuId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    KieuDangId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeGiayId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TheLoaiGiayId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SoLuongCon = table.Column<int>(type: "int", nullable: false),
                    AnhGiay = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgaySua = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gia = table.Column<float>(type: "real", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiayChiTiets", x => x.GiayChiTietId);
                    table.ForeignKey(
                        name: "FK_GiayChiTiets_ChatLieus_ChatLieuId",
                        column: x => x.ChatLieuId,
                        principalTable: "ChatLieus",
                        principalColumn: "ChatLieuId");
                    table.ForeignKey(
                        name: "FK_GiayChiTiets_DeGiays_DeGiayId",
                        column: x => x.DeGiayId,
                        principalTable: "DeGiays",
                        principalColumn: "DeGiayId");
                    table.ForeignKey(
                        name: "FK_GiayChiTiets_Giays_GiayId",
                        column: x => x.GiayId,
                        principalTable: "Giays",
                        principalColumn: "GiayId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GiayChiTiets_KichCos_KichCoId",
                        column: x => x.KichCoId,
                        principalTable: "KichCos",
                        principalColumn: "KichCoId");
                    table.ForeignKey(
                        name: "FK_GiayChiTiets_KieuDangs_KieuDangId",
                        column: x => x.KieuDangId,
                        principalTable: "KieuDangs",
                        principalColumn: "KieuDangId");
                    table.ForeignKey(
                        name: "FK_GiayChiTiets_MauSacs_MauSacId",
                        column: x => x.MauSacId,
                        principalTable: "MauSacs",
                        principalColumn: "MauSacId");
                    table.ForeignKey(
                        name: "FK_GiayChiTiets_TheLoaiGiays_TheLoaiGiayId",
                        column: x => x.TheLoaiGiayId,
                        principalTable: "TheLoaiGiays",
                        principalColumn: "TheLoaiGiayId");
                    table.ForeignKey(
                        name: "FK_GiayChiTiets_ThuongHieus_ThuongHieuId",
                        column: x => x.ThuongHieuId,
                        principalTable: "ThuongHieus",
                        principalColumn: "ThuongHieuId");
                });

            migrationBuilder.CreateTable(
                name: "diaChiKhachHangs",
                columns: table => new
                {
                    DiaChiKhachHangId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenDiaChi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    khachHangId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_diaChiKhachHangs", x => x.DiaChiKhachHangId);
                    table.ForeignKey(
                        name: "FK_diaChiKhachHangs_KhachHangs_khachHangId",
                        column: x => x.khachHangId,
                        principalTable: "KhachHangs",
                        principalColumn: "KhachHangId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GioHangs",
                columns: table => new
                {
                    GioHangId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NgayTaoGioHang = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayCapNhatCuoiCung = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false),
                    KhachHangId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GioHangs", x => x.GioHangId);
                    table.ForeignKey(
                        name: "FK_GioHangs_KhachHangs_KhachHangId",
                        column: x => x.KhachHangId,
                        principalTable: "KhachHangs",
                        principalColumn: "KhachHangId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HoaDons",
                columns: table => new
                {
                    HoaDonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaiKhoanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KhachHangId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    HinhThucThanhToanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VoucherId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TenCuaKhachHang = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SDTCuaKhachHang = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    EmailCuaKhachHang = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayNhanHang = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TongTienSauKhiGiam = table.Column<float>(type: "real", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDons", x => x.HoaDonId);
                    table.ForeignKey(
                        name: "FK_HoaDons_KhachHangs_KhachHangId",
                        column: x => x.KhachHangId,
                        principalTable: "KhachHangs",
                        principalColumn: "KhachHangId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HoaDons_TaiKhoans_TaiKhoanId",
                        column: x => x.TaiKhoanId,
                        principalTable: "TaiKhoans",
                        principalColumn: "TaikhoanId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HoaDons_Vouchers_VoucherId",
                        column: x => x.VoucherId,
                        principalTable: "Vouchers",
                        principalColumn: "VoucherId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_HoaDons_hinhThucThanhToans_HinhThucThanhToanId",
                        column: x => x.HinhThucThanhToanId,
                        principalTable: "hinhThucThanhToans",
                        principalColumn: "HinhThucThanhToanId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Anhs",
                columns: table => new
                {
                    AnhId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GiayChiTietId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DuongDan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenAnh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anhs", x => x.AnhId);
                    table.ForeignKey(
                        name: "FK_Anhs_GiayChiTiets_GiayChiTietId",
                        column: x => x.GiayChiTietId,
                        principalTable: "GiayChiTiets",
                        principalColumn: "GiayChiTietId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GioHangChiTiets",
                columns: table => new
                {
                    GioHangChiTietId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GioHangId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GiayId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SoLuongSanPham = table.Column<int>(type: "int", nullable: false),
                    Gia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayCapNhat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GioHangChiTiets", x => x.GioHangChiTietId);
                    table.ForeignKey(
                        name: "FK_GioHangChiTiets_Giays_GiayId",
                        column: x => x.GiayId,
                        principalTable: "Giays",
                        principalColumn: "GiayId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GioHangChiTiets_GioHangs_GioHangId",
                        column: x => x.GioHangId,
                        principalTable: "GioHangs",
                        principalColumn: "GioHangId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HoaDonChiTiets",
                columns: table => new
                {
                    HoaDonChiTietId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GiayId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HoaDonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SoLuongSanPham = table.Column<int>(type: "int", nullable: false),
                    Gia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDonChiTiets", x => x.HoaDonChiTietId);
                    table.ForeignKey(
                        name: "FK_HoaDonChiTiets_Giays_GiayId",
                        column: x => x.GiayId,
                        principalTable: "Giays",
                        principalColumn: "GiayId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HoaDonChiTiets_HoaDons_HoaDonId",
                        column: x => x.HoaDonId,
                        principalTable: "HoaDons",
                        principalColumn: "HoaDonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ChucVus",
                columns: new[] { "ChucVuId", "MotaChucVu", "TenChucVu", "TrangThai" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), "Quản trị hệ thống", "Admin", 1 },
                    { new Guid("22222222-2222-2222-2222-222222222222"), "Nhân viên bán hàng", "NhanVien", 1 }
                });

            migrationBuilder.InsertData(
                table: "TaiKhoans",
                columns: new[] { "TaikhoanId", "Ngaytaotaikhoan", "Password", "Username" },
<<<<<<<< HEAD:API/Migrations/20250616041657_huyd.cs
                values: new object[] { new Guid("99999999-9999-9999-9999-999999999999"), new DateTime(2025, 6, 16, 11, 16, 57, 101, DateTimeKind.Local).AddTicks(3352), "admin123", "admin" });

            migrationBuilder.InsertData(
                table: "NhanViens",
                columns: new[] { "NhanVienId", "ChucVuId", "Email", "HoTen", "NgayCapNhatCuoiCung", "NgaySinh", "SoDienThoai", "TaikhoanId", "TaikhoanId1", "TrangThai" },
                values: new object[] { new Guid("88888888-8888-8888-8888-888888888888"), new Guid("11111111-1111-1111-1111-111111111111"), "admin@shop.com", "Nguyễn Văn Quản Trị", new DateTime(2025, 6, 16, 11, 16, 57, 101, DateTimeKind.Local).AddTicks(3420), new DateTime(1995, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "0987654321", new Guid("99999999-9999-9999-9999-999999999999"), null, true });
========
                values: new object[] { new Guid("99999999-9999-9999-9999-999999999999"), new DateTime(2025, 6, 17, 13, 1, 40, 17, DateTimeKind.Local).AddTicks(3500), "admin123", "admin" });

            migrationBuilder.InsertData(
                table: "NhanViens",
                columns: new[] { "NhanVienId", "ChucVuId", "Email", "HoTen", "NgayCapNhatCuoiCung", "NgaySinh", "SoDienThoai", "TaikhoanId", "TrangThai" },
                values: new object[] { new Guid("88888888-8888-8888-8888-888888888888"), new Guid("11111111-1111-1111-1111-111111111111"), "admin@shop.com", "Nguyễn Văn Quản Trị", new DateTime(2025, 6, 17, 13, 1, 40, 17, DateTimeKind.Local).AddTicks(3656), new DateTime(1995, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "0987654321", new Guid("99999999-9999-9999-9999-999999999999"), true });
>>>>>>>> 4168f10e50849ff8daf3c71b643e813282a1eef7:API/Migrations/20250617060141_Nhom11.cs

            migrationBuilder.CreateIndex(
                name: "IX_Anhs_GiayChiTietId",
                table: "Anhs",
                column: "GiayChiTietId");

            migrationBuilder.CreateIndex(
                name: "IX_diaChiKhachHangs_khachHangId",
                table: "diaChiKhachHangs",
                column: "khachHangId");

            migrationBuilder.CreateIndex(
                name: "IX_GiayChiTiets_ChatLieuId",
                table: "GiayChiTiets",
                column: "ChatLieuId");

            migrationBuilder.CreateIndex(
                name: "IX_GiayChiTiets_DeGiayId",
                table: "GiayChiTiets",
                column: "DeGiayId");

            migrationBuilder.CreateIndex(
                name: "IX_GiayChiTiets_GiayId",
                table: "GiayChiTiets",
                column: "GiayId");

            migrationBuilder.CreateIndex(
                name: "IX_GiayChiTiets_KichCoId",
                table: "GiayChiTiets",
                column: "KichCoId");

            migrationBuilder.CreateIndex(
                name: "IX_GiayChiTiets_KieuDangId",
                table: "GiayChiTiets",
                column: "KieuDangId");

            migrationBuilder.CreateIndex(
                name: "IX_GiayChiTiets_MauSacId",
                table: "GiayChiTiets",
                column: "MauSacId");

            migrationBuilder.CreateIndex(
                name: "IX_GiayChiTiets_TheLoaiGiayId",
                table: "GiayChiTiets",
                column: "TheLoaiGiayId");

            migrationBuilder.CreateIndex(
                name: "IX_GiayChiTiets_ThuongHieuId",
                table: "GiayChiTiets",
                column: "ThuongHieuId");

            migrationBuilder.CreateIndex(
                name: "IX_GiayDotGiamGias_GiamGiaId",
                table: "GiayDotGiamGias",
                column: "GiamGiaId");

            migrationBuilder.CreateIndex(
                name: "IX_GiayDotGiamGias_GiayId",
                table: "GiayDotGiamGias",
                column: "GiayId");

            migrationBuilder.CreateIndex(
                name: "IX_GioHangChiTiets_GiayId",
                table: "GioHangChiTiets",
                column: "GiayId");

            migrationBuilder.CreateIndex(
                name: "IX_GioHangChiTiets_GioHangId",
                table: "GioHangChiTiets",
                column: "GioHangId");

            migrationBuilder.CreateIndex(
                name: "IX_GioHangs_KhachHangId",
                table: "GioHangs",
                column: "KhachHangId");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDonChiTiets_GiayId",
                table: "HoaDonChiTiets",
                column: "GiayId");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDonChiTiets_HoaDonId",
                table: "HoaDonChiTiets",
                column: "HoaDonId");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDons_HinhThucThanhToanId",
                table: "HoaDons",
                column: "HinhThucThanhToanId");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDons_KhachHangId",
                table: "HoaDons",
                column: "KhachHangId");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDons_TaiKhoanId",
                table: "HoaDons",
                column: "TaiKhoanId");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDons_VoucherId",
                table: "HoaDons",
                column: "VoucherId");

            migrationBuilder.CreateIndex(
                name: "IX_KhachHangs_TaiKhoanId",
                table: "KhachHangs",
                column: "TaiKhoanId");

            migrationBuilder.CreateIndex(
                name: "IX_NhanViens_ChucVuId",
                table: "NhanViens",
                column: "ChucVuId");

            migrationBuilder.CreateIndex(
                name: "IX_NhanViens_TaikhoanId",
                table: "NhanViens",
                column: "TaikhoanId",
                unique: true,
                filter: "[TaikhoanId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_NhanViens_TaikhoanId1",
                table: "NhanViens",
                column: "TaikhoanId1",
                unique: true,
                filter: "[TaikhoanId1] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Vouchers_TaikhoanId",
                table: "Vouchers",
                column: "TaikhoanId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Anhs");

            migrationBuilder.DropTable(
                name: "diaChiKhachHangs");

            migrationBuilder.DropTable(
                name: "GiayDotGiamGias");

            migrationBuilder.DropTable(
                name: "GioHangChiTiets");

            migrationBuilder.DropTable(
                name: "HoaDonChiTiets");

            migrationBuilder.DropTable(
                name: "NhanViens");

            migrationBuilder.DropTable(
                name: "GiayChiTiets");

            migrationBuilder.DropTable(
                name: "GiamGias");

            migrationBuilder.DropTable(
                name: "GioHangs");

            migrationBuilder.DropTable(
                name: "HoaDons");

            migrationBuilder.DropTable(
                name: "ChucVus");

            migrationBuilder.DropTable(
                name: "ChatLieus");

            migrationBuilder.DropTable(
                name: "DeGiays");

            migrationBuilder.DropTable(
                name: "Giays");

            migrationBuilder.DropTable(
                name: "KichCos");

            migrationBuilder.DropTable(
                name: "KieuDangs");

            migrationBuilder.DropTable(
                name: "MauSacs");

            migrationBuilder.DropTable(
                name: "TheLoaiGiays");

            migrationBuilder.DropTable(
                name: "ThuongHieus");

            migrationBuilder.DropTable(
                name: "KhachHangs");

            migrationBuilder.DropTable(
                name: "Vouchers");

            migrationBuilder.DropTable(
                name: "hinhThucThanhToans");

            migrationBuilder.DropTable(
                name: "TaiKhoans");
        }
    }
}
