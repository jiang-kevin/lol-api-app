using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LolApp.Data
{
    /// <summary>
    /// Class representing the properties of an image
    /// </summary>
    public class PImage
    {
        /// <summary>
        /// Filename for the image
        /// </summary>
        [JsonProperty("full")]
        public string Full { get; set; }

        /// <summary>
        /// Group the image belongs to
        /// </summary>
        [JsonProperty("group")]
        public string Group { get; set; }

        /// <summary>
        /// Filename for the sprite image
        /// </summary>
        [JsonProperty("sprite")]
        public string Sprite { get; set; }

        /// <summary>
        /// Height of image
        /// </summary>
        [JsonProperty("h")]
        public int H { get; set; }

        /// <summary>
        /// Width of image
        /// </summary>
        [JsonProperty("w")]
        public int W { get; set; }

        /// <summary>
        /// Y starting point for the image
        /// </summary>
        [JsonProperty("y")]
        public int Y { get; set; }

        /// <summary>
        /// X starting point for the image
        /// </summary>
        [JsonProperty("x")]
        public int X { get; set; }
    }
}
