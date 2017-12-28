using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using LolApp.Interfaces;
using LolApp.Data;

namespace LolApp
{
    public class RiotApi : IRiotApi
    {
        public string ApiKey { get; set; }

        // private fields
        private const string BaseUrl = "https://{0}.api.riotgames.com";

        private const string SummonerRootUrl = "/lol/summoner/v3/summoners";
        private const string SummonerByNameUrl = SummonerRootUrl + "/by-name/{0}";

        public RiotApi(string apiKey)
        {
            ApiKey = apiKey;
        }

        public Summoner GetSummonerByName(string region, string name)
        {
            string json = RequestJson(String.Format(SummonerByNameUrl, name), region);
            return JsonConvert.DeserializeObject<Summoner>(json);
        }

        private string RequestJson(string rootUrl, string region)
        {
            string url = String.Format(BaseUrl, region) + rootUrl + "?api_key=" + ApiKey;
            return new WebClient().DownloadString(url);
        }
    }
}
