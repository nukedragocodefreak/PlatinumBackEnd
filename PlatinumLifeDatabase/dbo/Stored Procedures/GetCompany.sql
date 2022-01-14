-- =============================================

-- =============================================
CREATE PROCEDURE [dbo].[GetCompany] 
AS

BEGIN
	BEGIN TRY
		BEGIN TRAN
			SET NOCOUNT ON;
				SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
			SELECT 
			[CompanyID]
		  ,[Name]
		  ,[Address]
		  ,[Email]
		  ,[Phonenumbers]
			 FROM [PaymentProcessing].[dbo].[Company]				

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
