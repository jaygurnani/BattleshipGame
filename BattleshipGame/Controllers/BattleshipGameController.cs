using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BattleshipGame.Engine.Models;
using BattleshipGame.Engine.Services;
using BattleshipGame.Models;
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
        private readonly IGameService _gameService;
        private static GameState _gameState;

        public BattleshipGame(IGameService gameService)
        {
            _logger = LogManager.GetCurrentClassLogger();
            _gameService = gameService;
        }

        [HttpPost]
        [Route("CreateGame")]
        public IActionResult CreateGame([FromBody] CreateGameRequest request)
        {
            _logger.Debug("Creating Game");

            _gameState = new GameState(request.player1Name, request.player2Name);
            return Ok();
        }
        
        [HttpPost]
        [Route("AddShip")]
        public IActionResult AddShip([FromBody] AddShipRequest request)
        {
            if(_gameState == null)
            {
                var msg = "The Game has not been created yet, please create first";
                _logger.Debug(msg);
                throw new ApplicationException(msg);
            }

            Player currentPlayer;
            if(request.playerId == PlayerId.Player1)
            {
                currentPlayer = _gameState.player1;
            } else
            {
                currentPlayer = _gameState.player2;
            }

            _gameService.AddShip(request.shipId, request.lengthOrWidth, request.startingRow, request.startingColumn, request.orientation, currentPlayer);
            return Ok();
        }


        [HttpPost]
        [Route("AttackShip")]
        public IActionResult AttackShip([FromBody] AttackSquareRequest request)
        {
            if (_gameState == null)
            {
                var msg = "The Game has not been created yet, please create first";
                _logger.Debug(msg);
                throw new ApplicationException(msg);
            }

            Player playerToAttack;
            if (request.playerToAttack == PlayerId.Player1)
            {
                playerToAttack = _gameState.player1;
            }
            else
            {
                playerToAttack = _gameState.player2;
            }

            var result = _gameService.AttackSquare(request.row, request.column, playerToAttack);
            if (playerToAttack.HasPlayerLost())
            {
                return Ok($"Player {request.playerToAttack} has lost!");
            }

            return Ok(result);
        }

    }
}
