using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCA.DAL.Data;
using Dapper;
using PE.BO.Models.Request;
using PE.BO.Models.Response;
using PE.DAL.Repository;

namespace PE.DAL.Repositories
{
    public class CoverSheetRepository : ICoverSheetRepository
    {
        private readonly IDbContextFactory _connection;
        public CoverSheetRepository(IDbContextFactory connection)
        {
            _connection = connection;
        }
        public async Task<ApiGenericResponse> SaveCoverSheet(CoverSheet coverSheet)
        {
            var result = new ApiGenericResponse();

            var coverSheetDT = new DataTable();
            coverSheetDT.Columns.Add("FirstName", typeof(string));
            coverSheetDT.Columns.Add("LastName", typeof(string));
            coverSheetDT.Columns.Add("DepartmentID", typeof(int));
            coverSheetDT.Columns.Add("DateOfInvoce", typeof(DateTime));
            coverSheetDT.Columns.Add("DateOfPayment", typeof(DateTime));
            coverSheetDT.Columns.Add("ManagerID", typeof(int));
            coverSheetDT.Columns.Add("CompanyID", typeof(int));

            coverSheetDT.Rows.Add(coverSheet.FirstName,
                                     coverSheet.LastName,
                                     coverSheet.DepartmentID,
                                     coverSheet.DateOfInvoce,
                                     coverSheet.DateOfPayment,
                                     coverSheet.ManagerID,
                                     coverSheet.CompanyID
                                     );

            var spParams = new DynamicParameters(new
            {
                coverSheet = coverSheetDT
            });

            using (IDbConnection conn = _connection.GetMyConnection(BO.Enums.ORM.Dapper))
            {
                result = await conn.QueryFirstOrDefaultAsync<ApiGenericResponse>("SaveCoverSheet", spParams, commandType: CommandType.StoredProcedure);
            }

            return result;
        }
    }
}
