-- =============================================

-- =============================================
CREATE PROCEDURE [dbo].[SaveCoverSheet] 
	@CoverSheet AS ttCoverSheet READONLY
AS

BEGIN
	BEGIN TRY
		BEGIN TRAN
			SET NOCOUNT ON;
 
					INSERT INTO CoverSheet
					SELECT 
					[CoverSheetID]
				  ,[FirstName]
				  ,[LastName]
				  ,[DepartmentID]
				  ,[DateOfInvoce]
				  ,[DateOfPayment]
				  ,[ManagerID]
				  ,[CompanyID]
				  ,[FK_PaymentStatusID]
				    FROM @CoverSheet				

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
