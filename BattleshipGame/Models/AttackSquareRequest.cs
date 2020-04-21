using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleshipGame.Models
{
    public class AttackSquareRequest
    {
        [JsonProperty("row")]
        public int row { get; set; }

        [JsonProperty("column")]
        public int column { get; set; }

        [JsonProperty("playerId")]
        public PlayerId playerToAttack { get; set; }
    }
}
