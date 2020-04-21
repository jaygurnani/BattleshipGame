using BattleshipGame.Engine.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleshipGame.Models
{
    public class AddShipRequest
    {
        [JsonProperty("shipId")]
        public int shipId { get; set; }

        [JsonProperty("lengthOrWidth")]
        public int lengthOrWidth { get; set; }

        [JsonProperty("startingRow")]
        public int startingRow { get; set; }

        [JsonProperty("startingColumn")]
        public int startingColumn { get; set; }

        [JsonProperty("orientation")]
        public OrientationType orientation { get; set; }

        [JsonProperty("player1Or2")]
        public Player1Or2 player1Or2 { get; set; }
    }
}
