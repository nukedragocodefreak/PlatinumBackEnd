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

        public async Task<IEnumerable<Employee>> GetEmployee()
        {
            using (IDbConnection conn = _connection.GetMyConnection(BO.Enums.ORM.Dapper))
            {
                var resp = await conn.QueryAsync<Employee>("GetEmployees", commandType: CommandType.StoredProcedure);
                return resp.ToList();
            }
        }

        public async Task<IEnumerable<Position>> GetPosition()
        {
            using (IDbConnection conn = _connection.GetMyConnection(BO.Enums.ORM.Dapper))
            {
                var resp = await conn.QueryAsync<Position>("GetPosition", commandType: CommandType.StoredProcedure);
                return resp.ToList();
            }
        }

        public async Task<ApiGenericResponse> SaveEmployee(Employee employee)
        {
            var result = new ApiGenericResponse();

            var employeeDT = new DataTable();
            employeeDT.Columns.Add("EmployeeCode", typeof(string));
            employeeDT.Columns.Add("FirstName", typeof(string));
            employeeDT.Columns.Add("LastName", typeof(string));
            employeeDT.Columns.Add("FK_DepartmentID", typeof(int));
            employeeDT.Columns.Add("Position", typeof(string));
            employeeDT.Columns.Add("Signature", typeof(string));

            employeeDT.Rows.Add(employee.EmployeeCode,
                                     employee.FirstName,
                                     employee.LastName,
                                     employee.FK_DepartmentID,
                                     employee.Position,
                                     employee.Signature);

            var spParams = new DynamicParameters(new
            {
                employee = employeeDT
            });

            using (IDbConnection conn = _connection.GetMyConnection(BO.Enums.ORM.Dapper))
            {
                result = await conn.QueryFirstOrDefaultAsync<ApiGenericResponse>("SaveEmployee", spParams, commandType: CommandType.StoredProcedure);
            }

            return result;
        }

        public async Task<ApiGenericResponse> UserLogin(Users users)
        {
            var result = new ApiGenericResponse();

            var usersDT = new DataTable();
            usersDT.Columns.Add("EmployeeCode", typeof(string));
            usersDT.Columns.Add("Password", typeof(string));

            usersDT.Rows.Add(users.EmployeeCode,
                                     users.Password);

            var spParams = new DynamicParameters(new
            {
                employee = usersDT
            });

            using (IDbConnection conn = _connection.GetMyConnection(BO.Enums.ORM.Dapper))
            {
                result = await conn.QueryFirstOrDefaultAsync<ApiGenericResponse>("GetUser", spParams, commandType: CommandType.StoredProcedure);
            }

            return result;
        }
    }
}
