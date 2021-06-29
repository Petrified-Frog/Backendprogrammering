CREATE TABLE Guest(
	ID int not null identity(1,1) primary key,
	FirstName nvarchar(30) not null,
	LastName nvarchar(50) not null,
	Phone varchar(15) not null,
	Email varchar(50) not null unique
)

CREATE TABLE Room(
	RoomNr smallint not null identity(1,1) primary key,
	RoomType varchar(6) not null,
	Price money not null
)
GO

CREATE TABLE Reservation(
	ReservationNr int not null identity(1,1) primary key,
	RoomNr smallint not null references Room(RoomNr),
	CheckInDate date not null,
	CheckOutDate date not null,
	PaymentMethod nvarchar(10) not null
) 
GO

CREATE TABLE PartyReservation(
	GuestID int not null references Guest(ID),
	ReservationNr int not null references Reservation(ReservationNr)

	primary key (GuestID, ReservationNr)
)