using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class cuong : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "KichCos",
                keyColumn: "KichCoId",
                keyValue: new Guid("03f9e68f-140c-43d2-85bc-45c098aa840e"));

            migrationBuilder.DeleteData(
                table: "KichCos",
                keyColumn: "KichCoId",
                keyValue: new Guid("119eb773-b4d2-4f7f-9f47-dff1a458a3bd"));

            migrationBuilder.DeleteData(
                table: "KichCos",
                keyColumn: "KichCoId",
                keyValue: new Guid("33bcf7d5-f030-4da0-8446-cc0650ca1fc4"));

            migrationBuilder.DeleteData(
                table: "KichCos",
                keyColumn: "KichCoId",
                keyValue: new Guid("3507d4e0-5bff-4201-8f0d-652bdfcf445e"));

            migrationBuilder.DeleteData(
                table: "KichCos",
                keyColumn: "KichCoId",
                keyValue: new Guid("35bd4d23-57e0-45d8-a861-8f2bfd74c80b"));

            migrationBuilder.DeleteData(
                table: "KichCos",
                keyColumn: "KichCoId",
                keyValue: new Guid("366d78ed-b84b-406b-999b-73e8141d68b5"));

            migrationBuilder.DeleteData(
                table: "KichCos",
                keyColumn: "KichCoId",
                keyValue: new Guid("390c40dc-d645-41db-a6c6-15a49c76bcf0"));

            migrationBuilder.DeleteData(
                table: "KichCos",
                keyColumn: "KichCoId",
                keyValue: new Guid("54a19d3a-99aa-4904-a3e9-d1ec64583574"));

            migrationBuilder.DeleteData(
                table: "KichCos",
                keyColumn: "KichCoId",
                keyValue: new Guid("940bb50a-acd4-41df-9f9b-a5a23934a089"));

            migrationBuilder.DeleteData(
                table: "KichCos",
                keyColumn: "KichCoId",
                keyValue: new Guid("9f35db6a-f480-4122-8017-bfceddd0ebb5"));

            migrationBuilder.DeleteData(
                table: "KichCos",
                keyColumn: "KichCoId",
                keyValue: new Guid("a2306dac-6784-49c5-b160-c36eacae2406"));

            migrationBuilder.DeleteData(
                table: "KichCos",
                keyColumn: "KichCoId",
                keyValue: new Guid("ab6b5a88-2307-4d8f-94bb-30227adfed34"));

            migrationBuilder.DeleteData(
                table: "KichCos",
                keyColumn: "KichCoId",
                keyValue: new Guid("b9a97407-4735-4e48-937f-9c920cd18f1f"));

            migrationBuilder.DeleteData(
                table: "KichCos",
                keyColumn: "KichCoId",
                keyValue: new Guid("be771506-4d53-4251-ae4d-5620085ca712"));

            migrationBuilder.DeleteData(
                table: "KichCos",
                keyColumn: "KichCoId",
                keyValue: new Guid("df77673c-7883-45c2-87f5-b85e805e906f"));

            migrationBuilder.DeleteData(
                table: "KichCos",
                keyColumn: "KichCoId",
                keyValue: new Guid("ebbcac53-480f-4272-aa1d-440d07e90fea"));

            migrationBuilder.DeleteData(
                table: "MauSacs",
                keyColumn: "MauSacId",
                keyValue: new Guid("124298e8-8f43-4b58-a9df-3e3081e73995"));

            migrationBuilder.DeleteData(
                table: "MauSacs",
                keyColumn: "MauSacId",
                keyValue: new Guid("13ce6a10-84be-4fff-afce-d1f7238b06b4"));

            migrationBuilder.DeleteData(
                table: "MauSacs",
                keyColumn: "MauSacId",
                keyValue: new Guid("453a1263-0f6d-4e5e-aeca-5c49c127b63c"));

            migrationBuilder.DeleteData(
                table: "MauSacs",
                keyColumn: "MauSacId",
                keyValue: new Guid("7ffbb495-975c-4bbf-b45d-d875e70bf99c"));

            migrationBuilder.DeleteData(
                table: "MauSacs",
                keyColumn: "MauSacId",
                keyValue: new Guid("94472d6b-c982-418c-a501-eb5347248ad7"));

            migrationBuilder.DeleteData(
                table: "MauSacs",
                keyColumn: "MauSacId",
                keyValue: new Guid("9ea70a42-824c-4df1-85f2-d6c7cf2907d0"));

            migrationBuilder.InsertData(
                table: "KichCos",
                columns: new[] { "KichCoId", "MoTa", "TenKichCo", "TrangThai", "size" },
                values: new object[,]
                {
                    { new Guid("176f04af-f14d-4a29-b724-72799e32e0e5"), "Cỡ giày 41", "Size 41", true, 41 },
                    { new Guid("3f6486a3-0720-4bc9-94f7-81c67a1f5ce6"), "Cỡ giày 43", "Size 43", true, 43 },
                    { new Guid("58c97e6e-2f08-4c07-bbe6-ea24dff46b72"), "Cỡ giày 50", "Size 50", true, 50 },
                    { new Guid("5a3f874f-35de-4f9f-a889-3c1f62d60abc"), "Cỡ giày 45", "Size 45", true, 45 },
                    { new Guid("68839e1a-aa5f-4d09-9a94-8f4e81314b41"), "Cỡ giày 44", "Size 44", true, 44 },
                    { new Guid("697d199c-6a49-4287-8421-b82d6f5dd8a3"), "Cỡ giày 46", "Size 46", true, 46 },
                    { new Guid("718f5991-829c-4704-b70d-ea6808fcb1d6"), "Cỡ giày 49", "Size 49", true, 49 },
                    { new Guid("8a1c3b4d-62ab-491f-8003-339952afaf11"), "Cỡ giày 35", "Size 35", true, 35 },
                    { new Guid("8c4a700e-051b-4a53-8139-db1147d039dd"), "Cỡ giày 47", "Size 47", true, 47 },
                    { new Guid("a03ff5e1-060a-4e20-a801-38fa14235336"), "Cỡ giày 42", "Size 42", true, 42 },
                    { new Guid("ae511527-30f7-4041-8a9a-c2a983351a08"), "Cỡ giày 40", "Size 40", true, 40 },
                    { new Guid("bb059590-ee77-4978-842d-78fdbe404877"), "Cỡ giày 37", "Size 37", true, 37 },
                    { new Guid("c2c28965-474a-4105-a335-1b07dc006fc7"), "Cỡ giày 48", "Size 48", true, 48 },
                    { new Guid("c545ddea-4c1e-47d6-be7e-3b44dd4c6eff"), "Cỡ giày 36", "Size 36", true, 36 },
                    { new Guid("da73a36d-33e7-4b07-9496-08da43213f71"), "Cỡ giày 39", "Size 39", true, 39 },
                    { new Guid("fed47760-bd9f-404d-b5f7-6396022ce749"), "Cỡ giày 38", "Size 38", true, 38 }
                });

            migrationBuilder.InsertData(
                table: "MauSacs",
                columns: new[] { "MauSacId", "Color", "MoTa", "TenMau", "TrangThai" },
                values: new object[,]
                {
                    { new Guid("10468e6e-ff38-47a7-a413-a221ef7b5049"), "#000000", "Màu đen", "Đen", true },
                    { new Guid("178af05d-ad49-4f28-9184-b14ef8e60a02"), "#FFFF00", "Màu vàng", "Vàng", true },
                    { new Guid("3262cb6a-e0a1-476f-ab04-592d482c470a"), "#0000FF", "Màu xanh dương cơ bản", "Xanh dương", true },
                    { new Guid("4d0da789-d73a-4aaa-a5f6-55206420b79a"), "#FFFFFF", "Màu trắng", "Trắng", true },
                    { new Guid("5be650c4-a2e1-4b24-b8e0-6e855c406848"), "#00FF00", "Màu xanh lá cây", "Xanh lá", true },
                    { new Guid("83fa58e5-f22c-4447-b9f1-29d34ee4fb6f"), "#FF0000", "Màu đỏ cơ bản", "Đỏ", true }
                });

            migrationBuilder.UpdateData(
                table: "NhanViens",
                keyColumn: "NhanVienId",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                column: "NgayCapNhatCuoiCung",
                value: new DateTime(2025, 7, 11, 15, 23, 48, 375, DateTimeKind.Local).AddTicks(1120));

            migrationBuilder.UpdateData(
                table: "TaiKhoans",
                keyColumn: "TaikhoanId",
                keyValue: new Guid("99999999-9999-9999-9999-999999999999"),
                column: "Ngaytaotaikhoan",
                value: new DateTime(2025, 7, 11, 15, 23, 48, 375, DateTimeKind.Local).AddTicks(1003));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "KichCos",
                keyColumn: "KichCoId",
                keyValue: new Guid("176f04af-f14d-4a29-b724-72799e32e0e5"));

            migrationBuilder.DeleteData(
                table: "KichCos",
                keyColumn: "KichCoId",
                keyValue: new Guid("3f6486a3-0720-4bc9-94f7-81c67a1f5ce6"));

            migrationBuilder.DeleteData(
                table: "KichCos",
                keyColumn: "KichCoId",
                keyValue: new Guid("58c97e6e-2f08-4c07-bbe6-ea24dff46b72"));

            migrationBuilder.DeleteData(
                table: "KichCos",
                keyColumn: "KichCoId",
                keyValue: new Guid("5a3f874f-35de-4f9f-a889-3c1f62d60abc"));

            migrationBuilder.DeleteData(
                table: "KichCos",
                keyColumn: "KichCoId",
                keyValue: new Guid("68839e1a-aa5f-4d09-9a94-8f4e81314b41"));

            migrationBuilder.DeleteData(
                table: "KichCos",
                keyColumn: "KichCoId",
                keyValue: new Guid("697d199c-6a49-4287-8421-b82d6f5dd8a3"));

            migrationBuilder.DeleteData(
                table: "KichCos",
                keyColumn: "KichCoId",
                keyValue: new Guid("718f5991-829c-4704-b70d-ea6808fcb1d6"));

            migrationBuilder.DeleteData(
                table: "KichCos",
                keyColumn: "KichCoId",
                keyValue: new Guid("8a1c3b4d-62ab-491f-8003-339952afaf11"));

            migrationBuilder.DeleteData(
                table: "KichCos",
                keyColumn: "KichCoId",
                keyValue: new Guid("8c4a700e-051b-4a53-8139-db1147d039dd"));

            migrationBuilder.DeleteData(
                table: "KichCos",
                keyColumn: "KichCoId",
                keyValue: new Guid("a03ff5e1-060a-4e20-a801-38fa14235336"));

            migrationBuilder.DeleteData(
                table: "KichCos",
                keyColumn: "KichCoId",
                keyValue: new Guid("ae511527-30f7-4041-8a9a-c2a983351a08"));

            migrationBuilder.DeleteData(
                table: "KichCos",
                keyColumn: "KichCoId",
                keyValue: new Guid("bb059590-ee77-4978-842d-78fdbe404877"));

            migrationBuilder.DeleteData(
                table: "KichCos",
                keyColumn: "KichCoId",
                keyValue: new Guid("c2c28965-474a-4105-a335-1b07dc006fc7"));

            migrationBuilder.DeleteData(
                table: "KichCos",
                keyColumn: "KichCoId",
                keyValue: new Guid("c545ddea-4c1e-47d6-be7e-3b44dd4c6eff"));

            migrationBuilder.DeleteData(
                table: "KichCos",
                keyColumn: "KichCoId",
                keyValue: new Guid("da73a36d-33e7-4b07-9496-08da43213f71"));

            migrationBuilder.DeleteData(
                table: "KichCos",
                keyColumn: "KichCoId",
                keyValue: new Guid("fed47760-bd9f-404d-b5f7-6396022ce749"));

            migrationBuilder.DeleteData(
                table: "MauSacs",
                keyColumn: "MauSacId",
                keyValue: new Guid("10468e6e-ff38-47a7-a413-a221ef7b5049"));

            migrationBuilder.DeleteData(
                table: "MauSacs",
                keyColumn: "MauSacId",
                keyValue: new Guid("178af05d-ad49-4f28-9184-b14ef8e60a02"));

            migrationBuilder.DeleteData(
                table: "MauSacs",
                keyColumn: "MauSacId",
                keyValue: new Guid("3262cb6a-e0a1-476f-ab04-592d482c470a"));

            migrationBuilder.DeleteData(
                table: "MauSacs",
                keyColumn: "MauSacId",
                keyValue: new Guid("4d0da789-d73a-4aaa-a5f6-55206420b79a"));

            migrationBuilder.DeleteData(
                table: "MauSacs",
                keyColumn: "MauSacId",
                keyValue: new Guid("5be650c4-a2e1-4b24-b8e0-6e855c406848"));

            migrationBuilder.DeleteData(
                table: "MauSacs",
                keyColumn: "MauSacId",
                keyValue: new Guid("83fa58e5-f22c-4447-b9f1-29d34ee4fb6f"));

            migrationBuilder.InsertData(
                table: "KichCos",
                columns: new[] { "KichCoId", "MoTa", "TenKichCo", "TrangThai", "size" },
                values: new object[,]
                {
                    { new Guid("03f9e68f-140c-43d2-85bc-45c098aa840e"), "Cỡ giày 50", "Size 50", true, 50 },
                    { new Guid("119eb773-b4d2-4f7f-9f47-dff1a458a3bd"), "Cỡ giày 48", "Size 48", true, 48 },
                    { new Guid("33bcf7d5-f030-4da0-8446-cc0650ca1fc4"), "Cỡ giày 43", "Size 43", true, 43 },
                    { new Guid("3507d4e0-5bff-4201-8f0d-652bdfcf445e"), "Cỡ giày 45", "Size 45", true, 45 },
                    { new Guid("35bd4d23-57e0-45d8-a861-8f2bfd74c80b"), "Cỡ giày 42", "Size 42", true, 42 },
                    { new Guid("366d78ed-b84b-406b-999b-73e8141d68b5"), "Cỡ giày 36", "Size 36", true, 36 },
                    { new Guid("390c40dc-d645-41db-a6c6-15a49c76bcf0"), "Cỡ giày 47", "Size 47", true, 47 },
                    { new Guid("54a19d3a-99aa-4904-a3e9-d1ec64583574"), "Cỡ giày 39", "Size 39", true, 39 },
                    { new Guid("940bb50a-acd4-41df-9f9b-a5a23934a089"), "Cỡ giày 37", "Size 37", true, 37 },
                    { new Guid("9f35db6a-f480-4122-8017-bfceddd0ebb5"), "Cỡ giày 44", "Size 44", true, 44 },
                    { new Guid("a2306dac-6784-49c5-b160-c36eacae2406"), "Cỡ giày 35", "Size 35", true, 35 },
                    { new Guid("ab6b5a88-2307-4d8f-94bb-30227adfed34"), "Cỡ giày 40", "Size 40", true, 40 },
                    { new Guid("b9a97407-4735-4e48-937f-9c920cd18f1f"), "Cỡ giày 46", "Size 46", true, 46 },
                    { new Guid("be771506-4d53-4251-ae4d-5620085ca712"), "Cỡ giày 41", "Size 41", true, 41 },
                    { new Guid("df77673c-7883-45c2-87f5-b85e805e906f"), "Cỡ giày 49", "Size 49", true, 49 },
                    { new Guid("ebbcac53-480f-4272-aa1d-440d07e90fea"), "Cỡ giày 38", "Size 38", true, 38 }
                });

            migrationBuilder.InsertData(
                table: "MauSacs",
                columns: new[] { "MauSacId", "Color", "MoTa", "TenMau", "TrangThai" },
                values: new object[,]
                {
                    { new Guid("124298e8-8f43-4b58-a9df-3e3081e73995"), "#000000", "Màu đen", "Đen", true },
                    { new Guid("13ce6a10-84be-4fff-afce-d1f7238b06b4"), "#0000FF", "Màu xanh dương cơ bản", "Xanh dương", true },
                    { new Guid("453a1263-0f6d-4e5e-aeca-5c49c127b63c"), "#FF0000", "Màu đỏ cơ bản", "Đỏ", true },
                    { new Guid("7ffbb495-975c-4bbf-b45d-d875e70bf99c"), "#FFFF00", "Màu vàng", "Vàng", true },
                    { new Guid("94472d6b-c982-418c-a501-eb5347248ad7"), "#00FF00", "Màu xanh lá cây", "Xanh lá", true },
                    { new Guid("9ea70a42-824c-4df1-85f2-d6c7cf2907d0"), "#FFFFFF", "Màu trắng", "Trắng", true }
                });

            migrationBuilder.UpdateData(
                table: "NhanViens",
                keyColumn: "NhanVienId",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                column: "NgayCapNhatCuoiCung",
                value: new DateTime(2025, 7, 4, 0, 21, 11, 550, DateTimeKind.Local).AddTicks(5225));

            migrationBuilder.UpdateData(
                table: "TaiKhoans",
                keyColumn: "TaikhoanId",
                keyValue: new Guid("99999999-9999-9999-9999-999999999999"),
                column: "Ngaytaotaikhoan",
                value: new DateTime(2025, 7, 4, 0, 21, 11, 550, DateTimeKind.Local).AddTicks(5144));
        }
    }
}
