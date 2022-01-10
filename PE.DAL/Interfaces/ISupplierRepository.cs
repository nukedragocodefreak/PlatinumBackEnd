using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PE.BO.Models.Request;
using PE.BO.Models.Response;

namespace PE.DAL.Interfaces
{
    public interface ISupplierRepository
    {
        public Task<ApiGenericResponse> SaveSupplier(Supplier supplier);
        public Task<IEnumerable<Supplier>> GetSupplier();
    }
}
