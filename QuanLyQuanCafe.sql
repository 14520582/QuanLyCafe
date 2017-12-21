CREATE DATABASE QuanLyQuanCafe
GO
SET DATEFORMAT dmy;
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
	IdTable INT primary key identity(1,1),
	Name NVARCHAR(100),
	Location NVARCHAR(200),
	Status NVARCHAR(20)
	--Status INT NOT NULL DEFAULT 0 --0: trong 1: co nguoi
)
GO
--Unit
CREATE TABLE Unit
(
	IdUnit INT primary key identity(1,1),
	Name NVARCHAR(100) NOT NULL,
)
GO
--FoodCategory
CREATE TABLE FoodCategory
(
	IdCategory INT primary key identity(1,1),
	Name NVARCHAR(100) NOT NULL
)
GO
--Food
CREATE TABLE Food
(
	IdFood INT primary key identity(1,1),
	Name NVARCHAR(100) NOT NULL,
	IdCategory INT NOT NULL,
	IdUnit INT NOT NULL,
	Price INT NOT NULL

	FOREIGN KEY (IdCategory) REFERENCES FoodCategory(IdCategory),
	FOREIGN KEY (IdUnit) REFERENCES Unit(IdUnit)
)
GO
--Account
CREATE TABLE Account
(
	IdAccount INT primary key identity(1,1),
	Name NVARCHAR(100) NOT NULL,
	PassWord NVARCHAR(1000) NOT NULL,
	Type INT NOT NULL
)
GO
--Bill
CREATE TABLE Bill
(
	IdBill INT primary key identity(1,1),
	Date DATE,
	TotalPrice INT NOT NULL,
	Status INT NOT NULL DEFAULT 0 --0: chua thanh toan 1: Da Thanh Toan
)
GO
--BillInfo
CREATE TABLE BillInFo
(
	Id INT primary key identity(1,1),
	IdBill INT NOT NULL,
	IdFood INT NOT NULL,
	Number INT NOT NULL DEFAULT 0

	FOREIGN KEY (IdBill) REFERENCES Bill(IdBill),
	FOREIGN KEY (IdFood) REFERENCES Food(IdFood)
)
GO
--BillTable
CREATE TABLE BillTable
(
	Id INT primary key identity(1,1),
	IdBill INT NOT NULL,
	IdTable INT NOT NULL,

	FOREIGN KEY (IdBill) REFERENCES Bill(IdBill),
	FOREIGN KEY (IdTable) REFERENCES TableCafe(IdTable)
)
GO
INSERT INTO dbo.Account ( Name,PassWord,Type) VALUES (N'TRAM',N'TRAM',0)
GO
INSERT INTO dbo.FoodCategory ( Name) VALUES (N'Sinh tố')
GO
INSERT INTO dbo.FoodCategory ( Name) VALUES (N'Mojito')
GO
GO
INSERT INTO dbo.FoodCategory ( Name) VALUES (N'Cà phê')
GO
INSERT INTO dbo.FoodCategory ( Name) VALUES (N'Bánh Ngọt')
GO
GO
INSERT INTO dbo.Unit ( Name) VALUES (N'Ly')
GO
INSERT INTO dbo.Unit ( Name) VALUES (N'Hộp')
GO
INSERT INTO dbo.Food ( Name,IdCategory,IdUnit,Price) VALUES (N'Sinh tố Bơ',1,1,15000)
GO
INSERT INTO dbo.Food ( Name,IdCategory,IdUnit,Price) VALUES (N'Sinh tố Mãng Cầu',1,1,15000)
GO
INSERT INTO dbo.Food ( Name,IdCategory,IdUnit,Price) VALUES (N'Mojito Chanh Dây',2,1,18000)
GO
INSERT INTO dbo.Food ( Name,IdCategory,IdUnit,Price) VALUES (N'Cà phê sữa',3,1,14000)
GO
INSERT INTO dbo.Food ( Name,IdCategory,IdUnit,Price) VALUES (N'Bánh Su kem',4,2,30000)
GO
INSERT INTO dbo.TableCafe( Name,Location,Status) VALUES (N'01',N'Ngoài sân',0)
GO
INSERT INTO dbo.TableCafe( Name,Location,Status) VALUES (N'02',N'Ngoài sân',0)
GO
INSERT INTO dbo.TableCafe( Name,Location,Status) VALUES (N'03',N'Trong nhà',0)
GO
INSERT INTO dbo.TableCafe( Name,Location,Status) VALUES (N'04',N'Trong nhà',0)
GO
INSERT INTO dbo.Bill ( Date,TotalPrice,Status) VALUES ('24-07-2017',30000,1)
GO
--BeginBillInfo
INSERT INTO dbo.BillTable ( IdBill,IdTable) VALUES (1,1)
GO
INSERT INTO dbo.BillInfo ( IdBill,IdFood,Number) VALUES (1,1,1)
GO
INSERT INTO dbo.BillInfo ( IdBill,IdFood,Number) VALUES (1,2,1)
GO
--EndBillInfo
INSERT INTO dbo.Bill ( Date,TotalPrice,Status) VALUES ('26-08-2017',59000,1)
GO
--BeginBillInfo
INSERT INTO dbo.BillTable ( IdBill,IdTable) VALUES (2,2)
GO
INSERT INTO dbo.BillInfo ( IdBill,IdFood,Number) VALUES (2,2,1)
GO
INSERT INTO dbo.BillInfo ( IdBill,IdFood,Number) VALUES (2,4,1)
GO
INSERT INTO dbo.BillInfo ( IdBill,IdFood,Number) VALUES (2,5,1)
GO
--EndBillInfo
INSERT INTO dbo.Bill ( Date,TotalPrice,Status) VALUES ('12-09-2017',48000,1)
GO
--BeginBillInfo
INSERT INTO dbo.BillTable ( IdBill,IdTable) VALUES (3,3)
GO
INSERT INTO dbo.BillInfo ( IdBill,IdFood,Number) VALUES (3,2,2)
GO
INSERT INTO dbo.BillInfo ( IdBill,IdFood,Number) VALUES (3,3,1)
GO
--EndBillInfo
INSERT INTO dbo.Bill ( Date,TotalPrice,Status) VALUES ('01-11-2017',60000,1)
GO
--BeginBillInfo
INSERT INTO dbo.BillTable ( IdBill,IdTable) VALUES (4,1)
GO
INSERT INTO dbo.BillTable ( IdBill,IdTable) VALUES (4,2)
GO
INSERT INTO dbo.BillInfo ( IdBill,IdFood,Number) VALUES (4,1,1)
GO
INSERT INTO dbo.BillInfo ( IdBill,IdFood,Number) VALUES (4,3,1)
GO
INSERT INTO dbo.BillInfo ( IdBill,IdFood,Number) VALUES (4,5,1)
GO
--EndBillInfo
INSERT INTO dbo.Bill ( Date,TotalPrice,Status) VALUES ('12-12-2017',36000,1)
GO
--BeginBillInfo
INSERT INTO dbo.BillTable ( IdBill,IdTable) VALUES (5,1)
GO
INSERT INTO dbo.BillInfo ( IdBill,IdFood,Number) VALUES (5,3,2)
GO
--EndBillInfo
--BÀN
--Load bàn
create proc LoadTable
as
begin
	select * from TableCafe
