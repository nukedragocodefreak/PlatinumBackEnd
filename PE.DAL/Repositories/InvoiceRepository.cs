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
    public class InvoiceRepository : IInvoiceRepository
    {
        public Task<ApiGenericResponse> SaveInvoice(Invoice invoice)
        {
            throw new NotImplementedException();
        }
    }
}
