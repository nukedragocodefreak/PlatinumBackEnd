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
using PE.DAL.Interfaces;

namespace PE.DAL.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly IDbContextFactory _connection;
        public InvoiceRepository(IDbContextFactory connection)
        {
            _connection = connection;
        }
        public async Task<ApiGenericResponse> SaveInvoice(Invoice invoice)
        {
            var result = new ApiGenericResponse();

            var invoiceDT = new DataTable();
            invoiceDT.Columns.Add("FK_CoverSheetID", typeof(int));
            invoiceDT.Columns.Add("FK_SupplierID", typeof(int));
            invoiceDT.Columns.Add("FIleName", typeof(string));
            invoiceDT.Columns.Add("InvoiceNumber", typeof(string));
            invoiceDT.Columns.Add("location", typeof(string));

            invoiceDT.Rows.Add(invoice.FK_CoverSheetID,
                                     invoice.FK_SupplierID,
                                     invoice.FIleName,
                                     invoice.InvoiceNumber,
                                     invoice.location);

            var spParams = new DynamicParameters(new
            {
                invoice = invoiceDT
            });

            using (IDbConnection conn = _connection.GetMyConnection(BO.Enums.ORM.Dapper))
            {
                result = await conn.QueryFirstOrDefaultAsync<ApiGenericResponse>("SaveCompany", spParams, commandType: CommandType.StoredProcedure);
            }

            return result;
        }
    }
}
