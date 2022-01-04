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
    public class SupplierRepository : ISupplierRepository
    {
        private readonly IDbContextFactory _connection;
        public SupplierRepository(IDbContextFactory connection)
        {
            _connection = connection;
        }
        public async Task<ApiGenericResponse> SaveSupplier(Supplier supplier)
        {
            var result = new ApiGenericResponse();

            var supplierDT = new DataTable();
            supplierDT.Columns.Add("Address", typeof(string));
            supplierDT.Columns.Add("Email", typeof(string));
            supplierDT.Columns.Add("Name", typeof(string));
            supplierDT.Columns.Add("Phonenumbers", typeof(int));
            supplierDT.Columns.Add("FK_InvoiceID", typeof(int));

            supplierDT.Rows.Add(supplier.Address,
                                     supplier.Email,
                                     supplier.Name,
                                     supplier.Phonenumbers,
                                     supplier.FK_InvoiceID);

            var spParams = new DynamicParameters(new
            {
                supplier = supplierDT
            });

            using (IDbConnection conn = _connection.GetMyConnection(BO.Enums.ORM.Dapper))
            {
                result = await conn.QueryFirstOrDefaultAsync<ApiGenericResponse>("SaveSupplier", spParams, commandType: CommandType.StoredProcedure);
            }

            return result;
        }
    }
}
