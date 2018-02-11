--a- list of clients, which have an order with order_sum > 50  
--MS SQL Actual Execution Plan is same for both queries 
SELECT DISTINCT clients.* 
FROM   clients 
       INNER JOIN orders 
               ON orders.order_sum > 50 
                  AND orders.client_id = clients.client_id 

SELECT clients.* 
FROM   clients 
WHERE  EXISTS (SELECT 1 
               FROM   orders 
               WHERE  orders.order_sum > 50 
                      AND orders.client_id = clients.client_id)

--b- clients, whose total sum of orders exceeds 100  
--MS SQL Actual Execution Plan shows the first query is faster than the second one 
SELECT clients.client_id, 
       clients.client_name 
FROM   clients 
       INNER JOIN orders 
               ON orders.client_id = clients.client_id 
GROUP  BY clients.client_id, 
          clients.client_name 
HAVING Sum(Isnull(orders.order_sum, 0)) > 100 

SELECT clients.* 
FROM   clients 
WHERE  EXISTS (SELECT 1 
               FROM   orders 
               WHERE  orders.client_id = clients.client_id 
               GROUP  BY orders.client_id 
               HAVING Sum(Isnull(orders.order_sum, 0)) > 100)