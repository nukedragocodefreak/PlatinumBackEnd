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
    public class BankDetailRepository : IBankDetailRepository
    {

        private readonly IDbContextFactory _connection;
        public BankDetailRepository(IDbContextFactory connection)
        {
            _connection = connection;
        }

        public async Task<ApiGenericResponse> SaveBankDetail(BankDetail bankDetail)
        {
            var result = new ApiGenericResponse();

            var bankDetailDT = new DataTable();
            bankDetailDT.Columns.Add("AccountNumber", typeof(int));
            bankDetailDT.Columns.Add("BankName", typeof(string));
            bankDetailDT.Columns.Add("BranchCode", typeof(string));
            bankDetailDT.Columns.Add("FK_BankID", typeof(int));
            bankDetailDT.Columns.Add("FK_CompanyID", typeof(int));

            bankDetailDT.Rows.Add(bankDetail.AccountNumber,
                                     bankDetail.BankName,
                                     bankDetail.BranchCode,
                                     bankDetail.FK_BankID,
                                     bankDetail.FK_CompanyID);
            var spParams = new DynamicParameters(new
            {
                bankDetail = bankDetailDT
            });

            using (IDbConnection conn = _connection.GetMyConnection(BO.Enums.ORM.Dapper))
            {
                result = await conn.QueryFirstOrDefaultAsync<ApiGenericResponse>("SaveBankDetail", spParams, commandType: CommandType.StoredProcedure);
            }

            return result;
        }
    }
}
