-- =========================
-- 1) CREATE DATABASE
-- =========================
IF DB_ID(N'GaraDb') IS NULL
BEGIN
    CREATE DATABASE GaraDb;
END
GO

USE GaraDb;
GO

-- =========================
-- 2) DROP TABLES (if rerun)
-- =========================
IF OBJECT_ID('dbo.RepairPartDetails', 'U') IS NOT NULL DROP TABLE dbo.RepairPartDetails;
IF OBJECT_ID('dbo.RepairServiceDetails', 'U') IS NOT NULL DROP TABLE dbo.RepairServiceDetails;
IF OBJECT_ID('dbo.RepairOrders', 'U') IS NOT NULL DROP TABLE dbo.RepairOrders;
IF OBJECT_ID('dbo.Cars', 'U') IS NOT NULL DROP TABLE dbo.Cars;
IF OBJECT_ID('dbo.Customers', 'U') IS NOT NULL DROP TABLE dbo.Customers;
IF OBJECT_ID('dbo.Parts', 'U') IS NOT NULL DROP TABLE dbo.Parts;
IF OBJECT_ID('dbo.Services', 'U') IS NOT NULL DROP TABLE dbo.Services;
GO

-- =========================
-- 3) MASTER TABLES
-- =========================
CREATE TABLE dbo.Customers
(
    CustomerId  INT IDENTITY(1,1) PRIMARY KEY,
    FullName    NVARCHAR(200) NOT NULL,
    Phone       NVARCHAR(20)  NULL,
    Address     NVARCHAR(300) NULL
);
GO

CREATE TABLE dbo.Cars
(
    CarId         INT IDENTITY(1,1) PRIMARY KEY,
    LicensePlate  NVARCHAR(20) NOT NULL,
    Brand         NVARCHAR(50) NULL,
    Model         NVARCHAR(50) NULL,
    [Year]        INT          NULL,
    CustomerId    INT          NOT NULL,

    CONSTRAINT FK_Cars_Customers
        FOREIGN KEY (CustomerId) REFERENCES dbo.Customers(CustomerId)
        ON DELETE CASCADE
);
GO

-- Unique biển số
CREATE UNIQUE INDEX UX_Cars_LicensePlate ON dbo.Cars(LicensePlate);
GO

CREATE TABLE dbo.Parts
(
    PartId     INT IDENTITY(1,1) PRIMARY KEY,
    PartName   NVARCHAR(200) NOT NULL,
    Unit       NVARCHAR(20)  NOT NULL DEFAULT N'pcs',
    UnitPrice  DECIMAL(18,2) NOT NULL DEFAULT 0,
    StockQty   INT           NOT NULL DEFAULT 0,
    MinQty     INT           NOT NULL DEFAULT 0
);
GO

CREATE TABLE dbo.Services
(
    ServiceId    INT IDENTITY(1,1) PRIMARY KEY,
    ServiceName  NVARCHAR(200) NOT NULL,
    BasePrice    DECIMAL(18,2) NOT NULL DEFAULT 0
);
GO

-- =========================
-- 4) TRANSACTION TABLES
-- =========================
CREATE TABLE dbo.RepairOrders
(
    RepairOrderId INT IDENTITY(1,1) PRIMARY KEY,
    CarId         INT           NOT NULL,
    ReceiveDate   DATETIME2     NOT NULL DEFAULT SYSUTCDATETIME(),
    Symptom       NVARCHAR(500) NULL,
    Odometer      INT           NOT NULL DEFAULT 0,
    [Status]      NVARCHAR(20)  NOT NULL DEFAULT N'OPEN', -- OPEN/PAID/CANCELED
    TotalAmount   DECIMAL(18,2) NOT NULL DEFAULT 0,

    CONSTRAINT FK_RepairOrders_Cars
        FOREIGN KEY (CarId) REFERENCES dbo.Cars(CarId)
        ON DELETE NO ACTION
);
GO

