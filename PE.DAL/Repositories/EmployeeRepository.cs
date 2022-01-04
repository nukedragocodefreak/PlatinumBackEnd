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
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IDbContextFactory _connection;
        public EmployeeRepository(IDbContextFactory connection)
        {
            _connection = connection;
        }
        public async Task<ApiGenericResponse> SaveEmployee(Employee employee)
        {
            var result = new ApiGenericResponse();

            var employeeDT = new DataTable();
            employeeDT.Columns.Add("EmployeeCode", typeof(string));
            employeeDT.Columns.Add("FirstName", typeof(string));
            employeeDT.Columns.Add("LastName", typeof(string));
            employeeDT.Columns.Add("Position", typeof(string));
            employeeDT.Columns.Add("Signature", typeof(string));
            employeeDT.Columns.Add("FK_DepartmentID", typeof(int));

            employeeDT.Rows.Add(employee.EmployeeCode,
                                     employee.FirstName,
                                     employee.FK_DepartmentID,
                                     employee.LastName,
                                     employee.Position,
                                     employee.Signature);

            var spParams = new DynamicParameters(new
            {
                employee = employeeDT
            });

            using (IDbConnection conn = _connection.GetMyConnection(BO.Enums.ORM.Dapper))
            {
                result = await conn.QueryFirstOrDefaultAsync<ApiGenericResponse>("SaveCompany", spParams, commandType: CommandType.StoredProcedure);
            }

            return result;
        }
    }
}
