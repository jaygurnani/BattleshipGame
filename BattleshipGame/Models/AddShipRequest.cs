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

        [JsonProperty("playerId")]
        public PlayerId playerId { get; set; }
    }
}
