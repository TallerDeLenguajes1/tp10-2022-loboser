using System.Text.Json;
using System.Text.Json.Serialization;

namespace tp10
{
    public class Civilizaciones{
        [JsonPropertyName("id")]

        public int Id { get; set; }

        [JsonPropertyName("name")]

        public string Name { get; set; }

        [JsonPropertyName("expansion")]

        public string Expansion { get; set; }

        [JsonPropertyName("army_type")]

        public string ArmyType { get; set; }

        [JsonPropertyName("unique_unit")]
        
        public string[] UniqueUnit { get; set; }

        [JsonPropertyName("unique_tech")]
        
        public string[] UniqueTech { get; set; }

        [JsonPropertyName("team_bonus")]
        
        public string TeamBonus { get; set; }

        [JsonPropertyName("civilization_bonus")]
        
        public string[] CivilizationBonus { get; set; }
    }

    public class ListaDeCivilizaciones{
        [JsonPropertyName("civilizations")]
        
        public List<Civilizaciones> Lista { get; set; }
    }
}