CREATE TABLE Addresses (
	Id int not null identity primary key,
	StreetName nvarchar(100) not null,
	PostalCode char(6) not null,
	City nvarchar(100) not null
)
GO

CREATE TABLE Customers (
	Id uniqueidentifier not null primary key,
	FirstName nvarchar(50) not null,
	LastName nvarchar(50) not null,
	Email nvarchar(100) not null unique,
	PhoneNumber char(13) null,
	
	AddressId int not null references Addresses(Id)
)
GO

INSERT INTO Addresses VALUES 
	('Nordkapsvägen 1', '136 57', 'VEGA'),
	('Nordkapsvägen 3', '136 57', 'VEGA'),
	('Nordkapsvägen 5', '136 57', 'VEGA')
GO

INSERT INTO Customers VALUES
	('b273e263-7543-4efb-8898-c44e123580dd','Hans','Mattin-Lassei','hans@domain.com','073-123 45 67', 1),
	('6c0bc120-5b04-4507-9f4b-7d3e73831667','Loke','Adamsson','loke@gmail.com','073-574 58 99', 1),
	('0830bada-bda0-4c85-9beb-1506edea4ac6','Gunilla','Jonsson','gunillajonson@gmail.com','070-555 68 91', 2)
GO