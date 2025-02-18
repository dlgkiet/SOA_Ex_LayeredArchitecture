using Business.Services;
using Microsoft.EntityFrameworkCore;
using MyApp.Persistence;
using Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Lấy connection string từ appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Cấu hình EF Core sử dụng SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

// Đăng ký Repository và Service
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerService, CustomerService>();

// Đăng ký Controller
builder.Services.AddControllers();

// (Tuỳ chọn) Cấu hình Swagger để test API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Tự động tạo database và bảng nếu chưa tồn tại
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.EnsureDeleted();   // Xóa database cũ (chỉ dùng cho development)
    dbContext.Database.EnsureCreated();   // Tạo lại database theo model hiện tại
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
