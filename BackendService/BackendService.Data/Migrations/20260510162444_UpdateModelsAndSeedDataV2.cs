using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BackendService.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModelsAndSeedDataV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Identify",
                table: "Suppliers",
                newName: "Status");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Suppliers",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<string>(
                name: "ContactName",
                table: "Suppliers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Field",
                table: "Suppliers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TaxCode",
                table: "Suppliers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SKU",
                table: "Products",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "CreatedTime", "TenDanhMuc", "UpdatedTime" },
                values: new object[] { new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), "Điện tử", new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                columns: new[] { "CreatedTime", "TenDanhMuc", "UpdatedTime" },
                values: new object[] { new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), "Gia dụng", new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "CreatedTime", "TenDanhMuc", "UpdatedTime" },
                values: new object[] { new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), "Thời trang", new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"),
                columns: new[] { "CreatedTime", "UpdatedTime" },
                values: new object[] { new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "CreatedTime", "TenDanhMuc", "UpdatedTime" },
                values: new object[] { new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), "Thực phẩm", new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "DonViTinhs",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
                columns: new[] { "CreatedTime", "UpdatedTime" },
                values: new object[] { new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.InsertData(
                table: "Inventories",
                columns: new[] { "Id", "CreatedBy", "CreatedTime", "DeleteFlag", "ProductId", "UpdatedBy", "UpdatedTime", "quantity" },
                values: new object[,]
                {
                    { new Guid("10000000-0000-0000-0000-000000000001"), "", new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), false, new Guid("00000000-0000-0000-0000-000000000001"), "", new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), 100 },
                    { new Guid("10000000-0000-0000-0000-000000000002"), "", new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), false, new Guid("00000000-0000-0000-0000-000000000002"), "", new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), 110 },
                    { new Guid("10000000-0000-0000-0000-000000000003"), "", new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), false, new Guid("00000000-0000-0000-0000-000000000003"), "", new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), 120 },
                    { new Guid("10000000-0000-0000-0000-000000000004"), "", new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), false, new Guid("00000000-0000-0000-0000-000000000004"), "", new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), 130 },
                    { new Guid("10000000-0000-0000-0000-000000000005"), "", new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), false, new Guid("00000000-0000-0000-0000-000000000005"), "", new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), 140 },
                    { new Guid("10000000-0000-0000-0000-000000000006"), "", new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), false, new Guid("00000000-0000-0000-0000-000000000006"), "", new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), 150 },
                    { new Guid("10000000-0000-0000-0000-000000000007"), "", new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), false, new Guid("00000000-0000-0000-0000-000000000007"), "", new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), 160 },
                    { new Guid("10000000-0000-0000-0000-000000000008"), "", new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), false, new Guid("00000000-0000-0000-0000-000000000008"), "", new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), 170 },
                    { new Guid("10000000-0000-0000-0000-000000000009"), "", new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), false, new Guid("00000000-0000-0000-0000-000000000009"), "", new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), 180 },
                    { new Guid("10000000-0000-0000-0000-000000000010"), "", new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), false, new Guid("00000000-0000-0000-0000-000000000010"), "", new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), 190 },
                    { new Guid("10000000-0000-0000-0000-000000000011"), "", new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), false, new Guid("00000000-0000-0000-0000-000000000011"), "", new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), 200 },
                    { new Guid("10000000-0000-0000-0000-000000000012"), "", new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), false, new Guid("00000000-0000-0000-0000-000000000012"), "", new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), 210 },
                    { new Guid("10000000-0000-0000-0000-000000000013"), "", new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), false, new Guid("00000000-0000-0000-0000-000000000013"), "", new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), 220 },
                    { new Guid("10000000-0000-0000-0000-000000000014"), "", new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), false, new Guid("00000000-0000-0000-0000-000000000014"), "", new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), 230 },
                    { new Guid("10000000-0000-0000-0000-000000000015"), "", new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), false, new Guid("00000000-0000-0000-0000-000000000015"), "", new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), 240 },
                    { new Guid("10000000-0000-0000-0000-000000000016"), "", new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), false, new Guid("00000000-0000-0000-0000-000000000016"), "", new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), 250 },
                    { new Guid("10000000-0000-0000-0000-000000000017"), "", new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), false, new Guid("00000000-0000-0000-0000-000000000017"), "", new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), 260 },
                    { new Guid("10000000-0000-0000-0000-000000000018"), "", new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), false, new Guid("00000000-0000-0000-0000-000000000018"), "", new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), 270 },
                    { new Guid("10000000-0000-0000-0000-000000000019"), "", new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), false, new Guid("00000000-0000-0000-0000-000000000019"), "", new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), 280 },
                    { new Guid("10000000-0000-0000-0000-000000000020"), "", new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), false, new Guid("00000000-0000-0000-0000-000000000020"), "", new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), 290 },
                    { new Guid("10000000-0000-0000-0000-000000000021"), "", new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), false, new Guid("00000000-0000-0000-0000-000000000021"), "", new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), 300 },
                    { new Guid("10000000-0000-0000-0000-000000000022"), "", new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), false, new Guid("00000000-0000-0000-0000-000000000022"), "", new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), 310 },
                    { new Guid("10000000-0000-0000-0000-000000000023"), "", new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), false, new Guid("00000000-0000-0000-0000-000000000023"), "", new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), 320 },
                    { new Guid("10000000-0000-0000-0000-000000000024"), "", new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), false, new Guid("00000000-0000-0000-0000-000000000024"), "", new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), 330 },
                    { new Guid("10000000-0000-0000-0000-000000000025"), "", new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), false, new Guid("00000000-0000-0000-0000-000000000025"), "", new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), 340 },
                    { new Guid("10000000-0000-0000-0000-000000000026"), "", new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), false, new Guid("00000000-0000-0000-0000-000000000026"), "", new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), 350 },
                    { new Guid("10000000-0000-0000-0000-000000000027"), "", new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), false, new Guid("00000000-0000-0000-0000-000000000027"), "", new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), 360 },
                    { new Guid("10000000-0000-0000-0000-000000000028"), "", new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), false, new Guid("00000000-0000-0000-0000-000000000028"), "", new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), 370 },
                    { new Guid("10000000-0000-0000-0000-000000000029"), "", new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), false, new Guid("00000000-0000-0000-0000-000000000029"), "", new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), 380 },
                    { new Guid("10000000-0000-0000-0000-000000000030"), "", new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), false, new Guid("00000000-0000-0000-0000-000000000030"), "", new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), 390 }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "Address", "Code", "CreatedBy", "CreatedTime", "CustomerId", "DeleteFlag", "FullName", "PaymentMethod", "Phone", "Status", "TotalAmount", "UpdatedBy", "UpdatedTime" },
                values: new object[,]
                {
                    { new Guid("dddddddd-dddd-dddd-dddd-000000000001"), "Hà Nội", "TRX-8901", "", new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), new Guid("cccccccc-cccc-cccc-cccc-000000000002"), false, "Nguyễn Văn Nam", "Bank Transfer", "0901234567", 3, 125000000m, "", new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("dddddddd-dddd-dddd-dddd-000000000002"), "Đà Nẵng", "TRX-8902", "", new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), new Guid("cccccccc-cccc-cccc-cccc-000000000003"), false, "Trần Văn Nam", "COD", "0912345678", 1, 12500000m, "", new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("dddddddd-dddd-dddd-dddd-000000000003"), "TP.HCM", "TRX-8895", "", new DateTime(2024, 10, 23, 10, 0, 0, 0, DateTimeKind.Utc), null, false, "Lê Văn Minh", "Credit Card", "0987654321", 3, 450000000m, "", new DateTime(2024, 10, 23, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("dddddddd-dddd-dddd-dddd-000000000004"), "Cần Thơ", "TRX-8890", "", new DateTime(2024, 10, 23, 10, 0, 0, 0, DateTimeKind.Utc), null, false, "Phạm Hoàng", "Bank Transfer", "0909090909", 4, 34200000m, "", new DateTime(2024, 10, 23, 10, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "Cost", "CreatedTime", "Description", "DiscountPrice", "Price", "ProductName", "SKU", "UpdatedTime" },
                values: new object[] { 700000m, new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), "Mô tả cho SmartWatch Pro X", 900000m, 1000000m, "SmartWatch Pro X", "SKU-001-SM", new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "Cost", "CreatedTime", "Description", "DiscountPrice", "Price", "ProductName", "SKU", "SupplierId", "UpdatedTime" },
                values: new object[] { 800000m, new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), "Mô tả cho Tai nghe Audio Q7", 1000000m, 1100000m, "Tai nghe Audio Q7", "SKU-002-TA", new Guid("aaaaaaaa-aaaa-aaaa-aaaa-bbbbbbbbbbbb"), new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "Cost", "CreatedTime", "Description", "DiscountPrice", "Price", "ProductName", "SKU", "SupplierId", "UpdatedTime" },
                values: new object[] { 900000m, new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), "Mô tả cho Bàn phím cơ MX", 1100000m, 1200000m, "Bàn phím cơ MX", "SKU-003-BÀ", new Guid("aaaaaaaa-aaaa-aaaa-aaaa-cccccccccccc"), new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "Cost", "CreatedTime", "DiscountPrice", "Price", "SKU", "SupplierId", "UpdatedTime" },
                values: new object[] { 1000000m, new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), 1200000m, 1300000m, "SKU-004-XI", new Guid("aaaaaaaa-aaaa-aaaa-aaaa-dddddddddddd"), new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "Cost", "CreatedTime", "DiscountPrice", "Price", "SKU", "SupplierId", "UpdatedTime" },
                values: new object[] { 1100000m, new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), 1300000m, 1400000m, "SKU-005-OP", new Guid("aaaaaaaa-aaaa-aaaa-aaaa-eeeeeeeeeeee"), new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "Cost", "CreatedTime", "DiscountPrice", "Price", "SKU", "UpdatedTime" },
                values: new object[] { 1200000m, new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), 1400000m, 1500000m, "SKU-006-MA", new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "Cost", "CreatedTime", "DiscountPrice", "Price", "SKU", "SupplierId", "UpdatedTime" },
                values: new object[] { 1300000m, new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), 1500000m, 1600000m, "SKU-007-DE", new Guid("aaaaaaaa-aaaa-aaaa-aaaa-bbbbbbbbbbbb"), new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "Cost", "CreatedTime", "DiscountPrice", "Price", "SKU", "SupplierId", "UpdatedTime" },
                values: new object[] { 1400000m, new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), 1600000m, 1700000m, "SKU-008-HP", new Guid("aaaaaaaa-aaaa-aaaa-aaaa-cccccccccccc"), new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "Cost", "CreatedTime", "DiscountPrice", "Price", "SKU", "SupplierId", "UpdatedTime" },
                values: new object[] { 1500000m, new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), 1700000m, 1800000m, "SKU-009-AS", new Guid("aaaaaaaa-aaaa-aaaa-aaaa-dddddddddddd"), new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "Cost", "CreatedTime", "DiscountPrice", "Price", "SKU", "SupplierId", "UpdatedTime" },
                values: new object[] { 1600000m, new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), 1800000m, 1900000m, "SKU-010-LE", new Guid("aaaaaaaa-aaaa-aaaa-aaaa-eeeeeeeeeeee"), new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "Cost", "CreatedTime", "DiscountPrice", "Price", "SKU", "UpdatedTime" },
                values: new object[] { 1700000m, new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), 1900000m, 2000000m, "SKU-011-IP", new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "Cost", "CreatedTime", "DiscountPrice", "Price", "SKU", "SupplierId", "UpdatedTime" },
                values: new object[] { 1800000m, new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), 2000000m, 2100000m, "SKU-012-SA", new Guid("aaaaaaaa-aaaa-aaaa-aaaa-bbbbbbbbbbbb"), new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "Cost", "CreatedTime", "DiscountPrice", "Price", "SKU", "SupplierId", "UpdatedTime" },
                values: new object[] { 1900000m, new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), 2100000m, 2200000m, "SKU-013-SU", new Guid("aaaaaaaa-aaaa-aaaa-aaaa-cccccccccccc"), new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "Cost", "CreatedTime", "DiscountPrice", "Price", "SKU", "SupplierId", "UpdatedTime" },
                values: new object[] { 2000000m, new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), 2200000m, 2300000m, "SKU-014-XI", new Guid("aaaaaaaa-aaaa-aaaa-aaaa-dddddddddddd"), new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "Cost", "CreatedTime", "DiscountPrice", "Price", "SKU", "SupplierId", "UpdatedTime" },
                values: new object[] { 2100000m, new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), 2300000m, 2400000m, "SKU-015-LE", new Guid("aaaaaaaa-aaaa-aaaa-aaaa-eeeeeeeeeeee"), new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "Cost", "CreatedTime", "DiscountPrice", "Price", "SKU", "UpdatedTime" },
                values: new object[] { 2200000m, new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), 2400000m, 2500000m, "SKU-016-AI", new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "Cost", "CreatedTime", "DiscountPrice", "Price", "SKU", "SupplierId", "UpdatedTime" },
                values: new object[] { 2300000m, new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), 2500000m, 2600000m, "SKU-017-SO", new Guid("aaaaaaaa-aaaa-aaaa-aaaa-bbbbbbbbbbbb"), new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "Cost", "CreatedTime", "DiscountPrice", "Price", "SKU", "SupplierId", "UpdatedTime" },
                values: new object[] { 2400000m, new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), 2600000m, 2700000m, "SKU-018-SA", new Guid("aaaaaaaa-aaaa-aaaa-aaaa-cccccccccccc"), new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "Cost", "CreatedTime", "DiscountPrice", "Price", "SKU", "SupplierId", "UpdatedTime" },
                values: new object[] { 2500000m, new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), 2700000m, 2800000m, "SKU-019-LO", new Guid("aaaaaaaa-aaaa-aaaa-aaaa-dddddddddddd"), new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "Cost", "CreatedTime", "DiscountPrice", "Price", "SKU", "SupplierId", "UpdatedTime" },
                values: new object[] { 2600000m, new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), 2800000m, 2900000m, "SKU-020-RA", new Guid("aaaaaaaa-aaaa-aaaa-aaaa-eeeeeeeeeeee"), new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "Cost", "CreatedTime", "DiscountPrice", "Price", "SKU", "UpdatedTime" },
                values: new object[] { 2700000m, new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), 2900000m, 3000000m, "SKU-021-AP", new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "Cost", "CreatedTime", "DiscountPrice", "Price", "SKU", "SupplierId", "UpdatedTime" },
                values: new object[] { 2800000m, new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), 3000000m, 3100000m, "SKU-022-SA", new Guid("aaaaaaaa-aaaa-aaaa-aaaa-bbbbbbbbbbbb"), new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "Cost", "CreatedTime", "DiscountPrice", "Price", "SKU", "SupplierId", "UpdatedTime" },
                values: new object[] { 2900000m, new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), 3100000m, 3200000m, "SKU-023-GA", new Guid("aaaaaaaa-aaaa-aaaa-aaaa-cccccccccccc"), new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "Cost", "CreatedTime", "DiscountPrice", "Price", "SKU", "SupplierId", "UpdatedTime" },
                values: new object[] { 3000000m, new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), 3200000m, 3300000m, "SKU-024-HU", new Guid("aaaaaaaa-aaaa-aaaa-aaaa-dddddddddddd"), new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "Cost", "CreatedTime", "DiscountPrice", "Price", "SKU", "SupplierId", "UpdatedTime" },
                values: new object[] { 3100000m, new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), 3300000m, 3400000m, "SKU-025-AM", new Guid("aaaaaaaa-aaaa-aaaa-aaaa-eeeeeeeeeeee"), new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "Cost", "CreatedTime", "DiscountPrice", "Price", "SKU", "UpdatedTime" },
                values: new object[] { 3200000m, new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), 3400000m, 3500000m, "SKU-026-IP", new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "Cost", "CreatedTime", "DiscountPrice", "Price", "SKU", "SupplierId", "UpdatedTime" },
                values: new object[] { 3300000m, new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), 3500000m, 3600000m, "SKU-027-SA", new Guid("aaaaaaaa-aaaa-aaaa-aaaa-bbbbbbbbbbbb"), new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "Cost", "CreatedTime", "DiscountPrice", "Price", "SKU", "SupplierId", "UpdatedTime" },
                values: new object[] { 3400000m, new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), 3600000m, 3700000m, "SKU-028-MA", new Guid("aaaaaaaa-aaaa-aaaa-aaaa-cccccccccccc"), new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "Cost", "CreatedTime", "DiscountPrice", "Price", "SKU", "SupplierId", "UpdatedTime" },
                values: new object[] { 3500000m, new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), 3700000m, 3800000m, "SKU-029-IP", new Guid("aaaaaaaa-aaaa-aaaa-aaaa-dddddddddddd"), new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "Cost", "CreatedTime", "DiscountPrice", "Price", "SKU", "SupplierId", "UpdatedTime" },
                values: new object[] { 3600000m, new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), 3800000m, 3900000m, "SKU-030-SO", new Guid("aaaaaaaa-aaaa-aaaa-aaaa-eeeeeeeeeeee"), new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                columns: new[] { "Address", "ContactName", "CreatedTime", "Email", "Field", "PhoneNumber", "Status", "SupplierName", "TaxCode", "UpdatedTime" },
                values: new object[] { "TP.HCM", "Nguyễn Văn A", new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), "contact@vinamilk.com", "Thực phẩm, Sữa", "0901234567", 1, "Công ty CP Vinamilk", "0300588569", new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "Address", "ContactName", "CreatedBy", "CreatedTime", "DeleteFlag", "Email", "Field", "PhoneNumber", "Status", "SupplierName", "TaxCode", "UpdatedBy", "UpdatedTime" },
                values: new object[,]
                {
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-bbbbbbbbbbbb"), "Hà Nội", "Trần Thị B", "", new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), false, "contact@hoaphat.com", "Thép, Công nghiệp", "0912345678", 1, "Tập đoàn Hòa Phát", "0900189284", "", new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-cccccccccccc"), "Hải Phòng", "Lê Văn C", "", new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), false, "contact@thanglong.com", "Bao bì, In ấn", "0987654321", 4, "Cty Bao bì Thăng Long", "0102345678", "", new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-dddddddddddd"), "TP.HCM", "Phạm Hoàng D", "", new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), false, "contact@tgdd.vn", "Bán lẻ điện tử", "18001060", 1, "Thế Giới Di Động", "0303217354", "", new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-eeeeeeeeeeee"), "Hà Nội", "Vũ Nam E", "", new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), false, "contact@fpt.com.vn", "Bán lẻ kỹ thuật số", "18006601", 1, "FPT Retail", "0311609355", "", new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedBy", "CreatedTime", "DeleteFlag", "Email", "FullName", "Image", "IsActive", "Password", "Phone", "Role", "UpdatedBy", "UpdatedTime" },
                values: new object[,]
                {
                    { new Guid("cccccccc-cccc-cccc-cccc-000000000001"), null, "", new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), false, "admin@test.com", "Nguyễn Văn Nam", null, false, "admin", null, "Admin", "", new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("cccccccc-cccc-cccc-cccc-000000000002"), null, "", new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), false, "customer1@test.com", "Trần Thị Lan", null, false, "123", null, "Customer", "", new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("cccccccc-cccc-cccc-cccc-000000000003"), null, "", new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), false, "customer2@test.com", "Lê Văn Tuấn", null, false, "123", null, "Customer", "", new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryId",
                table: "Products");

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000007"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000008"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000009"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000010"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000011"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000012"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000013"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000014"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000015"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000016"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000017"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000018"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000019"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000020"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000021"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000022"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000023"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000024"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000025"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000026"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000027"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000028"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000029"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000030"));

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-dddd-dddd-dddd-000000000001"));

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-dddd-dddd-dddd-000000000002"));

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-dddd-dddd-dddd-000000000003"));

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-dddd-dddd-dddd-000000000004"));

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-bbbbbbbbbbbb"));

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-cccccccccccc"));

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-dddddddddddd"));

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-eeeeeeeeeeee"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("cccccccc-cccc-cccc-cccc-000000000001"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("cccccccc-cccc-cccc-cccc-000000000002"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("cccccccc-cccc-cccc-cccc-000000000003"));

            migrationBuilder.DropColumn(
                name: "ContactName",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "Field",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "TaxCode",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "SKU",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Suppliers",
                newName: "Identify");

            migrationBuilder.AlterColumn<int>(
                name: "PhoneNumber",
                table: "Suppliers",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "CreatedTime", "TenDanhMuc", "UpdatedTime" },
                values: new object[] { new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Điện thoại", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                columns: new[] { "CreatedTime", "TenDanhMuc", "UpdatedTime" },
                values: new object[] { new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Laptop", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "CreatedTime", "TenDanhMuc", "UpdatedTime" },
                values: new object[] { new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Máy tính bảng", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"),
                columns: new[] { "CreatedTime", "UpdatedTime" },
                values: new object[] { new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "CreatedTime", "TenDanhMuc", "UpdatedTime" },
                values: new object[] { new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Đồng hồ", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "DonViTinhs",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
                columns: new[] { "CreatedTime", "UpdatedTime" },
                values: new object[] { new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "Cost", "CreatedTime", "Description", "DiscountPrice", "Price", "ProductName", "UpdatedTime" },
                values: new object[] { 8000000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả cho iPhone 15 Pro Max", 9000000m, 10000000m, "iPhone 15 Pro Max", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "Cost", "CreatedTime", "Description", "DiscountPrice", "Price", "ProductName", "SupplierId", "UpdatedTime" },
                values: new object[] { 8500000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả cho Samsung Galaxy S24 Ultra", 9500000m, 10500000m, "Samsung Galaxy S24 Ultra", new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "Cost", "CreatedTime", "Description", "DiscountPrice", "Price", "ProductName", "SupplierId", "UpdatedTime" },
                values: new object[] { 9000000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mô tả cho Google Pixel 8 Pro", 10000000m, 11000000m, "Google Pixel 8 Pro", new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "Cost", "CreatedTime", "DiscountPrice", "Price", "SupplierId", "UpdatedTime" },
                values: new object[] { 9500000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 10500000m, 11500000m, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "Cost", "CreatedTime", "DiscountPrice", "Price", "SupplierId", "UpdatedTime" },
                values: new object[] { 10000000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 11000000m, 12000000m, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "Cost", "CreatedTime", "DiscountPrice", "Price", "UpdatedTime" },
                values: new object[] { 10500000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 11500000m, 12500000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "Cost", "CreatedTime", "DiscountPrice", "Price", "SupplierId", "UpdatedTime" },
                values: new object[] { 11000000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 12000000m, 13000000m, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "Cost", "CreatedTime", "DiscountPrice", "Price", "SupplierId", "UpdatedTime" },
                values: new object[] { 11500000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 12500000m, 13500000m, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "Cost", "CreatedTime", "DiscountPrice", "Price", "SupplierId", "UpdatedTime" },
                values: new object[] { 12000000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 13000000m, 14000000m, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "Cost", "CreatedTime", "DiscountPrice", "Price", "SupplierId", "UpdatedTime" },
                values: new object[] { 12500000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 13500000m, 14500000m, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "Cost", "CreatedTime", "DiscountPrice", "Price", "UpdatedTime" },
                values: new object[] { 13000000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 14000000m, 15000000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "Cost", "CreatedTime", "DiscountPrice", "Price", "SupplierId", "UpdatedTime" },
                values: new object[] { 13500000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 14500000m, 15500000m, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "Cost", "CreatedTime", "DiscountPrice", "Price", "SupplierId", "UpdatedTime" },
                values: new object[] { 14000000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 15000000m, 16000000m, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "Cost", "CreatedTime", "DiscountPrice", "Price", "SupplierId", "UpdatedTime" },
                values: new object[] { 14500000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 15500000m, 16500000m, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "Cost", "CreatedTime", "DiscountPrice", "Price", "SupplierId", "UpdatedTime" },
                values: new object[] { 15000000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 16000000m, 17000000m, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "Cost", "CreatedTime", "DiscountPrice", "Price", "UpdatedTime" },
                values: new object[] { 15500000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 16500000m, 17500000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "Cost", "CreatedTime", "DiscountPrice", "Price", "SupplierId", "UpdatedTime" },
                values: new object[] { 16000000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 17000000m, 18000000m, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "Cost", "CreatedTime", "DiscountPrice", "Price", "SupplierId", "UpdatedTime" },
                values: new object[] { 16500000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 17500000m, 18500000m, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "Cost", "CreatedTime", "DiscountPrice", "Price", "SupplierId", "UpdatedTime" },
                values: new object[] { 17000000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 18000000m, 19000000m, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "Cost", "CreatedTime", "DiscountPrice", "Price", "SupplierId", "UpdatedTime" },
                values: new object[] { 17500000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 18500000m, 19500000m, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "Cost", "CreatedTime", "DiscountPrice", "Price", "UpdatedTime" },
                values: new object[] { 18000000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 19000000m, 20000000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "Cost", "CreatedTime", "DiscountPrice", "Price", "SupplierId", "UpdatedTime" },
                values: new object[] { 18500000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 19500000m, 20500000m, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "Cost", "CreatedTime", "DiscountPrice", "Price", "SupplierId", "UpdatedTime" },
                values: new object[] { 19000000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 20000000m, 21000000m, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "Cost", "CreatedTime", "DiscountPrice", "Price", "SupplierId", "UpdatedTime" },
                values: new object[] { 19500000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 20500000m, 21500000m, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "Cost", "CreatedTime", "DiscountPrice", "Price", "SupplierId", "UpdatedTime" },
                values: new object[] { 20000000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 21000000m, 22000000m, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "Cost", "CreatedTime", "DiscountPrice", "Price", "UpdatedTime" },
                values: new object[] { 20500000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 21500000m, 22500000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "Cost", "CreatedTime", "DiscountPrice", "Price", "SupplierId", "UpdatedTime" },
                values: new object[] { 21000000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 22000000m, 23000000m, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "Cost", "CreatedTime", "DiscountPrice", "Price", "SupplierId", "UpdatedTime" },
                values: new object[] { 21500000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 22500000m, 23500000m, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "Cost", "CreatedTime", "DiscountPrice", "Price", "SupplierId", "UpdatedTime" },
                values: new object[] { 22000000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 23000000m, 24000000m, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "Cost", "CreatedTime", "DiscountPrice", "Price", "SupplierId", "UpdatedTime" },
                values: new object[] { 22500000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 23500000m, 24500000m, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                columns: new[] { "Address", "CreatedTime", "Email", "Identify", "PhoneNumber", "SupplierName", "UpdatedTime" },
                values: new object[] { "Hà Nội", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "contact@tongkho.com", 123456, 123456789, "Tổng kho điện máy", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });
        }
    }
}
