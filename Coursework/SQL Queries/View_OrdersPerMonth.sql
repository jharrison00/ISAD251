SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Cafe_View_OrdersPerMonth] AS 
SELECT MONTH(Cafe_Orders.OrderDate) as month,
COUNT(Cafe_Orders.OrderId) as TotalOrders
FROM Cafe_Orders
WHERE OrderDate IS NOT NULL 
AND YEAR(OrderDate) = YEAR(GETDATE())
GROUP BY MONTH(OrderDate);
GO
