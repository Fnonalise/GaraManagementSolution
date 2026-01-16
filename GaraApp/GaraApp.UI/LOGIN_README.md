# H??NG D?N S? D?NG CH?C N?NG ??NG NH?P

## Các file ?ã t?o

### 1. Entity Layer (GaraApp.Entities)
- **User.cs**: L?p th?c th? ng??i dùng v?i các thu?c tính:
  - UserId: ID ng??i dùng (auto increment)
  - Username: Tên ??ng nh?p (unique, required)
  - Password: M?t kh?u ?ã ???c hash SHA256
  - FullName: H? tên ??y ??
  - Role: Vai trò (Admin, User)
  - IsActive: Tr?ng thái kích ho?t
  - CreatedDate: Ngày t?o tài kho?n

### 2. Data Access Layer (GaraApp.DAL)
- **UserRepository.cs**: Repository cho User v?i các ph??ng th?c:
  - GetByUsernameAsync: L?y user theo username
  - UsernameExistsAsync: Ki?m tra username ?ã t?n t?i
  
- **GaraDbContext.cs**: ?ã c?p nh?t thêm DbSet<User>

### 3. Business Logic Layer (GaraApp.BLL)
- **UserService.cs**: Service x? lý nghi?p v?:
  - AuthenticateAsync: Xác th?c ??ng nh?p
  - CreateUserAsync: T?o tài kho?n m?i
  - ChangePasswordAsync: ??i m?t kh?u
  - HashPassword: Mã hóa m?t kh?u b?ng SHA256

### 4. Presentation Layer (GaraApp.UI)
- **frmLogin.cs**: Form ??ng nh?p
- **frmLogin.Designer.cs**: Designer c?a form ??ng nh?p
- **Program.cs**: ?ã c?p nh?t ?? hi?n th? form login tr??c
- **frmMain.cs**: ?ã c?p nh?t ?? hi?n th? thông tin ng??i dùng

### 5. Database Script
- **CreateUsersTable.sql**: Script t?o b?ng Users và d? li?u m?u

## Các b??c th?c hi?n

### B??c 1: Ch?y Migration (n?u dùng Entity Framework)
M? Package Manager Console và ch?y:
```
Add-Migration AddUsersTable
Update-Database
```

### B??c 2: Ho?c ch?y SQL Script tr?c ti?p
1. M? SQL Server Management Studio
2. K?t n?i ??n database c?a b?n
3. M? file `CreateUsersTable.sql`
4. Ch?y script (F5)

### B??c 3: Ch?y ?ng d?ng
1. Build solution (Ctrl + Shift + B)
2. Ch?y ?ng d?ng (F5)
3. Form ??ng nh?p s? hi?n th? ??u tiên

## Tài kho?n m?c ??nh

### Admin
- **Username**: admin
- **Password**: admin123
- **Vai trò**: Admin

### User
- **Username**: user1
- **Password**: user123
- **Vai trò**: User

## Tính n?ng

### 1. Form ??ng nh?p (frmLogin)
- Nh?p username và password
- Nh?n Enter ?? ??ng nh?p nhanh
- Xác th?c thông tin ??ng nh?p
- L?u thông tin ng??i dùng ?ã ??ng nh?p vào static properties:
  - frmLogin.LoggedInUserId
  - frmLogin.LoggedInUsername
  - frmLogin.LoggedInFullName
  - frmLogin.LoggedInRole

### 2. B?o m?t
- M?t kh?u ???c hash b?ng SHA256 tr??c khi l?u vào database
- Không l?u m?t kh?u d?ng plain text
- Ki?m tra username unique
- Ki?m tra tr?ng thái IsActive

### 3. Hi?n th? thông tin ng??i dùng
- Thanh tiêu ?? frmMain hi?n th? tên ng??i dùng và vai trò
- Có th? s? d?ng thông tin này ?? phân quy?n các ch?c n?ng

## M? r?ng thêm

### 1. Phân quy?n theo Role
Trong các form con, b?n có th? ki?m tra quy?n:
```csharp
if (frmLogin.LoggedInRole != "Admin")
{
    btnDelete.Enabled = false;
    MessageBox.Show("B?n không có quy?n xóa!");
}
```

### 2. Thêm menu ??i m?t kh?u
T?o form frmChangePassword và g?i UserService.ChangePasswordAsync()

### 3. Thêm menu qu?n lý ng??i dùng (cho Admin)
T?o form frmUser ?? Admin có th?:
- Xem danh sách ng??i dùng
- Thêm/s?a/xóa ng??i dùng
- Khóa/m? khóa tài kho?n
- Reset m?t kh?u

### 4. Ghi log ho?t ??ng
L?u l?i các thao tác c?a ng??i dùng:
- Ai ??ng nh?p lúc nào
- Ai th?c hi?n thao tác gì
- T?o b?ng ActivityLog v?i UserId

## L?u ý

1. **B?o m?t**: SHA256 là thu?t toán hash c? b?n. Trong production nên dùng:
   - BCrypt
   - PBKDF2
   - Argon2

2. **Session timeout**: Hi?n t?i ch?a có timeout. Nên thêm:
   - Th?i gian timeout sau khi không ho?t ??ng
   - T? ??ng ??ng xu?t sau 1 kho?ng th?i gian

3. **Remember Me**: Có th? thêm checkbox "Ghi nh? ??ng nh?p"

4. **Forgot Password**: Thêm ch?c n?ng khôi ph?c m?t kh?u

## Troubleshooting

### L?i k?t n?i database
- Ki?m tra connection string trong App.config
- ??m b?o SQL Server ?ang ch?y

### Không ??ng nh?p ???c
- Ki?m tra username/password ?úng
- Ki?m tra IsActive = true trong database
- Ki?m tra b?ng Users ?ã có d? li?u

### Form main không hi?n th?
- Ki?m tra DialogResult trong frmLogin
- Ki?m tra Program.cs ?ã c?p nh?t ?úng

## Liên h? h? tr?
N?u có v?n ??, vui lòng t?o issue trên GitHub repository.
