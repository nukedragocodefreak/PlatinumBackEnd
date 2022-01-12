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
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IEmployeeBLL _employeeRepository;
        public EmployeeController(ILogger<EmployeeController> logger, IEmployeeBLL employeeRepository)
        {
            _logger = logger;
            _employeeRepository = employeeRepository;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Employee employee)
        {
            try
            {
                var saveResponse = await _employeeRepository.SaveEmployee(employee);
                if (saveResponse.ReturnStatus != 1)
                {
                    return BadRequest(saveResponse.ReturnMessage);
                }
                return Ok("Employee Details saved successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"EmployeeController: SaveEmployee - {ex}");
                return StatusCode(500, "An error occurred. Please try again.");
            }
        }
        [HttpGet("GetPositions")]
        public async Task<IActionResult> GetPosition()
        {
            try
            {
                var data = await _employeeRepository.GetPosition();
                return Ok(new GetResponse { ResponseType = 1, ResponseObject = data, ResponseMessage = "Success." });
            }
            catch (Exception ex)
            {
                _logger.LogError($"EmployeeController: GetPosition - {ex}");
                return StatusCode(500, "An error occurred. Please try again.");
            }
        }

        [HttpGet("GetEmployees")]
        public async Task<IActionResult> GetEmployee()
        {
            try
            {
                var data = await _employeeRepository.GetEmployee();
                return Ok(new GetResponse { ResponseType = 1, ResponseObject = data, ResponseMessage = "Success." });
            }
            catch (Exception ex)
            {
                _logger.LogError($"EmployeeController: GetEmployee - {ex}");
                return StatusCode(500, "An error occurred. Please try again.");
            }
        }
    }
}
