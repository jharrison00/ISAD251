CREATE TRIGGER Cafe_GetTotalPrice ON Cafe_Orders AFTER INSERT AS
BEGIN
    DECLARE @Error NVARCHAR(Max);
    DECLARE @OrderID INT;
    DECLARE @OrderTotalPrice INT;

    BEGIN TRY
        SET @OrderId = (SELECT OrderID 
        FROM INSERTED);
        IF @@TRANCOUNT > 0 COMMIT; 
    END TRY
    BEGIN CATCH
        SET @Error = 'An error was encountered : OrderId could not be found';
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;
        RAISERROR(@Error, 1, 0);
    END CATCH;

    BEGIN TRY
            SET @OrderTotalPrice = (SELECT SUM(CAST(ProductOrderPrice AS DECIMAL))
            FROM Cafe_Order_Details
            WHERE OrderID = @OrderID);
    END TRY
    BEGIN CATCH
        SET @Error = 'An error was encountered : OrderId could not be found';
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;
        RAISERROR(@Error, 1, 0);
    END CATCH;
    
END;
GO