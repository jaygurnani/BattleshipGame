using BattleshipGame.Engine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleshipGame.Models
{
    public class GameState
    {
        public Player player1 { get; set; }
        public Player player2 { get; set; }
        public GameState(string player1Name, string player2Name)
        {
            player1 = new Player(player1Name);
            player2 = new Player(player2Name);
        }
    }

    public enum PlayerId
    {
        Player1,
        Player2
    }
}
