using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PE.BO.Models.Request;
using PE.BO.Models.Response;
using PE.DAL.Interfaces;
using PE.DAL.Repository;

namespace PlatinumBackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SupplierController : ControllerBase
    {
        private readonly ILogger<SupplierController> _logger;
        private readonly ISupplierBLL _supplierRepository;
        public SupplierController(ILogger<SupplierController> logger, ISupplierBLL supplierRepository)
        {
            _logger = logger;
            _supplierRepository = supplierRepository;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Supplier supplier)
        {
            try
            {
                var saveResponse = await _supplierRepository.SaveSupplier(supplier);
                if (saveResponse.ReturnStatus != 1)
                {
                    return BadRequest(saveResponse.ReturnMessage);
                }
                return Ok("Supplier Details saved successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"CompanyController: SaveBankDetail - {ex}");
                return StatusCode(500, "An error occurred. Please try again.");
            }
        }

        [HttpGet("GetSupplier")]
        public async Task<IActionResult> GetSupplier()
        {
            try
            {
                var data = await _supplierRepository.GetSupplier();
                return Ok(new GetResponse { ResponseType = 1, ResponseObject = data, ResponseMessage = "Success." });
            }
            catch (Exception ex)
            {
                _logger.LogError($"CompanyController: GetCompany - {ex}");
                return StatusCode(500, "An error occurred. Please try again.");
            }
        }
    }
}
