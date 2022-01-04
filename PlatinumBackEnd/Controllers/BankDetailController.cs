using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PE.BO.Models.Request;
using PE.DAL.Repository;

namespace PlatinumBackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BankDetailController: ControllerBase
    {

        private readonly ILogger<BankDetailController> _logger;
        private readonly IBankDetailBLL _bankDetailRepository;

        public BankDetailController(ILogger<BankDetailController> logger, IBankDetailBLL bankDetailRepository)
        {
            _logger = logger;
            _bankDetailRepository = bankDetailRepository;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] BankDetail bankDetail)
        {
            try
            {
             var saveResponse = await _bankDetailRepository.SaveBankDetail(bankDetail);
                if (saveResponse.ReturnStatus != 1)
                {
                    return BadRequest(saveResponse.ReturnMessage);
                }
                     return Ok("Bank Details saved successfully.");
             }
            catch (Exception ex)
            {
                _logger.LogError($"BankDetailController: SaveBankDetail - {ex}");
                return StatusCode(500, "An error occurred. Please try again.");
             }
        }

    }
}
