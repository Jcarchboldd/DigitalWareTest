
--Obtener la lista de precios de todos los productos

SELECT ProductName, FORMAT(UnitPrice, 'C') UnitPrice FROM Product

--Obtener la lista de productos cuya existencia en el inventario haya llegado al mínimo
--permitido (5 unidades)

SELECT ProductName, UnitsInStock FROM Product WHERE UnitsInStock <= 5

--Obtener una lista de clientes no mayores de 35 años que hayan realizado compras entre el
--1 de febrero de 2000 y el 25 de mayo de 2000SELECT DISTINCT cus.FullName, cus.Birthday, ord.OrderDate FROM [Order] ord INNER JOIN Order_Detail ode ON ord.OrderID = ode.OrderID						  INNER JOIN Customer cus ON cus.CustomerID = ord.CustomerID						  INNER JOIN Product prod ON prod.ProductID = ode.ProductIDWHERE ord.OrderDate BETWEEN '2000-01-02' AND '2000-05-25'AND DATEDIFF(year, GETDATE(), cus.Birthday) < 35ORDER BY OrderDate ASC--Obtener el valor total vendido por cada producto en el año 2000SELECT prod.ProductName, SUM(ode.UnitPrice * ode.Quantity) TotalVendido FROM [Order] ord INNER JOIN Order_Detail ode ON ord.OrderID = ode.OrderID						  INNER JOIN Product prod ON prod.ProductID = ode.ProductIDWHERE ord.OrderDate > '2000-01-01'GROUP BY prod.ProductName, prod.ProductID--Obtener la última fecha de compra de un cliente y según su frecuencia de compra estimar
--en qué fecha podría volver a comprar

SELECT cus.FullName,	MAX(ord.OrderDate) UltVenta,	MIN(ord.OrderDate) PrimeraVenta,	COUNT(ord.OrderID) CantidaVenta,	(DATEDIFF(day, MAX(ord.OrderDate),MIN(ord.OrderDate)) / COUNT(ord.OrderID)) Dias,	DATEADD(day,(DATEDIFF(day, MAX(ord.OrderDate),MIN(ord.OrderDate)) / COUNT(ord.OrderID)),MAX(ord.OrderDate)) ProxVentaFROM [Order] ord INNER JOIN [Order] ode ON ord.OrderID = ode.OrderID						  INNER JOIN Customer cus ON cus.CustomerID = ord.CustomerIDGROUP BY cus.FullName, cus.CustomerID