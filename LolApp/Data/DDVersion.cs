using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LolApp.Data
{
    public class DDVersion
    {
        [JsonProperty("lg")]
        public string Lg { get; set; }

        [JsonProperty("dd")]
        public string Dd { get; set; }

        [JsonProperty("l")]
        public string L { get; set; }

        [JsonProperty("n")]
        public Dictionary<string,string> N { get; set; }

        [JsonProperty("profileiconmax")]
        public int ProfileIconMax { get; set; }

        [JsonProperty("v")]
        public string V { get; set; }

        [JsonProperty("cdn")]
        public string Cdn { get; set; }

        [JsonProperty("css")]
        public string Css { get; set; }
    }
}
