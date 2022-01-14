-- =============================================

-- =============================================
CREATE PROCEDURE [dbo].[GetUser] 
	@User AS ttUsers READONLY
AS

BEGIN
	BEGIN TRY
		BEGIN TRAN
			SET NOCOUNT ON;
			SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
		

			  SELECT * INTO #tmpUsers FROM
				   (
					SELECT
					[EmployeeCode]
				   ,[Password]
				   ,[Position] FROM @User

				   ) AS tmpUsers

				SELECT [UserID]
				  ,[EmployeeCode]
				  ,[Password]
				  ,[Position]
			  FROM [PaymentProcessing].[dbo].[Users] --u
			  INNER JOIN #tmpUsers t ON t.[EmployeeCode] = u.[EmployeeCode] AND t.[Password] = u.[Password] 

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
