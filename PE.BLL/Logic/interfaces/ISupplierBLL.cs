using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PE.BO.Models.Request;
using PE.BO.Models.Response;

namespace PE.DAL.Interfaces
{
    public interface ISupplierBLL
    {
        public Task<ApiGenericResponse> SaveCoverSheet(Supplier supplier);
        public Task<IEnumerable<Supplier>> GetSupplier();
    }
}
