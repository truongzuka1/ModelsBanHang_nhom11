using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class huy1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "NhanViens",
                keyColumn: "NhanVienId",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                column: "NgayCapNhatCuoiCung",
                value: new DateTime(2025, 6, 16, 11, 18, 7, 682, DateTimeKind.Local).AddTicks(7185));

            migrationBuilder.UpdateData(
                table: "TaiKhoans",
                keyColumn: "TaikhoanId",
                keyValue: new Guid("99999999-9999-9999-9999-999999999999"),
                column: "Ngaytaotaikhoan",
                value: new DateTime(2025, 6, 16, 11, 18, 7, 682, DateTimeKind.Local).AddTicks(7124));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "NhanViens",
                keyColumn: "NhanVienId",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                column: "NgayCapNhatCuoiCung",
                value: new DateTime(2025, 6, 16, 11, 16, 57, 101, DateTimeKind.Local).AddTicks(3420));

            migrationBuilder.UpdateData(
                table: "TaiKhoans",
                keyColumn: "TaikhoanId",
                keyValue: new Guid("99999999-9999-9999-9999-999999999999"),
                column: "Ngaytaotaikhoan",
                value: new DateTime(2025, 6, 16, 11, 16, 57, 101, DateTimeKind.Local).AddTicks(3352));
        }
    }
}
