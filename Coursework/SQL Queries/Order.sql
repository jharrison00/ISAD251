CREATE TABLE Cafe_Orders(
    OrderID INT NOT NULL,
    CustID INT NOT NULL,
    OrderDate DATE NOT NULL,
    OrderTotalPrice DECIMAL(18,2),
CONSTRAINT pk_Cafe_Orders PRIMARY KEY (OrderID),
);

ALTER TABLE [dbo].[Cafe_Orders]  WITH CHECK ADD  CONSTRAINT [fk_Cafe_Orders] FOREIGN KEY([CustID])
REFERENCES [dbo].[Cafe_Customers] ([CustID])