end
go
--Kiểm tra tên bàn hợp lệ
CREATE PROC CheckValidTable
@Name nvarchar(100),
@Result int output
as
begin
	if exists (select * from TableCafe where Name = @Name)
		begin
			set @Result = 0
		end
		else
			begin
				set @Result = 1
			end
end
GO
--Thêm bàn
create proc AddTable
@Name nvarchar(100),
@Status nvarchar(20),
@Location nvarchar(200)
AS
BEGIN
	insert into TableCafe(Name, Location, Status) values(@Name, @Location,@Status)
END
GO
--Sửa bàn
create proc EditTable
@Idtable int,
@Name nvarchar(100),
@Location nvarchar(200),
@Status nvarchar(20)
as
begin
	update TableCafe set Name = @Name, Location = @Location, Status = @Status
	where IdTable = @Idtable
end
go
--Xóa bàn
create proc DeleteTable
@IdTable int
as
begin
	delete TableCafe where Idtable = @Idtable
end
go
--Đếm bàn
create proc CountTable
@Number int output
as
begin
	set @Number = (select Count(Name) from TableCafe) 
end
go
--MÓN ĂN
--Load loại món ăn
create proc LoadFoodCategory
as
begin
	select * from FoodCategory
end
go
--Load món ăn
create proc LoadFood
as
begin
	select * from Food
end
go
--Thêm món ăn
CREATE PROC AddFood
@Name nvarchar(100),
@IdCategory int,
@Price float
AS
BEGIN
	insert into Food(Name, IdCategory, Price) values(@Name, @IdCategory, @Price)
