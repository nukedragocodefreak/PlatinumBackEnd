using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace PlatinumBackEnd.Controllers
{
    public class CoverSheetController : ControllerBase
    {
        private readonly ILogger<CoverSheetController> _logger;

        public CoverSheetController(ILogger<CoverSheetController> logger)
        {
            _logger = logger;
        }

    }
}
