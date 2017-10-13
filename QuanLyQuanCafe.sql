CREATE DATABASE QuanLyQuanCafe
GO

USE QuanLyQuanCafe
GO
--đăng nhập tài khoản
CREATE PROC LogIn
@UserName nvarchar(50),
@Password nvarchar(50),
@Result int output
as
begin
	if exists (select * from Account where Name = @UserName and PassWord = @Password)
		begin
			select @Result = IdAccount from Account where Name = @UserName
			return 
		end
		else
			begin
				set @Result = 0
			end
end
GO
--Table
CREATE TABLE TableCafe
(
	IdTable INT IDENTITY PRIMARY KEY,
	Name NVARCHAR(100),
	Status INT NOT NULL DEFAULT 0 --0:chua dat  1: Da dat
)
GO
--FoodCategory
CREATE TABLE FoodCategory
(
	IdCategory INT IDENTITY PRIMARY KEY,
	Name NVARCHAR(100) NOT NULL
)
GO
--Food
CREATE TABLE Food
(
	IdFood INT IDENTITY PRIMARY KEY,
	Name NVARCHAR(100) NOT NULL,
	IdCategory INT NOT NULL,
	Price FLOAT NOT NULL

	FOREIGN KEY (IdCategory) REFERENCES FoodCategory(IdCategory)
)
GO

--Account
CREATE TABLE Account
(
	IdAccount INT IDENTITY PRIMARY KEY,
	Name NVARCHAR(100) NOT NULL,
	PassWord NVARCHAR(1000) NOT NULL,
	Type INT NOT NULL
)
GO
--Bill
CREATE TABLE Bill
(
	IdBill INT IDENTITY PRIMARY KEY,
	Date DATE,
	IdTable INT NOT NULL,
	TotalPrice int NOT NULL,
	Status INT NOT NULL DEFAULT 0 --0: chua thanh toan 1: Da Thanh Toan

	FOREIGN KEY (IdTable) REFERENCES TableCafe(IdTable)
)
GO
--BillInfo
CREATE TABLE BillInFo
(
	Id INT IDENTITY PRIMARY KEY,
	IdBill INT NOT NULL,
	IdFood INT NOT NULL,
	Number INT NOT NULL DEFAULT 0,
	TotalPrice int NOT NULL

	FOREIGN KEY (IdBill) REFERENCES Bill(IdBill),
	FOREIGN KEY (IdFood) REFERENCES Food(IdFood)
)
GO

INSERT INTO dbo.Account
		( Name,
		  PassWord,
		  Type		
		)
VALUES (N'TRAM',
		N'TRAM',
		0
		)
--CREATE PROC USP_GetAccountByName
--@name nvarchar(100)
--AS
--BEGIN
--	SELECT * FROM dbo.Account WHERE Name = @name
--END
--GO

