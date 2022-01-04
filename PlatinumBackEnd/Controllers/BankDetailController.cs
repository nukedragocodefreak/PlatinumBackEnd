using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace PlatinumBackEnd.Controllers
{
    public class BankDetailController: ControllerBase
    {
        private readonly ILogger<BankDetailController> _logger;

        public BankDetailController(ILogger<BankDetailController> logger)
        {
            _logger = logger;
        }

    }
}
