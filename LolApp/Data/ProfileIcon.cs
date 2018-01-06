using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public PImage Image { get; set; }

        /// <summary>
        /// Id of the profile image
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }
    }
}
