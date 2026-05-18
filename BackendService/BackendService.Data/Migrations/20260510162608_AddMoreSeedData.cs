using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BackendService.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddMoreSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "Address", "Code", "CreatedBy", "CreatedTime", "CustomerId", "DeleteFlag", "FullName", "PaymentMethod", "Phone", "Status", "TotalAmount", "UpdatedBy", "UpdatedTime" },
                values: new object[,]
                {
                    { new Guid("dddddddd-dddd-dddd-dddd-000000000005"), "Huế", "TRX-8888", "", new DateTime(2024, 10, 22, 10, 0, 0, 0, DateTimeKind.Utc), null, false, "Nguyễn Bích Liên", "COD", "0911223344", 3, 15000000m, "", new DateTime(2024, 10, 22, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("dddddddd-dddd-dddd-dddd-000000000006"), "Nha Trang", "TRX-8887", "", new DateTime(2024, 10, 22, 10, 0, 0, 0, DateTimeKind.Utc), null, false, "Trần Quốc Toản", "Bank Transfer", "0922334455", 1, 28000000m, "", new DateTime(2024, 10, 22, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("dddddddd-dddd-dddd-dddd-000000000007"), "Nam Định", "TRX-8886", "", new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Utc), null, false, "Vũ Trọng Phụng", "Credit Card", "0933445566", 3, 12000000m, "", new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("dddddddd-dddd-dddd-dddd-000000000008"), "Nghệ An", "TRX-8885", "", new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Utc), null, false, "Hồ Xuân Hương", "COD", "0944556677", 4, 9000000m, "", new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("dddddddd-dddd-dddd-dddd-000000000009"), "Hải Dương", "TRX-8884", "", new DateTime(2024, 10, 20, 10, 0, 0, 0, DateTimeKind.Utc), null, false, "Tô Hoài", "Bank Transfer", "0955667788", 3, 21000000m, "", new DateTime(2024, 10, 20, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("dddddddd-dddd-dddd-dddd-000000000010"), "Hà Nam", "TRX-8883", "", new DateTime(2024, 10, 20, 10, 0, 0, 0, DateTimeKind.Utc), null, false, "Nam Cao", "Credit Card", "0966778899", 1, 17500000m, "", new DateTime(2024, 10, 20, 10, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedBy", "CreatedTime", "DeleteFlag", "Email", "FullName", "Image", "IsActive", "Password", "Phone", "Role", "UpdatedBy", "UpdatedTime" },
                values: new object[,]
                {
                    { new Guid("cccccccc-cccc-cccc-cccc-000000000004"), null, "", new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), false, "customer3@test.com", "Hoàng Thị Mai", null, false, "123", null, "Customer", "", new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("cccccccc-cccc-cccc-cccc-000000000005"), null, "", new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc), false, "customer4@test.com", "Đỗ Minh Đức", null, false, "123", null, "Customer", "", new DateTime(2024, 10, 24, 10, 0, 0, 0, DateTimeKind.Utc) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-dddd-dddd-dddd-000000000005"));

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-dddd-dddd-dddd-000000000006"));

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-dddd-dddd-dddd-000000000007"));

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-dddd-dddd-dddd-000000000008"));

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-dddd-dddd-dddd-000000000009"));

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-dddd-dddd-dddd-000000000010"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("cccccccc-cccc-cccc-cccc-000000000004"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("cccccccc-cccc-cccc-cccc-000000000005"));
        }
    }
}