CREATE TABLE dbo.RepairServiceDetails
(
    RepairServiceDetailId INT IDENTITY(1,1) PRIMARY KEY,
    RepairOrderId         INT           NOT NULL,
    ServiceId             INT           NOT NULL,
    Qty                   INT           NOT NULL DEFAULT 1,
    UnitPrice             DECIMAL(18,2) NOT NULL DEFAULT 0,
    LineTotal             DECIMAL(18,2) NOT NULL DEFAULT 0,

    CONSTRAINT FK_RSD_RepairOrders
        FOREIGN KEY (RepairOrderId) REFERENCES dbo.RepairOrders(RepairOrderId)
        ON DELETE CASCADE,

    CONSTRAINT FK_RSD_Services
        FOREIGN KEY (ServiceId) REFERENCES dbo.Services(ServiceId)
        ON DELETE NO ACTION
);
GO

CREATE TABLE dbo.RepairPartDetails
(
    RepairPartDetailId INT IDENTITY(1,1) PRIMARY KEY,
    RepairOrderId      INT           NOT NULL,
    PartId             INT           NOT NULL,
    Qty                INT           NOT NULL DEFAULT 1,
    UnitPrice          DECIMAL(18,2) NOT NULL DEFAULT 0,
    LineTotal          DECIMAL(18,2) NOT NULL DEFAULT 0,

    CONSTRAINT FK_RPD_RepairOrders
        FOREIGN KEY (RepairOrderId) REFERENCES dbo.RepairOrders(RepairOrderId)
        ON DELETE CASCADE,

    CONSTRAINT FK_RPD_Parts
        FOREIGN KEY (PartId) REFERENCES dbo.Parts(PartId)
        ON DELETE NO ACTION
);
GO

-- =========================
-- 5) SAMPLE DATA (optional)
-- =========================
INSERT dbo.Customers(FullName, Phone, Address)
VALUES (N'Nguyễn Văn A', N'0900000001', N'Hà Nội'),
       (N'Trần Thị B', N'0900000002', N'Hải Phòng');

INSERT dbo.Cars(LicensePlate, Brand, Model, [Year], CustomerId)
VALUES (N'30A-12345', N'Toyota', N'Vios', 2020, 1),
       (N'15B-88888', N'Kia',    N'Cerato', 2021, 2);

INSERT dbo.Parts(PartName, Unit, UnitPrice, StockQty, MinQty)
VALUES (N'Lọc dầu', N'cái', 120000, 10, 2),
       (N'Dầu nhớt 1L', N'chai', 180000, 20, 5);

INSERT dbo.Services(ServiceName, BasePrice)
VALUES (N'Thay dầu', 150000),
       (N'Bảo dưỡng cơ bản', 300000);
GO

GO

-- Kiểm tra và tạo bảng Users nếu chưa tồn tại
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND type in (N'U'))
BEGIN
    PRINT 'Đang tạo bảng Users...'
    
    CREATE TABLE [dbo].[Users](
        [UserId] [int] IDENTITY(1,1) NOT NULL,
        [Username] [nvarchar](50) NOT NULL,
        [Password] [nvarchar](255) NOT NULL,
        [FullName] [nvarchar](200) NULL,
        [Role] [nvarchar](20) NOT NULL CONSTRAINT [DF_Users_Role] DEFAULT ('User'),
        [IsActive] [bit] NOT NULL CONSTRAINT [DF_Users_IsActive] DEFAULT (1),
        [CreatedDate] [datetime] NOT NULL CONSTRAINT [DF_Users_CreatedDate] DEFAULT (GETDATE()),
        CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([UserId] ASC)
    )
    
    PRINT 'Đã tạo bảng Users thành công!'
END
ELSE
BEGIN
    PRINT 'Bảng Users đã tồn tại.'
END
GO

-- Tạo unique constraint cho Username
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_Users_Username' AND object_id = OBJECT_ID('Users'))
BEGIN
    CREATE UNIQUE NONCLUSTERED INDEX [IX_Users_Username] ON [dbo].[Users]
    (
        [Username] ASC
    )
    PRINT 'Đã tạo unique index cho Username.'
END
GO

