using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PE.BO.Models.Request;
using PE.BO.Models.Response;
using PE.DAL.Repository;

namespace PlatinumBackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly ILogger<CompanyController> _logger;
        private readonly ICompanyBLL _companyRepository;
        public CompanyController(ILogger<CompanyController> logger, ICompanyBLL companyRepository)
        {
            _logger = logger;
            _companyRepository = companyRepository;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Company company)
        {
            try
            {
                var saveResponse = await _companyRepository.SaveCompany(company);
                if (saveResponse.ReturnStatus != 1)
                {
                    return BadRequest(saveResponse.ReturnMessage);
                }
                return Ok("Company Details saved successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"CompanyController: SaveBankDetail - {ex}");
                return StatusCode(500, "An error occurred. Please try again.");
            }
        }

        [HttpGet("GetCompany")]
        public async Task<IActionResult> GetCompany()
        {
            try
            {
                var data = await _companyRepository.GetCompany();
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
