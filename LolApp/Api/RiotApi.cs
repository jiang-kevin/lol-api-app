using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using LolApp.Data;

namespace LolApp.Api
{
    public class RiotApi : Api
    {
        // private fields
        private const string SummonerRootUrl = "/lol/summoner/v3/summoners";
        private const string SummonerByNameUrl = SummonerRootUrl + "/by-name/{0}";

        private const string LeagueRootUrl = "/lol/league/v3";
        private const string LeaguePositionByIdUrl = LeagueRootUrl + "/positions/by-summoner/{0}";

        public RiotApi(string apiKey) :
            base(apiKey)
        { }

        public Summoner GetSummonerByName(Region region, string name)
        {
            string json = RequestJson(String.Format(SummonerByNameUrl, name), region);
            return JsonConvert.DeserializeObject<Summoner>(json);
        }

        public List<LeaguePosition> GetLeaguePositionById(Region region, long id)
        {
            string json = RequestJson(String.Format(LeaguePositionByIdUrl, id.ToString()), region);
            return JsonConvert.DeserializeObject<List<LeaguePosition>>(json);
        }
    }
}
