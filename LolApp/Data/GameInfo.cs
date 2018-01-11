using Newtonsoft.Json;

namespace LolApp.Data
{
    /// <summary>
    /// Class representing a Summoner in the Riot Games API
    /// </summary>
    public class GameInfo
    {
        /// <summary>
        /// The ID of the game
        /// </summary>
        [JsonProperty("gameId")]
        public long GameId { get; set; }

        /// <summary>
        /// The game start time represented in epoch milliseconds
        /// </summary>
        [JsonProperty("gameStartTime")]
        public long GameStartTime { get; set; }

        /// <summary>
        /// The ID of the platform on which the game is being played
        /// </summary>
        [JsonProperty("platformId")]
        public string PlatformId { get; set; }

        /// <summary>
        /// The game mode
        /// </summary>
        [JsonProperty("gameMode")]
        public string GameMode { get; set; }

        /// <summary>
        /// The ID of the map
        /// </summary>
        [JsonProperty("mapId")]
        public long MapId { get; set; }

        /// <summary>
        /// The game type
        /// </summary>
        [JsonProperty("gameType")]
        public string GameType { get; set; }

        /// <summary>
        /// Banned champion information
        /// </summary>
        [JsonProperty("bannedChampions")]
        public list<BannedChampion> BannedChampions { get; set; }

        /// <summary>
        /// The observer information
        /// </summary>
        [JsonProperty("observers")]
        public Observer Observers { get; set; }

        /// <summary>
        /// The participant information
        /// </summary>
        [JsonProperty("participants")]
        public list<CurrentGameParticipant> Participants { get; set; }

        /// <summary>
        /// The amount of time in seconds that has passed since the game started
        /// </summary>
        [JsonProperty("gameLength")]
        public long GameLength { get; set; }

        /// <summary>
        /// The queue type (queue types are documented on the Game Constants page)
        /// </summary>
        [JsonProperty("gameQueueConfigId")]
        public long GameQueueConfigId { get; set; }
    }
}
