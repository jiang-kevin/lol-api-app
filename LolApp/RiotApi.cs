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
        private const string BaseUrl = "api.riotgames.com";

        private const string SummonerRootUrl = "/lol/summoner/v3/summoners";
        private const string SummonerByNameUrl = "/by-name/";

        public RiotApi(string apiKey)
        {
            ApiKey = apiKey;
        }

        public string BuildUrl(string region, string rootUrl, string specUrl, string data)
        {
            string url = "https://" + region + "." + BaseUrl + rootUrl + specUrl + data + "?api_key=" + ApiKey;
            return url;
        }

        public Summoner GetSummonerByName(string region, string name)
        {
            string url = BuildUrl(region, SummonerRootUrl, SummonerByNameUrl, name);
            string json = new WebClient().DownloadString(url);
            return JsonConvert.DeserializeObject<Summoner>(json);
        }
    }
}
