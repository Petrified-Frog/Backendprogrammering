CREATE TABLE Guests (
	Id int not null identity(1,1) primary key,
	FirstName nvarchar(50) not null,
	LastName nvarchar(50) not null,
	Email varchar(100) not null unique
)
GO

CREATE TABLE RoomTypes ( 
	Id int not null identity(1,1) primary key,
	Name nvarchar(50) not null 
)
GO

CREATE TABLE PaymentMethods (
	Id int not null identity(1,1) primary key,
	Name nvarchar(50) not null
)
GO

CREATE TABLE Rooms (
	Id int not null identity(1,1) primary key,
	RoomTypeId int not null references RoomTypes(Id)
)
GO

CREATE TABLE Reservations (
	Id int not null identity(1,1) primary key,
	GuestId int not null references Guests(Id),
	RoomId int not null references Rooms(Id),
	PaymentMethodId int not null references PaymentMethods(Id),
	StartDate date not null,
	EndDate date not null
)
GO