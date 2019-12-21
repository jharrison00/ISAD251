SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Cafe_Remove_Product](@ProductID AS INT) AS
BEGIN
    BEGIN TRANSACTION        
    DECLARE @Error NVARCHAR(Max);
    BEGIN TRY 
    DELETE FROM Cafe_Products
    WHERE ProductID = @ProductID;
    END TRY
    BEGIN CATCH
        SET @Error = 'An error was encountered : Product could not be deleted from table';
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;
        RAISERROR(@Error, 1, 0);
    END CATCH;

END;
GO
