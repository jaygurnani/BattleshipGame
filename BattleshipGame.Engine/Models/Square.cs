using System;
using System.Collections.Generic;
using System.Text;

namespace BattleshipGame.Engine.Models
{
    public class Square
    {
        private int? _shipId;
        
        public Square()
        {
            _shipId = null;
        }

        /// <summary>
        /// Return true if the addition was successful
        /// </summary>
        /// <param name="shipId"></param>
        /// <returns></returns>
        public bool AddShip(int shipId)
        {
            if (_shipId == null)
            {
                _shipId = shipId;
                return true;
            }

            return false;
        }

        public void RemoveContent()
        {
            _shipId = null;
        }

        /// <summary>
        /// Return null if nothing there or the Ship id if there is something there
        /// </summary>
        /// <returns></returns>
        public int? GetSquareContent()
        {
            return _shipId;
        }
    }
}
