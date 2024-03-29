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
    public class CompanyRepository : ICompanyRepository
    {
        private readonly IDbContextFactory _connection;
        public CompanyRepository(IDbContextFactory connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<Company>> GetCompany()
        {
            using (IDbConnection conn = _connection.GetMyConnection(BO.Enums.ORM.Dapper))
            {
                var resp = await conn.QueryAsync<Company>("GetCompany", commandType: CommandType.StoredProcedure);
                return resp.ToList();
            }
        }

        public async Task<ApiGenericResponse> SaveCompany(Company company)
        {
            var result = new ApiGenericResponse();

            var companyDT = new DataTable();
            companyDT.Columns.Add("Name", typeof(string));
            companyDT.Columns.Add("Address", typeof(string));
            companyDT.Columns.Add("Email", typeof(string));          
            companyDT.Columns.Add("Phonenumbers", typeof(string));

            companyDT.Rows.Add(company.Name,
                                     company.Email,
                                     company.Address,
                                     company.Phonenumbers);

            var spParams = new DynamicParameters(new
            {
                company = companyDT
            });

            using (IDbConnection conn = _connection.GetMyConnection(BO.Enums.ORM.Dapper))
            {
                result = await conn.QueryFirstOrDefaultAsync<ApiGenericResponse>("SaveCompany", spParams, commandType: CommandType.StoredProcedure);
            }

            return result;
        }
    }
}
