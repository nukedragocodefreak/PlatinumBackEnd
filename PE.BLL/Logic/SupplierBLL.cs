﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PE.BO.Models.Request;
using PE.BO.Models.Response;
using PE.DAL.Interfaces;
using PE.DAL.Repositories;

namespace PE.BLL.Logic
{
    public class SupplierBLL : ISupplierBLL
    {
        private readonly ISupplierRepository _supplierRepository;
        public SupplierBLL(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }
        public async Task<ApiGenericResponse> SaveSupplier(Supplier supplier)
        {
            var saveResponse = await _supplierRepository.SaveSupplier(supplier);
            return saveResponse;
        }
        public async Task<IEnumerable<Supplier>> GetSupplier()
        {
            var saveResponse = await _supplierRepository.GetSupplier();
            return saveResponse;
        }
    }
}