END
go
--Update món ăn
create proc UpdateFood
@IdFood int,
@Name nvarchar(100),
@IdCategory int,
@Price float
as
begin
	update Food set Name = @Name, IdCategory = @IdCategory, Price = @Price
	where IdFood = @IdFood
end
go
--Xóa món ăn
create proc DeleteFood
@IdFood int
as
begin
	delete Food where IdFood = @IdFood
end
go
--HOADON va CTHD
--Load hoa don
create proc LoadAllBill
as
begin
	select * from Bill
end
go
--Load hoa don
create proc LoadBillByIdTable
@IdTable int
as
begin
	select b.IdBill, b.Date, b.TotalPrice, b.Status from BillTable a, Bill b
	where a.IdTable = @IdTable and a.IdBill = b.IdBill and b.Status = 0
end
go
--Load chi tiet hoa don theo bill
create proc LoadBillInfoByIdBill
@IdBill int
as
begin
	select BillInfo.Id, BillInfo.IdBill, Food.Name as FoodName, Number, Price*Number as Total
	from Food, BillInFo
	where Food.IdFood = BillInFo.IdFood
	and BillInFo.IdBill = @IdBill
end
go
--Load tat ca chi tiet hoa don
create proc LoadAllBillInfo
as
begin
	select BillInfo.Id, BillInfo.IdBill, Food.Name as FoodName, Number, Price*Number as Total
	from Food, BillInFo
	where Food.IdFood = BillInFo.IdFood
end
go
--Load tat ca chi tiet ban cua hoa don
create proc LoadAllBillTable
as
begin
	select BillTable.Id, BillTable.IdBill, TableCafe.IdTable, TableCafe.Name
	from TableCafe, BillTable
	where TableCafe.IdTable = BillTable.IdTable
end
go
--Them chi tiet hoa don
create proc AddBillInfo
@IdTable int,
@IdFood int,
@Number int
as
begin

		insert into BillInfo(IdBill,IdFood,Number) values (@IdTable,@IdFood,@Number)
end
go
--Tao hoa don
--TÌM KIẾM
--Tìm theo tên món ăn
create proc FindByNameOfFood
@NameOfFood nvarchar(50)
as
begin
	select Food.Name, FoodCategory.Name, Price
	from Food, FoodCategory
	where Food.IdCategory = FoodCategory.IdCategory
	and Food.Name like ('%' + @NameOfFood + '%')
end
go
--tìm chi tiết hóa đơn theo ngày
create proc FindBillInfoByDate
@Date smalldatetime
as
begin
	select Food.Name, Number, (select sum(BillInfo.Number * Food.Price) from BillInFo, Food, Bill where Bill.IdBill = BillInFo.IdBill and BillInfo.IdFood = Food.IdFood), Bill.TotalPrice, Status
	from Food, Bill, BillInFo
	where Food.IdFood = BillInFo.IdFood
	and Bill.IdBill = BillInFo.IdBill
	and Bill.Date = @Date
end
go
--BAOCAO
--Chọn các tháng 
create proc MonthReport
as
begin
	select cast(datepart(mm,Date) as varchar)+'/'+cast(datepart(yyyy,Date) as varchar) as MonthYear
	into Temp
	from Bill
	select * from Temp
	where MonthYear <> (cast(datepart(mm,GETDATE()) as varchar)+'/'+cast(datepart(yyyy,GETDATE()) as varchar))
	group by MonthYear
	order by MonthYear desc
	drop table temp
end
go
--lap chi tiet bao cao ngay
create proc DailyReport
@FirstDay smalldatetime,
@LastDay smalldatetime
as
begin
	select Date, SUM(TotalPrice) 
	from Bill
	where DATEDIFF(month,@FirstDay,Date) >=0 and DATEDIFF(month,@LastDay,Date) <= 0
	group by Date
end
go
--chi tiet bao cao theo món ăn
create proc FoodReport
@FirstDay smalldatetime,
@LastDay smalldatetime
as
begin
	select Food.Name , Food.Price, Sum(BillInFo.Number), count(BillInFo.IdBill)
	from Food, Bill, BillInFo
	where Bill.IdBill = BillInFo.IdBill
	and BillInFo.IdFood = Food.IdFood
	and DATEDIFF(month,@FirstDay,Date) >=0 and DATEDIFF(month,@LastDay,Date) <= 0
	group by BillInfo.IdFood,Name,Price
end  
go
