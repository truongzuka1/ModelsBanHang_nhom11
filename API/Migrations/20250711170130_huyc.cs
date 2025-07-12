using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class huyc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "KichCos",
                keyColumn: "KichCoId",
                keyValue: new Guid("12b004df-469b-4d32-a9c6-fcf530d8aae6"));

            migrationBuilder.DeleteData(
                table: "KichCos",
                keyColumn: "KichCoId",
                keyValue: new Guid("1ae9c20b-ad39-4edb-a5da-1191858277ac"));

            migrationBuilder.DeleteData(
                table: "KichCos",
                keyColumn: "KichCoId",
                keyValue: new Guid("1dfcdf55-694e-40a0-9b31-9e9dc30c2083"));

            migrationBuilder.DeleteData(
                table: "KichCos",
                keyColumn: "KichCoId",
                keyValue: new Guid("22e98e54-b459-458e-9cf3-b37d4fb0593d"));

            migrationBuilder.DeleteData(
                table: "KichCos",
                keyColumn: "KichCoId",
                keyValue: new Guid("3e6573a5-7011-4d26-8972-7b41030d43c7"));

            migrationBuilder.DeleteData(
                table: "KichCos",
                keyColumn: "KichCoId",
                keyValue: new Guid("4bfcca6c-022b-4048-98f6-32802eb2b6dd"));

            migrationBuilder.DeleteData(
                table: "KichCos",
                keyColumn: "KichCoId",
                keyValue: new Guid("71260003-807a-4c81-a688-b6daf8d536a8"));

            migrationBuilder.DeleteData(
                table: "KichCos",
                keyColumn: "KichCoId",
                keyValue: new Guid("78742740-5d45-4f05-828c-bd1b6a560080"));

            migrationBuilder.DeleteData(
                table: "KichCos",
                keyColumn: "KichCoId",
                keyValue: new Guid("819765e2-6a57-4f54-873f-7b3f9f000d13"));

            migrationBuilder.DeleteData(
                table: "KichCos",
                keyColumn: "KichCoId",
                keyValue: new Guid("8ed4b2dd-f6e5-4db6-9c29-518e70d34b49"));

            migrationBuilder.DeleteData(
                table: "KichCos",
                keyColumn: "KichCoId",
                keyValue: new Guid("90deb8b3-bd77-4acb-9a08-c23b20bbe698"));

            migrationBuilder.DeleteData(
                table: "KichCos",
                keyColumn: "KichCoId",
                keyValue: new Guid("9c81bc1f-d119-4e9b-9e0c-f4706dc291d1"));

            migrationBuilder.DeleteData(
                table: "KichCos",
                keyColumn: "KichCoId",
                keyValue: new Guid("a82aa67e-55ca-403c-a470-3942433134db"));

            migrationBuilder.DeleteData(
                table: "KichCos",
                keyColumn: "KichCoId",
                keyValue: new Guid("a8d93c0f-e048-43ad-8b8c-53a5663f0d2d"));

            migrationBuilder.DeleteData(
                table: "KichCos",
                keyColumn: "KichCoId",
                keyValue: new Guid("c84aa1ab-22e1-4e7c-83d3-0793956250d4"));

            migrationBuilder.DeleteData(
                table: "KichCos",
                keyColumn: "KichCoId",
                keyValue: new Guid("dffb4943-7ec1-4542-b3c2-7de05e03718f"));

            migrationBuilder.DeleteData(
                table: "MauSacs",
                keyColumn: "MauSacId",
                keyValue: new Guid("04cbd972-4d93-4d32-b4c7-d89fad507845"));

            migrationBuilder.DeleteData(
                table: "MauSacs",
                keyColumn: "MauSacId",
                keyValue: new Guid("0ce682d2-4368-4534-a30f-67c350f61b64"));

            migrationBuilder.DeleteData(
                table: "MauSacs",
                keyColumn: "MauSacId",
                keyValue: new Guid("2afc55a5-c6c5-43c6-8597-e1d057203adc"));

            migrationBuilder.DeleteData(
                table: "MauSacs",
                keyColumn: "MauSacId",
                keyValue: new Guid("d16a3053-0e84-46ef-b3cf-45280f66775d"));

            migrationBuilder.DeleteData(
                table: "MauSacs",
                keyColumn: "MauSacId",
                keyValue: new Guid("e459dd53-6f19-44ba-994e-667e7bd3fc18"));

            migrationBuilder.DeleteData(
                table: "MauSacs",
                keyColumn: "MauSacId",
                keyValue: new Guid("f698fceb-e0ef-47d4-921c-98b68edf5411"));

            migrationBuilder.InsertData(
                table: "KichCos",
                columns: new[] { "KichCoId", "MoTa", "TenKichCo", "TrangThai", "size" },
                values: new object[,]
                {
                    { new Guid("02738769-66d1-4019-b831-f9f6631b5786"), "Cỡ giày 36", "Size 36", true, 36 },
                    { new Guid("109d06f8-7ec1-4ec3-98a0-b42ced7f0896"), "Cỡ giày 50", "Size 50", true, 50 },
                    { new Guid("1d5190a5-9cad-435b-b0f0-047aa7510f23"), "Cỡ giày 44", "Size 44", true, 44 },
                    { new Guid("23f877e7-9cdd-4bef-a0ef-1cdeb277e597"), "Cỡ giày 42", "Size 42", true, 42 },
                    { new Guid("2b47267f-e5cf-4890-a4b9-cdf862c4afec"), "Cỡ giày 47", "Size 47", true, 47 },
                    { new Guid("3620d5f0-8618-4f63-8178-d6ee399fa2a0"), "Cỡ giày 46", "Size 46", true, 46 },
                    { new Guid("56798ff7-a5c4-4779-bf9c-97a12fb835aa"), "Cỡ giày 37", "Size 37", true, 37 },
                    { new Guid("57f71ffb-0206-4bec-801b-0ce3449287d7"), "Cỡ giày 48", "Size 48", true, 48 },
                    { new Guid("7cf3b2d9-9b79-44c8-9ec1-800d806ab829"), "Cỡ giày 38", "Size 38", true, 38 },
                    { new Guid("a0d340cc-69e1-47d8-bf98-66a41c18ff8b"), "Cỡ giày 45", "Size 45", true, 45 },
                    { new Guid("afc615da-6c10-4ae9-8862-7e0de710cec3"), "Cỡ giày 40", "Size 40", true, 40 },
                    { new Guid("be8165ed-b2e4-49dc-9ce5-b8ff4d179cb9"), "Cỡ giày 39", "Size 39", true, 39 },
                    { new Guid("ddfe3579-8c6e-466f-9103-3af9d841a0f0"), "Cỡ giày 43", "Size 43", true, 43 },
                    { new Guid("e1601acb-dfad-4628-b266-8f6edc541b1c"), "Cỡ giày 35", "Size 35", true, 35 },
                    { new Guid("fd3dba15-20b2-4c12-9fd5-fa173bfe4b6c"), "Cỡ giày 49", "Size 49", true, 49 },
                    { new Guid("ff6e3f59-1c7f-4039-b0da-0e91cf4ce66d"), "Cỡ giày 41", "Size 41", true, 41 }
                });

            migrationBuilder.InsertData(
                table: "MauSacs",
                columns: new[] { "MauSacId", "Color", "MoTa", "TenMau", "TrangThai" },
                values: new object[,]
                {
                    { new Guid("176b5a94-d6ce-4cdd-95f8-dbb56710fd79"), "#FF0000", "Màu đỏ cơ bản", "Đỏ", true },
                    { new Guid("33a82186-2305-4d25-b414-b8f5af0a246e"), "#0000FF", "Màu xanh dương cơ bản", "Xanh dương", true },
                    { new Guid("37f40d16-7265-4058-a1a4-e72bc5474150"), "#000000", "Màu đen", "Đen", true },
                    { new Guid("72e069de-9b39-436f-90a1-905b7d93b3f6"), "#FFFF00", "Màu vàng", "Vàng", true },
                    { new Guid("7eb3cfa8-f48c-4808-ba51-b06bc90d618a"), "#00FF00", "Màu xanh lá cây", "Xanh lá", true },
                    { new Guid("d2805797-de40-4334-881a-17461cd8de8a"), "#FFFFFF", "Màu trắng", "Trắng", true }
                });

            migrationBuilder.UpdateData(
                table: "NhanViens",
                keyColumn: "NhanVienId",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                column: "NgayCapNhatCuoiCung",
                value: new DateTime(2025, 7, 12, 0, 1, 30, 45, DateTimeKind.Local).AddTicks(2973));

            migrationBuilder.UpdateData(
                table: "TaiKhoans",
                keyColumn: "TaikhoanId",
                keyValue: new Guid("99999999-9999-9999-9999-999999999999"),
                column: "Ngaytaotaikhoan",
                value: new DateTime(2025, 7, 12, 0, 1, 30, 45, DateTimeKind.Local).AddTicks(2881));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "KichCos",
                keyColumn: "KichCoId",
                keyValue: new Guid("02738769-66d1-4019-b831-f9f6631b5786"));

            migrationBuilder.DeleteData(
                table: "KichCos",
                keyColumn: "KichCoId",
                keyValue: new Guid("109d06f8-7ec1-4ec3-98a0-b42ced7f0896"));

            migrationBuilder.DeleteData(
                table: "KichCos",
                keyColumn: "KichCoId",
                keyValue: new Guid("1d5190a5-9cad-435b-b0f0-047aa7510f23"));

            migrationBuilder.DeleteData(
                table: "KichCos",
                keyColumn: "KichCoId",
                keyValue: new Guid("23f877e7-9cdd-4bef-a0ef-1cdeb277e597"));

            migrationBuilder.DeleteData(
                table: "KichCos",
                keyColumn: "KichCoId",
                keyValue: new Guid("2b47267f-e5cf-4890-a4b9-cdf862c4afec"));

            migrationBuilder.DeleteData(
                table: "KichCos",
                keyColumn: "KichCoId",
                keyValue: new Guid("3620d5f0-8618-4f63-8178-d6ee399fa2a0"));

            migrationBuilder.DeleteData(
                table: "KichCos",
                keyColumn: "KichCoId",
                keyValue: new Guid("56798ff7-a5c4-4779-bf9c-97a12fb835aa"));

            migrationBuilder.DeleteData(
                table: "KichCos",
                keyColumn: "KichCoId",
                keyValue: new Guid("57f71ffb-0206-4bec-801b-0ce3449287d7"));

            migrationBuilder.DeleteData(
                table: "KichCos",
                keyColumn: "KichCoId",
                keyValue: new Guid("7cf3b2d9-9b79-44c8-9ec1-800d806ab829"));

            migrationBuilder.DeleteData(
                table: "KichCos",
                keyColumn: "KichCoId",
                keyValue: new Guid("a0d340cc-69e1-47d8-bf98-66a41c18ff8b"));

            migrationBuilder.DeleteData(
                table: "KichCos",
                keyColumn: "KichCoId",
                keyValue: new Guid("afc615da-6c10-4ae9-8862-7e0de710cec3"));

            migrationBuilder.DeleteData(
                table: "KichCos",
                keyColumn: "KichCoId",
                keyValue: new Guid("be8165ed-b2e4-49dc-9ce5-b8ff4d179cb9"));

            migrationBuilder.DeleteData(
                table: "KichCos",
                keyColumn: "KichCoId",
                keyValue: new Guid("ddfe3579-8c6e-466f-9103-3af9d841a0f0"));

            migrationBuilder.DeleteData(
                table: "KichCos",
                keyColumn: "KichCoId",
                keyValue: new Guid("e1601acb-dfad-4628-b266-8f6edc541b1c"));

            migrationBuilder.DeleteData(
                table: "KichCos",
                keyColumn: "KichCoId",
                keyValue: new Guid("fd3dba15-20b2-4c12-9fd5-fa173bfe4b6c"));

            migrationBuilder.DeleteData(
                table: "KichCos",
                keyColumn: "KichCoId",
                keyValue: new Guid("ff6e3f59-1c7f-4039-b0da-0e91cf4ce66d"));

            migrationBuilder.DeleteData(
                table: "MauSacs",
                keyColumn: "MauSacId",
                keyValue: new Guid("176b5a94-d6ce-4cdd-95f8-dbb56710fd79"));

            migrationBuilder.DeleteData(
                table: "MauSacs",
                keyColumn: "MauSacId",
                keyValue: new Guid("33a82186-2305-4d25-b414-b8f5af0a246e"));

            migrationBuilder.DeleteData(
                table: "MauSacs",
                keyColumn: "MauSacId",
                keyValue: new Guid("37f40d16-7265-4058-a1a4-e72bc5474150"));

            migrationBuilder.DeleteData(
                table: "MauSacs",
                keyColumn: "MauSacId",
                keyValue: new Guid("72e069de-9b39-436f-90a1-905b7d93b3f6"));

            migrationBuilder.DeleteData(
                table: "MauSacs",
                keyColumn: "MauSacId",
                keyValue: new Guid("7eb3cfa8-f48c-4808-ba51-b06bc90d618a"));

            migrationBuilder.DeleteData(
                table: "MauSacs",
                keyColumn: "MauSacId",
                keyValue: new Guid("d2805797-de40-4334-881a-17461cd8de8a"));

            migrationBuilder.InsertData(
                table: "KichCos",
                columns: new[] { "KichCoId", "MoTa", "TenKichCo", "TrangThai", "size" },
                values: new object[,]
                {
                    { new Guid("12b004df-469b-4d32-a9c6-fcf530d8aae6"), "Cỡ giày 47", "Size 47", true, 47 },
                    { new Guid("1ae9c20b-ad39-4edb-a5da-1191858277ac"), "Cỡ giày 36", "Size 36", true, 36 },
                    { new Guid("1dfcdf55-694e-40a0-9b31-9e9dc30c2083"), "Cỡ giày 49", "Size 49", true, 49 },
                    { new Guid("22e98e54-b459-458e-9cf3-b37d4fb0593d"), "Cỡ giày 41", "Size 41", true, 41 },
                    { new Guid("3e6573a5-7011-4d26-8972-7b41030d43c7"), "Cỡ giày 48", "Size 48", true, 48 },
                    { new Guid("4bfcca6c-022b-4048-98f6-32802eb2b6dd"), "Cỡ giày 46", "Size 46", true, 46 },
                    { new Guid("71260003-807a-4c81-a688-b6daf8d536a8"), "Cỡ giày 38", "Size 38", true, 38 },
                    { new Guid("78742740-5d45-4f05-828c-bd1b6a560080"), "Cỡ giày 39", "Size 39", true, 39 },
                    { new Guid("819765e2-6a57-4f54-873f-7b3f9f000d13"), "Cỡ giày 45", "Size 45", true, 45 },
                    { new Guid("8ed4b2dd-f6e5-4db6-9c29-518e70d34b49"), "Cỡ giày 42", "Size 42", true, 42 },
                    { new Guid("90deb8b3-bd77-4acb-9a08-c23b20bbe698"), "Cỡ giày 35", "Size 35", true, 35 },
                    { new Guid("9c81bc1f-d119-4e9b-9e0c-f4706dc291d1"), "Cỡ giày 37", "Size 37", true, 37 },
                    { new Guid("a82aa67e-55ca-403c-a470-3942433134db"), "Cỡ giày 40", "Size 40", true, 40 },
                    { new Guid("a8d93c0f-e048-43ad-8b8c-53a5663f0d2d"), "Cỡ giày 44", "Size 44", true, 44 },
                    { new Guid("c84aa1ab-22e1-4e7c-83d3-0793956250d4"), "Cỡ giày 43", "Size 43", true, 43 },
                    { new Guid("dffb4943-7ec1-4542-b3c2-7de05e03718f"), "Cỡ giày 50", "Size 50", true, 50 }
                });

            migrationBuilder.InsertData(
                table: "MauSacs",
                columns: new[] { "MauSacId", "Color", "MoTa", "TenMau", "TrangThai" },
                values: new object[,]
                {
                    { new Guid("04cbd972-4d93-4d32-b4c7-d89fad507845"), "#000000", "Màu đen", "Đen", true },
                    { new Guid("0ce682d2-4368-4534-a30f-67c350f61b64"), "#FF0000", "Màu đỏ cơ bản", "Đỏ", true },
                    { new Guid("2afc55a5-c6c5-43c6-8597-e1d057203adc"), "#FFFFFF", "Màu trắng", "Trắng", true },
                    { new Guid("d16a3053-0e84-46ef-b3cf-45280f66775d"), "#FFFF00", "Màu vàng", "Vàng", true },
                    { new Guid("e459dd53-6f19-44ba-994e-667e7bd3fc18"), "#00FF00", "Màu xanh lá cây", "Xanh lá", true },
                    { new Guid("f698fceb-e0ef-47d4-921c-98b68edf5411"), "#0000FF", "Màu xanh dương cơ bản", "Xanh dương", true }
                });

            migrationBuilder.UpdateData(
                table: "NhanViens",
                keyColumn: "NhanVienId",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                column: "NgayCapNhatCuoiCung",
                value: new DateTime(2025, 7, 11, 19, 30, 32, 638, DateTimeKind.Local).AddTicks(793));

            migrationBuilder.UpdateData(
                table: "TaiKhoans",
                keyColumn: "TaikhoanId",
                keyValue: new Guid("99999999-9999-9999-9999-999999999999"),
                column: "Ngaytaotaikhoan",
                value: new DateTime(2025, 7, 11, 19, 30, 32, 638, DateTimeKind.Local).AddTicks(696));
        }
    }
}
