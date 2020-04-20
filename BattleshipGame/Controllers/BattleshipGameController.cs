using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NLog;

namespace BattleshipGame.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BattleshipGame : ControllerBase
    {
        private readonly Logger _logger;

        public BattleshipGame()
        {
            _logger = LogManager.GetCurrentClassLogger();
        }

        [HttpPost]
        public IActionResult CreateGame()
        {
            return Ok();
        }
    }
}
