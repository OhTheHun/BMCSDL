using BackendService.Model;
using BackendService.Model.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace BackendService.Data.DataContext
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<EmployeeProfile> EmployeeProfiles { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<Promotion> Promotions { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<InvoiceItem> InvoiceItems { get; set; }
        public virtual DbSet<Import> Imports { get; set; }
        public virtual DbSet<ImportDetail> ImportDetails { get; set; }
        public virtual DbSet<DonViTinh> DonViTinhs { get; set; }
        public virtual DbSet<EmailHistory> EmailHistories { get; set; }
        public virtual DbSet<SystemAuditLog> SystemAuditLogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var configuration = new ConfigurationBuilder()
                       .SetBasePath(Directory.GetCurrentDirectory())
                       .AddJsonFile("appsettings.json")
                       .Build();

                var connectionString = configuration.GetConnectionString("SqlServerDb");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users", tb => tb.UseSqlOutputClause(false));
            });

            modelBuilder.Entity<EmployeeProfile>(entity =>
            {
                entity.ToTable("EmployeeProfiles", tb => tb.UseSqlOutputClause(false));
                
                // Thuộc tính Salary trong C# bị Ignore (do là decimal), 
                // nhưng dưới CSDL ta bắt buộc EF tạo ra cột Salary kiểu VARBINARY(MAX) 
                // để Stored Procedure làm việc.
                entity.Ignore(e => e.Salary);
                entity.Property<byte[]>("Salary_Encrypted")
                      .HasColumnName("Salary")
                      .HasColumnType("varbinary(max)")
                      .IsRequired(false);

                // Converter tự động chuyển đổi giữa DateOnly và DateTime (DATETIME2) của SQL Server
                entity.Property(e => e.Date)
                      .HasConversion(
                          d => d.ToDateTime(TimeOnly.MinValue),
                          d => DateOnly.FromDateTime(d)
                      );
            });

            modelBuilder.Entity<Category>().ToTable("Categories", tb => tb.UseSqlOutputClause(false));
            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Products", tb => tb.UseSqlOutputClause(false));
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.ToTable("Suppliers", tb => tb.UseSqlOutputClause(false));
            });

            modelBuilder.Entity<Inventory>().ToTable("Inventories", tb => tb.UseSqlOutputClause(false));
            modelBuilder.Entity<Promotion>().ToTable("Promotions", tb => tb.UseSqlOutputClause(false));
            modelBuilder.Entity<Invoice>().ToTable("Invoices", tb => tb.UseSqlOutputClause(false));
            
            modelBuilder.Entity<InvoiceItem>(entity =>
            {
                entity.ToTable("InvoiceItems", tb => tb.UseSqlOutputClause(false));
            });
            
            modelBuilder.Entity<Import>().ToTable("Imports", tb => tb.UseSqlOutputClause(false));
            
            modelBuilder.Entity<ImportDetail>(entity =>
            {
                entity.ToTable("ImportDetails", tb => tb.UseSqlOutputClause(false));
            });
            
            modelBuilder.Entity<DonViTinh>().ToTable("DonViTinhs", tb => tb.UseSqlOutputClause(false));
            modelBuilder.Entity<EmailHistory>().ToTable("EmailHistories", tb => tb.UseSqlOutputClause(false));
            modelBuilder.Entity<SystemAuditLog>().ToTable("SystemAuditLogs", tb => tb.UseSqlOutputClause(false));

            modelBuilder.Seed();
        }
    }
}
