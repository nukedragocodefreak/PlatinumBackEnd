﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PE.BO.Models.Request;
using PE.BO.Models.Response;

namespace PE.DAL.Repository
{
    public interface IBankDetailBLL
    {
        public Task<ApiGenericResponse> SaveBankDetail(BankDetail bankDetail);
        public Task<IEnumerable<Bank>> GetBank();
    }
}
