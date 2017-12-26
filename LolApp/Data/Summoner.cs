using System;
using Newtonsoft.Json;

namespace LolApp.Data
{
    /// <summary>
    /// Class representing a Summoner in the Riot Games API
    /// </summary>
    public class Summoner
    {
        /// <summary>
        /// ID of the summoner icon associated with the summoner
        /// </summary>
        [JsonProperty("profileIconId")]
        public int ProfileIconId { get; set; }

        /// <summary>
        /// Summoner name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Summoner level associated with the summoner
        /// </summary>
        [JsonProperty("summonerLevel")]
        public long SummonerLevel { get; set; }

        /// <summary>
        /// Date summoner was last modified specified as epoch milliseconds
        /// </summary>
        [JsonProperty("revisionDate")]
        public DateTime RevisionDate { get; set; }

        /// <summary>
        /// Summoner ID
        /// </summary>
        [JsonProperty("Id")]
        public long Id { get; set; }

        /// <summary>
        /// Account ID
        /// </summary>
        [JsonProperty("accountId")]
        public long AccountId { get; set; }
    }
}
