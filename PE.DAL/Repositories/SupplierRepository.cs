using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PE.BO.Models.Request;
using PE.BO.Models.Response;
using PE.DAL.Interfaces;

namespace PE.DAL.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        public Task<ApiGenericResponse> SaveCoverSheet(Supplier supplier)
        {
            throw new NotImplementedException();
        }
    }
}
