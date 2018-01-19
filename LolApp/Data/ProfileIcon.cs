using Newtonsoft.Json;

namespace LolApp.Data
{
    /// <summary>
    /// Class representing a profile image
    /// </summary>
    public class ProfileIcon
    {
        /// <summary>
        /// Image object
        /// </summary>
        [JsonProperty("image")]
        public RiotImage Image { get; set; }

        /// <summary>
        /// Id of the profile image
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }
    }
}
