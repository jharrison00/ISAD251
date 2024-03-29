SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Cafe_Find_Order](@OrderID AS INT) AS
BEGIN
    BEGIN TRANSACTION        
    DECLARE @Error NVARCHAR(Max);
    BEGIN TRY 
    SELECT * 
    FROM Cafe_Order_Details
    WHERE OrderID = @OrderID;
    END TRY
    BEGIN CATCH
        SET @Error = 'An error was encountered : OrderID does not exist in Order_Details table';
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;
        RAISERROR(@Error, 1, 0);
    END CATCH;

END;
GO
