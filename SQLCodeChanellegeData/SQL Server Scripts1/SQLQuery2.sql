/*INSERT INTO Products
    ([Name],[Price])
VALUES
    ('iPhone5s', $129.99),
	('iPhone6s', $189.99),
	('iPhone7s', $249.99)
;

INSERT INTO Customers
    ([FirstName],[LastName],[CardNumber])
VALUES
    ('Bart','Simpson',324529874532),
    ('Rick','Thomas', 990833216354),
    ('Morty','Clinton', 786512340987)
;

INSERT INTO Orders
    ([PID],[CID])
VALUES
    (9201821738 , 347567809),
	(7300283213 , 391004909),
	(7300382901 , 300304340)
;*/

INSERT INTO Products([ID],[Name],[Price])
	VALUES (0, 'A-Product', 5),
		(1, 'B-Product', 10),
		(2, 'C-Product', 15),
		(3, 'iPhone7s', 20) /*Tina's Product*/

INSERT INTO Customers([ID],[Firstname],[Lastname],[CardNumber])
	VALUES (0,'Bart','Simpson','324529874532'),
		(1,'Rick','Thomas', '990833216354'),
		(2,'Morty','Clinton','786512340987'),
		(3, 'Tina', 'Smith', '112390392031') /*Add Tina*/

INSERT INTO Orders([ID],[PID],[CID])
	VALUES (0, 0, 0),
		(1, 1, 1),
		(2, 2, 2),
		(3, 3, 3)