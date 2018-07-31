--use ToadDB;

CREATE TABLE Products
([ID] int PRIMARY KEY,
[Name] varchar(50),
[Price] decimal(3)
);

CREATE TABLE Customers
([ID] int PRIMARY KEY,
[Firstname] varchar(50),
[Lastname] varchar (50),
[CardNumber] varchar(50)
);

CREATE TABLE Orders
([ID] int PRIMARY KEY,
[PID] int FOREIGN KEY References Products(ID),
[CID] int FOREIGN KEY References Customers(ID),
);

