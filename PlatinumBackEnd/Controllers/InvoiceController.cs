using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PE.BO.Models.Request;
using PE.DAL.Interfaces;

namespace PlatinumBackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvoiceController : ControllerBase
    {
        private readonly ILogger<InvoiceController> _logger;
        private readonly IInvoiceBLL _invoiceRepository;
        public InvoiceController(ILogger<InvoiceController> logger, IInvoiceBLL invoiceRepository)
        {
            _logger = logger;
            _invoiceRepository = invoiceRepository;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Invoice invoice)
        {
            try
            {
                var saveResponse = await _invoiceRepository.SaveInvoice(invoice);
                if (saveResponse.ReturnStatus != 1)
                {
                    return BadRequest(saveResponse.ReturnMessage);
                }
                return Ok("Invoice Details saved successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"CompanyController: SaveBankDetail - {ex}");
                return StatusCode(500, "An error occurred. Please try again.");
            }
        }
    }
}
