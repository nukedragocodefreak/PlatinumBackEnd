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
    public class BankDetailBLL : IBankDetailBLL
    {
        private readonly IBankDetailRepository _bankDetailRepository;
        public BankDetailBLL(IBankDetailRepository bankDetailRepository)
        {
            _bankDetailRepository = bankDetailRepository;
        }

        public async Task<IEnumerable<Bank>> GetBank()
        {
            var saveResponse = await _bankDetailRepository.GetBank();
            return saveResponse;
        }

        public async Task<ApiGenericResponse> SaveBankDetail(BankDetail bankDetail)
        {
            var saveResponse = await _bankDetailRepository.SaveBankDetail(bankDetail);
            return saveResponse;

        }
    }
}
