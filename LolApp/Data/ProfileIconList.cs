using System.Collections.Generic;
using Newtonsoft.Json;

namespace LolApp.Data
{
    /// <summary>
    /// Class representing a list of profile icons
    /// </summary>
    public class IconList<d,t>
    {
        /// <summary>
        /// List of profile image objects
        /// </summary>
        [JsonProperty("data")]
        public Dictionary<d, t> Data { get; set; }

        /// <summary>
        /// Version of Data Dragon
        /// </summary>
        [JsonProperty("version")]
        public string Version { get; set; }

        /// <summary>
        /// Type of list
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
