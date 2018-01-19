using Newtonsoft.Json;

namespace LolApp.Data
{
    /// <summary>
    /// Represents a league that a summoner is in
    /// </summary>
    public class LeaguePosition
    {
        [JsonProperty("queueType")]
        public string QueueType { get; set; }

        [JsonProperty("hotStreak")]
        public bool HotStreak { get; set; }

        [JsonProperty("wins")]
        public long Wins { get; set; }

        [JsonProperty("miniSeries")]
        public MiniSeries MiniSeries { get; set; }

        [JsonProperty("veteran")]
        public bool Veteran { get; set; }

        [JsonProperty("losses")]
        public long Losses { get; set; }

        [JsonProperty("playerOrTeamId")]
        public string PlayerOrTeamId { get; set; }

        [JsonProperty("leagueName")]
        public string LeagueName { get; set; }

        [JsonProperty("playerOrTeamName")]
        public string PlayerOrTeamName { get; set; }

        [JsonProperty("inactive")]
        public bool Inactive { get; set; }

        [JsonProperty("rank")]
        public string Rank { get; set; }

        [JsonProperty("freshBlood")]
        public bool FreshBlood { get; set; }

        [JsonProperty("leagueId")]
        public string LeagueId { get; set; }

        [JsonProperty("tier")]
        public string Tier { get; set; }

        [JsonProperty("leaguePoints")]
        public long LeaguePoints { get; set; }
    }
}
