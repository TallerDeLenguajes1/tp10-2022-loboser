using System.Text.Json;
using System.Text.Json.Serialization;

namespace tp10
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Cost
    {
        public int Wood { get; set; }
        public int Gold { get; set; }
        public int Stone { get; set; }
        public int Food { get; set; }
        public string info { get; set; }

        [JsonPropertyName("Cost")]
        public string cost { get; set; }
        public Provides Provides { get; set; }
    }

    public class Provides
    {
        public int Food { get; set; }

        [JsonPropertyName("Resource Decay")]
        public double ResourceDecay { get; set; }
    }

    public class Root
    {
        public List<Unit> units { get; set; }
    }

    public class Unit
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string expansion { get; set; }
        public string age { get; set; }
        public string created_in { get; set; }
        public Cost cost { get; set; }
        public int build_time { get; set; }
        public double reload_time { get; set; }
        public double attack_delay { get; set; }
        public double movement_rate { get; set; }
        public int line_of_sight { get; set; }
        public int hit_points { get; set; }
        public object range { get; set; }
        public int attack { get; set; }
        public string armor { get; set; }
        public string accuracy { get; set; }
        public List<string> attack_bonus { get; set; }
        public int? search_radius { get; set; }
        public double? blast_radius { get; set; }
        public List<string> armor_bonus { get; set; }
    }
}