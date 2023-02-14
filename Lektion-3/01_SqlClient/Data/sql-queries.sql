DECLARE @FirstName nvarchar(50) SET @FirstName = 'Anna'
DECLARE @LastName nvarchar(50) SET @LastName = 'Svanström'
DECLARE @Email nvarchar(100) SET @Email = 'anna@domain.com'
DECLARE @PhoneNumber char(13) SET @PhoneNumber = '073-123 45 67'
DECLARE @AddressId int SET @AddressId = 3
DECLARE @StreetName nvarchar(100) SET @StreetName = 'Nordkapsvägen 3'
DECLARE @PostalCode char(6) SET @PostalCode = '136 57'
DECLARE @City nvarchar(100) SET @City = 'Vega'

-- saves address to database if not exists and returns the id else it returns the id of the the already inserted address
IF NOT EXISTS (SELECT Id FROM Addresses WHERE StreetName = @StreetName AND PostalCode = @PostalCode AND City = @City)
	INSERT INTO Addresses OUTPUT INSERTED.Id VALUES (@StreetName, @PostalCode, @City)
ELSE
	SELECT Id FROM Addresses WHERE StreetName = @StreetName AND PostalCode = @PostalCode AND City = @City


-- saves the customer to the database if no customer with the same email address already exists
IF NOT EXISTS (SELECT Id FROM Customers WHERE Email = @Email)
	INSERT INTO Customers VALUES (@FirstName, @LastName, @Email, @PhoneNumber, @AddressId)


-- get all from addresses and get all from customers tabels
SELECT * FROM Addresses
SELECT * FROM Customers


-- get all customers+address from database
SELECT 
	c.Id, c.FirstName, c.LastName, c.Email, PhoneNumber,
	a.StreetName, a.PostalCode, a.City
FROM Customers c
JOIN Addresses a ON c.AddressId = a.Id


-- get specific customer+address from database based on email address
SELECT 
	c.Id, c.FirstName, c.LastName, c.Email, PhoneNumber,
	a.StreetName, a.PostalCode, a.City
FROM Customers c
JOIN Addresses a ON c.AddressId = a.Id
WHERE c.Email = @Email
