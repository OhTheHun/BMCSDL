using BackendService.Model;
using BackendService.Model.Common;
using BackendService.Model.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace BackendService.Data.DataContext
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var fixedDate = new DateTime(2024, 10, 24, 10, 0, 0, DateTimeKind.Utc);

            // Seed Categories
            var categoryIds = new List<Guid>
            {
                Guid.Parse("11111111-1111-1111-1111-111111111111"),
                Guid.Parse("22222222-2222-2222-2222-222222222222"),
                Guid.Parse("33333333-3333-3333-3333-333333333333"),
                Guid.Parse("44444444-4444-4444-4444-444444444444"),
                Guid.Parse("55555555-5555-5555-5555-555555555555")
            };

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = categoryIds[0], TenDanhMuc = "Điện tử", CreatedTime = fixedDate, UpdatedTime = fixedDate },
                new Category { Id = categoryIds[1], TenDanhMuc = "Gia dụng", CreatedTime = fixedDate, UpdatedTime = fixedDate },
                new Category { Id = categoryIds[2], TenDanhMuc = "Thời trang", CreatedTime = fixedDate, UpdatedTime = fixedDate },
                new Category { Id = categoryIds[3], TenDanhMuc = "Phụ kiện", CreatedTime = fixedDate, UpdatedTime = fixedDate },
                new Category { Id = categoryIds[4], TenDanhMuc = "Thực phẩm", CreatedTime = fixedDate, UpdatedTime = fixedDate }
            );

            // Seed Suppliers
            var supplierIds = new List<Guid>
            {
                Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-bbbbbbbbbbbb"),
                Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-cccccccccccc"),
                Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-dddddddddddd"),
                Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-eeeeeeeeeeee")
            };

            modelBuilder.Entity<Supplier>().HasData(
                new Supplier { Id = supplierIds[0], SupplierName = "Công ty CP Vinamilk", TaxCode = "0300588569", PhoneNumber = "0901234567", Email = "contact@vinamilk.com", Address = "TP.HCM", ContactName = "Nguyễn Văn A", Field = "Thực phẩm, Sữa", Status = SupplierEnum.Active, CreatedTime = fixedDate, UpdatedTime = fixedDate },
                new Supplier { Id = supplierIds[1], SupplierName = "Tập đoàn Hòa Phát", TaxCode = "0900189284", PhoneNumber = "0912345678", Email = "contact@hoaphat.com", Address = "Hà Nội", ContactName = "Trần Thị B", Field = "Thép, Công nghiệp", Status = SupplierEnum.Active, CreatedTime = fixedDate, UpdatedTime = fixedDate },
                new Supplier { Id = supplierIds[2], SupplierName = "Cty Bao bì Thăng Long", TaxCode = "0102345678", PhoneNumber = "0987654321", Email = "contact@thanglong.com", Address = "Hải Phòng", ContactName = "Lê Văn C", Field = "Bao bì, In ấn", Status = SupplierEnum.Paused, CreatedTime = fixedDate, UpdatedTime = fixedDate },
                new Supplier { Id = supplierIds[3], SupplierName = "Thế Giới Di Động", TaxCode = "0303217354", PhoneNumber = "18001060", Email = "contact@tgdd.vn", Address = "TP.HCM", ContactName = "Phạm Hoàng D", Field = "Bán lẻ điện tử", Status = SupplierEnum.Active, CreatedTime = fixedDate, UpdatedTime = fixedDate },
                new Supplier { Id = supplierIds[4], SupplierName = "FPT Retail", TaxCode = "0311609355", PhoneNumber = "18006601", Email = "contact@fpt.com.vn", Address = "Hà Nội", ContactName = "Vũ Nam E", Field = "Bán lẻ kỹ thuật số", Status = SupplierEnum.Active, CreatedTime = fixedDate, UpdatedTime = fixedDate }
            );

            // Seed DonViTinh
            var donViTinhId = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb");
            modelBuilder.Entity<DonViTinh>().HasData(
                new DonViTinh { Id = donViTinhId, TenDonViTinh = "Cái", Description = "Đơn vị tính cơ bản", CreatedTime = fixedDate, UpdatedTime = fixedDate }
            );

            // Seed 30 Products
            var products = new List<Product>();
            string[] productNames = {
                "SmartWatch Pro X", "Tai nghe Audio Q7", "Bàn phím cơ MX", "Xiaomi 14 Ultra", "Oppo Find X7 Ultra",
                "MacBook Pro M3", "Dell XPS 15", "HP Spectre x360", "Asus ROG Zephyrus G14", "Lenovo ThinkPad X1 Carbon",
                "iPad Pro M2", "Samsung Galaxy Tab S9", "Surface Pro 9", "Xiaomi Pad 6", "Lenovo Tab P12",
                "AirPods Pro 2", "Sony WH-1000XM5", "Samsung Galaxy Buds2 Pro", "Logitech MX Master 3S", "Razer DeathAdder V3",
                "Apple Watch Series 9", "Samsung Galaxy Watch 6", "Garmin Fenix 7", "Huawei Watch GT 4", "Amazfit GTR 4",
                "iPhone 14", "Samsung Galaxy A54", "MacBook Air M2", "iPad Air 5", "Sony WF-1000XM5"
            };

            for (int i = 0; i < 30; i++)
            {
                var productId = Guid.Parse($"00000000-0000-0000-0000-{(i + 1):D12}");
                products.Add(new Product
                {
                    Id = productId,
                    CategoryId = categoryIds[i % 5],
                    SupplierId = supplierIds[i % 5],
                    DonViTinhId = donViTinhId,
                    ProductName = productNames[i],
                    SKU = $"SKU-{(i + 1):D3}-{productNames[i].Substring(0, 2).ToUpper()}",
                    Price = 1000000 + (i * 100000),
                    DiscountPrice = 900000 + (i * 100000),
                    Cost = 700000 + (i * 100000),
                    Description = $"Mô tả cho {productNames[i]}",
                    Image_Url = "https://picsum.photos/200/300",
                    Status = ProductEnum.Active,
                    CreatedTime = fixedDate,
                    UpdatedTime = fixedDate
                });
            }
            modelBuilder.Entity<Product>().HasData(products);

            // Seed Inventories
            var inventories = new List<Inventory>();
            for (int i = 0; i < 30; i++)
            {
                inventories.Add(new Inventory
                {
                    Id = Guid.Parse($"10000000-0000-0000-0000-{(i + 1):D12}"),
                    ProductId = products[i].Id,
                    quantity = 100 + (i * 10),
                    CreatedTime = fixedDate,
                    UpdatedTime = fixedDate
                });
            }
            modelBuilder.Entity<Inventory>().HasData(inventories);

            // Seed Users
            var userIds = new List<Guid>
            {
                Guid.Parse("cccccccc-cccc-cccc-cccc-000000000001"),
                Guid.Parse("cccccccc-cccc-cccc-cccc-000000000002"),
                Guid.Parse("cccccccc-cccc-cccc-cccc-000000000003")
            };
            modelBuilder.Entity<User>().HasData(
                new User { Id = userIds[0], Email = "admin@test.com", Password = "admin", Role = "Admin", FullName = "Nguyễn Văn Nam", CreatedTime = fixedDate, UpdatedTime = fixedDate },
                new User { Id = userIds[1], Email = "customer1@test.com", Password = "123", Role = "Customer", FullName = "Trần Thị Lan", CreatedTime = fixedDate, UpdatedTime = fixedDate },
                new User { Id = userIds[2], Email = "customer2@test.com", Password = "123", Role = "Customer", FullName = "Lê Văn Tuấn", CreatedTime = fixedDate, UpdatedTime = fixedDate },
                new User { Id = Guid.Parse("cccccccc-cccc-cccc-cccc-000000000004"), Email = "customer3@test.com", Password = "123", Role = "Customer", FullName = "Hoàng Thị Mai", CreatedTime = fixedDate, UpdatedTime = fixedDate },
                new User { Id = Guid.Parse("cccccccc-cccc-cccc-cccc-000000000005"), Email = "customer4@test.com", Password = "123", Role = "Customer", FullName = "Đỗ Minh Đức", CreatedTime = fixedDate, UpdatedTime = fixedDate }
            );

            // Seed Invoices
            var invoiceIds = new List<Guid>
            {
                Guid.Parse("dddddddd-dddd-dddd-dddd-000000000001"),
                Guid.Parse("dddddddd-dddd-dddd-dddd-000000000002"),
                Guid.Parse("dddddddd-dddd-dddd-dddd-000000000003"),
                Guid.Parse("dddddddd-dddd-dddd-dddd-000000000004"),
                Guid.Parse("dddddddd-dddd-dddd-dddd-000000000005"),
                Guid.Parse("dddddddd-dddd-dddd-dddd-000000000006"),
                Guid.Parse("dddddddd-dddd-dddd-dddd-000000000007"),
                Guid.Parse("dddddddd-dddd-dddd-dddd-000000000008"),
                Guid.Parse("dddddddd-dddd-dddd-dddd-000000000009"),
                Guid.Parse("dddddddd-dddd-dddd-dddd-000000000010")
            };
            modelBuilder.Entity<Invoice>().HasData(
                new Invoice { Id = invoiceIds[0], CustomerId = userIds[1], Code = "TRX-8901", FullName = "Nguyễn Văn Nam", Phone = "0901234567", Address = "Hà Nội", TotalAmount = 125000000, Status = InvoiceEnum.Completed, CreatedTime = fixedDate, UpdatedTime = fixedDate, PaymentMethod = "Bank Transfer" },
                new Invoice { Id = invoiceIds[1], CustomerId = userIds[2], Code = "TRX-8902", FullName = "Trần Văn Nam", Phone = "0912345678", Address = "Đà Nẵng", TotalAmount = 12500000, Status = InvoiceEnum.Processing, CreatedTime = fixedDate, UpdatedTime = fixedDate, PaymentMethod = "COD" },
                new Invoice { Id = invoiceIds[2], Code = "TRX-8895", FullName = "Lê Văn Minh", Phone = "0987654321", Address = "TP.HCM", TotalAmount = 450000000, Status = InvoiceEnum.Completed, CreatedTime = fixedDate.AddDays(-1), UpdatedTime = fixedDate.AddDays(-1), PaymentMethod = "Credit Card" },
                new Invoice { Id = invoiceIds[3], Code = "TRX-8890", FullName = "Phạm Hoàng", Phone = "0909090909", Address = "Cần Thơ", TotalAmount = 34200000, Status = InvoiceEnum.Canceled, CreatedTime = fixedDate.AddDays(-1), UpdatedTime = fixedDate.AddDays(-1), PaymentMethod = "Bank Transfer" },
                new Invoice { Id = invoiceIds[4], Code = "TRX-8888", FullName = "Nguyễn Bích Liên", Phone = "0911223344", Address = "Huế", TotalAmount = 15000000, Status = InvoiceEnum.Completed, CreatedTime = fixedDate.AddDays(-2), UpdatedTime = fixedDate.AddDays(-2), PaymentMethod = "COD" },
                new Invoice { Id = invoiceIds[5], Code = "TRX-8887", FullName = "Trần Quốc Toản", Phone = "0922334455", Address = "Nha Trang", TotalAmount = 28000000, Status = InvoiceEnum.Processing, CreatedTime = fixedDate.AddDays(-2), UpdatedTime = fixedDate.AddDays(-2), PaymentMethod = "Bank Transfer" },
                new Invoice { Id = invoiceIds[6], Code = "TRX-8886", FullName = "Vũ Trọng Phụng", Phone = "0933445566", Address = "Nam Định", TotalAmount = 12000000, Status = InvoiceEnum.Completed, CreatedTime = fixedDate.AddDays(-3), UpdatedTime = fixedDate.AddDays(-3), PaymentMethod = "Credit Card" },
                new Invoice { Id = invoiceIds[7], Code = "TRX-8885", FullName = "Hồ Xuân Hương", Phone = "0944556677", Address = "Nghệ An", TotalAmount = 9000000, Status = InvoiceEnum.Canceled, CreatedTime = fixedDate.AddDays(-3), UpdatedTime = fixedDate.AddDays(-3), PaymentMethod = "COD" },
                new Invoice { Id = invoiceIds[8], Code = "TRX-8884", FullName = "Tô Hoài", Phone = "0955667788", Address = "Hải Dương", TotalAmount = 21000000, Status = InvoiceEnum.Completed, CreatedTime = fixedDate.AddDays(-4), UpdatedTime = fixedDate.AddDays(-4), PaymentMethod = "Bank Transfer" },
                new Invoice { Id = invoiceIds[9], Code = "TRX-8883", FullName = "Nam Cao", Phone = "0966778899", Address = "Hà Nam", TotalAmount = 17500000, Status = InvoiceEnum.Processing, CreatedTime = fixedDate.AddDays(-4), UpdatedTime = fixedDate.AddDays(-4), PaymentMethod = "Credit Card" }
            );
        }
    }
}
