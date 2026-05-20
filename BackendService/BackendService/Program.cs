using BackendService.Configuration;
using BackendService.Data;
using BackendService.Data.DataContext;
using BackendService.Data.Interface;
using BackendService.FluentValidation;
using BackendService.Services;
using BackendService.Services.Interface;
using BackendService.Middleware;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Microsoft.Data.SqlClient;
using Serilog;
using System.Security.Claims;
using System.Text;

// ================= LOGGING =================
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(new ConfigurationBuilder()
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .Build())
    .Enrich.FromLogContext()
    .CreateLogger();

Log.Information("API starting...");

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog();

// ================= CONFIG =================
var jwtConfig = builder.Configuration.GetSection("JwtConfig");
builder.Services.Configure<ConfigOptions>(builder.Configuration);

builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<DbSessionContextInterceptor>();

builder.Services.AddTransient<System.Data.IDbConnection>(sp =>
{
    var httpContextAccessor = sp.GetRequiredService<IHttpContextAccessor>();
    var configuration = sp.GetRequiredService<IConfiguration>();
    var user = httpContextAccessor.HttpContext?.User;
    var role = user?.FindFirst(System.Security.Claims.ClaimTypes.Role)?.Value;

    string connStringName = "SqlServerDb";
    if (!string.IsNullOrEmpty(role))
    {
        switch (role)
        {
            case "Admin": connStringName = "SqlServerDb_Admin"; break;
            case "HRManager": connStringName = "SqlServerDb_HR"; break;
            case "WareHouseManager": connStringName = "SqlServerDb_Warehouse"; break;
            case "Seller": connStringName = "SqlServerDb_Seller"; break;
            case "Customer": connStringName = "SqlServerDb_Customer"; break;
        }
    }
    var connectionString = configuration.GetConnectionString(connStringName) 
                           ?? configuration.GetConnectionString("SqlServerDb");
    return new Microsoft.Data.SqlClient.SqlConnection(connectionString);
});

builder.Services.AddDbContext<AppDbContext>((serviceProvider, options) =>
{
    var interceptor = serviceProvider.GetRequiredService<DbSessionContextInterceptor>();
    var httpContextAccessor = serviceProvider.GetRequiredService<IHttpContextAccessor>();
    var configuration = serviceProvider.GetRequiredService<IConfiguration>();

    var httpContext = httpContextAccessor.HttpContext;
    var user = httpContext?.User;
    var role = user?.FindFirst(System.Security.Claims.ClaimTypes.Role)?.Value;

    string connStringName = "SqlServerDb";
    if (!string.IsNullOrEmpty(role))
    {
        switch (role)
        {
            case "Admin": connStringName = "SqlServerDb_Admin"; break;
            case "HRManager": connStringName = "SqlServerDb_HR"; break;
            case "WareHouseManager": connStringName = "SqlServerDb_Warehouse"; break;
            case "Seller": connStringName = "SqlServerDb_Seller"; break;
            case "Customer": connStringName = "SqlServerDb_Customer"; break;
        }
    }

    var connectionString = configuration.GetConnectionString(connStringName) 
                           ?? configuration.GetConnectionString("SqlServerDb");

    options.UseSqlServer(connectionString)
           .AddInterceptors(interceptor);
});



builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IPasswordHasherService, PasswordHasherService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAdminUserService, AdminUserService>();
builder.Services.AddScoped<IOtherService, OtherService>();
builder.Services.AddScoped<IAsymmetricCryptographyService, AsymmetricCryptographyService>();
builder.Services.AddScoped<IHybridCryptographyService, HybridCryptographyService>();

// Email Services
builder.Services.AddScoped<IEmailService, SMTPEmailService>();
builder.Services.AddSingleton<IEmailTemplateService, EmailTemplateService>();

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddScoped<IInvoiceRepository, InvoiceRepository>();
builder.Services.AddScoped<IInvoiceService, InvoiceService>();
builder.Services.AddScoped<IInventoryRepository, InventoryRepository>();
builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();
builder.Services.AddScoped<ISupplierService, SupplierService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IDonViTinhRepository, DonViTinhRepository>();
builder.Services.AddScoped<IDonViTinhService, DonViTinhService>();
builder.Services.AddScoped<IImportRepository, ImportRepository>();
builder.Services.AddScoped<IImportService, ImportService>();

// Validation
builder.Services.AddValidatorsFromAssemblyContaining<Program>();

// Cache
builder.Services.AddMemoryCache();

// ================= JWT =================
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;

    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtConfig["Issuer"],
        ValidAudience = jwtConfig["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(jwtConfig["Key"])
        ),
        RoleClaimType = ClaimTypes.Role
    };
});

// ================= CORS =================
var allowedOrigins = builder.Configuration.GetSection("AllowedOrigins").Get<string[]>() ?? new[] { "http://localhost:4200" };

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowWebApp", policy =>
    {
        // đổi lại allowedOrigins sau khi xong
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// ================= SWAGGER + JWT =================
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Backend API",
        Version = "v1"
    });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Nhập JWT token",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

builder.Services.AddHttpContextAccessor();
var app = builder.Build();

app.UseMiddleware<GlobalExceptionMiddleware>();

app.UseSwagger();
app.UseSwaggerUI();

// ================= DATABASE INITIALIZATION =================
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<AppDbContext>();
        Log.Information("Checking for pending migrations...");
        context.Database.Migrate();
        Log.Information("Database is up to date.");
    }
    catch (Exception ex)
    {
        Log.Error(ex, "An error occurred while migrating the database.");
    }
}

app.UseStaticFiles();

if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

app.UseCors("AllowWebApp");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseSerilogRequestLogging();

app.Run();
