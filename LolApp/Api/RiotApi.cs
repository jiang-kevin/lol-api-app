using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using LolApp.Interfaces;
using LolApp.Data;

namespace LolApp.Api
{
    public class RiotApi : Api
    {
        // private fields
        private const string SummonerRootUrl = "/lol/summoner/v3/summoners";
        private const string SummonerByNameUrl = SummonerRootUrl + "/by-name/{0}";

        public RiotApi(string apiKey) :
            base(apiKey)
        { }

        public Summoner GetSummonerByName(string region, string name)
        {
            string json = RequestJson(String.Format(SummonerByNameUrl, name), region);
            return JsonConvert.DeserializeObject<Summoner>(json);
        }
    }
}
