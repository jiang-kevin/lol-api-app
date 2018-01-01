using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LolApp.Data
{
    public class ProfileIcon
    {
        [JsonProperty("image")]
        public PImage Image { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }
    }
}
