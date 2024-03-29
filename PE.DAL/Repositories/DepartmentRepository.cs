﻿using System;
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
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly IDbContextFactory _connection;
        public DepartmentRepository(IDbContextFactory connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<Department>> GetDepartment()
        {
            using (IDbConnection conn = _connection.GetMyConnection(BO.Enums.ORM.Dapper))
            {
                var resp = await conn.QueryAsync<Department>("GetDepartment", commandType: CommandType.StoredProcedure);
                return resp.ToList();

            }
        }

        public async Task<ApiGenericResponse> SaveDepartment(Department department)
        {
            var result = new ApiGenericResponse();

            var departmentDT = new DataTable();
            departmentDT.Columns.Add("DepartmentName", typeof(string));

            departmentDT.Rows.Add(department.DepartmentName);

            var spParams = new DynamicParameters(new
            {
                department = departmentDT
            });

            using (IDbConnection conn = _connection.GetMyConnection(BO.Enums.ORM.Dapper))
            {
                result = await conn.QueryFirstOrDefaultAsync<ApiGenericResponse>("SaveDepartment", spParams, commandType: CommandType.StoredProcedure);
            }

            return result;
        }
    }
}
