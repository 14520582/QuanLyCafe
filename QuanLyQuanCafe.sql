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
	IdTable INT primary key identity(1,1),
	Name NVARCHAR(100),
	Status INT NOT NULL DEFAULT 0 --0:chua dat  1: Da dat
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
	Price FLOAT NOT NULL

	FOREIGN KEY (IdCategory) REFERENCES FoodCategory(IdCategory)
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
	IdTable INT NOT NULL,
	TotalPrice int NOT NULL,
	Status INT NOT NULL DEFAULT 0 --0: chua thanh toan 1: Da Thanh Toan

	FOREIGN KEY (IdTable) REFERENCES TableCafe(IdTable)
)
GO
--BillInfo
CREATE TABLE BillInFo
(
	Id INT primary key identity(1,1),
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
GO
--BÀN
--Load bàn
create proc LoadTable
as
begin
	select * from TableCafe
end
go
--Thêm bàn
create proc AddTable
@Name nvarchar(100),
@Status nvarchar(4)
AS
BEGIN
	insert into TableCafe(Name, Status) values(@Name, @Status)
END
go
--Xóa bàn
create proc DeleteTable
@IdTable int
as
begin
	delete TableCafe where Idtable = @Idtable
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
create proc LoadBill
@IdTable int
as
begin
	select Date,IdTable,TotalPrice,Status from Bill
	where IdTable = @IdTable
end
go
--Load chi tiet hoa don
create proc LoadBillInfo
@IdBill int
as
begin
	select Food.Name, Number, Price
	from Food, BillInFo
	where Food.IdFood = BillInFo.IdFood
	and BillInFo.IdBill = @IdBill
end
go
--Them chi tiet hoa don
create proc AddBillInfo
@IdTable int
as
begin

		insert into BillInfo(IdBill,IdFood,Number,TotalPrice)
		select BillInFo.IdBill, BillInFo.IdFood, BillInfo.Number, (select sum(BillInfo.Number * Food.Price) from BillInFo, Food, Bill where BillInfo.IdFood = Food.IdFood)																																 																																			   
		from Bill, Food, BillInfo
		where Bill.IdBill = BillInfo.IdBill
		and Food.IdFood = BillInfo.IdFood
		and Bill.IdTable = @IdTable
end
go
--Tao hoa don
create proc CreateBill
@IdTable int
as
begin
		insert into Bill(Date,IdTable,TotalPrice, Status) values ((select Date from Bill), @IdTable, (select sum(BillInfo.Number * Food.Price) from BillInFo, Food, Bill
																																			 where Bill.IdBill = BillInFo.IdBill
																																			 and BillInfo.IdFood = Food.IdFood
																																			 and Bill.IdTable = @IdTable
																																			 group by IdTable), (select Status from Bill))
end
go
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
	select Date, count(IdTable), SUM(TotalPrice) 
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
