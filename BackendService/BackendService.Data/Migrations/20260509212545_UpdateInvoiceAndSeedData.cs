using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BackendService.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateInvoiceAndSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "CustomerId",
                table: "Invoices",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Invoices",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Invoices",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Invoices",
                type: "text",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedBy", "CreatedTime", "DeleteFlag", "Description", "ParentId", "TenDanhMuc", "UpdatedBy", "UpdatedTime" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), "", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, null, null, "Điện thoại", "", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("22222222-2222-2222-2222-222222222222"), "", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, null, null, "Laptop", "", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("33333333-3333-3333-3333-333333333333"), "", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, null, null, "Máy tính bảng", "", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("44444444-4444-4444-4444-444444444444"), "", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, null, null, "Phụ kiện", "", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("55555555-5555-5555-5555-555555555555"), "", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, null, null, "Đồng hồ", "", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                table: "DonViTinhs",
                columns: new[] { "Id", "CreatedBy", "CreatedTime", "DeleteFlag", "Description", "TenDonViTinh", "UpdatedBy", "UpdatedTime" },
                values: new object[] { new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "Đơn vị tính cơ bản", "Cái", "", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "Address", "CreatedBy", "CreatedTime", "DeleteFlag", "Email", "Identify", "PhoneNumber", "SupplierName", "UpdatedBy", "UpdatedTime" },
                values: new object[] { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "Hà Nội", "", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "contact@tongkho.com", 123456, 123456789, "Tổng kho điện máy", "", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Cost", "CreatedBy", "CreatedTime", "DeleteFlag", "Description", "DiscountPrice", "DonViTinhId", "Image_Url", "Price", "ProductName", "Status", "SupplierId", "UpdatedBy", "UpdatedTime" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("11111111-1111-1111-1111-111111111111"), 8000000m, "", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "Mô tả cho iPhone 15 Pro Max", 9000000m, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "https://picsum.photos/200/300", 10000000m, "iPhone 15 Pro Max", 2, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("22222222-2222-2222-2222-222222222222"), 8500000m, "", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "Mô tả cho Samsung Galaxy S24 Ultra", 9500000m, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "https://picsum.photos/200/300", 10500000m, "Samsung Galaxy S24 Ultra", 2, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new Guid("33333333-3333-3333-3333-333333333333"), 9000000m, "", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "Mô tả cho Google Pixel 8 Pro", 10000000m, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "https://picsum.photos/200/300", 11000000m, "Google Pixel 8 Pro", 2, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("44444444-4444-4444-4444-444444444444"), 9500000m, "", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "Mô tả cho Xiaomi 14 Ultra", 10500000m, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "https://picsum.photos/200/300", 11500000m, "Xiaomi 14 Ultra", 2, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-0000-000000000005"), new Guid("55555555-5555-5555-5555-555555555555"), 10000000m, "", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "Mô tả cho Oppo Find X7 Ultra", 11000000m, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "https://picsum.photos/200/300", 12000000m, "Oppo Find X7 Ultra", 2, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-0000-000000000006"), new Guid("11111111-1111-1111-1111-111111111111"), 10500000m, "", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "Mô tả cho MacBook Pro M3", 11500000m, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "https://picsum.photos/200/300", 12500000m, "MacBook Pro M3", 2, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-0000-000000000007"), new Guid("22222222-2222-2222-2222-222222222222"), 11000000m, "", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "Mô tả cho Dell XPS 15", 12000000m, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "https://picsum.photos/200/300", 13000000m, "Dell XPS 15", 2, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-0000-000000000008"), new Guid("33333333-3333-3333-3333-333333333333"), 11500000m, "", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "Mô tả cho HP Spectre x360", 12500000m, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "https://picsum.photos/200/300", 13500000m, "HP Spectre x360", 2, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-0000-000000000009"), new Guid("44444444-4444-4444-4444-444444444444"), 12000000m, "", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "Mô tả cho Asus ROG Zephyrus G14", 13000000m, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "https://picsum.photos/200/300", 14000000m, "Asus ROG Zephyrus G14", 2, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-0000-000000000010"), new Guid("55555555-5555-5555-5555-555555555555"), 12500000m, "", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "Mô tả cho Lenovo ThinkPad X1 Carbon", 13500000m, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "https://picsum.photos/200/300", 14500000m, "Lenovo ThinkPad X1 Carbon", 2, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-0000-000000000011"), new Guid("11111111-1111-1111-1111-111111111111"), 13000000m, "", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "Mô tả cho iPad Pro M2", 14000000m, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "https://picsum.photos/200/300", 15000000m, "iPad Pro M2", 2, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-0000-000000000012"), new Guid("22222222-2222-2222-2222-222222222222"), 13500000m, "", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "Mô tả cho Samsung Galaxy Tab S9", 14500000m, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "https://picsum.photos/200/300", 15500000m, "Samsung Galaxy Tab S9", 2, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-0000-000000000013"), new Guid("33333333-3333-3333-3333-333333333333"), 14000000m, "", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "Mô tả cho Surface Pro 9", 15000000m, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "https://picsum.photos/200/300", 16000000m, "Surface Pro 9", 2, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-0000-000000000014"), new Guid("44444444-4444-4444-4444-444444444444"), 14500000m, "", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "Mô tả cho Xiaomi Pad 6", 15500000m, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "https://picsum.photos/200/300", 16500000m, "Xiaomi Pad 6", 2, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-0000-000000000015"), new Guid("55555555-5555-5555-5555-555555555555"), 15000000m, "", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "Mô tả cho Lenovo Tab P12", 16000000m, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "https://picsum.photos/200/300", 17000000m, "Lenovo Tab P12", 2, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-0000-000000000016"), new Guid("11111111-1111-1111-1111-111111111111"), 15500000m, "", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "Mô tả cho AirPods Pro 2", 16500000m, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "https://picsum.photos/200/300", 17500000m, "AirPods Pro 2", 2, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-0000-000000000017"), new Guid("22222222-2222-2222-2222-222222222222"), 16000000m, "", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "Mô tả cho Sony WH-1000XM5", 17000000m, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "https://picsum.photos/200/300", 18000000m, "Sony WH-1000XM5", 2, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-0000-000000000018"), new Guid("33333333-3333-3333-3333-333333333333"), 16500000m, "", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "Mô tả cho Samsung Galaxy Buds2 Pro", 17500000m, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "https://picsum.photos/200/300", 18500000m, "Samsung Galaxy Buds2 Pro", 2, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-0000-000000000019"), new Guid("44444444-4444-4444-4444-444444444444"), 17000000m, "", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "Mô tả cho Logitech MX Master 3S", 18000000m, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "https://picsum.photos/200/300", 19000000m, "Logitech MX Master 3S", 2, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-0000-000000000020"), new Guid("55555555-5555-5555-5555-555555555555"), 17500000m, "", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "Mô tả cho Razer DeathAdder V3", 18500000m, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "https://picsum.photos/200/300", 19500000m, "Razer DeathAdder V3", 2, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-0000-000000000021"), new Guid("11111111-1111-1111-1111-111111111111"), 18000000m, "", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "Mô tả cho Apple Watch Series 9", 19000000m, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "https://picsum.photos/200/300", 20000000m, "Apple Watch Series 9", 2, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-0000-000000000022"), new Guid("22222222-2222-2222-2222-222222222222"), 18500000m, "", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "Mô tả cho Samsung Galaxy Watch 6", 19500000m, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "https://picsum.photos/200/300", 20500000m, "Samsung Galaxy Watch 6", 2, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-0000-000000000023"), new Guid("33333333-3333-3333-3333-333333333333"), 19000000m, "", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "Mô tả cho Garmin Fenix 7", 20000000m, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "https://picsum.photos/200/300", 21000000m, "Garmin Fenix 7", 2, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-0000-000000000024"), new Guid("44444444-4444-4444-4444-444444444444"), 19500000m, "", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "Mô tả cho Huawei Watch GT 4", 20500000m, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "https://picsum.photos/200/300", 21500000m, "Huawei Watch GT 4", 2, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-0000-000000000025"), new Guid("55555555-5555-5555-5555-555555555555"), 20000000m, "", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "Mô tả cho Amazfit GTR 4", 21000000m, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "https://picsum.photos/200/300", 22000000m, "Amazfit GTR 4", 2, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-0000-000000000026"), new Guid("11111111-1111-1111-1111-111111111111"), 20500000m, "", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "Mô tả cho iPhone 14", 21500000m, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "https://picsum.photos/200/300", 22500000m, "iPhone 14", 2, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-0000-000000000027"), new Guid("22222222-2222-2222-2222-222222222222"), 21000000m, "", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "Mô tả cho Samsung Galaxy A54", 22000000m, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "https://picsum.photos/200/300", 23000000m, "Samsung Galaxy A54", 2, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-0000-000000000028"), new Guid("33333333-3333-3333-3333-333333333333"), 21500000m, "", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "Mô tả cho MacBook Air M2", 22500000m, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "https://picsum.photos/200/300", 23500000m, "MacBook Air M2", 2, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-0000-000000000029"), new Guid("44444444-4444-4444-4444-444444444444"), 22000000m, "", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "Mô tả cho iPad Air 5", 23000000m, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "https://picsum.photos/200/300", 24000000m, "iPad Air 5", 2, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000000-0000-0000-0000-000000000030"), new Guid("55555555-5555-5555-5555-555555555555"), 22500000m, "", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "Mô tả cho Sony WF-1000XM5", 23500000m, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "https://picsum.photos/200/300", 24500000m, "Sony WF-1000XM5", 2, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_DonViTinhId",
                table: "Products",
                column: "DonViTinhId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_DonViTinhs_DonViTinhId",
                table: "Products",
                column: "DonViTinhId",
                principalTable: "DonViTinhs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_DonViTinhs_DonViTinhId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_DonViTinhId",
                table: "Products");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"));

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"));

            migrationBuilder.DeleteData(
                table: "DonViTinhs",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"));

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Invoices");

            migrationBuilder.AlterColumn<Guid>(
                name: "CustomerId",
                table: "Invoices",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);
        }
    }
}
