CREATE TABLE Addresses (
	Id int not null identity primary key,
	StreetName nvarchar(100) not null,
	PostalCode char(6) not null,
	City nvarchar(100) not null
)
GO

CREATE TABLE Customers (
	Id int not null identity primary key,
	FirstName nvarchar(50) not null,
	LastName nvarchar(50) not null,
	Email nvarchar(100) not null unique,
	PhoneNumber char(13) null,
	
	AddressId int not null references Addresses(Id)
)
