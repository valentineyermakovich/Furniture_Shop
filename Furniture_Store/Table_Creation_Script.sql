create table Items
(
	ID int primary key identity,
	[Name] nvarchar(40),
	Item_Type nvarchar(40),
	Cost decimal not null,
	Date_Of_Add datetime not null,
	Amount int not null,
	[Image] varbinary(max)
)

create table User_Role
(
	ID int primary key identity,
	[Name] nvarchar(40)
)

insert into dbo.User_Role Values('Admin')
insert into dbo.User_Role Values('User')

create table Users
(
	ID int primary key identity,
	[Name] nvarchar(40),
	[Login] nvarchar(40),
	[Password] nvarchar(15),
	[Role] int references User_Role(ID),
	[Address] nvarchar(70),
	[Phone_Number] nvarchar(13),
	[Mail] nvarchar(40),
)

create table Orders
(
	ID int primary key identity,
	Cost decimal not null,
	[Customer] int references [Users](ID),
	[Status] nvarchar(15),
	Is_Approved BIT
)

create table Order_Items
(
	ID int primary key identity(1,1),
	Item_ID int references Items(ID),
	Order_ID int references Orders(ID)
)

