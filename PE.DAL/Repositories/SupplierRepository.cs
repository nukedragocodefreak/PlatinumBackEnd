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

        public async Task<IEnumerable<Supplier>> GetSupplier()
        {
            using (IDbConnection conn = _connection.GetMyConnection(BO.Enums.ORM.Dapper))
            {
                var resp = await conn.QueryAsync<Supplier>("GetSupplier", commandType: CommandType.StoredProcedure);
                return resp.ToList();
            }
        }

        public async Task<ApiGenericResponse> SaveSupplier(Supplier supplier)
        {
            var result = new ApiGenericResponse();

            var supplierDT = new DataTable();

            supplierDT.Columns.Add("FK_InvoiceID", typeof(int));
            supplierDT.Columns.Add("Name", typeof(string));
            supplierDT.Columns.Add("Address", typeof(string));
            supplierDT.Columns.Add("Phonenumbers", typeof(int));
            supplierDT.Columns.Add("Email", typeof(string));

            supplierDT.Rows.Add( supplier.Name,
                                     supplier.Address,
                                     supplier.Phonenumbers,
                                     supplier.Email);

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
