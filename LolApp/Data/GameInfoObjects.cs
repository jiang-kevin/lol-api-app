using Newtonsoft.Json;

namespace LolApp.Data
{
    public class BannedChampion
    {
        /// <summary>
        /// The turn during which the champion was banned
        /// </summary>
        [JsonProperty("pickTurn")]
        public int PickTurn { get; set; }

        /// <summary>
        /// The ID of the banned champion
        /// </summary>
        [JsonProperty("losses")]
        public long Losses { get; set; }

        /// <summary>
        /// The ID of the team that banned the champion
        /// </summary>
        [JsonProperty("target")]
        public long Target { get; set; }
    }

    public class Observer
    {
        /// <summary>
        /// Key used to decrypt the spectator grid game data for playback
        /// </summary>
        [JsonProperty("encryptionKey")]
        public string EncryptionKey { get; set; }
    }

    public class CurrentGameParticipant
    {
        /// <summary>
        /// The ID of the profile icon used by this participant
        /// </summary>
        [JsonProperty("profileIconId")]
        public long ProfileIconId { get; set; }

        /// <summary>
        /// The ID of the champion played by this participant
        /// </summary>
        [JsonProperty("championId")]
        public long ChampionId { get; set; }

        /// <summary>
        /// The summoner name of this participant
        /// </summary>
        [JsonProperty("summonerName")]
        public string SummonerName { get; set; }

        /// <summary>
        /// List of Game Customizations
        /// </summary>
        [JsonProperty("gameCustomizationObjects")]
        public list<GameCustomizationObject> GameCustomizationObjects { get; set; }

        /// <summary>
        /// Flag indicating whether or not this participant is a bot
        /// </summary>
        [JsonProperty("bot")]
        public bool Bot { get; set; }

        /// <summary>
        /// Perks/Runes Reforged Information
        /// </summary>
        [JsonProperty("perks")]
        public perks Perks { get; set; }

        /// <summary>
        /// The ID of the second summoner spell used by this participant
        /// </summary>
        [JsonProperty("spell2Id")]
        public long Spell2Id { get; set; }

        /// <summary>
        /// The team ID of this participant, indicating the participant's team
        /// </summary>
        [JsonProperty("teamId")]
        public long TeamId { get; set; }

        /// <summary>
        /// The ID of the first summoner spell used by this participant
        /// </summary>
        [JsonProperty("spell1Id")]
        public long Spell1Id { get; set; }

        /// <summary>
        /// The summoner ID of this participant
        /// </summary>
        [JsonProperty("summonerId")]
        public long SummonerId { get; set; }
    }

    public class GameCustomizationObject
    {
        /// <summary>
        /// Category identifier for Game Customization
        /// </summary>
        [JsonProperty("category")]
        public string Category { get; set; }

        /// <summary>
        /// Game Customization content
        /// </summary>
        [JsonProperty("content")]
        public string Content { get; set; }
    }

    public class Perks
    {
        /// <summary>
        /// Primary runes path
        /// </summary>
        [JsonProperty("perkStyle")]
        public long PerkStyle { get; set; }

        /// <summary>
        /// IDs of the perks/runes assigned.
        /// </summary>
        [JsonProperty("perkIds")]
        public list<long> PerkIds { get; set; }

        /// <summary>
        /// Secondary runes path
        /// </summary>
        [JsonProperty("perkSubStyle")]
        public long PerkSubStyle { get; set; }
    }
}
