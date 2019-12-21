SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Cafe_Add_Product](@ProductType AS VARCHAR(5),@ProductPrice AS DECIMAL,@ProductName AS VARCHAR(20),@ProductCalories AS INT,@ProductDetails AS TEXT) AS
BEGIN
    BEGIN TRANSACTION
        DECLARE @Error NVARCHAR(Max);
        DECLARE @ProductID INT;

        BEGIN TRY
            SET @ProductId = (SELECT MAX(ProductId) + 1
            FROM Cafe_Products);
            IF @@TRANCOUNT > 0 COMMIT; 
        END TRY
        BEGIN CATCH
            SET @Error = 'An error was encountered : ProductId could not be found';
            IF @@TRANCOUNT > 0
                ROLLBACK TRANSACTION;
            RAISERROR(@Error, 1, 0);
        END CATCH;

        BEGIN TRY 
            INSERT INTO Cafe_Products(ProductId,ProductType,ProductPrice,ProductName,ProductCalories,ProductDetails)
            VALUES(@ProductID,@ProductType,@ProductPrice,@ProductName,@ProductCalories,@ProductDetails)
        END TRY
        BEGIN CATCH
            SET @Error = 'An error was encountered : Product could not be inserted to the table';
            IF @@TRANCOUNT > 0
                ROLLBACK TRANSACTION;
            RAISERROR(@Error, 1, 0);
        END CATCH;

END;
GO

