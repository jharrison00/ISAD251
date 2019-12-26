CREATE TABLE Cafe_Order_Details (
    OrderID INT NOT NULL,
    ProductID INT NOT NULL,
    Quantity INT NOT NULL,
    ProductOrderPrice DECIMAL(18,2),
    CONSTRAINT pk_Cafe_Order_Details PRIMARY KEY (OrderID, ProductID),
);

ALTER TABLE [dbo].[Cafe_Order_Details]  WITH CHECK ADD  CONSTRAINT [fk_Cafe_Order_Details_O] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Cafe_Orders] ([OrderID]);

ALTER TABLE [dbo].[Cafe_Order_Details]  WITH CHECK ADD  CONSTRAINT [fk_Cafe_Order_Details_P] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Cafe_Products] ([ProductID]);