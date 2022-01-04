using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PE.BO.Models.Request;
using PE.BO.Models.Response;
using PE.DAL.Repositories;
using PE.DAL.Repository;

namespace PE.BLL.Logic
{
    public class CompanyBLL : ICompanyBLL
    {
        private readonly CompanyRepository _companyRepository;
        public CompanyBLL(CompanyRepository  companyRepository)
        {
            _companyRepository = companyRepository;
        }
        public async Task<ApiGenericResponse> SaveCompany(Company company)
        {
            var saveResponse = await _companyRepository.SaveCompany(company);
            return saveResponse;
        }
    }
}
