﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BattleshipGame.Engine.Models
{
    public class Ship
    {
        public int Id { get; set; }
        public int LengthOrWidth { get; set; }
        public int Hits { get; set; }

        /// <summary>
        /// If the number of hits exceeds the lengh of the ship, then the ship has sunk
        /// </summary>
        /// <returns></returns>
        public bool IsSunk()
        {
            return Hits >= LengthOrWidth;
        }
    }

    public enum OrientationType
    {
        Horizontal,
        Vertical
    }
}
