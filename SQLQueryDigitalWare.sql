
--Obtener la lista de precios de todos los productos

SELECT ProductName, FORMAT(UnitPrice, 'C') UnitPrice FROM Product

--Obtener la lista de productos cuya existencia en el inventario haya llegado al m�nimo
--permitido (5 unidades)

SELECT ProductName, UnitsInStock FROM Product WHERE UnitsInStock <= 5

--Obtener una lista de clientes no mayores de 35 a�os que hayan realizado compras entre el
--1 de febrero de 2000 y el 25 de mayo de 2000
--en qu� fecha podr�a volver a comprar

SELECT cus.FullName,