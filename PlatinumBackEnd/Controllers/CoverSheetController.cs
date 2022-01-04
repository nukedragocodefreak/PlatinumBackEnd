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
    public class CoverSheetController : ControllerBase
    {
        private readonly ILogger<CoverSheetController> _logger;
        private readonly ICoverSheetBLL _coverSheetRepository;
        public CoverSheetController(ILogger<CoverSheetController> logger, ICoverSheetBLL coverSheetRepository)
        {
            _logger = logger;
            _coverSheetRepository = coverSheetRepository;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CoverSheet coverSheet)
        {
            try
            {
                var saveResponse = await _coverSheetRepository.SaveCoverSheet(coverSheet);
                if (saveResponse.ReturnStatus != 1)
                {
                    return BadRequest(saveResponse.ReturnMessage);
                }
                return Ok("CoverSheet Details saved successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"CoverSheetController: SaveCoverSheet - {ex}");
                return StatusCode(500, "An error occurred. Please try again.");
            }
        }
    }
}
