using BattleshipGame.Engine.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleshipGame.Engine.Services
{
    public interface IGameService
    {
        void AddShip(int shipId, int lengthOrWidth, int startingRow, int startingColumn, OrientationType orientation, Player player);
        bool AttackSquare(int row, int column, Player player);
    }
}
