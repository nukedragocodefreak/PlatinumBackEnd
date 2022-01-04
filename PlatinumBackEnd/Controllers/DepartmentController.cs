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
    public class DepartmentController : ControllerBase
    {
        private readonly ILogger<DepartmentController> _logger;
        private readonly IDepartmentBLL _departmentRepository;
        public DepartmentController(ILogger<DepartmentController> logger, IDepartmentBLL departmentRepository)
        {
            _logger = logger;
            _departmentRepository = departmentRepository;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Department department)
        {
            try
            {
                var saveResponse = await _departmentRepository.SaveDepartment(department);
                if (saveResponse.ReturnStatus != 1)
                {
                    return BadRequest(saveResponse.ReturnMessage);
                }
                return Ok("Department Details saved successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"CompanyController: SaveBankDetail - {ex}");
                return StatusCode(500, "An error occurred. Please try again.");
            }
        }
    }
}
