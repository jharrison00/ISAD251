SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Cafe_Edit_Product](@ProductID AS INT,@ProductType AS VARCHAR(5),@ProductPrice AS DECIMAL,@ProductName AS VARCHAR(20),@ProductCalories AS INT,@ProductDetails AS TEXT) AS
BEGIN
    BEGIN TRANSACTION
        DECLARE @Error NVARCHAR(Max);

        BEGIN TRY 
            UPDATE Cafe_Products
            SET ProductType = @ProductType,ProductPrice = @ProductPrice,ProductName = @ProductName,ProductCalories = @ProductCalories,ProductDetails = @ProductDetails
            WHERE ProductID = @ProductID;
        END TRY
        BEGIN CATCH
            SET @Error = 'An error was encountered : Product could not be edited';
            IF @@TRANCOUNT > 0
                ROLLBACK TRANSACTION;
            RAISERROR(@Error, 1, 0);
        END CATCH;

END;
GO

