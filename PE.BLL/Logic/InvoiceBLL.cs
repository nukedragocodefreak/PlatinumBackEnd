using System;
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
    public class InvoiceBLL : IInvoiceBLL
    {
        private readonly InvoiceRepository _invoiceRepository;
        public InvoiceBLL(InvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }
        public async Task<ApiGenericResponse> SaveInvoice(Invoice invoice)
        {
            var saveResponse = await _invoiceRepository.SaveInvoice(invoice);
            return saveResponse;
        }
    }
}
