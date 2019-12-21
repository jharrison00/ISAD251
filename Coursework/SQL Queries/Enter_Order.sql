SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Cafe_Enter_Order](@CustId AS INT,@ProductId as INT,@Quantity AS INT) AS
BEGIN
    BEGIN TRANSACTION
        DECLARE @Error NVARCHAR(Max);
        DECLARE @OrderId INT;
        DECLARE @ProductOrderPrice DECIMAL;

        BEGIN TRY
            SET @OrderId = (SELECT MAX(OrderId) + 1
            FROM Cafe_Orders);
            IF @@TRANCOUNT > 0 COMMIT; 
        END TRY
        BEGIN CATCH
            SET @Error = 'An error was encountered : OrderId could not be found';
            IF @@TRANCOUNT > 0
                ROLLBACK TRANSACTION;
            RAISERROR(@Error, 1, 0);
        END CATCH;

        BEGIN TRY 
            INSERT INTO Cafe_Orders(OrderId,OrderDate,CustID)
            VALUES(@OrderId,GETDATE(),@CustId)
        END TRY
        BEGIN CATCH
            SET @Error = 'An error was encountered : Order could not be inserted to the table';
            IF @@TRANCOUNT > 0
                ROLLBACK TRANSACTION;
            RAISERROR(@Error, 1, 0);
        END CATCH;

        BEGIN TRY
            SET @ProductOrderPrice = (SELECT ProductPrice 
            FROM Cafe_Products 
            WHERE ProductID = @ProductId) * @Quantity;
            IF @@TRANCOUNT > 0 COMMIT; 
        END TRY
        BEGIN CATCH
            SET @Error = 'An error was encountered : ProductPrice could not be found';
            IF @@TRANCOUNT > 0
                ROLLBACK TRANSACTION;
            RAISERROR(@Error, 1, 0);
        END CATCH;

        BEGIN TRY 
            INSERT INTO Cafe_Order_Details(OrderId,ProductId,Quantity,ProductOrderPrice)
            VALUES(@OrderId,@ProductId,@Quantity,@ProductOrderPrice)
        END TRY 
        BEGIN CATCH
            SET @Error = 'An error was encountered : Product does not exist';
            IF @@TRANCOUNT > 0
                ROLLBACK TRANSACTION;
            RAISERROR(@Error, 1, 0);
        END CATCH;
END;
GO
