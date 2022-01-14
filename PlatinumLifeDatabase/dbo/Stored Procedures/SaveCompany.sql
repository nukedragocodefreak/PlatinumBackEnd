-- =============================================

-- =============================================
CREATE PROCEDURE [dbo].[SaveCompany] 
	@Company AS ttCompany READONLY
AS

BEGIN
	BEGIN TRY
		BEGIN TRAN
			SET NOCOUNT ON;
 
					INSERT INTO Company
					SELECT 
			   [Name]
			  ,[Address]
			  ,[Email]
			  ,[Phonenumbers]
				    FROM @Company				

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
