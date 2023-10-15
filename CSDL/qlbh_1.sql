CREATE DATABASE PROJECT_QUAN_LI_BAN_HANG

-- BẢNG ROLE
CREATE TABLE Role (
    RoleId char(5) PRIMARY KEY,
    RoleName nvarchar(50) NOT NULL
);

INSERT INTO Role 
VALUES ('admin',N'quản trị'),
('nvien',N'nhân viên'),
('khang',N'khách hàng')

-- BẢNG CUSTOMERS

-- Tạo bảng Employees với cột tính toán MaNV
CREATE TABLE Employees (
    Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    MaNV AS ('NV' + CAST(Id AS VARCHAR(20))) PERSISTED UNIQUE,
    Email VARCHAR(50) UNIQUE,
    DiaChi NVARCHAR(100),
    RoleId CHAR(5),
    TinhTrang TINYINT,
    PasswordHash VARCHAR(64), -- Sử dụng VARCHAR(64) để lưu trữ giá trị băm SHA-256
    FOREIGN KEY (RoleId) REFERENCES Role(RoleId)
);

ALTER TABLE Employees
ADD HoTen NVARCHAR(100);


DROP TABLE Employees
-- Định nghĩa hàm băm SHA-256
-- Xóa hàm ComputeSHA256Hash nếu tồn tại
DROP FUNCTION IF EXISTS dbo.ComputeSHA256Hash;

CREATE FUNCTION ComputeSHA256Hash
(
    @rawData VARCHAR(MAX)
)
RETURNS VARCHAR(64)
AS
BEGIN
    DECLARE @hashedValue VARCHAR(64);
    SET @hashedValue = (SELECT LOWER(CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', @rawData), 2)));
    RETURN @hashedValue;
END;
GO

-- Chèn nhân viên mới với mật khẩu đã mã hóa
DECLARE @Password VARCHAR(100);
SET @Password = 'abcde'; -- Thay thế bằng mật khẩu mới của nhân viên

INSERT INTO Employees (Email, DiaChi, RoleId, TinhTrang, PasswordHash)
VALUES ('nguyenkinhthanh11@gmail.com', 'FPT POLYTECHNIC', 'admin', 1, dbo.ComputeSHA256Hash(@Password));
select * from  Employees 
DECLARE @Password VARCHAR(100);
SET @Password = '12345'; -- Thay thế bằng mật khẩu mới của nhân viên
update Employees set HoTen = N'Nguyễn Kinh Thành' where Id = 1
update Employees set HoTen = N'Dương Thị Minh' where Id = 2
INSERT INTO Employees (Email, DiaChi, RoleId, TinhTrang, PasswordHash)
VALUES ('duongthiminh0111@gmail.com', N'Quảng Nam', 'nvien', 1, dbo.ComputeSHA256Hash(@Password));
delete from Employees where Id = 6
select * from Employees

--
CREATE TABLE SANPHAM (
    MaSp varchar(20) NOT NULL PRIMARY KEY,
    TenSp NVARCHAR(255),
    SoLuong INT CHECK (SoLuong >= 0),
	DonGiaNhap float CHECK (DonGiaNhap >=0),
    DonGiaBan float CHECK (DonGiaBan >= 0),
    HinhAnh VARCHAR(255),
	GhiChu NVARCHAR(255),
    MaNV VARCHAR(22) NOT NULL,
    FOREIGN KEY (MaNV) REFERENCES Employees(MaNV)
);

DROP TABLE SANPHAM
select * from sanpham

--TAO BANG KHACHHANGONLINE

-- Tạo bảng Role trước đây, nơi bạn định nghĩa các vai trò
CREATE TABLE Role (
    RoleID INT PRIMARY KEY,
    RoleName VARCHAR(255) NOT NULL
);

CREATE TABLE KhachHangOnline (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    TenKhachHang NVARCHAR(255) NOT NULL,
    Email VARCHAR(50) UNIQUE NOT NULL,
    PasswordHash varchar(64)  NOT NULL,
    RoleID char(5),
    FOREIGN KEY (RoleID) REFERENCES Role(RoleID)
);
DECLARE @Password VARCHAR(100);
SET @Password = '12345'; 
INSERT INTO KhachHangOnline (TenKhachHang,Email, PasswordHash,RoleID)
VALUES (N'Nguyễn Kinh Thành', 'thanhnkpd07562@fpt.edu.com',dbo.ComputeSHA256Hash(@Password),'khang');
DECLARE @Password VARCHAR(100);
SET @Password = '01112'; 
INSERT INTO KhachHangOnline (TenKhachHang,Email, PasswordHash,RoleID)
VALUES (N'Nguyễn Văn Nhật','nguyenvannhatltqb@gmail.com', dbo.ComputeSHA256Hash(@Password),'khang')
delete from KhachHangOnline

select * from KhachHangOnline

select * from sanpham