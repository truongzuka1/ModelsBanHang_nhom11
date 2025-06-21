using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class democuacuong : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vouchers_TaiKhoans_TaikhoanId",
                table: "Vouchers");

            migrationBuilder.AlterColumn<Guid>(
                name: "TaikhoanId",
                table: "Vouchers",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "TaiKhoanId",
                table: "KhachHangs",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<string>(
                name: "GhiChu",
                table: "HoaDonChiTiets",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayTraHang",
                table: "HoaDonChiTiets",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TrangThaiChiTiet",
                table: "HoaDonChiTiets",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "NhanViens",
                keyColumn: "NhanVienId",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                column: "NgayCapNhatCuoiCung",
                value: new DateTime(2025, 6, 21, 13, 11, 17, 271, DateTimeKind.Local).AddTicks(6715));

            migrationBuilder.UpdateData(
                table: "TaiKhoans",
                keyColumn: "TaikhoanId",
                keyValue: new Guid("99999999-9999-9999-9999-999999999999"),
                column: "Ngaytaotaikhoan",
                value: new DateTime(2025, 6, 21, 13, 11, 17, 271, DateTimeKind.Local).AddTicks(6564));

            migrationBuilder.AddForeignKey(
                name: "FK_Vouchers_TaiKhoans_TaikhoanId",
                table: "Vouchers",
                column: "TaikhoanId",
                principalTable: "TaiKhoans",
                principalColumn: "TaikhoanId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vouchers_TaiKhoans_TaikhoanId",
                table: "Vouchers");

            migrationBuilder.DropColumn(
                name: "GhiChu",
                table: "HoaDonChiTiets");

            migrationBuilder.DropColumn(
                name: "NgayTraHang",
                table: "HoaDonChiTiets");

            migrationBuilder.DropColumn(
                name: "TrangThaiChiTiet",
                table: "HoaDonChiTiets");

            migrationBuilder.AlterColumn<Guid>(
                name: "TaikhoanId",
                table: "Vouchers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "TaiKhoanId",
                table: "KhachHangs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "NhanViens",
                keyColumn: "NhanVienId",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                column: "NgayCapNhatCuoiCung",
                value: new DateTime(2025, 6, 18, 10, 49, 32, 774, DateTimeKind.Local).AddTicks(5075));

            migrationBuilder.UpdateData(
                table: "TaiKhoans",
                keyColumn: "TaikhoanId",
                keyValue: new Guid("99999999-9999-9999-9999-999999999999"),
                column: "Ngaytaotaikhoan",
                value: new DateTime(2025, 6, 18, 10, 49, 32, 774, DateTimeKind.Local).AddTicks(5003));

            migrationBuilder.AddForeignKey(
                name: "FK_Vouchers_TaiKhoans_TaikhoanId",
                table: "Vouchers",
                column: "TaikhoanId",
                principalTable: "TaiKhoans",
                principalColumn: "TaikhoanId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
