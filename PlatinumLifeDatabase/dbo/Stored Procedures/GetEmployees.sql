-- =============================================

-- =============================================
CREATE PROCEDURE [dbo].[GetEmployees] 
AS

BEGIN
	BEGIN TRY
		BEGIN TRAN
			SET NOCOUNT ON;
 			SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;

			SELECT [EmployeeID]
      ,[EmployeeCode]
      ,[FirstName]
      ,[LastName]
      ,[FK_DepartmentID]
      ,[Position]
      ,[Signature]
		 FROM [PaymentProcessing].[dbo].[Employee] WITH(NOLOCK)
		 WHERE [Position] = 2 -- get managers only
		 

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
