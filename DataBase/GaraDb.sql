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

USE GaraDb;
INSERT INTO Customers(FullName, Phone, Address) VALUES(N'Test', '000', N'Test');
SELECT * FROM Customers;
