/*Looks for the Orders by Tina Smith*/
SELECT * FROM orders AS o
	WHERE o.CID = 3;

/* Looks for the column with "iPhone7s" to report the revenue*/
SELECT p.ID, p.Name, SUM(Price) 
	FROM products AS p
	INNER JOIN orders AS o ON p.ID = o.PID
	WHERE p.Name = 'iPhone7s'
	GROUP BY p.ID, p.Name;

/*Increase price of iPhone to 250*/
UPDATE products
	SET Price = 250
	WHERE ID = 3;