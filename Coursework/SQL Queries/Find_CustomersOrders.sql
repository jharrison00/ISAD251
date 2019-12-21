SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Cafe_Find_CustomersOrders](@CustID AS INT) AS
BEGIN
    BEGIN TRANSACTION        
    DECLARE @Error NVARCHAR(Max);
    BEGIN TRY 
    SELECT * FROM Cafe_Orders
    WHERE CustID = @CustID;
    END TRY
    BEGIN CATCH
        SET @Error = 'An error was encountered : CustID does not exist in Orders table';
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;
        RAISERROR(@Error, 1, 0);
    END CATCH;

END;
GO
