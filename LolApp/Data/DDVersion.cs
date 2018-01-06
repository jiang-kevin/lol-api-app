using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LolApp.Data
{
    /// <summary>
    /// Class representing a version number of Data Dragon
    /// </summary>
    public class DDVersion
    {
        /// <summary>
        /// Legacy script mode for IE6 or older
        /// </summary>
        [JsonProperty("lg")]
        public string Lg { get; set; }

        /// <summary>
        /// Latest changed version of Dragon Magic
        /// </summary>
        [JsonProperty("dd")]
        public string Dd { get; set; }

        /// <summary>
        /// Default language for this realm
        /// </summary>
        [JsonProperty("l")]
        public string L { get; set; }

        /// <summary>
        /// Latest changed version for each data type listed
        /// </summary>
        [JsonProperty("n")]
        public Dictionary<string,string> N { get; set; }

        /// <summary>
        /// Special behavior number identifying the largest profile icon ID that can be used under 500
        /// </summary>
        [JsonProperty("profileiconmax")]
        public int ProfileIconMax { get; set; }

        /// <summary>
        /// Current version of this file for this realm
        /// </summary>
        [JsonProperty("v")]
        public string V { get; set; }

        /// <summary>
        /// The base CDN URL
        /// </summary>
        [JsonProperty("cdn")]
        public string Cdn { get; set; }

        /// <summary>
        /// Latest changed version of Dragon Magic's CSS file
        /// </summary>
        [JsonProperty("css")]
        public string Css { get; set; }
    }
}
