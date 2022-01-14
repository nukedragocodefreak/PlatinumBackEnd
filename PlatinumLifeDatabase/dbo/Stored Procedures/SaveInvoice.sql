-- =============================================

-- =============================================
CREATE PROCEDURE [dbo].[SaveInvoice] 
	@Invoice AS ttInvoice READONLY
AS

BEGIN
	BEGIN TRY
		BEGIN TRAN
			SET NOCOUNT ON;
 
					INSERT INTO Invoice
					SELECT 
			  [InvoiceNumber]
			  ,[Date]
			  ,[location]
			  ,[FIleName]
			  ,[FK_CoverSheetID]
			  ,[FK_SupplierID]
				    FROM @Invoice				

		COMMIT TRAN;
			SELECT CAST(1 AS INT) [ReturnStatus],
		       CAST('Success' AS VARCHAR(50)) [ReturnMessage];
			RETURN;

	END TRY
	BEGIN CATCH
		ROLLBACK TRAN;
				
				SELECT CAST(-1 AS INT) [ReturnStatus],
					CAST(ERROR_MESSAGE() AS VARCHAR(50)) [ReturnMessage];
				RETURN;

	END CATCH
END
