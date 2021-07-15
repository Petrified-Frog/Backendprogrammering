CREATE TABLE Pupil(
	ID int not null identity(1,1) primary key,
	FirstName nvarchar(50) not null,
	LastNamr nvarchar(50) not null,
	Email nvarchar(50) not null unique,
	Password nvarchar(30) not null,
	AdOk bit not null,
	ProfileImgURL nvarchar(100),
	ClassId int 
)