-- Thêm tài khoản Admin mặc định
-- Username: admin
-- Password: admin123 (Hash SHA256: jGl25bVBBBW96Qi9Te4V37Fnqchz/Eu4qB9vKrRIqRg=)
IF NOT EXISTS (SELECT * FROM Users WHERE Username = 'admin')
BEGIN
    INSERT INTO [dbo].[Users] ([Username], [Password], [FullName], [Role], [IsActive], [CreatedDate])
    VALUES (
        'admin',
        'jGl25bVBBBW96Qi9Te4V37Fnqchz/Eu4qB9vKrRIqRg=',
        N'Quản trị viên',
        'Admin',
        1,
        GETDATE()
    )
    PRINT 'Đã tạo tài khoản Admin.'
END
ELSE
BEGIN
    PRINT 'Tài khoản admin đã tồn tại.'
END
GO

-- Thêm tài khoản User mẫu
-- Username: user1
-- Password: user123 (Hash SHA256: BPiZbadjt6lpsQKO4wB1aerzpjVIbdqyEdUSyFud+Ps=)
IF NOT EXISTS (SELECT * FROM Users WHERE Username = 'user1')
BEGIN
    INSERT INTO [dbo].[Users] ([Username], [Password], [FullName], [Role], [IsActive], [CreatedDate])
    VALUES (
        'user1',
        'BPiZbadjt6lpsQKO4wB1aerzpjVIbdqyEdUSyFud+Ps=',
        N'Nhân viên 1',
        'User',
        1,
        GETDATE()
    )
    PRINT 'Đã tạo tài khoản User mẫu.'
END
ELSE
BEGIN
    PRINT 'Tài khoản user1 đã tồn tại.'
END
GO

-- Hiển thị danh sách tài khoản đã tạo
PRINT ''
PRINT '============================================'
PRINT 'DANH SÁCH TÀI KHOẢN TRONG HỆ THỐNG:'
PRINT '============================================'
SELECT 
    UserId as [ID],
    Username as [Tên đăng nhập],
    FullName as [Họ tên],
    Role as [Vai trò],
    CASE WHEN IsActive = 1 THEN N'Kích hoạt' ELSE N'Khóa' END as [Trạng thái],
    CONVERT(varchar, CreatedDate, 103) as [Ngày tạo]
FROM Users
ORDER BY UserId
GO

PRINT ''
PRINT '============================================'
PRINT 'HOÀN TẤT! BẠN CÓ THỂ ĐĂNG NHẬP VỚI:'
PRINT '============================================'
PRINT 'Tài khoản Admin:'
PRINT '  Username: admin'
PRINT '  Password: admin123'
PRINT ''
PRINT 'Tài khoản User:'
PRINT '  Username: user1'
PRINT '  Password: user123'
PRINT '============================================'

GO

-- Xóa dữ liệu cũ
DELETE FROM Users
GO

-- Thêm tài khoản admin với hash đúng (từ debug info)
-- Username: admin
-- Password: admin123
-- Hash: JAvIGPq9JyTdtvBO6x2lInRI1+gxwIyPqCkAn3THlkk=
INSERT INTO [dbo].[Users] ([Username], [Password], [FullName], [Role], [IsActive], [CreatedDate])
VALUES (
    'admin',
    'JAvIGPq9JyTdtvBO6x2lInRI1+gxwIyPqCkAn3THlkk=',
    N'Quản trị viên',
    'Admin',
    1,
    GETDATE()
)
GO

PRINT 'Đã tạo tài khoản admin với hash mới.'
GO

-- Tạo hash cho user123 và thêm tài khoản user1
-- Tạm thời comment dòng này, chỉ dùng admin trước
-- Sau khi admin login thành công, ta sẽ tạo user1

-- Hiển thị kết quả
PRINT ''
PRINT '============================================'
PRINT 'TÀI KHOẢN ĐÃ TẠO:'
PRINT '============================================'
SELECT 
    UserId as [ID],
    Username as [Username],
    FullName as [Full Name],
    Role as [Role],
    CASE WHEN IsActive = 1 THEN 'Active' ELSE 'Inactive' END as [Status],
    LEFT(Password, 50) as [Password Hash]
FROM Users
ORDER BY UserId
GO

PRINT ''
PRINT '============================================'
PRINT 'ĐĂNG NHẬP VỚI:'
PRINT 'Username: admin'
PRINT 'Password: admin123'
PRINT '============================================'