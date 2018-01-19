using System;
using Newtonsoft.Json;
using LolApp.Data;

namespace LolApp.Api
{
    public class StaticApi : Api
    {
        private const string ProfileIconRootUrl = "/lol/static-data/v3/profile-icons";
        private const string RealmsRootUrl = "/lol/static-data/v3/realms";

        private const string DDProfileIconUrl = "http://ddragon.leagueoflegends.com/cdn/{0}/img/profileicon/";

        public StaticApi(string apiKey) :
            base(apiKey)
        { }

        public DDVersion GetVersion(Region region)
        {
            string json = RequestCachedJson(RealmsRootUrl, region);
            return JsonConvert.DeserializeObject<DDVersion>(json);
        }

        public IconList<int, ProfileIcon> GetProfileIconList(Region region)
        {
            string json = RequestCachedJson(ProfileIconRootUrl, region);
            return JsonConvert.DeserializeObject<IconList<int, ProfileIcon>>(json);
        }

        public string GetProfileIconUrl(int id, Region region)
        {
            IconList<int, ProfileIcon> profileIcons = GetProfileIconList(region);
            string filename = profileIcons.Data[id].Image.Full;
            DDVersion versionList = GetVersion(region);
            string profileIconVersion = versionList.N["profileicon"];
            return String.Format(DDProfileIconUrl, profileIconVersion) + filename;
        }

        public string GetChampionIconUrl(Region region)
        {

            return null;
        }
    }
}
