# WEB-ADV-LAB

## 📚 Giới thiệu

Repository này chứa toàn bộ các bài lab thực hành của môn **Phát triển ứng dụng web nâng cao (Advanced Web Application Development)**. Các bài lab được thiết kế để giúp sinh viên nắm vững các công nghệ và kỹ thuật phát triển web hiện đại sử dụng ASP.NET Core MVC, Entity Framework Core, và các công nghệ web khác.

## 🎯 Mục tiêu

- Hiểu và áp dụng HTML, CSS, JavaScript để xây dựng giao diện cho ứng dụng web
- Phát triển ứng dụng web với ASP.NET Core MVC sử dụng controllers và views
- Làm việc với Entity Framework Core để quản lý cơ sở dữ liệu
- Xây dựng Web API sử dụng Minimal APIs và Controller-based APIs
- Áp dụng các kỹ thuật validation, dependency injection, và migrations

## 📋 Danh sách các Lab

### [LAB 1: HTML CSS JAVASCRIPT](./Lab01/)

**Mục tiêu:**
- Hiểu và áp dụng HTML, CSS, JavaScript để xây dựng giao diện cho ứng dụng web

**Nội dung:**
- Tạo tài khoản GitHub
- Cài đặt Visual Studio Code 2022
- Làm quen với HTML, CSS, JavaScript
- Sử dụng Bootstrap 5
- Tìm hiểu về web accessibility

