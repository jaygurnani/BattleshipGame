using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BattleshipGame.Models
{
    public class CreateGameRequest
    {
        [JsonProperty("player1Name")]
        public string player1Name { get; set; }

        [JsonProperty("player2Name")]
        public string player2Name { get; set; }
    }
}
