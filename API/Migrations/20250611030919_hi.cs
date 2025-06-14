using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class hi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GiayChiTiets_Anhs_AnhId",
                table: "GiayChiTiets");

            migrationBuilder.DropForeignKey(
                name: "FK_GioHangChiTiets_Giays_GiaysGiayId",
                table: "GioHangChiTiets");

            migrationBuilder.DropForeignKey(
                name: "FK_HoaDonChiTiets_Giays_GiaysGiayId",
                table: "HoaDonChiTiets");

            migrationBuilder.DropIndex(
                name: "IX_GiayChiTiets_AnhId",
                table: "GiayChiTiets");

            migrationBuilder.DropColumn(
                name: "GiayChiTietId",
                table: "HoaDonChiTiets");

            migrationBuilder.DropColumn(
                name: "GiayChiTietId",
                table: "GioHangChiTiets");

            migrationBuilder.DropColumn(
                name: "AnhId",
                table: "GiayChiTiets");

            migrationBuilder.RenameColumn(
                name: "GiaysGiayId",
                table: "HoaDonChiTiets",
                newName: "GiayId");

            migrationBuilder.RenameIndex(
                name: "IX_HoaDonChiTiets_GiaysGiayId",
                table: "HoaDonChiTiets",
                newName: "IX_HoaDonChiTiets_GiayId");

            migrationBuilder.RenameColumn(
                name: "GiaysGiayId",
                table: "GioHangChiTiets",
                newName: "GiayId");

            migrationBuilder.RenameIndex(
                name: "IX_GioHangChiTiets_GiaysGiayId",
                table: "GioHangChiTiets",
                newName: "IX_GioHangChiTiets_GiayId");

            migrationBuilder.AddColumn<Guid>(
                name: "TaikhoanId1",
                table: "NhanViens",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "GiayChiTietId",
                table: "Anhs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "NhanViens",
                keyColumn: "NhanVienId",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "NgayCapNhatCuoiCung", "TaikhoanId1" },
                values: new object[] { new DateTime(2025, 6, 11, 10, 9, 18, 267, DateTimeKind.Local).AddTicks(901), null });

            migrationBuilder.UpdateData(
                table: "TaiKhoans",
                keyColumn: "TaikhoanId",
                keyValue: new Guid("99999999-9999-9999-9999-999999999999"),
                column: "Ngaytaotaikhoan",
                value: new DateTime(2025, 6, 11, 10, 9, 18, 267, DateTimeKind.Local).AddTicks(831));

            migrationBuilder.CreateIndex(
                name: "IX_NhanViens_TaikhoanId1",
                table: "NhanViens",
                column: "TaikhoanId1",
                unique: true,
                filter: "[TaikhoanId1] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Anhs_GiayChiTietId",
                table: "Anhs",
                column: "GiayChiTietId");

            migrationBuilder.AddForeignKey(
                name: "FK_Anhs_GiayChiTiets_GiayChiTietId",
                table: "Anhs",
                column: "GiayChiTietId",
                principalTable: "GiayChiTiets",
                principalColumn: "GiayChiTietId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GioHangChiTiets_Giays_GiayId",
                table: "GioHangChiTiets",
                column: "GiayId",
                principalTable: "Giays",
                principalColumn: "GiayId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HoaDonChiTiets_Giays_GiayId",
                table: "HoaDonChiTiets",
                column: "GiayId",
                principalTable: "Giays",
                principalColumn: "GiayId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NhanViens_TaiKhoans_TaikhoanId1",
                table: "NhanViens",
                column: "TaikhoanId1",
                principalTable: "TaiKhoans",
                principalColumn: "TaikhoanId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Anhs_GiayChiTiets_GiayChiTietId",
                table: "Anhs");

            migrationBuilder.DropForeignKey(
                name: "FK_GioHangChiTiets_Giays_GiayId",
                table: "GioHangChiTiets");

            migrationBuilder.DropForeignKey(
                name: "FK_HoaDonChiTiets_Giays_GiayId",
                table: "HoaDonChiTiets");

            migrationBuilder.DropForeignKey(
                name: "FK_NhanViens_TaiKhoans_TaikhoanId1",
                table: "NhanViens");

            migrationBuilder.DropIndex(
                name: "IX_NhanViens_TaikhoanId1",
                table: "NhanViens");

            migrationBuilder.DropIndex(
                name: "IX_Anhs_GiayChiTietId",
                table: "Anhs");

            migrationBuilder.DropColumn(
                name: "TaikhoanId1",
                table: "NhanViens");

            migrationBuilder.DropColumn(
                name: "GiayChiTietId",
                table: "Anhs");

            migrationBuilder.RenameColumn(
                name: "GiayId",
                table: "HoaDonChiTiets",
                newName: "GiaysGiayId");

            migrationBuilder.RenameIndex(
                name: "IX_HoaDonChiTiets_GiayId",
                table: "HoaDonChiTiets",
                newName: "IX_HoaDonChiTiets_GiaysGiayId");

            migrationBuilder.RenameColumn(
                name: "GiayId",
                table: "GioHangChiTiets",
                newName: "GiaysGiayId");

            migrationBuilder.RenameIndex(
                name: "IX_GioHangChiTiets_GiayId",
                table: "GioHangChiTiets",
                newName: "IX_GioHangChiTiets_GiaysGiayId");

            migrationBuilder.AddColumn<Guid>(
                name: "GiayChiTietId",
                table: "HoaDonChiTiets",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "GiayChiTietId",
                table: "GioHangChiTiets",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "AnhId",
                table: "GiayChiTiets",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "NhanViens",
                keyColumn: "NhanVienId",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                column: "NgayCapNhatCuoiCung",
                value: new DateTime(2025, 6, 7, 0, 52, 1, 977, DateTimeKind.Local).AddTicks(7606));

            migrationBuilder.UpdateData(
                table: "TaiKhoans",
                keyColumn: "TaikhoanId",
                keyValue: new Guid("99999999-9999-9999-9999-999999999999"),
                column: "Ngaytaotaikhoan",
                value: new DateTime(2025, 6, 7, 0, 52, 1, 977, DateTimeKind.Local).AddTicks(7512));

            migrationBuilder.CreateIndex(
                name: "IX_GiayChiTiets_AnhId",
                table: "GiayChiTiets",
                column: "AnhId");

            migrationBuilder.AddForeignKey(
                name: "FK_GiayChiTiets_Anhs_AnhId",
                table: "GiayChiTiets",
                column: "AnhId",
                principalTable: "Anhs",
                principalColumn: "AnhId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GioHangChiTiets_Giays_GiaysGiayId",
                table: "GioHangChiTiets",
                column: "GiaysGiayId",
                principalTable: "Giays",
                principalColumn: "GiayId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HoaDonChiTiets_Giays_GiaysGiayId",
                table: "HoaDonChiTiets",
                column: "GiaysGiayId",
                principalTable: "Giays",
                principalColumn: "GiayId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
