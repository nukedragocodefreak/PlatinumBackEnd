-- =============================================

-- =============================================
CREATE PROCEDURE [dbo].[SaveEmployee] 
	@Employee AS ttEmployee READONLY
AS

BEGIN
	BEGIN TRY
		BEGIN TRAN
			SET NOCOUNT ON;
 
					INSERT INTO Employee
					SELECT 
					[EmployeeCode]
				  ,[FirstName]
				  ,[LastName]
				  ,[FK_DepartmentID]
				  ,[Position]
				  ,[Signature]
				    FROM @Employee				

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
