Dự án Web API đơn giản sử dụng **ASP.NET Core** và **Entity Framework Core** để quản lý khách hàng, áp dụng kiến trúc nhiều tầng (Layered Architecture).

## 🛠 Công Nghệ Sử Dụng

- **.NET 8**
- **ASP.NET Core Web API**
- **Entity Framework Core**
- **SQL Server**
- **Swagger UI** (tích hợp sẵn để kiểm tra API)

---

## 💂🏻 Cấu Trúc Dự Án

```
LayeredArchitectureSolution
├── Business
│   └── Services
│       ├── ICustomerService.cs
│       └── CustomerService.cs
├── Persistence
│   ├── Models
│   │   └── Customer.cs
│   ├── AppDbContext.cs
│   └── Repositories
│       ├── ICustomerRepository.cs
│       └── CustomerRepository.cs
└── Presentation
    ├── Controllers
    │   └── CustomerController.cs
    ├── appsettings.json
    └── Program.cs
```

---

## 🔧 Cài Đặt & Cấu Hình

### 1️⃣ Cấu Hình Database

Mở `appsettings.json` trong **Presentation** và cập nhật chuỗi kết nối phù hợp:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=CustomerDB;Trusted_Connection=True;TrustServerCertificate=True"
  }
}
```

---

### 2️⃣ Cài Đặt Các Package

Chạy lệnh sau trong **Terminal** hoặc **Package Manager Console**:

```bash
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Design
```

---

### 3️⃣ Khởi Tạo Database & Bảng

Dự án đã được cấu hình để tự động tạo database và bảng `Customers` nếu chưa có.

Trong **Program.cs**, đoạn mã sau sẽ đảm bảo database được tạo:

```csharp
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.EnsureCreated(); // Tạo database nếu chưa tồn tại
}
```

---

## 🚀 Chạy Ứng Dụng

### **1️⃣ Đặt `Presentation` làm Startup Project**

- Trong **Visual Studio**, nhấp chuột phải vào `Presentation` → **Set as Startup Project**.

### **2️⃣ Build & Chạy Dự Án**

- Sử dụng **F5** hoặc **Ctrl + F5** (Visual Studio).
- Hoặc chạy bằng **Terminal**:

```bash
dotnet run --project Presentation
```

> Khi chạy thành công, API sẽ mở tại `https://localhost:{port}/swagger`.

---

## 📌 API Endpoints

| HTTP Method | Endpoint             | Chức Năng                        |
| ----------- | -------------------- | -------------------------------- |
| **GET**     | `/api/customer`      | Lấy danh sách khách hàng         |
| **GET**     | `/api/customer/{id}` | Lấy thông tin khách hàng theo ID |
| **POST**    | `/api/customer`      | Thêm mới khách hàng              |