**Tài liệu tham khảo:**
- [HTML Tutorial](https://www.w3schools.com/html/default.asp)
- [CSS Tutorial](https://www.w3schools.com/css/default.asp)
- [JavaScript Tutorial](https://www.w3schools.com/js/default.asp)
- [Bootstrap 5 Tutorial](https://www.w3schools.com/bootstrap5/index.php)

---

### [LAB 2: ASP.NET CORE MVC](./Lab02/)

**Mục tiêu:**
- Phát triển ứng dụng web với ASP.NET Core MVC sử dụng controllers và views

**Nội dung:**
1. Tạo Project
2. Thêm Controller vào ứng dụng ASP.NET Core MVC
3. Thêm View vào ứng dụng ASP.NET Core MVC
4. Thay đổi views và layout pages
5. Truyền dữ liệu từ Controller sang View

**Yêu cầu:**
- Tạo một ứng dụng web
- Làm việc với Controllers và Views
- Hiểu về Model-View-Controller pattern

---

### [LAB 3: ASP.NET Core MVC (Tiếp theo)](./Lab03/)

**Mục tiêu:**
- Tiếp tục phát triển ứng dụng MVC với Entity Framework Core

**Nội dung:**
6. Thêm NuGet packages
7. Scaffold movie pages
8. Initial migration
   - Add-Migration InitialCreate
   - Update-Database
   - Database context class và registration
   - Dependency injection
   - Database connection string
9. Dependency injection trong controller
10. Seed the database
11. Thêm seed initializer
12. Xử lý POST Request

---

### [LAB 4: ASP.NET Core MVC (Tiếp theo)](./Lab04/)

**Mục tiêu:**
- Nâng cao ứng dụng MVC với validation và search

**Nội dung:**
1. Thêm tìm kiếm theo genre
2. Thêm search box vào Index view
3. Thêm Rating Property vào Movie Model
4. Thêm validation rules vào movie model
5. Sử dụng DataType Attributes

---

### [LAB 5: Minimal APIs](./Lab05/)

**Mục tiêu:**
- Xây dựng Web API sử dụng Minimal APIs trong .NET 6+

**Nội dung:**
6. Tạo project mới
7. Test API
   - Cài đặt Postman để test ứng dụng
   - Test posting data
   - Test các GET endpoints
   - Kiểm tra PUT endpoint
   - Kiểm tra DELETE endpoint
8. Prevent over-posting
   - Tạo DTO model
   - Cập nhật code để sử dụng TodoItemDTO
9. Sử dụng JsonOptions

**Tài liệu tham khảo:**
- [Introduction to Minimal APIs in .NET 6](https://www.claudiobernasconi.ch/2022/02/23/introduction-to-minimal-apis-in-dotnet6)
- [Minimal APIs quick reference](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis?view=aspnetcore-7.0)

---

### [LAB 6: Controller-based APIs](./Lab06/)

**Mục tiêu:**
- Xây dựng Web API sử dụng Controllers

**Nội dung:**
1. Overview
   - ControllerBase class
   - Attributes
   - ApiController attribute
2. Tạo Web API với ASP.NET Core
   - Tạo web project
   - Test project
   - Cập nhật launchUrl
   - Thêm model class
   - Thêm database context
   - Đăng ký database context
   - Scaffold controller
   - Cập nhật PostTodoItem create method
   - Test Web APIs với HttpRepl
   - Test các GET methods
   - Routing và URL paths
   - PutTodoItem method
   - DeleteTodoItem method
   - Prevent over-posting
3. Gọi Web API với JavaScript
   - Lấy danh sách to-do items
   - Thêm to-do item
   - Cập nhật to-do item
   - Xóa to-do item
4. Sự khác biệt giữa Minimal APIs và APIs với controllers
5. Thêm authentication support (Tùy chọn)

---

### [LAB 7: ASP.NET Core MVC with EF Core](./Lab07/)

**Mục tiêu:**
- Xây dựng ứng dụng MVC hoàn chỉnh với Entity Framework Core

**Nội dung:**
1. Get started
   - Thêm NuGet packages
   - Tạo database context
   - Đăng ký SchoolContext
   - Thêm database exception filter
2. Khởi tạo DB với test data
3. Cập nhật Program.cs
4. Tạo controller và views
5. Xem database
6. Asynchronous code
7. SQL Logging của Entity Framework Core
8. Create, Read, Update, và Delete (CRUD)
   - Tùy chỉnh Details page
   - Route data
   - Thêm enrollments vào Details view
   - Cập nhật Create page
   - Cập nhật Edit page
   - Cập nhật Delete page
9. Sort, Filter, Page, và Group
   - Thêm sorting functionality
   - Thêm column heading hyperlinks
   - Thêm Search Box
   - Thêm paging
   - Tạo About page
   - Tạo view model
10. Migrations
    - Drop database
    - Tạo initial migration
    - Kiểm tra Up và Down methods
    - Data model snapshot

---

## 🛠️ Yêu cầu hệ thống

### Phần mềm cần thiết:
- **Visual Studio 2022** hoặc **Visual Studio Code**
  - [Download Visual Studio 2022](https://learn.microsoft.com/en-us/visualstudio/install/install-visual-studio?view=vs-2022)
- **.NET SDK** (phiên bản 6.0 trở lên)
- **SQL Server** hoặc **SQL Server Express**
- **Git** để quản lý source control
- **Postman** (cho LAB 5, 6) - để test Web API

### Tài khoản:
- **GitHub account**: [https://github.com](https://github.com)

---

## 📖 Tài liệu tham khảo

1. Hejlsberg A., Torgersen M. (2010), "The C# Programming Language". 4th edition, Addison-Wesley.
2. Adam Freeman (2018), "Pro Entity Framework Core 2 for ASP.NET Core MVC" 1st ed. Edition.
3. [HTML Tutorial](https://www.w3schools.com/html/default.asp)
4. [CSS Tutorial](https://www.w3schools.com/css/default.asp)
5. [JavaScript Tutorial](https://www.w3schools.com/js/default.asp)
6. [Bootstrap 5 Tutorial](https://www.w3schools.com/bootstrap5/index.php)
7. [Introduction to Minimal APIs in .NET 6](https://www.claudiobernasconi.ch/2022/02/23/introduction-to-minimal-apis-in-dotnet6)
8. [Minimal APIs quick reference](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis?view=aspnetcore-7.0)
9. [Microsoft Learn - ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/)

---

## 🚀 Hướng dẫn sử dụng

### 1. Clone repository
```bash
git clone <repository-url>
cd WEB-ADV-LAB
```

### 2. Mở project trong Visual Studio
- Mở file `.sln` trong Visual Studio 2022
- Hoặc mở thư mục project trong Visual Studio Code

### 3. Restore packages
```bash
dotnet restore
```

### 4. Chạy ứng dụng
```bash
dotnet run
```

### 5. Truy cập ứng dụng
- Mở trình duyệt và truy cập URL được hiển thị trong console (thường là `https://localhost:5001` hoặc `http://localhost:5000`)

---

## 📝 Lưu ý quan trọng

### ⚠️ Source Control
- **TẤT CẢ các bài lab phải được commit và push lên GitHub/GitLab**
- Mỗi lab nên được commit riêng biệt với message rõ ràng
- Ví dụ: `git commit -m "LAB 2: Complete ASP.NET Core MVC project"`

### 📦 NuGet Packages
- Các lab sử dụng các NuGet packages khác nhau, đảm bảo restore đúng packages
- Sử dụng Package Manager Console hoặc CLI để cài đặt packages

### 🗄️ Database
- Một số lab yêu cầu database, đảm bảo connection string đúng trong `appsettings.json`
- Sử dụng migrations để quản lý database schema

---

## 📁 Cấu trúc thư mục

```
WEB-ADV-LAB/
├── Lab01/              # HTML, CSS, JavaScript
├── Lab02/              # ASP.NET Core MVC cơ bản
├── Lab03/              # ASP.NET Core MVC với EF Core
├── Lab04/              # ASP.NET Core MVC nâng cao
├── Lab05/              # Minimal APIs
├── Lab06/              # Controller-based APIs
├── Lab07/              # ASP.NET Core MVC với EF Core hoàn chỉnh
├── AdvancedWebApplicationDevelopment_Lab.pdf
└── README.md
```

---

## 🔧 Các lệnh thường dùng

### Entity Framework Core
```bash
# Cài đặt EF Core tools
dotnet tool install --global dotnet-ef

# Tạo migration
dotnet ef migrations add InitialCreate

# Cập nhật database
dotnet ef database update

# Xóa database
dotnet ef database drop

# Xóa migration
dotnet ef migrations remove
```

### .NET CLI
```bash
# Restore packages
dotnet restore

# Build project
dotnet build

# Chạy project
dotnet run

# Clean build artifacts
dotnet clean
```

---

## 📞 Hỗ trợ

Nếu gặp vấn đề trong quá trình thực hành:
1. Kiểm tra lại các yêu cầu hệ thống
2. Đọc kỹ tài liệu trong file PDF
3. Tham khảo các link tài liệu tham khảo
4. Kiểm tra lỗi trong console/terminal

---

## 📄 License

Repository này được tạo cho mục đích học tập và nghiên cứu.

---

## ✅ Checklist hoàn thành

- [✅] LAB 1: HTML CSS JAVASCRIPT
- [✅] LAB 2: ASP.NET CORE MVC
- [✅] LAB 3: ASP.NET Core MVC (cont)
- [✅] LAB 4: ASP.NET Core MVC (cont)
- [✅] LAB 5: Minimal APIs
- [ ] LAB 6: Controller-based APIs
- [✅] LAB 7: ASP.NET Core MVC with EF Core
- [✅] LAB 8: ASP.NET Core MVC with EF Core & config from existing UI


**Lưu ý:** Đảm bảo commit và push tất cả các lab lên GitHub/GitLab trước khi nộp bài!

---

**Chúc các bạn học tập tốt! 🎓**
