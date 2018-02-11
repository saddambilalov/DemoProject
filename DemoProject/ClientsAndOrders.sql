--a- list of clients, which have an order with order_sum > 50 
--MS SQL Actual Execution Plan is same for both queries
SELECT DISTINCT Clients.* FROM Clients
INNER JOIN Orders ON Orders.order_sum > 50 AND Orders.client_id = Clients.client_id


SELECT Clients.* FROM Clients
WHERE EXISTS (
 SELECT 1
 FROM Orders
 WHERE Orders.order_sum > 50 AND Orders.client_id = Clients.client_id
 );

 --b- clients, whose total sum of orders exceeds 100 
 --MS SQL Actual Execution Plan shows the first query is faster than the second one
SELECT Clients.client_id, Clients.client_name FROM Clients
INNER JOIN Orders ON Orders.client_id = Clients.client_id
GROUP BY Clients.client_id, Clients.client_name
HAVING SUM(ISNULL(Orders.order_sum, 0)) > 100

SELECT Clients.* FROM Clients
WHERE EXISTS (
	SELECT 1
	FROM Orders
	WHERE Orders.client_id = Clients.client_id
	GROUP BY Orders.client_id
	HAVING SUM(ISNULL(Orders.order_sum, 0)) > 100
 );